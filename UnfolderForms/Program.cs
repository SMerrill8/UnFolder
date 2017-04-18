#region File Header

// Project: Forms
// File:  Program.cs
// Author: Merrill, Shaun
// Created: 2017/04/17

#endregion

#region Usings

using System;
using System.Windows.Forms;
using UnFolder.Forms;

#endregion

namespace UnFolder
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmUnpack());
        }
    }
}