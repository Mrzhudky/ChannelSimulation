namespace ChanSimSource
{
    partial class ConfigBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigBox));
            this.txtArbitraryWave = new System.Windows.Forms.TextBox();
            this.btnCancel = new CCWin.SkinControl.SkinButton();
            this.btnCfgOk = new CCWin.SkinControl.SkinButton();
            this.btnAeroTrace = new CCWin.SkinControl.SkinButton();
            this.lalGeneSNR = new System.Windows.Forms.Label();
            this.errorShow = new System.Windows.Forms.ErrorProvider(this.components);
            this.TipShow = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorShow)).BeginInit();
            this.SuspendLayout();
            // 
            // txtArbitraryWave
            // 
            this.txtArbitraryWave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.txtArbitraryWave.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtArbitraryWave.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtArbitraryWave.ForeColor = System.Drawing.Color.White;
            this.txtArbitraryWave.Location = new System.Drawing.Point(44, 68);
            this.txtArbitraryWave.Name = "txtArbitraryWave";
            this.txtArbitraryWave.Size = new System.Drawing.Size(383, 18);
            this.txtArbitraryWave.TabIndex = 8;
            this.txtArbitraryWave.TextChanged += new System.EventHandler(this.txtFileExist_TextChanged);
            this.txtArbitraryWave.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtChanCfg_DragDrop);
            this.txtArbitraryWave.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtChanCfg_DragEnter);
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
            this.btnCancel.Location = new System.Drawing.Point(386, 110);
            this.btnCancel.MouseBack = null;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormlBack = null;
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCfgOk
            // 
            this.btnCfgOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnCfgOk.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnCfgOk.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnCfgOk.DownBack = null;
            this.btnCfgOk.DownBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCfgOk.Enabled = false;
            this.btnCfgOk.FadeGlow = false;
            this.btnCfgOk.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnCfgOk.ForeColor = System.Drawing.Color.White;
            this.btnCfgOk.IsDrawBorder = false;
            this.btnCfgOk.IsDrawGlass = false;
            this.btnCfgOk.Location = new System.Drawing.Point(287, 110);
            this.btnCfgOk.MouseBack = null;
            this.btnCfgOk.MouseBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnCfgOk.Name = "btnCfgOk";
            this.btnCfgOk.NormlBack = null;
            this.btnCfgOk.Size = new System.Drawing.Size(75, 28);
            this.btnCfgOk.TabIndex = 6;
            this.btnCfgOk.Text = "确定";
            this.btnCfgOk.UseVisualStyleBackColor = false;
            this.btnCfgOk.Click += new System.EventHandler(this.btnCfgOk_Click);
            // 
            // btnAeroTrace
            // 
            this.btnAeroTrace.BackColor = System.Drawing.Color.Transparent;
            this.btnAeroTrace.BaseColor = System.Drawing.Color.Transparent;
            this.btnAeroTrace.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnAeroTrace.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnAeroTrace.DownBack = null;
            this.btnAeroTrace.DownBaseColor = System.Drawing.Color.Transparent;
            this.btnAeroTrace.FadeGlow = false;
            this.btnAeroTrace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAeroTrace.GlowColor = System.Drawing.Color.Transparent;
            this.btnAeroTrace.InnerBorderColor = System.Drawing.Color.Transparent;
            this.btnAeroTrace.IsDrawGlass = false;
            this.btnAeroTrace.Location = new System.Drawing.Point(427, 58);
            this.btnAeroTrace.MouseBack = null;
            this.btnAeroTrace.MouseBaseColor = System.Drawing.Color.Transparent;
            this.btnAeroTrace.Name = "btnAeroTrace";
            this.btnAeroTrace.NormlBack = null;
            this.btnAeroTrace.Radius = 4;
            this.btnAeroTrace.Size = new System.Drawing.Size(37, 36);
            this.btnAeroTrace.TabIndex = 138;
            this.btnAeroTrace.Text = "...";
            this.btnAeroTrace.UseVisualStyleBackColor = false;
            this.btnAeroTrace.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // lalGeneSNR
            // 
            this.lalGeneSNR.AutoSize = true;
            this.lalGeneSNR.BackColor = System.Drawing.Color.Transparent;
            this.lalGeneSNR.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lalGeneSNR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.lalGeneSNR.Location = new System.Drawing.Point(12, 20);
            this.lalGeneSNR.Name = "lalGeneSNR";
            this.lalGeneSNR.Size = new System.Drawing.Size(126, 25);
            this.lalGeneSNR.TabIndex = 139;
            this.lalGeneSNR.Text = "任意波文件：";
            // 
            // errorShow
            // 
            this.errorShow.BlinkRate = 0;
            this.errorShow.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorShow.ContainerControl = this;
            this.errorShow.RightToLeft = true;
            // 
            // TipShow
            // 
            this.TipShow.ShowAlways = true;
            // 
            // ConfigBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(501, 159);
            this.Controls.Add(this.lalGeneSNR);
            this.Controls.Add(this.btnAeroTrace);
            this.Controls.Add(this.txtArbitraryWave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCfgOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConfigBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.errorShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtArbitraryWave;
        private CCWin.SkinControl.SkinButton btnCancel;
        private CCWin.SkinControl.SkinButton btnCfgOk;
        private CCWin.SkinControl.SkinButton btnAeroTrace;
        private System.Windows.Forms.Label lalGeneSNR;
        private System.Windows.Forms.ErrorProvider errorShow;
        private System.Windows.Forms.ToolTip TipShow;
    }
}