#region File Header

// Project: Forms
// File:  FolderUnpacker.cs
// Author: Merrill, Shaun
// Created: 2017/04/18

#endregion

#region

using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace UnFolder.Forms
{
    public partial class FrmUnpack : Form
    {
        private readonly StringCollection _fc;

        /// <summary>
        ///     Constructor of FrmUnpack
        /// </summary>
        public FrmUnpack()
        {
            InitializeComponent();
            _fc = new StringCollection();
            RefreshDisplay();
        }

        public void UnloadFolders()
        {
            btnUnload.Enabled = false;
            Unfolder uf = new Unfolder();
            uf.UnfolderError += Uf_OnUnfolderError;
            uf.UnfolderMessage += Uf_OnUnfolderMessage;

            bool unpackSubfolders = chkSubfolders.Checked;
            bool whatIf = chkWhatIf.Checked;
            uf.Unpack(_fc, unpackSubfolders, whatIf);
            btnUnload.Enabled = true;
        }

        private void Uf_OnUnfolderMessage(object sender, UnfolderMessageEventArgs unfolderMessageEventArgs)
        {
            string msg = unfolderMessageEventArgs.Message;
            tbxLog.Text += $"{msg}\r\n";
        }

        private void Uf_OnUnfolderError(object sender, UnfolderMessageEventArgs unfolderMessageEventArgs)
        {
            string msg = unfolderMessageEventArgs.Message;
            Color c = tbxLog.ForeColor;
            tbxLog.ForeColor = Color.Red;
            tbxLog.Text += $"{msg}\r\n";
            tbxLog.ForeColor = c;
        }

        public void SelectFolder()
        {
            if (folderBrowser.ShowDialog() != DialogResult.OK) return;
            tbxFolder.Text = folderBrowser.SelectedPath;
            RefreshDisplay();
        }

        public void Clear()
        {
            _fc.Clear();
            tbxLog.Text = "";
            tbxFolder.Text = "";
            RefreshDisplay();
        }

        public void Add(string folderName)
        {
            _fc.Add(folderName);
            RefreshDisplay();
        }

        private void RefreshDisplay()
        {
            btnAdd.Enabled = !string.IsNullOrEmpty(tbxFolder.Text);
            btnClear.Enabled = _fc.Count > 0;
            btnUnload.Enabled = btnClear.Enabled;
            lbxCollection.DataSource = _fc;
            lbxCollection.Refresh();
        }

        #region Event Handlers

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            SelectFolder();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add(tbxFolder.Text);
        }

        private void btnUnload_Click(object sender, EventArgs e)
        {
            UnloadFolders();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        #endregion
    }
}