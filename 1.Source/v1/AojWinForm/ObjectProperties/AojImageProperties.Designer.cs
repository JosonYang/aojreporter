namespace AojReport.AojWinForm.ObjectProperties
{
    partial class AojImageProperties
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
            this.lbView = new System.Windows.Forms.Label();
            this.picView = new System.Windows.Forms.PictureBox();
            this.btnSrc = new System.Windows.Forms.Button();
            this.txtSrc = new System.Windows.Forms.TextBox();
            this.lbSrc = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.groupBoxFormat = new System.Windows.Forms.GroupBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.lbHeight = new System.Windows.Forms.Label();
            this.lbWidth = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.openFileDialogForm = new System.Windows.Forms.OpenFileDialog();
            this.groupBoxText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picView)).BeginInit();
            this.groupBoxFormat.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxText
            // 
            this.groupBoxText.Controls.Add(this.lbView);
            this.groupBoxText.Controls.Add(this.picView);
            this.groupBoxText.Controls.Add(this.btnSrc);
            this.groupBoxText.Controls.Add(this.txtSrc);
            this.groupBoxText.Controls.Add(this.lbSrc);
            this.groupBoxText.Controls.Add(this.txtName);
            this.groupBoxText.Controls.Add(this.lbName);
            this.groupBoxText.Location = new System.Drawing.Point(12, 12);
            this.groupBoxText.Name = "groupBoxText";
            this.groupBoxText.Size = new System.Drawing.Size(403, 234);
            this.groupBoxText.TabIndex = 0;
            this.groupBoxText.TabStop = false;
            this.groupBoxText.Text = "图像属性";
            // 
            // lbView
            // 
            this.lbView.AutoSize = true;
            this.lbView.Location = new System.Drawing.Point(32, 139);
            this.lbView.Name = "lbView";
            this.lbView.Size = new System.Drawing.Size(34, 13);
            this.lbView.TabIndex = 12;
            this.lbView.Text = "预览:";
            // 
            // picView
            // 
            this.picView.ErrorImage = global::AojReport.AojWinForm.Properties.Resources.None;
            this.picView.Location = new System.Drawing.Point(72, 87);
            this.picView.Name = "picView";
            this.picView.Size = new System.Drawing.Size(305, 133);
            this.picView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picView.TabIndex = 11;
            this.picView.TabStop = false;
            // 
            // btnSrc
            // 
            this.btnSrc.Location = new System.Drawing.Point(302, 49);
            this.btnSrc.Name = "btnSrc";
            this.btnSrc.Size = new System.Drawing.Size(75, 23);
            this.btnSrc.TabIndex = 10;
            this.btnSrc.Text = "图片地址";
            this.btnSrc.UseVisualStyleBackColor = true;
            this.btnSrc.Click += new System.EventHandler(this.btnSrc_Click);
            // 
            // txtSrc
            // 
            this.txtSrc.Location = new System.Drawing.Point(72, 51);
            this.txtSrc.Name = "txtSrc";
            this.txtSrc.ReadOnly = true;
            this.txtSrc.Size = new System.Drawing.Size(224, 20);
            this.txtSrc.TabIndex = 1;
            // 
            // lbSrc
            // 
            this.lbSrc.AutoSize = true;
            this.lbSrc.Location = new System.Drawing.Point(32, 58);
            this.lbSrc.Name = "lbSrc";
            this.lbSrc.Size = new System.Drawing.Size(34, 13);
            this.lbSrc.TabIndex = 3;
            this.lbSrc.Text = "路径:";
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
            // groupBoxFormat
            // 
            this.groupBoxFormat.Controls.Add(this.txtHeight);
            this.groupBoxFormat.Controls.Add(this.txtWidth);
            this.groupBoxFormat.Controls.Add(this.lbHeight);
            this.groupBoxFormat.Controls.Add(this.lbWidth);
            this.groupBoxFormat.Location = new System.Drawing.Point(12, 252);
            this.groupBoxFormat.Name = "groupBoxFormat";
            this.groupBoxFormat.Size = new System.Drawing.Size(403, 88);
            this.groupBoxFormat.TabIndex = 2;
            this.groupBoxFormat.TabStop = false;
            this.groupBoxFormat.Text = "大小属性";
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
            this.btnOK.Location = new System.Drawing.Point(263, 428);
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
            this.btnCancel.Location = new System.Drawing.Point(344, 428);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // openFileDialogForm
            // 
            this.openFileDialogForm.FileName = "所有图片";
            this.openFileDialogForm.Filter = "所有图片|*.ico;*.jpg;*.bmp;*.png;*.gif|ICO图片|*.ico|JPG图片|*.jpg|Bmp图片|*.bmp|PNG图片|*.pn" +
                "g|GIF图片|*.gif";
            // 
            // AojImageProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 463);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBoxFormat);
            this.Controls.Add(this.groupBoxText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AojImageProperties";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ImageProperties";
            this.groupBoxText.ResumeLayout(false);
            this.groupBoxText.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picView)).EndInit();
            this.groupBoxFormat.ResumeLayout(false);
            this.groupBoxFormat.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxText;
        private System.Windows.Forms.GroupBox groupBoxFormat;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lbSrc;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label lbHeight;
        private System.Windows.Forms.Label lbWidth;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtSrc;
        private System.Windows.Forms.OpenFileDialog openFileDialogForm;
        private System.Windows.Forms.Button btnSrc;
        private System.Windows.Forms.Label lbView;
        private System.Windows.Forms.PictureBox picView;
    }
}