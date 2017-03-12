using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UnFolder
{
    public class Program
    {
        /// <summary>
        /// Main Entry Point
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            List<DirectoryInfo> folders = new List<DirectoryInfo>();      
            bool recursiveSwitch;
            bool whatIfSwitch;

            if (InterpretArgs(args, folders, out recursiveSwitch, out whatIfSwitch))
                return;

            if (args.Any())
            {
                UnFolder u = new UnFolder();
                u.Unpack(folders, recursiveSwitch, whatIfSwitch);
            }
            if (whatIfSwitch) PressAnyKey();
        }

        /// <summary>
        /// Usage
        /// </summary>
        public static void Usage()
        {
            Console.WriteLine("Usage:\n\nUnFolder [/s] \"FolderName\"[, \"FolderName2\", ...]");
            PressAnyKey();
        }

        #region Helpers
        private static void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }

        private static bool InterpretArgs(
            string[] args,
            List<DirectoryInfo> folders,
            out bool recursiveSwitch,
            out bool whatIfSwitch)
        {
            if (args == null)
            {
                Usage();
                recursiveSwitch = false;
                whatIfSwitch = false;
                return true;
            }
            if (!args.Any())
            {
                Usage();
                recursiveSwitch = false;
                whatIfSwitch = false;
                return true;
            }
            // search args for switches.  The /s switch does all subfolders too.
            string a = args.FirstOrDefault(x => x.ToLower().Equals("/s"));
            recursiveSwitch = !string.IsNullOrEmpty(a);
            a = args.FirstOrDefault(x => x.ToLower().Equals("/whatif"));
            whatIfSwitch = !string.IsNullOrEmpty(a);
            // remove any arguments which are not valid folder names: 

            foreach (string arg in args)
            {
                if (Directory.Exists(arg))
                {
                    DirectoryInfo d = new DirectoryInfo(arg);
                    if (d.Parent != null)
                        folders.Add(d);
                }
            }
            return false;
        }
        #endregion
    }
}