using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace UnFolder
{
    /// <summary>
    /// The Main Class for the UnFolder project
    /// </summary>
    public class UnFolder
    {
        public void Unpack(IEnumerable<DirectoryInfo> folders, bool unpackSubfolders=false, bool whatIf=false)
        { 
        
            DirectoryInfo[] directoryInfos = folders as DirectoryInfo[] ?? folders.ToArray();
            if (!directoryInfos.Any())
            {
                Trace.WriteLine("There were no folders to process.");
                DisplayError("There were no folders to process.");
            }
            else
            {
                foreach (DirectoryInfo dir in directoryInfos)
                {
                    Trace.WriteLine($"\nUnpacking [{dir.FullName}]");
                    if (whatIf)
                        Console.WriteLine($"\nUnpacking [{dir.FullName}]");
                    Trace.Indent();
                    if (unpackSubfolders)
                    {
                        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                        Unpack(dir.GetDirectories(), unpackSubfolders, whatIf);
                    }
                    foreach (FileInfo file in dir.GetFiles())
                        if (dir.Parent != null)
                        {
                            string fileName = file.Name;
                            string ext = file.Extension;
                            Trace.WriteLine($"Move file [{fileName}] to folder [{dir.Parent.FullName}]");
                            if (whatIf)
                            {
                                Console.WriteLine($"    File [{fileName}] would move to folder [{dir.Parent.FullName}]");
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
                                    {
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
                                    }
                                    try
                                    {
                                        file.MoveTo($"{destination}\\{fileName}");
                                        done = true; // stop retrying
                                    }
                                    catch (IOException exIo)
                                    {
                                        if (
                                            exIo.Message.Equals(
                                                "Cannot create a file when that file already exists.\r\n"))
                                        {
                                        }
                                        else
                                        {
                                            DisplayError(exIo.Message);
                                            throw;
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
                    if (!dir.GetDirectories().Any() && !dir.GetFiles().Any())
                    {
                        Trace.WriteLine($"removing folder [{dir.FullName}]");
                        dir.Delete();
                    }
                    Trace.Unindent();
                }
            }
        }

        internal void DisplayError(string msg)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n{msg}\n");
            Console.ForegroundColor = oldColor;
        }
    }
}