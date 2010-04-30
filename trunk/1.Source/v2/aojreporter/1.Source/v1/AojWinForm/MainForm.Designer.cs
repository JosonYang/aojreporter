namespace AojReport.AojWinForm
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStripDesign = new System.Windows.Forms.MenuStrip();
            this.tsmFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmCut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmReportDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmObject = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLabel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTable = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmImage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerDesign = new System.Windows.Forms.SplitContainer();
            this.aojOopenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.aojSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolStripInfo = new System.Windows.Forms.ToolStrip();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPointer = new System.Windows.Forms.ToolStripButton();
            this.tsbLabel = new System.Windows.Forms.ToolStripButton();
            this.tsbTable = new System.Windows.Forms.ToolStripButton();
            this.tsbImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCmbPage = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbGridStyle = new System.Windows.Forms.ToolStripButton();
            this.tsbTxtGridStyle = new System.Windows.Forms.ToolStripTextBox();
            this.tsbAutoCompute = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCmbZoom = new System.Windows.Forms.ToolStripComboBox();
            this.menuStripDesign.SuspendLayout();
            this.splitContainerDesign.SuspendLayout();
            this.toolStripInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripDesign
            // 
            this.menuStripDesign.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStripDesign.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFile,
            this.tsmEdit,
            this.tsmView,
            this.tsmObject,
            this.tsmHelp});
            this.menuStripDesign.Location = new System.Drawing.Point(0, 0);
            this.menuStripDesign.Name = "menuStripDesign";
            this.menuStripDesign.Size = new System.Drawing.Size(1181, 24);
            this.menuStripDesign.TabIndex = 1;
            this.menuStripDesign.Text = "menuStrip1";
            // 
            // tsmFile
            // 
            this.tsmFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmNew,
            this.tsmOpen,
            this.tsmItem2,
            this.tsmSave,
            this.tsmItem1,
            this.tsmExit});
            this.tsmFile.Name = "tsmFile";
            this.tsmFile.Size = new System.Drawing.Size(35, 20);
            this.tsmFile.Text = "File";
            this.tsmFile.DropDownOpened += new System.EventHandler(this.tsmFile_DropDownOpened);
            // 
            // tsmNew
            // 
            this.tsmNew.Name = "tsmNew";
            this.tsmNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tsmNew.Size = new System.Drawing.Size(140, 22);
            this.tsmNew.Text = "New";
            this.tsmNew.Click += new System.EventHandler(this.tsmNew_Click);
            // 
            // tsmOpen
            // 
            this.tsmOpen.Name = "tsmOpen";
            this.tsmOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.tsmOpen.Size = new System.Drawing.Size(140, 22);
            this.tsmOpen.Text = "Open";
            this.tsmOpen.Click += new System.EventHandler(this.tsmOpen_Click);
            // 
            // tsmItem2
            // 
            this.tsmItem2.Name = "tsmItem2";
            this.tsmItem2.Size = new System.Drawing.Size(137, 6);
            // 
            // tsmSave
            // 
            this.tsmSave.Name = "tsmSave";
            this.tsmSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmSave.Size = new System.Drawing.Size(140, 22);
            this.tsmSave.Text = "Save";
            this.tsmSave.Click += new System.EventHandler(this.tsmSave_Click);
            // 
            // tsmItem1
            // 
            this.tsmItem1.Name = "tsmItem1";
            this.tsmItem1.Size = new System.Drawing.Size(137, 6);
            // 
            // tsmExit
            // 
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.Size = new System.Drawing.Size(140, 22);
            this.tsmExit.Text = "Exit";
            this.tsmExit.Click += new System.EventHandler(this.tsmExit_Click);
            // 
            // tsmEdit
            // 
            this.tsmEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmUndo,
            this.tsmRedo,
            this.tsmItem3,
            this.tsmCut,
            this.tsmCopy,
            this.tsmPaste,
            this.tsmDelete,
            this.tsmItem4,
            this.tsmSelectAll});
            this.tsmEdit.Name = "tsmEdit";
            this.tsmEdit.Size = new System.Drawing.Size(37, 20);
            this.tsmEdit.Text = "Edit";
            this.tsmEdit.DropDownOpened += new System.EventHandler(this.tsmEdit_DropDownOpened);
            // 
            // tsmUndo
            // 
            this.tsmUndo.Name = "tsmUndo";
            this.tsmUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.tsmUndo.Size = new System.Drawing.Size(153, 22);
            this.tsmUndo.Text = "Undo";
            this.tsmUndo.Click += new System.EventHandler(this.tsmUndo_Click);
            // 
            // tsmRedo
            // 
            this.tsmRedo.Name = "tsmRedo";
            this.tsmRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.tsmRedo.Size = new System.Drawing.Size(153, 22);
            this.tsmRedo.Text = "Redo";
            this.tsmRedo.Click += new System.EventHandler(this.tsmRedo_Click);
            // 
            // tsmItem3
            // 
            this.tsmItem3.Name = "tsmItem3";
            this.tsmItem3.Size = new System.Drawing.Size(150, 6);
            // 
            // tsmCut
            // 
            this.tsmCut.Name = "tsmCut";
            this.tsmCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.tsmCut.Size = new System.Drawing.Size(153, 22);
            this.tsmCut.Text = "Cut";
            this.tsmCut.Click += new System.EventHandler(this.tsmCut_Click);
            // 
            // tsmCopy
            // 
            this.tsmCopy.Name = "tsmCopy";
            this.tsmCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.tsmCopy.Size = new System.Drawing.Size(153, 22);
            this.tsmCopy.Text = "Copy";
            this.tsmCopy.Click += new System.EventHandler(this.tsmCopy_Click);
            // 
            // tsmPaste
            // 
            this.tsmPaste.Name = "tsmPaste";
            this.tsmPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.tsmPaste.Size = new System.Drawing.Size(153, 22);
            this.tsmPaste.Text = "Paste";
            this.tsmPaste.Click += new System.EventHandler(this.tsmPaste_Click);
            // 
            // tsmDelete
            // 
            this.tsmDelete.Name = "tsmDelete";
            this.tsmDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.tsmDelete.Size = new System.Drawing.Size(153, 22);
            this.tsmDelete.Text = "Delete";
            this.tsmDelete.Click += new System.EventHandler(this.tsmDelete_Click);
            // 
            // tsmItem4
            // 
            this.tsmItem4.Name = "tsmItem4";
            this.tsmItem4.Size = new System.Drawing.Size(150, 6);
            // 
            // tsmSelectAll
            // 
            this.tsmSelectAll.Name = "tsmSelectAll";
            this.tsmSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.tsmSelectAll.Size = new System.Drawing.Size(153, 22);
            this.tsmSelectAll.Text = "SelectAll";
            this.tsmSelectAll.Click += new System.EventHandler(this.tsmSelectAll_Click);
            // 
            // tsmView
            // 
            this.tsmView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmReportDocument});
            this.tsmView.Name = "tsmView";
            this.tsmView.Size = new System.Drawing.Size(41, 20);
            this.tsmView.Text = "View";
            this.tsmView.DropDownOpened += new System.EventHandler(this.tsmView_DropDownOpened);
            // 
            // tsmReportDocument
            // 
            this.tsmReportDocument.Name = "tsmReportDocument";
            this.tsmReportDocument.Size = new System.Drawing.Size(155, 22);
            this.tsmReportDocument.Text = "ReportDocument";
            this.tsmReportDocument.Click += new System.EventHandler(this.tsmReportDocument_Click);
            // 
            // tsmObject
            // 
            this.tsmObject.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmLabel,
            this.tsmTable,
            this.tsmImage});
            this.tsmObject.Name = "tsmObject";
            this.tsmObject.Size = new System.Drawing.Size(51, 20);
            this.tsmObject.Text = "Object";
            this.tsmObject.DropDownOpened += new System.EventHandler(this.tsmObject_DropDownOpened);
            // 
            // tsmLabel
            // 
            this.tsmLabel.Name = "tsmLabel";
            this.tsmLabel.Size = new System.Drawing.Size(104, 22);
            this.tsmLabel.Text = "Label";
            this.tsmLabel.Click += new System.EventHandler(this.tsmLabel_Click);
            // 
            // tsmTable
            // 
            this.tsmTable.Name = "tsmTable";
            this.tsmTable.Size = new System.Drawing.Size(104, 22);
            this.tsmTable.Text = "Table";
            this.tsmTable.Click += new System.EventHandler(this.tsmTable_Click);
            // 
            // tsmImage
            // 
            this.tsmImage.Name = "tsmImage";
            this.tsmImage.Size = new System.Drawing.Size(104, 22);
            this.tsmImage.Text = "Image";
            this.tsmImage.Click += new System.EventHandler(this.tsmImage_Click);
            // 
            // tsmHelp
            // 
            this.tsmHelp.Name = "tsmHelp";
            this.tsmHelp.Size = new System.Drawing.Size(40, 20);
            this.tsmHelp.Text = "Help";
            // 
            // splitContainerDesign
            // 
            this.splitContainerDesign.BackColor = System.Drawing.Color.DarkGray;
            this.splitContainerDesign.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainerDesign.Location = new System.Drawing.Point(0, 49);
            this.splitContainerDesign.Name = "splitContainerDesign";
            // 
            // splitContainerDesign.Panel1
            // 
            this.splitContainerDesign.Panel1.AutoScroll = true;
            this.splitContainerDesign.Panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.splitContainerDesign.Panel2Collapsed = true;
            this.splitContainerDesign.Size = new System.Drawing.Size(1181, 783);
            this.splitContainerDesign.SplitterDistance = 90;
            this.splitContainerDesign.TabIndex = 2;
            // 
            // aojOopenFileDialog
            // 
            this.aojOopenFileDialog.FileName = "AojReportDocument";
            this.aojOopenFileDialog.Filter = "*.aojx|*.aojx";
            // 
            // aojSaveFileDialog
            // 
            this.aojSaveFileDialog.FileName = "AojReportDocument";
            this.aojSaveFileDialog.Filter = "*.aojx|*.aojx";
            // 
            // toolStripInfo
            // 
            this.toolStripInfo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNew,
            this.tsbOpen,
            this.tsbSave,
            this.toolStripSeparator1,
            this.tsbPointer,
            this.tsbLabel,
            this.tsbTable,
            this.tsbImage,
            this.toolStripSeparator2,
            this.tsbCmbPage,
            this.toolStripSeparator4,
            this.tsbGridStyle,
            this.tsbTxtGridStyle,
            this.tsbAutoCompute,
            this.toolStripSeparator5,
            this.tsbCmbZoom});
            this.toolStripInfo.Location = new System.Drawing.Point(0, 24);
            this.toolStripInfo.Name = "toolStripInfo";
            this.toolStripInfo.Size = new System.Drawing.Size(1181, 25);
            this.toolStripInfo.TabIndex = 11;
            this.toolStripInfo.Text = "toolStrip1";
            // 
            // tsbNew
            // 
            this.tsbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNew.Image = global::AojReport.AojWinForm.Properties.Resources._new;
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(23, 22);
            this.tsbNew.Text = "toolStripButton1";
            this.tsbNew.ToolTipText = "New";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // tsbOpen
            // 
            this.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpen.Image = global::AojReport.AojWinForm.Properties.Resources.open;
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(23, 22);
            this.tsbOpen.Text = "toolStripButton2";
            this.tsbOpen.ToolTipText = "Open";
            this.tsbOpen.Click += new System.EventHandler(this.tsbOpen_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = global::AojReport.AojWinForm.Properties.Resources.save;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(23, 22);
            this.tsbSave.Text = "toolStripButton3";
            this.tsbSave.ToolTipText = "Save";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbPointer
            // 
            this.tsbPointer.Checked = true;
            this.tsbPointer.CheckOnClick = true;
            this.tsbPointer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbPointer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPointer.Image = global::AojReport.AojWinForm.Properties.Resources.pointer;
            this.tsbPointer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPointer.Name = "tsbPointer";
            this.tsbPointer.Size = new System.Drawing.Size(23, 22);
            this.tsbPointer.Text = "toolStripButton1";
            this.tsbPointer.ToolTipText = "Pointer";
            this.tsbPointer.Click += new System.EventHandler(this.tsbPointer_Click);
            // 
            // tsbLabel
            // 
            this.tsbLabel.CheckOnClick = true;
            this.tsbLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLabel.Image = global::AojReport.AojWinForm.Properties.Resources.label;
            this.tsbLabel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLabel.Name = "tsbLabel";
            this.tsbLabel.Size = new System.Drawing.Size(23, 22);
            this.tsbLabel.Text = "toolStripButton2";
            this.tsbLabel.ToolTipText = "Label";
            this.tsbLabel.Click += new System.EventHandler(this.tsbLabel_Click);
            // 
            // tsbTable
            // 
            this.tsbTable.CheckOnClick = true;
            this.tsbTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbTable.Image = global::AojReport.AojWinForm.Properties.Resources.table;
            this.tsbTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTable.Name = "tsbTable";
            this.tsbTable.Size = new System.Drawing.Size(23, 22);
            this.tsbTable.Text = "toolStripButton3";
            this.tsbTable.ToolTipText = "Table";
            this.tsbTable.Click += new System.EventHandler(this.tsbTable_Click);
            // 
            // tsbImage
            // 
            this.tsbImage.CheckOnClick = true;
            this.tsbImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbImage.Image = global::AojReport.AojWinForm.Properties.Resources.image;
            this.tsbImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImage.Name = "tsbImage";
            this.tsbImage.Size = new System.Drawing.Size(23, 22);
            this.tsbImage.Text = "toolStripButton4";
            this.tsbImage.ToolTipText = "Image";
            this.tsbImage.Click += new System.EventHandler(this.tsbImage_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbCmbPage
            // 
            this.tsbCmbPage.Name = "tsbCmbPage";
            this.tsbCmbPage.Size = new System.Drawing.Size(121, 25);
            this.tsbCmbPage.ToolTipText = "Page";
            this.tsbCmbPage.SelectedIndexChanged += new System.EventHandler(this.tsbCmbPage_SelectedIndexChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbGridStyle
            // 
            this.tsbGridStyle.Checked = true;
            this.tsbGridStyle.CheckOnClick = true;
            this.tsbGridStyle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbGridStyle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGridStyle.Image = global::AojReport.AojWinForm.Properties.Resources.gridstyle;
            this.tsbGridStyle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGridStyle.Name = "tsbGridStyle";
            this.tsbGridStyle.Size = new System.Drawing.Size(23, 22);
            this.tsbGridStyle.Text = "Grid";
            this.tsbGridStyle.ToolTipText = "Grid";
            this.tsbGridStyle.Click += new System.EventHandler(this.tsbGridStyle_Click);
            // 
            // tsbTxtGridStyle
            // 
            this.tsbTxtGridStyle.Name = "tsbTxtGridStyle";
            this.tsbTxtGridStyle.Size = new System.Drawing.Size(100, 25);
            this.tsbTxtGridStyle.Text = "10";
            this.tsbTxtGridStyle.ToolTipText = "Distance";
            this.tsbTxtGridStyle.Validated += new System.EventHandler(this.tsbTxtGridStyle_Validated);
            // 
            // tsbAutoCompute
            // 
            this.tsbAutoCompute.Checked = true;
            this.tsbAutoCompute.CheckOnClick = true;
            this.tsbAutoCompute.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbAutoCompute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAutoCompute.Image = global::AojReport.AojWinForm.Properties.Resources.autocompute;
            this.tsbAutoCompute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAutoCompute.Name = "tsbAutoCompute";
            this.tsbAutoCompute.Size = new System.Drawing.Size(23, 22);
            this.tsbAutoCompute.Text = "toolStripButton1";
            this.tsbAutoCompute.ToolTipText = "AutoCompute";
            this.tsbAutoCompute.Click += new System.EventHandler(this.tsbAutoCompute_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbCmbZoom
            // 
            this.tsbCmbZoom.Name = "tsbCmbZoom";
            this.tsbCmbZoom.Size = new System.Drawing.Size(121, 25);
            this.tsbCmbZoom.ToolTipText = "Zoom";
            this.tsbCmbZoom.SelectedIndexChanged += new System.EventHandler(this.tsbCmbZoom_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 807);
            this.Controls.Add(this.splitContainerDesign);
            this.Controls.Add(this.toolStripInfo);
            this.Controls.Add(this.menuStripDesign);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripDesign;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "翱捷报表设计器";
            this.Deactivate += new System.EventHandler(this.MainForm_Deactivate);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStripDesign.ResumeLayout(false);
            this.menuStripDesign.PerformLayout();
            this.splitContainerDesign.ResumeLayout(false);
            this.toolStripInfo.ResumeLayout(false);
            this.toolStripInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripDesign;
        private System.Windows.Forms.ToolStripMenuItem tsmFile;
        private System.Windows.Forms.ToolStripMenuItem tsmNew;
        private System.Windows.Forms.ToolStripMenuItem tsmOpen;
        private System.Windows.Forms.ToolStripSeparator tsmItem2;
        private System.Windows.Forms.ToolStripMenuItem tsmSave;
        private System.Windows.Forms.ToolStripSeparator tsmItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmExit;
        private System.Windows.Forms.ToolStripMenuItem tsmEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmUndo;
        private System.Windows.Forms.ToolStripMenuItem tsmRedo;
        private System.Windows.Forms.ToolStripSeparator tsmItem3;
        private System.Windows.Forms.ToolStripMenuItem tsmCut;
        private System.Windows.Forms.ToolStripMenuItem tsmCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmPaste;
        private System.Windows.Forms.ToolStripMenuItem tsmDelete;
        private System.Windows.Forms.ToolStripSeparator tsmItem4;
        private System.Windows.Forms.ToolStripMenuItem tsmSelectAll;
        private System.Windows.Forms.ToolStripMenuItem tsmView;
        private System.Windows.Forms.ToolStripMenuItem tsmReportDocument;
        private System.Windows.Forms.ToolStripMenuItem tsmObject;
        private System.Windows.Forms.ToolStripMenuItem tsmLabel;
        private System.Windows.Forms.ToolStripMenuItem tsmTable;
        private System.Windows.Forms.ToolStripMenuItem tsmImage;
        private System.Windows.Forms.ToolStripMenuItem tsmHelp;
        private System.Windows.Forms.SplitContainer splitContainerDesign;
        private System.Windows.Forms.OpenFileDialog aojOopenFileDialog;
        private System.Windows.Forms.SaveFileDialog aojSaveFileDialog;
        private System.Windows.Forms.ToolStrip toolStripInfo;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbPointer;
        private System.Windows.Forms.ToolStripButton tsbLabel;
        private System.Windows.Forms.ToolStripButton tsbTable;
        private System.Windows.Forms.ToolStripButton tsbImage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripComboBox tsbCmbPage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbGridStyle;
        private System.Windows.Forms.ToolStripTextBox tsbTxtGridStyle;
        private System.Windows.Forms.ToolStripButton tsbAutoCompute;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripComboBox tsbCmbZoom;
    }
}