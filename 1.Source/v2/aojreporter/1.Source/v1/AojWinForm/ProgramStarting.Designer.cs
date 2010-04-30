namespace AojReport.AojWinForm
{
    partial class ProgramStarting
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
            this.picStarting = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picStarting)).BeginInit();
            this.SuspendLayout();
            // 
            // picStarting
            // 
            this.picStarting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picStarting.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.picStarting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picStarting.Image = global::AojReport.AojWinForm.Properties.Resources.ProgramStarting;
            this.picStarting.Location = new System.Drawing.Point(0, 0);
            this.picStarting.Name = "picStarting";
            this.picStarting.Size = new System.Drawing.Size(414, 212);
            this.picStarting.TabIndex = 0;
            this.picStarting.TabStop = false;
            // 
            // ProgramStarting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(414, 212);
            this.Controls.Add(this.picStarting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProgramStarting";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProgramStarting";
            ((System.ComponentModel.ISupportInitialize)(this.picStarting)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picStarting;
    }
}