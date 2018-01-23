namespace ChanSimSource
{
    partial class RiceBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RiceBox));
            this.btnGeneCnl = new System.Windows.Forms.Button();
            this.btnGeneOk = new System.Windows.Forms.Button();
            this.lalGeneRiceAOAUnit = new System.Windows.Forms.Label();
            this.lalGeneRiceKUnit = new System.Windows.Forms.Label();
            this.txtGeneRiceAOA = new System.Windows.Forms.TextBox();
            this.txtGeneRiceK = new System.Windows.Forms.TextBox();
            this.lalGeneRiceAOA = new System.Windows.Forms.Label();
            this.lalGeneRiceK = new System.Windows.Forms.Label();
            this.errorShow = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorShow)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGeneCnl
            // 
            this.btnGeneCnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnGeneCnl.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnGeneCnl.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGeneCnl.ForeColor = System.Drawing.Color.White;
            this.btnGeneCnl.Location = new System.Drawing.Point(190, 151);
            this.btnGeneCnl.Name = "btnGeneCnl";
            this.btnGeneCnl.Size = new System.Drawing.Size(75, 32);
            this.btnGeneCnl.TabIndex = 18;
            this.btnGeneCnl.Text = "取消";
            this.btnGeneCnl.UseVisualStyleBackColor = false;
            // 
            // btnGeneOk
            // 
            this.btnGeneOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnGeneOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGeneOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGeneOk.ForeColor = System.Drawing.Color.White;
            this.btnGeneOk.Location = new System.Drawing.Point(54, 151);
            this.btnGeneOk.Name = "btnGeneOk";
            this.btnGeneOk.Size = new System.Drawing.Size(75, 32);
            this.btnGeneOk.TabIndex = 17;
            this.btnGeneOk.Text = "确定";
            this.btnGeneOk.UseVisualStyleBackColor = false;
            // 
            // lalGeneRiceAOAUnit
            // 
            this.lalGeneRiceAOAUnit.AutoSize = true;
            this.lalGeneRiceAOAUnit.BackColor = System.Drawing.Color.Transparent;
            this.lalGeneRiceAOAUnit.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lalGeneRiceAOAUnit.ForeColor = System.Drawing.Color.White;
            this.lalGeneRiceAOAUnit.Location = new System.Drawing.Point(253, 85);
            this.lalGeneRiceAOAUnit.Name = "lalGeneRiceAOAUnit";
            this.lalGeneRiceAOAUnit.Size = new System.Drawing.Size(38, 20);
            this.lalGeneRiceAOAUnit.TabIndex = 16;
            this.lalGeneRiceAOAUnit.Text = "deg";
            // 
            // lalGeneRiceKUnit
            // 
            this.lalGeneRiceKUnit.AutoSize = true;
            this.lalGeneRiceKUnit.BackColor = System.Drawing.Color.Transparent;
            this.lalGeneRiceKUnit.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lalGeneRiceKUnit.ForeColor = System.Drawing.Color.White;
            this.lalGeneRiceKUnit.Location = new System.Drawing.Point(257, 36);
            this.lalGeneRiceKUnit.Name = "lalGeneRiceKUnit";
            this.lalGeneRiceKUnit.Size = new System.Drawing.Size(28, 20);
            this.lalGeneRiceKUnit.TabIndex = 15;
            this.lalGeneRiceKUnit.Text = "dB";
            // 
            // txtGeneRiceAOA
            // 
            this.txtGeneRiceAOA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.txtGeneRiceAOA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGeneRiceAOA.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtGeneRiceAOA.Location = new System.Drawing.Point(117, 88);
            this.txtGeneRiceAOA.Name = "txtGeneRiceAOA";
            this.txtGeneRiceAOA.Size = new System.Drawing.Size(136, 18);
            this.txtGeneRiceAOA.TabIndex = 14;
            this.txtGeneRiceAOA.Text = "1";
            this.txtGeneRiceAOA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGeneRiceAOA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxKeyPress);
            // 
            // txtGeneRiceK
            // 
            this.txtGeneRiceK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.txtGeneRiceK.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGeneRiceK.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtGeneRiceK.Location = new System.Drawing.Point(117, 38);
            this.txtGeneRiceK.Name = "txtGeneRiceK";
            this.txtGeneRiceK.Size = new System.Drawing.Size(134, 18);
            this.txtGeneRiceK.TabIndex = 13;
            this.txtGeneRiceK.Text = "5";
            this.txtGeneRiceK.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGeneRiceK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxKeyPress);
            // 
            // lalGeneRiceAOA
            // 
            this.lalGeneRiceAOA.AutoSize = true;
            this.lalGeneRiceAOA.BackColor = System.Drawing.Color.Transparent;
            this.lalGeneRiceAOA.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lalGeneRiceAOA.ForeColor = System.Drawing.Color.White;
            this.lalGeneRiceAOA.Location = new System.Drawing.Point(9, 85);
            this.lalGeneRiceAOA.Name = "lalGeneRiceAOA";
            this.lalGeneRiceAOA.Size = new System.Drawing.Size(99, 20);
            this.lalGeneRiceAOA.TabIndex = 12;
            this.lalGeneRiceAOA.Text = "直射径入射角";
            // 
            // lalGeneRiceK
            // 
            this.lalGeneRiceK.AutoSize = true;
            this.lalGeneRiceK.BackColor = System.Drawing.Color.Transparent;
            this.lalGeneRiceK.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lalGeneRiceK.ForeColor = System.Drawing.Color.White;
            this.lalGeneRiceK.Location = new System.Drawing.Point(9, 36);
            this.lalGeneRiceK.Name = "lalGeneRiceK";
            this.lalGeneRiceK.Size = new System.Drawing.Size(62, 20);
            this.lalGeneRiceK.TabIndex = 11;
            this.lalGeneRiceK.Text = "功率比k";
            // 
            // errorShow
            // 
            this.errorShow.BlinkRate = 0;
            this.errorShow.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorShow.ContainerControl = this;
            this.errorShow.RightToLeft = true;
            // 
            // RiceBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(302, 196);
            this.Controls.Add(this.btnGeneCnl);
            this.Controls.Add(this.btnGeneOk);
            this.Controls.Add(this.lalGeneRiceAOAUnit);
            this.Controls.Add(this.lalGeneRiceKUnit);
            this.Controls.Add(this.txtGeneRiceAOA);
            this.Controls.Add(this.txtGeneRiceK);
            this.Controls.Add(this.lalGeneRiceAOA);
            this.Controls.Add(this.lalGeneRiceK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RiceBox";
            this.Text = "RiceBox";
            ((System.ComponentModel.ISupportInitialize)(this.errorShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGeneCnl;
        private System.Windows.Forms.Button btnGeneOk;
        private System.Windows.Forms.Label lalGeneRiceAOAUnit;
        private System.Windows.Forms.Label lalGeneRiceKUnit;
        private System.Windows.Forms.TextBox txtGeneRiceAOA;
        private System.Windows.Forms.TextBox txtGeneRiceK;
        private System.Windows.Forms.Label lalGeneRiceAOA;
        private System.Windows.Forms.Label lalGeneRiceK;
        private System.Windows.Forms.ErrorProvider errorShow;
    }
}