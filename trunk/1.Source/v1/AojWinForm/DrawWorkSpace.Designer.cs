namespace AojReport.AojWinForm
{
    partial class DrawWorkSpace
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmCut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.separatorInfo1 = new System.Windows.Forms.ToolStripSeparator();
            this.separatorInfo2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsMenu
            // 
            this.cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCopy,
            this.tsmPaste,
            this.separatorInfo2,
            this.tsmCut,
            this.tsmDelete,
            this.separatorInfo1,
            this.tsmProperties});
            this.cmsMenu.Name = "cmsMenu";
            this.cmsMenu.Size = new System.Drawing.Size(153, 148);
            // 
            // tsmCut
            // 
            this.tsmCut.Name = "tsmCut";
            this.tsmCut.Size = new System.Drawing.Size(152, 22);
            this.tsmCut.Text = "Cut";
            this.tsmCut.Click += new System.EventHandler(this.tsmCut_Click);
            // 
            // tsmCopy
            // 
            this.tsmCopy.Name = "tsmCopy";
            this.tsmCopy.Size = new System.Drawing.Size(152, 22);
            this.tsmCopy.Text = "Copy";
            this.tsmCopy.Click += new System.EventHandler(this.tsmCopy_Click);
            // 
            // tsmPaste
            // 
            this.tsmPaste.Name = "tsmPaste";
            this.tsmPaste.Size = new System.Drawing.Size(152, 22);
            this.tsmPaste.Text = "Paste";
            this.tsmPaste.Click += new System.EventHandler(this.tsmPaste_Click);
            // 
            // tsmDelete
            // 
            this.tsmDelete.Name = "tsmDelete";
            this.tsmDelete.Size = new System.Drawing.Size(152, 22);
            this.tsmDelete.Text = "Delete";
            this.tsmDelete.Click += new System.EventHandler(this.tsmDelete_Click);
            // 
            // tsmProperties
            // 
            this.tsmProperties.Name = "tsmProperties";
            this.tsmProperties.Size = new System.Drawing.Size(152, 22);
            this.tsmProperties.Text = "Properties";
            this.tsmProperties.Click += new System.EventHandler(this.tsmProperties_Click);
            // 
            // separatorInfo1
            // 
            this.separatorInfo1.Name = "separatorInfo1";
            this.separatorInfo1.Size = new System.Drawing.Size(149, 6);
            // 
            // separatorInfo2
            // 
            this.separatorInfo2.Name = "separatorInfo2";
            this.separatorInfo2.Size = new System.Drawing.Size(149, 6);
            // 
            // DrawWorkSpace
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Name = "DrawWorkSpace";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawWorkSpace_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawWorkSpace_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawWorkSpace_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawWorkSpace_MouseUp);
            this.cmsMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmCut;
        private System.Windows.Forms.ToolStripMenuItem tsmCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmPaste;
        private System.Windows.Forms.ToolStripMenuItem tsmDelete;
        private System.Windows.Forms.ToolStripSeparator separatorInfo1;
        private System.Windows.Forms.ToolStripMenuItem tsmProperties;
        private System.Windows.Forms.ToolStripSeparator separatorInfo2;
    }
}
