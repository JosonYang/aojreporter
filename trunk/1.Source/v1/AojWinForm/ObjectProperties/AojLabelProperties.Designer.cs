namespace AojReport.AojWinForm.ObjectProperties
{
    partial class AojLabelProperties
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
            this.groupBoxText = new System.Windows.Forms.GroupBox();
            this.lbContent = new System.Windows.Forms.Label();
            this.txtConent = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.groupBoxFont = new System.Windows.Forms.GroupBox();
            this.btnColor = new System.Windows.Forms.Button();
            this.btnFont = new System.Windows.Forms.Button();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.txtFont = new System.Windows.Forms.TextBox();
            this.lbColor = new System.Windows.Forms.Label();
            this.lbFont = new System.Windows.Forms.Label();
            this.groupBoxFormat = new System.Windows.Forms.GroupBox();
            this.cmbLineAlignment = new System.Windows.Forms.ComboBox();
            this.cmbAlignment = new System.Windows.Forms.ComboBox();
            this.lbVertical = new System.Windows.Forms.Label();
            this.lbHorizontal = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.lbHeight = new System.Windows.Forms.Label();
            this.lbWidth = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.fontDialogForm = new System.Windows.Forms.FontDialog();
            this.colorDialogForm = new System.Windows.Forms.ColorDialog();
            this.groupBoxText.SuspendLayout();
            this.groupBoxFont.SuspendLayout();
            this.groupBoxFormat.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxText
            // 
            this.groupBoxText.Controls.Add(this.lbContent);
            this.groupBoxText.Controls.Add(this.txtConent);
            this.groupBoxText.Controls.Add(this.txtName);
            this.groupBoxText.Controls.Add(this.lbName);
            this.groupBoxText.Location = new System.Drawing.Point(12, 12);
            this.groupBoxText.Name = "groupBoxText";
            this.groupBoxText.Size = new System.Drawing.Size(403, 151);
            this.groupBoxText.TabIndex = 0;
            this.groupBoxText.TabStop = false;
            this.groupBoxText.Text = "文本属性";
            // 
            // lbContent
            // 
            this.lbContent.AutoSize = true;
            this.lbContent.Location = new System.Drawing.Point(32, 58);
            this.lbContent.Name = "lbContent";
            this.lbContent.Size = new System.Drawing.Size(34, 13);
            this.lbContent.TabIndex = 3;
            this.lbContent.Text = "文本:";
            // 
            // txtConent
            // 
            this.txtConent.Location = new System.Drawing.Point(72, 55);
            this.txtConent.Multiline = true;
            this.txtConent.Name = "txtConent";
            this.txtConent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConent.Size = new System.Drawing.Size(314, 57);
            this.txtConent.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(72, 17);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 2;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(32, 20);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(34, 13);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "名称:";
            // 
            // groupBoxFont
            // 
            this.groupBoxFont.Controls.Add(this.btnColor);
            this.groupBoxFont.Controls.Add(this.btnFont);
            this.groupBoxFont.Controls.Add(this.txtColor);
            this.groupBoxFont.Controls.Add(this.txtFont);
            this.groupBoxFont.Controls.Add(this.lbColor);
            this.groupBoxFont.Controls.Add(this.lbFont);
            this.groupBoxFont.Location = new System.Drawing.Point(12, 169);
            this.groupBoxFont.Name = "groupBoxFont";
            this.groupBoxFont.Size = new System.Drawing.Size(403, 100);
            this.groupBoxFont.TabIndex = 1;
            this.groupBoxFont.TabStop = false;
            this.groupBoxFont.Text = "字体属性";
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(311, 58);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(75, 23);
            this.btnColor.TabIndex = 9;
            this.btnColor.Text = "选择颜色";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnFont
            // 
            this.btnFont.Location = new System.Drawing.Point(311, 19);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(75, 23);
            this.btnFont.TabIndex = 8;
            this.btnFont.Text = "选择字体";
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // txtColor
            // 
            this.txtColor.Enabled = false;
            this.txtColor.Location = new System.Drawing.Point(72, 60);
            this.txtColor.Name = "txtColor";
            this.txtColor.ReadOnly = true;
            this.txtColor.Size = new System.Drawing.Size(224, 20);
            this.txtColor.TabIndex = 7;
            // 
            // txtFont
            // 
            this.txtFont.Location = new System.Drawing.Point(72, 22);
            this.txtFont.Name = "txtFont";
            this.txtFont.ReadOnly = true;
            this.txtFont.Size = new System.Drawing.Size(224, 20);
            this.txtFont.TabIndex = 6;
            // 
            // lbColor
            // 
            this.lbColor.AutoSize = true;
            this.lbColor.Location = new System.Drawing.Point(32, 63);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(34, 13);
            this.lbColor.TabIndex = 5;
            this.lbColor.Text = "颜色:";
            // 
            // lbFont
            // 
            this.lbFont.AutoSize = true;
            this.lbFont.Location = new System.Drawing.Point(32, 25);
            this.lbFont.Name = "lbFont";
            this.lbFont.Size = new System.Drawing.Size(34, 13);
            this.lbFont.TabIndex = 4;
            this.lbFont.Text = "字体:";
            // 
            // groupBoxFormat
            // 
            this.groupBoxFormat.Controls.Add(this.cmbLineAlignment);
            this.groupBoxFormat.Controls.Add(this.cmbAlignment);
            this.groupBoxFormat.Controls.Add(this.lbVertical);
            this.groupBoxFormat.Controls.Add(this.lbHorizontal);
            this.groupBoxFormat.Controls.Add(this.txtHeight);
            this.groupBoxFormat.Controls.Add(this.txtWidth);
            this.groupBoxFormat.Controls.Add(this.lbHeight);
            this.groupBoxFormat.Controls.Add(this.lbWidth);
            this.groupBoxFormat.Location = new System.Drawing.Point(12, 275);
            this.groupBoxFormat.Name = "groupBoxFormat";
            this.groupBoxFormat.Size = new System.Drawing.Size(403, 114);
            this.groupBoxFormat.TabIndex = 2;
            this.groupBoxFormat.TabStop = false;
            this.groupBoxFormat.Text = "对齐属性";
            // 
            // cmbLineAlignment
            // 
            this.cmbLineAlignment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLineAlignment.FormattingEnabled = true;
            this.cmbLineAlignment.Location = new System.Drawing.Point(251, 48);
            this.cmbLineAlignment.Name = "cmbLineAlignment";
            this.cmbLineAlignment.Size = new System.Drawing.Size(76, 21);
            this.cmbLineAlignment.TabIndex = 12;
            this.cmbLineAlignment.SelectedIndexChanged += new System.EventHandler(this.cmbLineAlignment_SelectedIndexChanged);
            // 
            // cmbAlignment
            // 
            this.cmbAlignment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlignment.FormattingEnabled = true;
            this.cmbAlignment.Location = new System.Drawing.Point(72, 48);
            this.cmbAlignment.Name = "cmbAlignment";
            this.cmbAlignment.Size = new System.Drawing.Size(76, 21);
            this.cmbAlignment.TabIndex = 11;
            this.cmbAlignment.SelectedIndexChanged += new System.EventHandler(this.cmbAlignment_SelectedIndexChanged);
            // 
            // lbVertical
            // 
            this.lbVertical.AutoSize = true;
            this.lbVertical.Location = new System.Drawing.Point(187, 51);
            this.lbVertical.Name = "lbVertical";
            this.lbVertical.Size = new System.Drawing.Size(58, 13);
            this.lbVertical.TabIndex = 10;
            this.lbVertical.Text = "上下对齐:";
            // 
            // lbHorizontal
            // 
            this.lbHorizontal.AutoSize = true;
            this.lbHorizontal.Location = new System.Drawing.Point(8, 51);
            this.lbHorizontal.Name = "lbHorizontal";
            this.lbHorizontal.Size = new System.Drawing.Size(58, 13);
            this.lbHorizontal.TabIndex = 9;
            this.lbHorizontal.Text = "左右对齐:";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(251, 24);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(100, 20);
            this.txtHeight.TabIndex = 8;
            this.txtHeight.Validated += new System.EventHandler(this.txtHeight_Validated);
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(72, 24);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(100, 20);
            this.txtWidth.TabIndex = 7;
            this.txtWidth.Validated += new System.EventHandler(this.txtWidth_Validated);
            // 
            // lbHeight
            // 
            this.lbHeight.AutoSize = true;
            this.lbHeight.Location = new System.Drawing.Point(211, 27);
            this.lbHeight.Name = "lbHeight";
            this.lbHeight.Size = new System.Drawing.Size(34, 13);
            this.lbHeight.TabIndex = 6;
            this.lbHeight.Text = "高度:";
            // 
            // lbWidth
            // 
            this.lbWidth.AutoSize = true;
            this.lbWidth.Location = new System.Drawing.Point(32, 27);
            this.lbWidth.Name = "lbWidth";
            this.lbWidth.Size = new System.Drawing.Size(34, 13);
            this.lbWidth.TabIndex = 5;
            this.lbWidth.Text = "宽度:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(264, 428);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(345, 428);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // fontDialogForm
            // 
            this.fontDialogForm.AllowScriptChange = false;
            // 
            // AojLabelProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 463);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBoxFormat);
            this.Controls.Add(this.groupBoxFont);
            this.Controls.Add(this.groupBoxText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AojLabelProperties";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LabelProperties";
            this.groupBoxText.ResumeLayout(false);
            this.groupBoxText.PerformLayout();
            this.groupBoxFont.ResumeLayout(false);
            this.groupBoxFont.PerformLayout();
            this.groupBoxFormat.ResumeLayout(false);
            this.groupBoxFormat.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxText;
        private System.Windows.Forms.GroupBox groupBoxFont;
        private System.Windows.Forms.GroupBox groupBoxFormat;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lbContent;
        private System.Windows.Forms.TextBox txtConent;
        private System.Windows.Forms.Label lbColor;
        private System.Windows.Forms.Label lbFont;
        private System.Windows.Forms.TextBox txtFont;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label lbHeight;
        private System.Windows.Forms.Label lbWidth;
        private System.Windows.Forms.Label lbVertical;
        private System.Windows.Forms.Label lbHorizontal;
        private System.Windows.Forms.ComboBox cmbLineAlignment;
        private System.Windows.Forms.ComboBox cmbAlignment;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FontDialog fontDialogForm;
        private System.Windows.Forms.ColorDialog colorDialogForm;
        private System.Windows.Forms.TextBox txtColor;
    }
}