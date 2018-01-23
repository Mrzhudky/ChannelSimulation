namespace ChanSimSource
{
    partial class LossBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LossBox));
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.errorShow = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtArbitraryWave = new System.Windows.Forms.TextBox();
            this.btnDetermine = new CCWin.SkinControl.SkinButton();
            this.btnCancel = new CCWin.SkinControl.SkinButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorShow)).BeginInit();
            this.SuspendLayout();
            // 
            // skinLabel1
            // 
            this.skinLabel1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold);
            this.skinLabel1.ForeColor = System.Drawing.Color.White;
            this.skinLabel1.Location = new System.Drawing.Point(25, 43);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(76, 18);
            this.skinLabel1.TabIndex = 1;
            this.skinLabel1.Text = "路径损耗";
            // 
            // skinLabel2
            // 
            this.skinLabel2.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold);
            this.skinLabel2.ForeColor = System.Drawing.Color.White;
            this.skinLabel2.Location = new System.Drawing.Point(257, 45);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(24, 18);
            this.skinLabel2.TabIndex = 2;
            this.skinLabel2.Text = "dB";
            // 
            // errorShow
            // 
            this.errorShow.BlinkRate = 0;
            this.errorShow.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorShow.ContainerControl = this;
            this.errorShow.RightToLeft = true;
            // 
            // txtArbitraryWave
            // 
            this.txtArbitraryWave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.txtArbitraryWave.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorShow.SetError(this.txtArbitraryWave, "输入值应该大于0");
            this.txtArbitraryWave.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtArbitraryWave.ForeColor = System.Drawing.Color.White;
            this.txtArbitraryWave.Location = new System.Drawing.Point(118, 45);
            this.txtArbitraryWave.Name = "txtArbitraryWave";
            this.txtArbitraryWave.Size = new System.Drawing.Size(133, 18);
            this.txtArbitraryWave.TabIndex = 5;
            this.txtArbitraryWave.TextChanged += new System.EventHandler(this.txtArbitraryWave_TextChanged);
            this.txtArbitraryWave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInputUFloat_KeyPress);
            // 
            // btnDetermine
            // 
            this.btnDetermine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnDetermine.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnDetermine.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnDetermine.DownBack = null;
            this.btnDetermine.DownBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDetermine.Enabled = false;
            this.btnDetermine.FadeGlow = false;
            this.btnDetermine.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnDetermine.ForeColor = System.Drawing.Color.White;
            this.btnDetermine.IsDrawBorder = false;
            this.btnDetermine.IsDrawGlass = false;
            this.btnDetermine.Location = new System.Drawing.Point(46, 98);
            this.btnDetermine.MouseBack = null;
            this.btnDetermine.MouseBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnDetermine.Name = "btnDetermine";
            this.btnDetermine.NormlBack = null;
            this.btnDetermine.Size = new System.Drawing.Size(75, 28);
            this.btnDetermine.TabIndex = 3;
            this.btnDetermine.Text = "确定";
            this.btnDetermine.UseVisualStyleBackColor = false;
            this.btnDetermine.Click += new System.EventHandler(this.btnDetermine_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnCancel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnCancel.DownBack = null;
            this.btnCancel.DownBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCancel.FadeGlow = false;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnCancel.IsDrawBorder = false;
            this.btnCancel.IsDrawGlass = false;
            this.btnCancel.Location = new System.Drawing.Point(182, 98);
            this.btnCancel.MouseBack = null;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormlBack = null;
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // LossBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(306, 138);
            this.ControlBox = false;
            this.Controls.Add(this.txtArbitraryWave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDetermine);
            this.Controls.Add(this.skinLabel2);
            this.Controls.Add(this.skinLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LossBox";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.LossBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private System.Windows.Forms.ErrorProvider errorShow;
        private CCWin.SkinControl.SkinButton btnCancel;
        private CCWin.SkinControl.SkinButton btnDetermine;
        private System.Windows.Forms.TextBox txtArbitraryWave;
    }
}