namespace AojReport.AojPrintEngine
{
    partial class PrintForm
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
            this.grpTop = new System.Windows.Forms.GroupBox();
            this.lbPrinter = new System.Windows.Forms.Label();
            this.cmbPrinters = new System.Windows.Forms.ComboBox();
            this.fpnlTop = new System.Windows.Forms.FlowLayoutPanel();
            this.gpPageRange = new System.Windows.Forms.GroupBox();
            this.pnlPageNums = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPageEnd = new System.Windows.Forms.TextBox();
            this.txtPageStart = new System.Windows.Forms.TextBox();
            this.rabPageNums = new System.Windows.Forms.RadioButton();
            this.rabPageAll = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ChkAutoPageBreak = new System.Windows.Forms.CheckBox();
            this.nubPageCounts = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.grpTop.SuspendLayout();
            this.fpnlTop.SuspendLayout();
            this.gpPageRange.SuspendLayout();
            this.pnlPageNums.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nubPageCounts)).BeginInit();
            this.SuspendLayout();
            // 
            // grpTop
            // 
            this.grpTop.Controls.Add(this.lbPrinter);
            this.grpTop.Controls.Add(this.cmbPrinters);
            this.grpTop.Location = new System.Drawing.Point(3, 3);
            this.grpTop.Name = "grpTop";
            this.grpTop.Size = new System.Drawing.Size(460, 92);
            this.grpTop.TabIndex = 0;
            this.grpTop.TabStop = false;
            this.grpTop.Text = "打印机";
            // 
            // lbPrinter
            // 
            this.lbPrinter.AutoSize = true;
            this.lbPrinter.Location = new System.Drawing.Point(18, 20);
            this.lbPrinter.Name = "lbPrinter";
            this.lbPrinter.Size = new System.Drawing.Size(47, 12);
            this.lbPrinter.TabIndex = 1;
            this.lbPrinter.Text = "打印机:";
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbPrinters.FormattingEnabled = true;
            this.cmbPrinters.Location = new System.Drawing.Point(70, 18);
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(362, 20);
            this.cmbPrinters.TabIndex = 0;
            // 
            // fpnlTop
            // 
            this.fpnlTop.Controls.Add(this.grpTop);
            this.fpnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.fpnlTop.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fpnlTop.Location = new System.Drawing.Point(0, 0);
            this.fpnlTop.Name = "fpnlTop";
            this.fpnlTop.Size = new System.Drawing.Size(471, 102);
            this.fpnlTop.TabIndex = 1;
            // 
            // gpPageRange
            // 
            this.gpPageRange.Controls.Add(this.pnlPageNums);
            this.gpPageRange.Controls.Add(this.rabPageNums);
            this.gpPageRange.Controls.Add(this.rabPageAll);
            this.gpPageRange.Location = new System.Drawing.Point(3, 108);
            this.gpPageRange.Name = "gpPageRange";
            this.gpPageRange.Size = new System.Drawing.Size(248, 115);
            this.gpPageRange.TabIndex = 2;
            this.gpPageRange.TabStop = false;
            this.gpPageRange.Text = "打印页数";
            // 
            // pnlPageNums
            // 
            this.pnlPageNums.Controls.Add(this.label1);
            this.pnlPageNums.Controls.Add(this.txtPageEnd);
            this.pnlPageNums.Controls.Add(this.txtPageStart);
            this.pnlPageNums.Enabled = false;
            this.pnlPageNums.Location = new System.Drawing.Point(6, 62);
            this.pnlPageNums.Name = "pnlPageNums";
            this.pnlPageNums.Size = new System.Drawing.Size(236, 47);
            this.pnlPageNums.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "～";
            // 
            // txtPageEnd
            // 
            this.txtPageEnd.Location = new System.Drawing.Point(102, 13);
            this.txtPageEnd.Name = "txtPageEnd";
            this.txtPageEnd.Size = new System.Drawing.Size(52, 21);
            this.txtPageEnd.TabIndex = 5;
            // 
            // txtPageStart
            // 
            this.txtPageStart.Location = new System.Drawing.Point(18, 13);
            this.txtPageStart.Name = "txtPageStart";
            this.txtPageStart.Size = new System.Drawing.Size(53, 21);
            this.txtPageStart.TabIndex = 3;
            // 
            // rabPageNums
            // 
            this.rabPageNums.AutoSize = true;
            this.rabPageNums.Location = new System.Drawing.Point(21, 39);
            this.rabPageNums.Name = "rabPageNums";
            this.rabPageNums.Size = new System.Drawing.Size(47, 16);
            this.rabPageNums.TabIndex = 2;
            this.rabPageNums.Text = "页码";
            this.rabPageNums.UseVisualStyleBackColor = true;
            this.rabPageNums.CheckedChanged += new System.EventHandler(this.rabPageNums_CheckedChanged);
            // 
            // rabPageAll
            // 
            this.rabPageAll.AutoSize = true;
            this.rabPageAll.Checked = true;
            this.rabPageAll.Location = new System.Drawing.Point(21, 18);
            this.rabPageAll.Name = "rabPageAll";
            this.rabPageAll.Size = new System.Drawing.Size(47, 16);
            this.rabPageAll.TabIndex = 0;
            this.rabPageAll.TabStop = true;
            this.rabPageAll.Text = "全部";
            this.rabPageAll.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ChkAutoPageBreak);
            this.groupBox1.Controls.Add(this.nubPageCounts);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(271, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 115);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "份数";
            // 
            // ChkAutoPageBreak
            // 
            this.ChkAutoPageBreak.AutoSize = true;
            this.ChkAutoPageBreak.Location = new System.Drawing.Point(33, 53);
            this.ChkAutoPageBreak.Name = "ChkAutoPageBreak";
            this.ChkAutoPageBreak.Size = new System.Drawing.Size(72, 16);
            this.ChkAutoPageBreak.TabIndex = 2;
            this.ChkAutoPageBreak.Text = "自动分页";
            this.ChkAutoPageBreak.UseVisualStyleBackColor = true;
            // 
            // nubPageCounts
            // 
            this.nubPageCounts.Location = new System.Drawing.Point(93, 18);
            this.nubPageCounts.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nubPageCounts.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nubPageCounts.Name = "nubPageCounts";
            this.nubPageCounts.Size = new System.Drawing.Size(62, 21);
            this.nubPageCounts.TabIndex = 1;
            this.nubPageCounts.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "份数：";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(222, 229);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(304, 229);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(384, 229);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 6;
            this.btnSet.Text = "应用";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // PrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 259);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gpPageRange);
            this.Controls.Add(this.fpnlTop);
            this.Name = "PrintForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PrintForm";
            this.grpTop.ResumeLayout(false);
            this.grpTop.PerformLayout();
            this.fpnlTop.ResumeLayout(false);
            this.gpPageRange.ResumeLayout(false);
            this.gpPageRange.PerformLayout();
            this.pnlPageNums.ResumeLayout(false);
            this.pnlPageNums.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nubPageCounts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpTop;
        private System.Windows.Forms.Label lbPrinter;
        private System.Windows.Forms.ComboBox cmbPrinters;
        private System.Windows.Forms.FlowLayoutPanel fpnlTop;
        private System.Windows.Forms.GroupBox gpPageRange;
        private System.Windows.Forms.TextBox txtPageEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPageStart;
        private System.Windows.Forms.RadioButton rabPageNums;
        private System.Windows.Forms.RadioButton rabPageAll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nubPageCounts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlPageNums;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.CheckBox ChkAutoPageBreak;
    }
}