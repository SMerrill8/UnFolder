namespace UnFolder.Forms
{
    partial class FrmUnpack
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tbxFolder = new System.Windows.Forms.TextBox();
            this.chkSubfolders = new System.Windows.Forms.CheckBox();
            this.chkWhatIf = new System.Windows.Forms.CheckBox();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.lbxCollection = new System.Windows.Forms.ListBox();
            this.lblFolderCollection = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUnload = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.tbxLog = new System.Windows.Forms.TextBox();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.AutoSize = true;
            this.tlpMain.ColumnCount = 6;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 575F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Controls.Add(this.tbxFolder, 1, 1);
            this.tlpMain.Controls.Add(this.chkSubfolders, 1, 4);
            this.tlpMain.Controls.Add(this.chkWhatIf, 2, 4);
            this.tlpMain.Controls.Add(this.btnSelectFolder, 1, 0);
            this.tlpMain.Controls.Add(this.lbxCollection, 1, 3);
            this.tlpMain.Controls.Add(this.lblFolderCollection, 1, 2);
            this.tlpMain.Controls.Add(this.btnAdd, 3, 2);
            this.tlpMain.Controls.Add(this.btnUnload, 3, 4);
            this.tlpMain.Controls.Add(this.btnClear, 2, 2);
            this.tlpMain.Controls.Add(this.tbxLog, 4, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 6;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 225F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(973, 364);
            this.tlpMain.TabIndex = 0;
            // 
            // tbxFolder
            // 
            this.tlpMain.SetColumnSpan(this.tbxFolder, 3);
            this.tbxFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxFolder.Location = new System.Drawing.Point(23, 32);
            this.tbxFolder.Name = "tbxFolder";
            this.tbxFolder.Size = new System.Drawing.Size(352, 20);
            this.tbxFolder.TabIndex = 1;
            // 
            // chkSubfolders
            // 
            this.chkSubfolders.AutoSize = true;
            this.chkSubfolders.Location = new System.Drawing.Point(23, 315);
            this.chkSubfolders.Name = "chkSubfolders";
            this.chkSubfolders.Size = new System.Drawing.Size(119, 17);
            this.chkSubfolders.TabIndex = 2;
            this.chkSubfolders.Text = "Unload Subfolders?";
            this.chkSubfolders.UseVisualStyleBackColor = true;
            // 
            // chkWhatIf
            // 
            this.chkWhatIf.AutoSize = true;
            this.chkWhatIf.Location = new System.Drawing.Point(158, 315);
            this.chkWhatIf.Name = "chkWhatIf";
            this.chkWhatIf.Size = new System.Drawing.Size(67, 17);
            this.chkWhatIf.TabIndex = 3;
            this.chkWhatIf.Text = "What If?";
            this.chkWhatIf.UseVisualStyleBackColor = true;
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSelectFolder.Location = new System.Drawing.Point(23, 3);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(83, 23);
            this.btnSelectFolder.TabIndex = 0;
            this.btnSelectFolder.Text = "Select Folder";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // lbxCollection
            // 
            this.tlpMain.SetColumnSpan(this.lbxCollection, 3);
            this.lbxCollection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxCollection.FormattingEnabled = true;
            this.lbxCollection.Location = new System.Drawing.Point(23, 90);
            this.lbxCollection.Name = "lbxCollection";
            this.lbxCollection.Size = new System.Drawing.Size(352, 219);
            this.lbxCollection.TabIndex = 4;
            // 
            // lblFolderCollection
            // 
            this.lblFolderCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFolderCollection.AutoSize = true;
            this.lblFolderCollection.Location = new System.Drawing.Point(23, 74);
            this.lblFolderCollection.Name = "lblFolderCollection";
            this.lblFolderCollection.Size = new System.Drawing.Size(85, 13);
            this.lblFolderCollection.TabIndex = 6;
            this.lblFolderCollection.Text = "Folder Collection";
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(267, 62);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(104, 22);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add to Collection";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUnload
            // 
            this.btnUnload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUnload.Location = new System.Drawing.Point(267, 315);
            this.btnUnload.Name = "btnUnload";
            this.btnUnload.Size = new System.Drawing.Size(108, 26);
            this.btnUnload.TabIndex = 7;
            this.btnUnload.Text = "Unload";
            this.btnUnload.UseVisualStyleBackColor = true;
            this.btnUnload.Click += new System.EventHandler(this.btnUnload_Click);
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClear.Location = new System.Drawing.Point(158, 62);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(103, 22);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear Collection";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // folderBrowser
            // 
            this.folderBrowser.Description = "Select Folder";
            this.folderBrowser.ShowNewFolderButton = false;
            // 
            // tbxLog
            // 
            this.tbxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxLog.Location = new System.Drawing.Point(381, 32);
            this.tbxLog.Multiline = true;
            this.tbxLog.Name = "tbxLog";
            this.tlpMain.SetRowSpan(this.tbxLog, 4);
            this.tbxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxLog.Size = new System.Drawing.Size(569, 309);
            this.tbxLog.TabIndex = 9;
            // 
            // FrmUnpack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 364);
            this.Controls.Add(this.tlpMain);
            this.Name = "FrmUnpack";
            this.Text = "Folder Unpacker";
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.TextBox tbxFolder;
        private System.Windows.Forms.CheckBox chkSubfolders;
        private System.Windows.Forms.CheckBox chkWhatIf;
        public System.Windows.Forms.ListBox lbxCollection;
        private System.Windows.Forms.Label lblFolderCollection;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUnload;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox tbxLog;
    }
}

