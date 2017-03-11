using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace UnFolder
{
    public class Program
    {
        #region Private Properties

        private static bool UnpackSubfolders { get; set; }

        private static bool WhatIf { get; set; }

        #endregion

        public static void Main(string[] args)
        {
            if (args == null)
            {
                Usage();
                return;
            }
            if (!args.Any())
            {
                Usage();
                return;
            }
            // search args for switches.  The /s switch does all subfolders too.
            string a = args.FirstOrDefault(x => x.ToLower().Equals("/s"));
            UnpackSubfolders = !string.IsNullOrEmpty(a);
            a = args.FirstOrDefault(x => x.ToLower().Equals("/whatif"));
            WhatIf = !string.IsNullOrEmpty(a);
            var folders = new List<DirectoryInfo>();
            // remove any arguments which are not valid folder names: 
            if (args.Any())
            {
                foreach (string arg in args)
                    if (Directory.Exists(arg))
                    {
                        var d = new DirectoryInfo(arg);
                        if (d.Parent != null)
                            folders.Add(d);
                    }
                Unpack(folders);
            }
            if (WhatIf)
                PressAnyKey();
        }

        public static void Unpack(IEnumerable<DirectoryInfo> folders)
        {
            var directoryInfos = folders as DirectoryInfo[] ?? folders.ToArray();
            if (directoryInfos.Any())
            {
                foreach (var dir in directoryInfos)
                {
                    Trace.WriteLine($"\nUnpacking [{dir.FullName}]");
                    if (WhatIf)
                        Console.WriteLine($"\nUnpacking [{dir.FullName}]");
                    Trace.Indent();

                    foreach (var file in dir.GetFiles())
                        if (dir.Parent != null)
                        {
                            Trace.WriteLine($"Move file [{file.Name}] to folder [{dir.Parent.FullName}]");
                            if (WhatIf)
                            {
                                Console.WriteLine($"    File [{file.Name}] would move to folder [{dir.Parent.FullName}]");
                            }
                            else
                            {
                                string destination = dir.Parent.FullName;
                                int c = 0;
                                bool done = false;
                                while (!done)
                                {
                                    Debug.WriteLine($"Attempting to move {file.Name} to {destination}:");
                                    if (dir.Parent.GetFiles(file.Name).Any())
                                        if (file.Name.EndsWith($"){file.Extension}") && file.Name.Contains("("))
                                        {
                                            // the filename probably ends with a parenthesized enumerator.
                                            // determine what the value of the number in the enumerator might be.
                                            string num = file.Name.Split('(')[1].Split(')')[0];
                                            int.TryParse(num, out c);
                                            // append the incremented integer to the filename just after the open parenthesis:
                                            destination =
                                                $"{dir.Parent.FullName}\\{file.Name.Split('(')[0]}({++c}){file.Extension}";
                                        }
                                        else
                                        {
                                            // append a parenthesized enumerator to the filename just before the extension:
                                            destination =
                                                $"{dir.Parent.FullName}\\{file.Name.Replace(file.Extension, "")}({++c}){file.Extension}";
                                        }
                                    try
                                    {
                                        file.MoveTo(destination);
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
                    if (UnpackSubfolders)
                        Unpack(dir.GetDirectories());
                }
            }
            else
            {
                Trace.WriteLine("There were no folders to process.");
                DisplayError("There were no folders to process.");
            }
        }

        #region Private Methods
        private static void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }

        private static void Usage()
        {
            Console.WriteLine("Usage:\n\nUnFolder [/s] \"FolderName\"[, \"FolderName2\", ...]");
            PressAnyKey();
        }

        private static void DisplayError(string msg)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n{msg}\n");
            Console.ForegroundColor = oldColor;
        }

        #endregion

    }
}