namespace ChanSimSource
{
    partial class GroundParaBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroundParaBox));
            this.btnCnl = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtAeroAngSp = new System.Windows.Forms.TextBox();
            this.lalAeroAngSp = new System.Windows.Forms.Label();
            this.lalAeroAngSpUnit = new System.Windows.Forms.Label();
            this.txtAeroConductivity = new System.Windows.Forms.TextBox();
            this.lalAeroConductivity = new System.Windows.Forms.Label();
            this.txtAeroDielectric = new System.Windows.Forms.TextBox();
            this.lalAeroDielectric = new System.Windows.Forms.Label();
            this.errorShow = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorShow)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCnl
            // 
            this.btnCnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnCnl.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCnl.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCnl.Location = new System.Drawing.Point(195, 195);
            this.btnCnl.Name = "btnCnl";
            this.btnCnl.Size = new System.Drawing.Size(75, 32);
            this.btnCnl.TabIndex = 87;
            this.btnCnl.Text = "取消";
            this.btnCnl.UseVisualStyleBackColor = false;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Enabled = false;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOk.Location = new System.Drawing.Point(44, 195);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 32);
            this.btnOk.TabIndex = 86;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            // 
            // txtAeroAngSp
            // 
            this.txtAeroAngSp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.txtAeroAngSp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAeroAngSp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtAeroAngSp.ForeColor = System.Drawing.Color.White;
            this.txtAeroAngSp.Location = new System.Drawing.Point(120, 129);
            this.txtAeroAngSp.Name = "txtAeroAngSp";
            this.txtAeroAngSp.Size = new System.Drawing.Size(134, 17);
            this.txtAeroAngSp.TabIndex = 82;
            this.txtAeroAngSp.Text = "1";
            this.txtAeroAngSp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAeroAngSp.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtAeroAngSp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInputUFloat_KeyPress);
            // 
            // lalAeroAngSp
            // 
            this.lalAeroAngSp.AutoSize = true;
            this.lalAeroAngSp.BackColor = System.Drawing.Color.Transparent;
            this.lalAeroAngSp.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lalAeroAngSp.ForeColor = System.Drawing.Color.White;
            this.lalAeroAngSp.Location = new System.Drawing.Point(14, 129);
            this.lalAeroAngSp.Name = "lalAeroAngSp";
            this.lalAeroAngSp.Size = new System.Drawing.Size(69, 20);
            this.lalAeroAngSp.TabIndex = 84;
            this.lalAeroAngSp.Text = "角度扩展";
            // 
            // lalAeroAngSpUnit
            // 
            this.lalAeroAngSpUnit.AutoSize = true;
            this.lalAeroAngSpUnit.BackColor = System.Drawing.Color.Transparent;
            this.lalAeroAngSpUnit.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lalAeroAngSpUnit.ForeColor = System.Drawing.Color.White;
            this.lalAeroAngSpUnit.Location = new System.Drawing.Point(253, 127);
            this.lalAeroAngSpUnit.Name = "lalAeroAngSpUnit";
            this.lalAeroAngSpUnit.Size = new System.Drawing.Size(38, 20);
            this.lalAeroAngSpUnit.TabIndex = 85;
            this.lalAeroAngSpUnit.Text = "deg";
            // 
            // txtAeroConductivity
            // 
            this.txtAeroConductivity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.txtAeroConductivity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAeroConductivity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtAeroConductivity.ForeColor = System.Drawing.Color.White;
            this.txtAeroConductivity.Location = new System.Drawing.Point(120, 86);
            this.txtAeroConductivity.Name = "txtAeroConductivity";
            this.txtAeroConductivity.Size = new System.Drawing.Size(165, 17);
            this.txtAeroConductivity.TabIndex = 81;
            this.txtAeroConductivity.Text = "0.08";
            this.txtAeroConductivity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAeroConductivity.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtAeroConductivity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInputUFloat_KeyPress);
            // 
            // lalAeroConductivity
            // 
            this.lalAeroConductivity.AutoSize = true;
            this.lalAeroConductivity.BackColor = System.Drawing.Color.Transparent;
            this.lalAeroConductivity.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lalAeroConductivity.ForeColor = System.Drawing.Color.White;
            this.lalAeroConductivity.Location = new System.Drawing.Point(14, 86);
            this.lalAeroConductivity.Name = "lalAeroConductivity";
            this.lalAeroConductivity.Size = new System.Drawing.Size(54, 20);
            this.lalAeroConductivity.TabIndex = 83;
            this.lalAeroConductivity.Text = "电导率";
            // 
            // txtAeroDielectric
            // 
            this.txtAeroDielectric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.txtAeroDielectric.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAeroDielectric.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtAeroDielectric.ForeColor = System.Drawing.Color.White;
            this.txtAeroDielectric.Location = new System.Drawing.Point(120, 40);
            this.txtAeroDielectric.Name = "txtAeroDielectric";
            this.txtAeroDielectric.Size = new System.Drawing.Size(166, 17);
            this.txtAeroDielectric.TabIndex = 79;
            this.txtAeroDielectric.Text = "15";
            this.txtAeroDielectric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAeroDielectric.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtAeroDielectric.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInputUFloat_KeyPress);
            // 
            // lalAeroDielectric
            // 
            this.lalAeroDielectric.AutoSize = true;
            this.lalAeroDielectric.BackColor = System.Drawing.Color.Transparent;
            this.lalAeroDielectric.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lalAeroDielectric.ForeColor = System.Drawing.Color.White;
            this.lalAeroDielectric.Location = new System.Drawing.Point(14, 38);
            this.lalAeroDielectric.Name = "lalAeroDielectric";
            this.lalAeroDielectric.Size = new System.Drawing.Size(69, 20);
            this.lalAeroDielectric.TabIndex = 80;
            this.lalAeroDielectric.Text = "介电常数";
            // 
            // errorShow
            // 
            this.errorShow.BlinkRate = 0;
            this.errorShow.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorShow.ContainerControl = this;
            this.errorShow.RightToLeft = true;
            // 
            // GroundParaBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(306, 244);
            this.Controls.Add(this.btnCnl);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtAeroAngSp);
            this.Controls.Add(this.lalAeroAngSp);
            this.Controls.Add(this.lalAeroAngSpUnit);
            this.Controls.Add(this.txtAeroConductivity);
            this.Controls.Add(this.lalAeroConductivity);
            this.Controls.Add(this.txtAeroDielectric);
            this.Controls.Add(this.lalAeroDielectric);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GroundParaBox";
            this.Text = "GroundParaBox";
            ((System.ComponentModel.ISupportInitialize)(this.errorShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCnl;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtAeroAngSp;
        private System.Windows.Forms.Label lalAeroAngSp;
        private System.Windows.Forms.Label lalAeroAngSpUnit;
        private System.Windows.Forms.TextBox txtAeroConductivity;
        private System.Windows.Forms.Label lalAeroConductivity;
        private System.Windows.Forms.TextBox txtAeroDielectric;
        private System.Windows.Forms.Label lalAeroDielectric;
        private System.Windows.Forms.ErrorProvider errorShow;
    }
}