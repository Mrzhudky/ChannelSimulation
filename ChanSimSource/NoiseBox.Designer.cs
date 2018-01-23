namespace ChanSimSource
{
    partial class NoiseBox
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoiseBox));
            this.txtGeneSNR = new System.Windows.Forms.TextBox();
            this.lalGeneSNR = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new CCWin.SkinControl.SkinButton();
            this.btnDetermine = new CCWin.SkinControl.SkinButton();
            this.errorShow = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorShow)).BeginInit();
            this.SuspendLayout();
            // 
            // txtGeneSNR
            // 
            this.txtGeneSNR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.txtGeneSNR.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorShow.SetError(this.txtGeneSNR, "输入值应该大于0");
            this.txtGeneSNR.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtGeneSNR.ForeColor = System.Drawing.Color.White;
            this.txtGeneSNR.Location = new System.Drawing.Point(120, 44);
            this.txtGeneSNR.Name = "txtGeneSNR";
            this.txtGeneSNR.Size = new System.Drawing.Size(134, 17);
            this.txtGeneSNR.TabIndex = 104;
            this.txtGeneSNR.Text = "5";
            this.txtGeneSNR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGeneSNR.TextChanged += new System.EventHandler(this.txtGeneSNR_TextChanged);
            this.txtGeneSNR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInputUFloat_KeyPress);
            // 
            // lalGeneSNR
            // 
            this.lalGeneSNR.AutoSize = true;
            this.lalGeneSNR.BackColor = System.Drawing.Color.Transparent;
            this.lalGeneSNR.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold);
            this.lalGeneSNR.ForeColor = System.Drawing.Color.White;
            this.lalGeneSNR.Location = new System.Drawing.Point(41, 42);
            this.lalGeneSNR.Name = "lalGeneSNR";
            this.lalGeneSNR.Size = new System.Drawing.Size(59, 18);
            this.lalGeneSNR.TabIndex = 103;
            this.lalGeneSNR.Text = "信噪比";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(257, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 18);
            this.label1.TabIndex = 105;
            this.label1.Text = "dB";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnCancel.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnCancel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnCancel.DownBack = null;
            this.btnCancel.DownBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCancel.FadeGlow = false;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(163)))), ((int)(((byte)(220)))));
            this.btnCancel.IsDrawBorder = false;
            this.btnCancel.IsDrawGlass = false;
            this.btnCancel.Location = new System.Drawing.Point(194, 97);
            this.btnCancel.MouseBack = null;
            this.btnCancel.MouseBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormlBack = null;
            this.btnCancel.Size = new System.Drawing.Size(75, 29);
            this.btnCancel.TabIndex = 107;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDetermine
            // 
            this.btnDetermine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnDetermine.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnDetermine.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnDetermine.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnDetermine.DownBack = null;
            this.btnDetermine.DownBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDetermine.Enabled = false;
            this.btnDetermine.FadeGlow = false;
            this.btnDetermine.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnDetermine.ForeColor = System.Drawing.Color.White;
            this.btnDetermine.IsDrawBorder = false;
            this.btnDetermine.IsDrawGlass = false;
            this.btnDetermine.Location = new System.Drawing.Point(55, 97);
            this.btnDetermine.MouseBack = null;
            this.btnDetermine.MouseBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnDetermine.Name = "btnDetermine";
            this.btnDetermine.NormlBack = null;
            this.btnDetermine.Size = new System.Drawing.Size(75, 29);
            this.btnDetermine.TabIndex = 106;
            this.btnDetermine.Text = "确定";
            this.btnDetermine.UseVisualStyleBackColor = false;
            this.btnDetermine.Click += new System.EventHandler(this.btnDetermine_Click);
            // 
            // errorShow
            // 
            this.errorShow.BlinkRate = 0;
            this.errorShow.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorShow.ContainerControl = this;
            this.errorShow.RightToLeft = true;
            // 
            // NoiseBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(306, 138);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDetermine);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGeneSNR);
            this.Controls.Add(this.lalGeneSNR);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NoiseBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.NoiseBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGeneSNR;
        private System.Windows.Forms.Label lalGeneSNR;
        private System.Windows.Forms.Label label1;
        private CCWin.SkinControl.SkinButton btnCancel;
        private CCWin.SkinControl.SkinButton btnDetermine;
        private System.Windows.Forms.ErrorProvider errorShow;
    }
}