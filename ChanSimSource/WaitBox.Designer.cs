namespace ChanSimSource
{
    partial class WaitBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaitBox));
            this.lalInformation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lalInformation
            // 
            this.lalInformation.AutoSize = true;
            this.lalInformation.BackColor = System.Drawing.Color.Transparent;
            this.lalInformation.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.lalInformation.ForeColor = System.Drawing.Color.White;
            this.lalInformation.Location = new System.Drawing.Point(57, 27);
            this.lalInformation.Name = "lalInformation";
            this.lalInformation.Size = new System.Drawing.Size(166, 24);
            this.lalInformation.TabIndex = 1;
            this.lalInformation.Text = "正在处理，请稍后...";
            // 
            // WaitBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(284, 77);
            this.ControlBox = false;
            this.Controls.Add(this.lalInformation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WaitBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WaitBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lalInformation;

    }
}