namespace AojReport.AojPrintEngine
{
    partial class PreviewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreviewForm));
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.tlsTop = new System.Windows.Forms.ToolStrip();
            this.tlsbPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsbZoom = new System.Windows.Forms.ToolStripComboBox();
            this.tlsbPrvStart = new System.Windows.Forms.ToolStripButton();
            this.tlsbNextEnd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.lblCurrentPage = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.lblAllPage = new System.Windows.Forms.ToolStripLabel();
            this.tlsbSave = new System.Windows.Forms.ToolStripButton();
            this.aojPrintPreviewControl = new AojReport.AojPrintEngine.AojPrintPreviewControl();
            this.tlsbPrv = new System.Windows.Forms.ToolStripButton();
            this.tlsbNext = new System.Windows.Forms.ToolStripButton();
            this.tlsTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // printDialog1
            // 
            this.printDialog1.AllowCurrentPage = true;
            this.printDialog1.UseEXDialog = true;
            // 
            // tlsTop
            // 
            this.tlsTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsbPrint,
            this.tlsbSave,
            this.toolStripSeparator1,
            this.tlsbPrvStart,
            this.tlsbPrv,
            this.tlsbNext,
            this.tlsbNextEnd,
            this.toolStripSeparator2,
            this.tlsbZoom,
            this.toolStripLabel1,
            this.lblCurrentPage,
            this.toolStripLabel3,
            this.lblAllPage});
            this.tlsTop.Location = new System.Drawing.Point(0, 0);
            this.tlsTop.Name = "tlsTop";
            this.tlsTop.Size = new System.Drawing.Size(1016, 25);
            this.tlsTop.TabIndex = 2;
            this.tlsTop.Text = "toolStrip1";
            // 
            // tlsbPrint
            // 
            this.tlsbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tlsbPrint.Image")));
            this.tlsbPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tlsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsbPrint.Name = "tlsbPrint";
            this.tlsbPrint.Size = new System.Drawing.Size(23, 22);
            this.tlsbPrint.Text = "打印";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tlsbZoom
            // 
            this.tlsbZoom.Name = "tlsbZoom";
            this.tlsbZoom.Size = new System.Drawing.Size(75, 25);
            this.tlsbZoom.ToolTipText = "放大缩小";
            // 
            // tlsbPrvStart
            // 
            this.tlsbPrvStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsbPrvStart.Image = ((System.Drawing.Image)(resources.GetObject("tlsbPrvStart.Image")));
            this.tlsbPrvStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsbPrvStart.Name = "tlsbPrvStart";
            this.tlsbPrvStart.Size = new System.Drawing.Size(23, 22);
            this.tlsbPrvStart.Text = "前一页";
            // 
            // tlsbNextEnd
            // 
            this.tlsbNextEnd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsbNextEnd.Image = ((System.Drawing.Image)(resources.GetObject("tlsbNextEnd.Image")));
            this.tlsbNextEnd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsbNextEnd.Name = "tlsbNextEnd";
            this.tlsbNextEnd.Size = new System.Drawing.Size(23, 22);
            this.tlsbNextEnd.Text = "后一页";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(56, 22);
            this.toolStripLabel1.Text = "当前页：";
            // 
            // lblCurrentPage
            // 
            this.lblCurrentPage.Name = "lblCurrentPage";
            this.lblCurrentPage.Size = new System.Drawing.Size(80, 22);
            this.lblCurrentPage.Text = "CurrentPage";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(56, 22);
            this.toolStripLabel3.Text = "总页数：";
            // 
            // lblAllPage
            // 
            this.lblAllPage.Name = "lblAllPage";
            this.lblAllPage.Size = new System.Drawing.Size(51, 22);
            this.lblAllPage.Text = "AllPage";
            // 
            // tlsbSave
            // 
            this.tlsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tlsbSave.Image")));
            this.tlsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsbSave.Name = "tlsbSave";
            this.tlsbSave.Size = new System.Drawing.Size(23, 22);
            this.tlsbSave.Text = "保存";
            // 
            // aojPrintPreviewControl
            // 
            this.aojPrintPreviewControl.AutoScroll = true;
            this.aojPrintPreviewControl.BackColor = System.Drawing.SystemColors.ControlDark;
            this.aojPrintPreviewControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.aojPrintPreviewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aojPrintPreviewControl.Document = null;
            this.aojPrintPreviewControl.Location = new System.Drawing.Point(0, 25);
            this.aojPrintPreviewControl.Name = "aojPrintPreviewControl";
            this.aojPrintPreviewControl.Picture = ((System.Drawing.Image)(resources.GetObject("aojPrintPreviewControl.Picture")));
            this.aojPrintPreviewControl.Size = new System.Drawing.Size(1016, 709);
            this.aojPrintPreviewControl.TabIndex = 1;
            // 
            // tlsbPrv
            // 
            this.tlsbPrv.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsbPrv.Image = ((System.Drawing.Image)(resources.GetObject("tlsbPrv.Image")));
            this.tlsbPrv.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsbPrv.Name = "tlsbPrv";
            this.tlsbPrv.Size = new System.Drawing.Size(23, 22);
            this.tlsbPrv.Text = "toolStripButton1";
            // 
            // tlsbNext
            // 
            this.tlsbNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsbNext.Image = ((System.Drawing.Image)(resources.GetObject("tlsbNext.Image")));
            this.tlsbNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsbNext.Name = "tlsbNext";
            this.tlsbNext.Size = new System.Drawing.Size(23, 22);
            this.tlsbNext.Text = "toolStripButton2";
            // 
            // PreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this.aojPrintPreviewControl);
            this.Controls.Add(this.tlsTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PreviewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "打印预览";
            this.tlsTop.ResumeLayout(false);
            this.tlsTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AojPrintPreviewControl aojPrintPreviewControl;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.ToolStrip tlsTop;
        private System.Windows.Forms.ToolStripComboBox tlsbZoom;
        private System.Windows.Forms.ToolStripButton tlsbPrint;
        private System.Windows.Forms.ToolStripButton tlsbPrvStart;
        private System.Windows.Forms.ToolStripButton tlsbNextEnd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel lblCurrentPage;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel lblAllPage;
        private System.Windows.Forms.ToolStripButton tlsbSave;
        private System.Windows.Forms.ToolStripButton tlsbPrv;
        private System.Windows.Forms.ToolStripButton tlsbNext;
    }
}