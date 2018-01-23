namespace ChanSimSource
{
    partial class ArbitraryWave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArbitraryWave));
            this.cboSignalType = new CCWin.SkinControl.SkinComboBox();
            this.cboxShapingFilter = new CCWin.SkinControl.SkinComboBox();
            this.txtSignFre = new System.Windows.Forms.TextBox();
            this.txtSymbolRate = new System.Windows.Forms.TextBox();
            this.txtPulseWidth = new System.Windows.Forms.TextBox();
            this.txtDutyCycle = new System.Windows.Forms.TextBox();
            this.txtModuDepth = new System.Windows.Forms.TextBox();
            this.lalAeroUpdateUnit = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboFreUnit = new CCWin.SkinControl.SkinComboBox();
            this.cboxRateUnit = new CCWin.SkinControl.SkinComboBox();
            this.cboModuType = new CCWin.SkinControl.SkinComboBox();
            this.errorShow = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnCancel = new CCWin.SkinControl.SkinButton();
            this.btnDetermine = new CCWin.SkinControl.SkinButton();
            this.bgwDmaTransfer = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.errorShow)).BeginInit();
            this.SuspendLayout();
            // 
            // cboSignalType
            // 
            this.cboSignalType.ArrowColor = System.Drawing.Color.White;
            this.cboSignalType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboSignalType.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboSignalType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboSignalType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSignalType.DropBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboSignalType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSignalType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboSignalType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.cboSignalType.ForeColor = System.Drawing.Color.White;
            this.cboSignalType.FormattingEnabled = true;
            this.cboSignalType.Items.AddRange(new object[] {
            "正弦波",
            "脉冲信号",
            "方波",
            "锯齿波",
            "三角波",
            "PSK调制信号",
            "QAM调制信号",
            "2ASK",
            "自定义"});
            this.cboSignalType.Location = new System.Drawing.Point(568, 125);
            this.cboSignalType.Name = "cboSignalType";
            this.cboSignalType.Size = new System.Drawing.Size(253, 25);
            this.cboSignalType.TabIndex = 135;
            this.cboSignalType.WaterColor = System.Drawing.Color.Transparent;
            this.cboSignalType.WaterText = "";
            this.cboSignalType.SelectedIndexChanged += new System.EventHandler(this.cboAeroPolar_SelectedIndexChanged);
            // 
            // cboxShapingFilter
            // 
            this.cboxShapingFilter.ArrowColor = System.Drawing.Color.White;
            this.cboxShapingFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxShapingFilter.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxShapingFilter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxShapingFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboxShapingFilter.DropBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxShapingFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxShapingFilter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboxShapingFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.cboxShapingFilter.ForeColor = System.Drawing.Color.White;
            this.cboxShapingFilter.FormattingEnabled = true;
            this.cboxShapingFilter.Items.AddRange(new object[] {
            "升余弦",
            "根升余弦"});
            this.cboxShapingFilter.Location = new System.Drawing.Point(568, 417);
            this.cboxShapingFilter.Name = "cboxShapingFilter";
            this.cboxShapingFilter.Size = new System.Drawing.Size(253, 25);
            this.cboxShapingFilter.TabIndex = 136;
            this.cboxShapingFilter.WaterColor = System.Drawing.Color.Transparent;
            this.cboxShapingFilter.WaterText = "";
            // 
            // txtSignFre
            // 
            this.txtSignFre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.txtSignFre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSignFre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtSignFre.ForeColor = System.Drawing.Color.White;
            this.txtSignFre.Location = new System.Drawing.Point(568, 212);
            this.txtSignFre.Name = "txtSignFre";
            this.txtSignFre.Size = new System.Drawing.Size(211, 17);
            this.txtSignFre.TabIndex = 137;
            this.txtSignFre.Text = "0";
            this.txtSignFre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSignFre.TextChanged += new System.EventHandler(this.txtSignFre_TextChanged);
            this.txtSignFre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInputUFloat_KeyPress);
            // 
            // txtSymbolRate
            // 
            this.txtSymbolRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.txtSymbolRate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSymbolRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtSymbolRate.ForeColor = System.Drawing.Color.White;
            this.txtSymbolRate.Location = new System.Drawing.Point(568, 255);
            this.txtSymbolRate.Name = "txtSymbolRate";
            this.txtSymbolRate.Size = new System.Drawing.Size(211, 17);
            this.txtSymbolRate.TabIndex = 138;
            this.txtSymbolRate.Text = "0";
            this.txtSymbolRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSymbolRate.TextChanged += new System.EventHandler(this.txtSignFre_TextChanged);
            this.txtSymbolRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInputUFloat_KeyPress);
            // 
            // txtPulseWidth
            // 
            this.txtPulseWidth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.txtPulseWidth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPulseWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtPulseWidth.ForeColor = System.Drawing.Color.White;
            this.txtPulseWidth.Location = new System.Drawing.Point(568, 295);
            this.txtPulseWidth.Name = "txtPulseWidth";
            this.txtPulseWidth.Size = new System.Drawing.Size(211, 17);
            this.txtPulseWidth.TabIndex = 139;
            this.txtPulseWidth.Text = "0";
            this.txtPulseWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPulseWidth.TextChanged += new System.EventHandler(this.txtSignFre_TextChanged);
            this.txtPulseWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInputUInt_KeyPress);
            // 
            // txtDutyCycle
            // 
            this.txtDutyCycle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.txtDutyCycle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDutyCycle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtDutyCycle.ForeColor = System.Drawing.Color.White;
            this.txtDutyCycle.Location = new System.Drawing.Point(568, 338);
            this.txtDutyCycle.Name = "txtDutyCycle";
            this.txtDutyCycle.Size = new System.Drawing.Size(211, 17);
            this.txtDutyCycle.TabIndex = 140;
            this.txtDutyCycle.Text = "0";
            this.txtDutyCycle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDutyCycle.TextChanged += new System.EventHandler(this.txtSignFre_TextChanged);
            this.txtDutyCycle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInputUInt_KeyPress);
            // 
            // txtModuDepth
            // 
            this.txtModuDepth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.txtModuDepth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtModuDepth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtModuDepth.ForeColor = System.Drawing.Color.White;
            this.txtModuDepth.Location = new System.Drawing.Point(568, 380);
            this.txtModuDepth.Name = "txtModuDepth";
            this.txtModuDepth.Size = new System.Drawing.Size(211, 17);
            this.txtModuDepth.TabIndex = 141;
            this.txtModuDepth.Text = "0";
            this.txtModuDepth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtModuDepth.TextChanged += new System.EventHandler(this.txtSignFre_TextChanged);
            this.txtModuDepth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInputUFloat_KeyPress);
            // 
            // lalAeroUpdateUnit
            // 
            this.lalAeroUpdateUnit.AutoSize = true;
            this.lalAeroUpdateUnit.BackColor = System.Drawing.Color.Transparent;
            this.lalAeroUpdateUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.lalAeroUpdateUnit.ForeColor = System.Drawing.Color.White;
            this.lalAeroUpdateUnit.Location = new System.Drawing.Point(790, 295);
            this.lalAeroUpdateUnit.Name = "lalAeroUpdateUnit";
            this.lalAeroUpdateUnit.Size = new System.Drawing.Size(22, 18);
            this.lalAeroUpdateUnit.TabIndex = 142;
            this.lalAeroUpdateUnit.Text = "%";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(790, 335);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 18);
            this.label1.TabIndex = 143;
            this.label1.Text = "%";
            // 
            // cboFreUnit
            // 
            this.cboFreUnit.ArrowColor = System.Drawing.Color.White;
            this.cboFreUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboFreUnit.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboFreUnit.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboFreUnit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboFreUnit.DropBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboFreUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFreUnit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboFreUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFreUnit.ForeColor = System.Drawing.Color.White;
            this.cboFreUnit.FormattingEnabled = true;
            this.cboFreUnit.Items.AddRange(new object[] {
            "MHz",
            "kHz",
            "Hz"});
            this.cboFreUnit.Location = new System.Drawing.Point(756, 208);
            this.cboFreUnit.Name = "cboFreUnit";
            this.cboFreUnit.Size = new System.Drawing.Size(65, 22);
            this.cboFreUnit.TabIndex = 144;
            this.cboFreUnit.WaterColor = System.Drawing.Color.Transparent;
            this.cboFreUnit.WaterText = "";
            // 
            // cboxRateUnit
            // 
            this.cboxRateUnit.ArrowColor = System.Drawing.Color.White;
            this.cboxRateUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxRateUnit.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxRateUnit.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxRateUnit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboxRateUnit.DropBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxRateUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxRateUnit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboxRateUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxRateUnit.ForeColor = System.Drawing.Color.White;
            this.cboxRateUnit.FormattingEnabled = true;
            this.cboxRateUnit.Items.AddRange(new object[] {
            "MBaud",
            "kBaud",
            "Baud"});
            this.cboxRateUnit.Location = new System.Drawing.Point(756, 251);
            this.cboxRateUnit.Name = "cboxRateUnit";
            this.cboxRateUnit.Size = new System.Drawing.Size(65, 22);
            this.cboxRateUnit.TabIndex = 145;
            this.cboxRateUnit.WaterColor = System.Drawing.Color.Transparent;
            this.cboxRateUnit.WaterText = "";
            // 
            // cboModuType
            // 
            this.cboModuType.ArrowColor = System.Drawing.Color.White;
            this.cboModuType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboModuType.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboModuType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboModuType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboModuType.DropBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboModuType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModuType.Enabled = false;
            this.cboModuType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboModuType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.cboModuType.ForeColor = System.Drawing.Color.White;
            this.cboModuType.FormattingEnabled = true;
            this.cboModuType.Items.AddRange(new object[] {
            "BPSK",
            "QPSK",
            "8PSK",
            "16PSK",
            "32PSK",
            "QAM",
            "16QAM",
            "32QAM",
            "64QAM",
            "128QAM",
            "256QAM"});
            this.cboModuType.Location = new System.Drawing.Point(568, 167);
            this.cboModuType.Name = "cboModuType";
            this.cboModuType.Size = new System.Drawing.Size(253, 25);
            this.cboModuType.TabIndex = 146;
            this.cboModuType.WaterColor = System.Drawing.Color.Transparent;
            this.cboModuType.WaterText = "";
            this.cboModuType.SelectedIndexChanged += new System.EventHandler(this.cboModuType_SelectedIndexChanged);
            // 
            // errorShow
            // 
            this.errorShow.BlinkRate = 0;
            this.errorShow.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorShow.ContainerControl = this;
            this.errorShow.RightToLeft = true;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnCancel.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnCancel.BorderColor = System.Drawing.Color.Transparent;
            this.btnCancel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DownBack = null;
            this.btnCancel.DownBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCancel.FadeGlow = false;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.GlowColor = System.Drawing.Color.Transparent;
            this.btnCancel.InnerBorderColor = System.Drawing.Color.Transparent;
            this.btnCancel.IsDrawBorder = false;
            this.btnCancel.IsDrawGlass = false;
            this.btnCancel.Location = new System.Drawing.Point(812, 64);
            this.btnCancel.MouseBack = null;
            this.btnCancel.MouseBaseColor = System.Drawing.Color.Transparent;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormlBack = null;
            this.btnCancel.Radius = 20;
            this.btnCancel.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnCancel.Size = new System.Drawing.Size(75, 29);
            this.btnCancel.TabIndex = 148;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnDetermine
            // 
            this.btnDetermine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnDetermine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDetermine.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnDetermine.BorderColor = System.Drawing.Color.Transparent;
            this.btnDetermine.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnDetermine.DownBack = null;
            this.btnDetermine.DownBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDetermine.FadeGlow = false;
            this.btnDetermine.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnDetermine.ForeColor = System.Drawing.Color.White;
            this.btnDetermine.GlowColor = System.Drawing.Color.Transparent;
            this.btnDetermine.InnerBorderColor = System.Drawing.Color.Transparent;
            this.btnDetermine.IsDrawBorder = false;
            this.btnDetermine.IsDrawGlass = false;
            this.btnDetermine.Location = new System.Drawing.Point(716, 64);
            this.btnDetermine.MouseBack = null;
            this.btnDetermine.MouseBaseColor = System.Drawing.Color.Transparent;
            this.btnDetermine.Name = "btnDetermine";
            this.btnDetermine.NormlBack = null;
            this.btnDetermine.Size = new System.Drawing.Size(75, 29);
            this.btnDetermine.TabIndex = 147;
            this.btnDetermine.Text = "确定";
            this.btnDetermine.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDetermine.UseVisualStyleBackColor = false;
            // 
            // bgwDmaTransfer
            // 
            this.bgwDmaTransfer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwDmaTransfer_DoWork);
            this.bgwDmaTransfer.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwDmaTransfer_RunWorkerCompleted);
            // 
            // ArbitraryWave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1280, 513);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDetermine);
            this.Controls.Add(this.cboModuType);
            this.Controls.Add(this.cboxRateUnit);
            this.Controls.Add(this.cboFreUnit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lalAeroUpdateUnit);
            this.Controls.Add(this.txtModuDepth);
            this.Controls.Add(this.txtDutyCycle);
            this.Controls.Add(this.txtPulseWidth);
            this.Controls.Add(this.txtSymbolRate);
            this.Controls.Add(this.txtSignFre);
            this.Controls.Add(this.cboxShapingFilter);
            this.Controls.Add(this.cboSignalType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ArbitraryWave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ArbitraryWave";
            this.Load += new System.EventHandler(this.ArbitraryWave_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinComboBox cboSignalType;
        private CCWin.SkinControl.SkinComboBox cboxShapingFilter;
        private System.Windows.Forms.TextBox txtSignFre;
        private System.Windows.Forms.TextBox txtSymbolRate;
        private System.Windows.Forms.TextBox txtPulseWidth;
        private System.Windows.Forms.TextBox txtDutyCycle;
        private System.Windows.Forms.TextBox txtModuDepth;
        private System.Windows.Forms.Label lalAeroUpdateUnit;
        private System.Windows.Forms.Label label1;
        private CCWin.SkinControl.SkinComboBox cboFreUnit;
        private CCWin.SkinControl.SkinComboBox cboxRateUnit;
        private CCWin.SkinControl.SkinComboBox cboModuType;
        private System.Windows.Forms.ErrorProvider errorShow;
        private CCWin.SkinControl.SkinButton btnCancel;
        private CCWin.SkinControl.SkinButton btnDetermine;
        private System.ComponentModel.BackgroundWorker bgwDmaTransfer;

    }
}