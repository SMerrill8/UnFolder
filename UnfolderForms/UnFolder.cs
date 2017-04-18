#region File Header

// Project: Forms
// File:  UnFolder.cs
// Author: Merrill, Shaun
// Created: 2017/04/18

#endregion

#region

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;

#endregion

namespace UnFolder
{
    /// <summary>
    ///     The Main Class for the UnFolder project
    /// </summary>
    public class Unfolder
    {
        public void Unpack(StringCollection folderNames, bool unpackSubfolders = false, bool whatIf = false)
        {
            Unpack((from string s in folderNames
                select new DirectoryInfo(s)).ToList(), unpackSubfolders, whatIf);
        }

        public void Unpack(IEnumerable<DirectoryInfo> folders, bool unpackSubfolders = false, bool whatIf = false)
        {
            DirectoryInfo[] directoryInfos = folders as DirectoryInfo[] ?? folders.ToArray();
            if (!directoryInfos.Any())
                DisplayError("There were no folders to process.");
            else
                foreach (DirectoryInfo dir in directoryInfos)
                {
                    SendMessage($"\nUnpacking [{dir.FullName}]");

                    if (whatIf)
                        SendMessage($"\nUnpacking [{dir.FullName}]");
                    if (unpackSubfolders)
                        Unpack(dir.GetDirectories(), unpackSubfolders, whatIf);
                    foreach (FileInfo file in dir.GetFiles())
                        if (dir.Parent != null)
                        {
                            string fileName = file.Name;
                            string ext = file.Extension;
                            SendMessage($"Move file [{fileName}] to folder [{dir.Parent.FullName}]");
                            if (whatIf)
                            {
                                SendMessage($"    File [{fileName}] would move to folder [{dir.Parent.FullName}]");
                            }
                            else
                            {
                                if (fileName == ".picasa.ini")
                                {
                                    file.Delete();
                                }
                                else
                                {
                                    string destination = dir.Parent.FullName;
                                    int c = 0;
                                    bool done = false;
                                    while (!done)
                                    {
                                        Debug.WriteLine($"Attempting to move {fileName} to {destination}:");

                                        if (File.Exists($"{destination}\\{fileName}"))
                                            if (fileName.EndsWith($"){ext}") && fileName.Contains("("))
                                            {
                                                // the filename probably ends with a parenthesized enumerator.
                                                // determine what the value of the number in the enumerator might be.
                                                string num = fileName.Split('(')[1].Split(')')[0];
                                                int.TryParse(num, out c);
                                                // append the incremented integer to the filename just after the open parenthesis:
                                                destination =
                                                    $"{dir.Parent.FullName}\\{fileName.Split('(')[0]}({++c}){ext}";
                                            }
                                            else
                                            {
                                                // append a parenthesized enumerator to the filename just before the extension:
                                                destination =
                                                    $"{dir.Parent.FullName}\\{fileName.Replace(ext, "")}({++c}){ext}";
                                            }
                                        try
                                        {
                                            file.MoveTo($"{destination}\\{fileName}");
                                            done = true; // stop retrying
                                        }
                                        catch (IOException exIo)
                                        {
                                            switch (exIo.Message)
                                            {
                                                case "Could not find a part of the path.":
                                                {
                                                    DisplayError(exIo.Message);
                                                    break;
                                                }

                                                case "Cannot create a file when that file already exists.\r\n":
                                                {
                                                    DisplayError(exIo.Message);
                                                    break;
                                                }

                                                default:
                                                {
                                                    throw;
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            DisplayError(ex.Message);
                                            throw;
                                        }
                                    }
                                }
                            }
                        }
                    if (!dir.GetDirectories().Any() && !dir.GetFiles().Any())
                    {
                        SendMessage($"removing folder [{dir.FullName}]");
                        dir.Delete();
                    }
                }
        }

        internal void SendMessage(string msg)
        {
            OnRaiseUnfolderMessage(new UnfolderMessageEventArgs(msg));
        }

        internal void DisplayError(string msg)
        {
            OnRaiseUnfolderError(new UnfolderMessageEventArgs(msg));
        }

        #region Events

        public event UnfolderErrorEventHandler UnfolderError;
        public event UnfolderMessageEventHandler UnfolderMessage;

        public delegate void UnfolderErrorEventHandler(object sender, UnfolderMessageEventArgs a);

        public delegate void UnfolderMessageEventHandler(object sender, UnfolderMessageEventArgs a);

        protected virtual void OnRaiseUnfolderError(UnfolderMessageEventArgs a)
        {
            UnfolderError?.Invoke(this, a);
        }

        protected virtual void OnRaiseUnfolderMessage(UnfolderMessageEventArgs a)
        {
            UnfolderMessage?.Invoke(this, a);
        }

        #endregion
    }
}