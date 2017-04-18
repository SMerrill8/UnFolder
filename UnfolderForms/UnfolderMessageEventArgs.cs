#region File Header

// Project: Forms
// File:  UnfolderMessageEventArgs.cs
// Author: Merrill, Shaun
// Created: 2017/04/18

#endregion

#region Usings

using System;

#endregion

namespace UnFolder
{
    public class UnfolderMessageEventArgs : EventArgs
    {
        public UnfolderMessageEventArgs(string s)
        {
            Message = s;
        }

        public string Message { get; }
    }
}