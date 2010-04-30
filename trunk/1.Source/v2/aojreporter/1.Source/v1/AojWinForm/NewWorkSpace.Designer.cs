namespace AojReport.AojWinForm
{
    partial class NewWorkSpace
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewWorkSpace));
            this.lbPage = new System.Windows.Forms.Label();
            this.lbStyle = new System.Windows.Forms.Label();
            this.cmbPage = new System.Windows.Forms.ComboBox();
            this.cmbStyle = new System.Windows.Forms.ComboBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.grpInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbPage
            // 
            this.lbPage.AutoSize = true;
            this.lbPage.Location = new System.Drawing.Point(30, 50);
            this.lbPage.Name = "lbPage";
            this.lbPage.Size = new System.Drawing.Size(58, 13);
            this.lbPage.TabIndex = 0;
            this.lbPage.Text = "报表纸张:";
            // 
            // lbStyle
            // 
            this.lbStyle.AutoSize = true;
            this.lbStyle.Location = new System.Drawing.Point(30, 106);
            this.lbStyle.Name = "lbStyle";
            this.lbStyle.Size = new System.Drawing.Size(58, 13);
            this.lbStyle.TabIndex = 1;
            this.lbStyle.Text = "显示方式:";
            // 
            // cmbPage
            // 
            this.cmbPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPage.FormattingEnabled = true;
            this.cmbPage.Location = new System.Drawing.Point(94, 47);
            this.cmbPage.Name = "cmbPage";
            this.cmbPage.Size = new System.Drawing.Size(87, 21);
            this.cmbPage.TabIndex = 7;
            // 
            // cmbStyle
            // 
            this.cmbStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStyle.FormattingEnabled = true;
            this.cmbStyle.Location = new System.Drawing.Point(94, 103);
            this.cmbStyle.Name = "cmbStyle";
            this.cmbStyle.Size = new System.Drawing.Size(87, 21);
            this.cmbStyle.TabIndex = 8;
            // 
            // btnNew
            // 
            this.btnNew.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnNew.Location = new System.Drawing.Point(369, 13);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 9;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(369, 55);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.lbPage);
            this.grpInfo.Controls.Add(this.lbStyle);
            this.grpInfo.Controls.Add(this.cmbPage);
            this.grpInfo.Controls.Add(this.cmbStyle);
            this.grpInfo.Location = new System.Drawing.Point(12, 13);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(281, 244);
            this.grpInfo.TabIndex = 11;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "报表预设";
            // 
            // NewWorkSpace
            // 
            this.AcceptButton = this.btnNew;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(472, 300);
            this.Controls.Add(this.grpInfo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNew);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewWorkSpace";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New";
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbPage;
        private System.Windows.Forms.Label lbStyle;
        private System.Windows.Forms.ComboBox cmbPage;
        private System.Windows.Forms.ComboBox cmbStyle;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpInfo;
    }
}