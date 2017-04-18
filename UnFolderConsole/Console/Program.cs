using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Console;
using static System.Diagnostics.Debugger;

namespace UnFolder.Console
{
    public class Program
    {
        /// <summary>
        /// Main Entry Point
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
#if DEBUG
            if (!IsAttached)
            {
                Launch();
                Break();
            }
            
#endif
            List<DirectoryInfo> folders;      
            bool recursiveSwitch;
            bool whatIfSwitch;

            if (InterpretArgs(args, out folders, out recursiveSwitch, out whatIfSwitch))
                return;

            if (args.Any())
            {
                Unfolder u = new Unfolder();
                u.UnfolderError += UOnUnfolderError;
                u.UnfolderMessage += UOnUnfolderMessage;
                u.Unpack(folders, recursiveSwitch, whatIfSwitch);
            }
            if (whatIfSwitch) PressAnyKey();
        }

        private static void UOnUnfolderMessage(object sender, UnfolderMessageEventArgs unfolderMessageEventArgs)
        {
            string msg = unfolderMessageEventArgs.Message;
            WriteLine($"\n{msg}\n");
        }

        private static void UOnUnfolderError(object sender, UnfolderMessageEventArgs unfolderMessageEventArgs)
        {
            string msg = unfolderMessageEventArgs.Message;
            ConsoleColor oldColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Red;
            WriteLine($"\n{msg}\n");
            ForegroundColor = oldColor;
        }


        /// <summary>
        /// Usage
        /// </summary>
        public static void Usage()
        {
            WriteLine("Usage:\n\nUnFolder [/s] \"FolderName\"[, \"FolderName2\", ...]");
            PressAnyKey();
        }

        #region Helpers
        private static void PressAnyKey()
        {
            WriteLine("Press any key to continue ...");
            ReadKey();
        }

        private static bool InterpretArgs(
            string[] args,
            out List<DirectoryInfo> folders,
            out bool recursiveSwitch,
            out bool whatIfSwitch)
        {
            folders = new List<DirectoryInfo>();
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