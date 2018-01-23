namespace ChanSimSource
{
    partial class DooplerBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DooplerBox));
            this.btnGeneCnl = new System.Windows.Forms.Button();
            this.btnGeneOk = new System.Windows.Forms.Button();
            this.lalGeneDopplerUnit = new System.Windows.Forms.Label();
            this.txtGeneDoppler = new System.Windows.Forms.TextBox();
            this.lalGeneDoppler = new System.Windows.Forms.Label();
            this.errorShow = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorShow)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGeneCnl
            // 
            this.btnGeneCnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnGeneCnl.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnGeneCnl.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGeneCnl.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnGeneCnl.ForeColor = System.Drawing.Color.White;
            this.btnGeneCnl.Location = new System.Drawing.Point(193, 89);
            this.btnGeneCnl.Name = "btnGeneCnl";
            this.btnGeneCnl.Size = new System.Drawing.Size(75, 32);
            this.btnGeneCnl.TabIndex = 20;
            this.btnGeneCnl.Text = "取消";
            this.btnGeneCnl.UseVisualStyleBackColor = false;
            // 
            // btnGeneOk
            // 
            this.btnGeneOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnGeneOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGeneOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGeneOk.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnGeneOk.ForeColor = System.Drawing.Color.White;
            this.btnGeneOk.Location = new System.Drawing.Point(39, 89);
            this.btnGeneOk.Name = "btnGeneOk";
            this.btnGeneOk.Size = new System.Drawing.Size(75, 32);
            this.btnGeneOk.TabIndex = 19;
            this.btnGeneOk.Text = "确定";
            this.btnGeneOk.UseVisualStyleBackColor = false;
            // 
            // lalGeneDopplerUnit
            // 
            this.lalGeneDopplerUnit.AutoSize = true;
            this.lalGeneDopplerUnit.BackColor = System.Drawing.Color.Transparent;
            this.lalGeneDopplerUnit.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.lalGeneDopplerUnit.ForeColor = System.Drawing.Color.White;
            this.lalGeneDopplerUnit.Location = new System.Drawing.Point(264, 44);
            this.lalGeneDopplerUnit.Name = "lalGeneDopplerUnit";
            this.lalGeneDopplerUnit.Size = new System.Drawing.Size(28, 20);
            this.lalGeneDopplerUnit.TabIndex = 18;
            this.lalGeneDopplerUnit.Text = "Hz";
            // 
            // txtGeneDoppler
            // 
            this.txtGeneDoppler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.txtGeneDoppler.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGeneDoppler.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtGeneDoppler.ForeColor = System.Drawing.Color.White;
            this.txtGeneDoppler.Location = new System.Drawing.Point(117, 45);
            this.txtGeneDoppler.Name = "txtGeneDoppler";
            this.txtGeneDoppler.Size = new System.Drawing.Size(146, 17);
            this.txtGeneDoppler.TabIndex = 17;
            this.txtGeneDoppler.Text = "0";
            this.txtGeneDoppler.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGeneDoppler.TextChanged += new System.EventHandler(this.txtInputLimit_TextChanged);
            // 
            // lalGeneDoppler
            // 
            this.lalGeneDoppler.AutoSize = true;
            this.lalGeneDoppler.BackColor = System.Drawing.Color.Transparent;
            this.lalGeneDoppler.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.lalGeneDoppler.ForeColor = System.Drawing.Color.White;
            this.lalGeneDoppler.Location = new System.Drawing.Point(21, 44);
            this.lalGeneDoppler.Name = "lalGeneDoppler";
            this.lalGeneDoppler.Size = new System.Drawing.Size(84, 20);
            this.lalGeneDoppler.TabIndex = 16;
            this.lalGeneDoppler.Text = "多普勒频率";
            // 
            // errorShow
            // 
            this.errorShow.BlinkRate = 0;
            this.errorShow.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorShow.ContainerControl = this;
            this.errorShow.RightToLeft = true;
            // 
            // DooplerBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(306, 141);
            this.ControlBox = false;
            this.Controls.Add(this.btnGeneCnl);
            this.Controls.Add(this.btnGeneOk);
            this.Controls.Add(this.lalGeneDopplerUnit);
            this.Controls.Add(this.txtGeneDoppler);
            this.Controls.Add(this.lalGeneDoppler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DooplerBox";
            this.Text = "DooplerBox";
            ((System.ComponentModel.ISupportInitialize)(this.errorShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGeneCnl;
        private System.Windows.Forms.Button btnGeneOk;
        private System.Windows.Forms.Label lalGeneDopplerUnit;
        private System.Windows.Forms.TextBox txtGeneDoppler;
        private System.Windows.Forms.Label lalGeneDoppler;
        private System.Windows.Forms.ErrorProvider errorShow;
    }
}