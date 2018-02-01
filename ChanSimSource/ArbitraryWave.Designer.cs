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
            this.cboxSignalType = new CCWin.SkinControl.SkinComboBox();
            this.cboxFilterType = new CCWin.SkinControl.SkinComboBox();
            this.tboxSymbolRate = new System.Windows.Forms.TextBox();
            this.tboxDutyCycle = new System.Windows.Forms.TextBox();
            this.tboxFrequency = new System.Windows.Forms.TextBox();
            this.lalAeroUpdateUnit = new System.Windows.Forms.Label();
            this.cboxDataSource = new CCWin.SkinControl.SkinComboBox();
            this.cboxSymbolNum = new CCWin.SkinControl.SkinComboBox();
            this.cboxModuType = new CCWin.SkinControl.SkinComboBox();
            this.errorShow = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnCancel = new CCWin.SkinControl.SkinButton();
            this.btnDetermine = new CCWin.SkinControl.SkinButton();
            this.bgwDmaTransfer = new System.ComponentModel.BackgroundWorker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboxFreUnit = new CCWin.SkinControl.SkinComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorShow)).BeginInit();
            this.SuspendLayout();
            // 
            // cboxSignalType
            // 
            this.cboxSignalType.ArrowColor = System.Drawing.Color.White;
            this.cboxSignalType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxSignalType.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxSignalType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxSignalType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboxSignalType.DropBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxSignalType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSignalType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboxSignalType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.cboxSignalType.ForeColor = System.Drawing.Color.White;
            this.cboxSignalType.FormattingEnabled = true;
            this.cboxSignalType.ItemHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxSignalType.Items.AddRange(new object[] {
            "单音",
            "双音",
            "脉冲",
            "PSK调制信号",
            "QAM调制信号",
            "任意波"});
            this.cboxSignalType.Location = new System.Drawing.Point(541, 125);
            this.cboxSignalType.Name = "cboxSignalType";
            this.cboxSignalType.Size = new System.Drawing.Size(253, 25);
            this.cboxSignalType.TabIndex = 135;
            this.cboxSignalType.WaterColor = System.Drawing.Color.Transparent;
            this.cboxSignalType.WaterText = "";
            this.cboxSignalType.SelectedIndexChanged += new System.EventHandler(this.cboxSignalType_SelectedIndexChanged);
            // 
            // cboxFilterType
            // 
            this.cboxFilterType.ArrowColor = System.Drawing.Color.White;
            this.cboxFilterType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxFilterType.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxFilterType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxFilterType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboxFilterType.DropBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxFilterType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboxFilterType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxFilterType.ForeColor = System.Drawing.Color.White;
            this.cboxFilterType.FormattingEnabled = true;
            this.cboxFilterType.Items.AddRange(new object[] {
            "升余弦",
            "根升余弦"});
            this.cboxFilterType.Location = new System.Drawing.Point(541, 397);
            this.cboxFilterType.Name = "cboxFilterType";
            this.cboxFilterType.Size = new System.Drawing.Size(253, 24);
            this.cboxFilterType.TabIndex = 136;
            this.cboxFilterType.WaterColor = System.Drawing.Color.Transparent;
            this.cboxFilterType.WaterText = "";
            this.cboxFilterType.SelectedIndexChanged += new System.EventHandler(this.cboxFilterType_SelectedIndexChanged);
            // 
            // tboxSymbolRate
            // 
            this.tboxSymbolRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.tboxSymbolRate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tboxSymbolRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxSymbolRate.ForeColor = System.Drawing.Color.White;
            this.tboxSymbolRate.Location = new System.Drawing.Point(541, 359);
            this.tboxSymbolRate.Name = "tboxSymbolRate";
            this.tboxSymbolRate.Size = new System.Drawing.Size(211, 22);
            this.tboxSymbolRate.TabIndex = 138;
            this.tboxSymbolRate.Text = "0";
            this.tboxSymbolRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tboxSymbolRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxIntegerNum_KeyPress);
            // 
            // tboxDutyCycle
            // 
            this.tboxDutyCycle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.tboxDutyCycle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tboxDutyCycle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxDutyCycle.ForeColor = System.Drawing.Color.White;
            this.tboxDutyCycle.Location = new System.Drawing.Point(541, 283);
            this.tboxDutyCycle.Name = "tboxDutyCycle";
            this.tboxDutyCycle.Size = new System.Drawing.Size(211, 22);
            this.tboxDutyCycle.TabIndex = 139;
            this.tboxDutyCycle.Text = "0";
            this.tboxDutyCycle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tboxDutyCycle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxPositiveNum_KeyPress);
            // 
            // tboxFrequency
            // 
            this.tboxFrequency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.tboxFrequency.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tboxFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxFrequency.ForeColor = System.Drawing.Color.White;
            this.tboxFrequency.Location = new System.Drawing.Point(541, 321);
            this.tboxFrequency.Name = "tboxFrequency";
            this.tboxFrequency.Size = new System.Drawing.Size(211, 22);
            this.tboxFrequency.TabIndex = 140;
            this.tboxFrequency.Text = "0";
            this.tboxFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tboxFrequency.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxPositiveNum_KeyPress);
            // 
            // lalAeroUpdateUnit
            // 
            this.lalAeroUpdateUnit.AutoSize = true;
            this.lalAeroUpdateUnit.BackColor = System.Drawing.Color.Transparent;
            this.lalAeroUpdateUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.lalAeroUpdateUnit.ForeColor = System.Drawing.Color.White;
            this.lalAeroUpdateUnit.Location = new System.Drawing.Point(763, 287);
            this.lalAeroUpdateUnit.Name = "lalAeroUpdateUnit";
            this.lalAeroUpdateUnit.Size = new System.Drawing.Size(22, 18);
            this.lalAeroUpdateUnit.TabIndex = 142;
            this.lalAeroUpdateUnit.Text = "%";
            // 
            // cboxDataSource
            // 
            this.cboxDataSource.ArrowColor = System.Drawing.Color.White;
            this.cboxDataSource.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxDataSource.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxDataSource.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxDataSource.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboxDataSource.DropBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxDataSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxDataSource.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboxDataSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxDataSource.ForeColor = System.Drawing.Color.White;
            this.cboxDataSource.FormattingEnabled = true;
            this.cboxDataSource.Items.AddRange(new object[] {
            "PN9",
            "PN11",
            "PN15",
            "PN16",
            "PN20",
            "PN21",
            "PN23",
            "PN167"});
            this.cboxDataSource.Location = new System.Drawing.Point(541, 207);
            this.cboxDataSource.Name = "cboxDataSource";
            this.cboxDataSource.Size = new System.Drawing.Size(253, 22);
            this.cboxDataSource.TabIndex = 144;
            this.cboxDataSource.WaterColor = System.Drawing.Color.Transparent;
            this.cboxDataSource.WaterText = "";
            this.cboxDataSource.SelectedIndexChanged += new System.EventHandler(this.cboxDataSource_SelectedIndexChanged);
            // 
            // cboxSymbolNum
            // 
            this.cboxSymbolNum.ArrowColor = System.Drawing.Color.White;
            this.cboxSymbolNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxSymbolNum.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxSymbolNum.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxSymbolNum.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboxSymbolNum.DropBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxSymbolNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSymbolNum.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboxSymbolNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxSymbolNum.ForeColor = System.Drawing.Color.White;
            this.cboxSymbolNum.FormattingEnabled = true;
            this.cboxSymbolNum.Items.AddRange(new object[] {
            "0 个码",
            "1 个码",
            "2 个码",
            "3 个码",
            "4 个码",
            "5 个码",
            "6 个码",
            "7 个码",
            "8 个码",
            "9 个码",
            "10 个码"});
            this.cboxSymbolNum.Location = new System.Drawing.Point(541, 245);
            this.cboxSymbolNum.Name = "cboxSymbolNum";
            this.cboxSymbolNum.Size = new System.Drawing.Size(253, 22);
            this.cboxSymbolNum.TabIndex = 145;
            this.cboxSymbolNum.WaterColor = System.Drawing.Color.Transparent;
            this.cboxSymbolNum.WaterText = "";
            this.cboxSymbolNum.SelectedIndexChanged += new System.EventHandler(this.cboxSymbolNum_SelectedIndexChanged);
            // 
            // cboxModuType
            // 
            this.cboxModuType.ArrowColor = System.Drawing.Color.White;
            this.cboxModuType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxModuType.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxModuType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxModuType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboxModuType.DropBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxModuType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxModuType.Enabled = false;
            this.cboxModuType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboxModuType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.cboxModuType.ForeColor = System.Drawing.Color.White;
            this.cboxModuType.FormattingEnabled = true;
            this.cboxModuType.ItemHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxModuType.Items.AddRange(new object[] {
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
            this.cboxModuType.Location = new System.Drawing.Point(541, 166);
            this.cboxModuType.Name = "cboxModuType";
            this.cboxModuType.Size = new System.Drawing.Size(253, 25);
            this.cboxModuType.TabIndex = 146;
            this.cboxModuType.WaterColor = System.Drawing.Color.Transparent;
            this.cboxModuType.WaterText = "";
            this.cboxModuType.SelectedIndexChanged += new System.EventHandler(this.cboModuType_SelectedIndexChanged);
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
            this.btnCancel.Location = new System.Drawing.Point(785, 64);
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
            this.btnDetermine.Location = new System.Drawing.Point(689, 64);
            this.btnDetermine.MouseBack = null;
            this.btnDetermine.MouseBaseColor = System.Drawing.Color.Transparent;
            this.btnDetermine.Name = "btnDetermine";
            this.btnDetermine.NormlBack = null;
            this.btnDetermine.Size = new System.Drawing.Size(75, 29);
            this.btnDetermine.TabIndex = 147;
            this.btnDetermine.Text = "确定";
            this.btnDetermine.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDetermine.UseVisualStyleBackColor = false;
            this.btnDetermine.Click += new System.EventHandler(this.btnDetermine_Click);
            // 
            // bgwDmaTransfer
            // 
            this.bgwDmaTransfer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwDmaTransfer_DoWork);
            this.bgwDmaTransfer.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwDmaTransfer_RunWorkerCompleted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(450, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 21);
            this.label2.TabIndex = 149;
            this.label2.Text = "数据源";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(450, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 21);
            this.label3.TabIndex = 150;
            this.label3.Text = "码元数量";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(450, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 21);
            this.label4.TabIndex = 151;
            this.label4.Text = "占空比";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(450, 322);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 21);
            this.label5.TabIndex = 152;
            this.label5.Text = "频率";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(450, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 21);
            this.label6.TabIndex = 153;
            this.label6.Text = "信号类型";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(450, 166);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 21);
            this.label7.TabIndex = 154;
            this.label7.Text = "调制类型";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(450, 361);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 21);
            this.label8.TabIndex = 155;
            this.label8.Text = "码元速率";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(450, 400);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 21);
            this.label9.TabIndex = 156;
            this.label9.Text = "滤波器类型";
            // 
            // cboxFreUnit
            // 
            this.cboxFreUnit.ArrowColor = System.Drawing.Color.White;
            this.cboxFreUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxFreUnit.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxFreUnit.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxFreUnit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboxFreUnit.DropBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxFreUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxFreUnit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboxFreUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxFreUnit.ForeColor = System.Drawing.Color.White;
            this.cboxFreUnit.FormattingEnabled = true;
            this.cboxFreUnit.Items.AddRange(new object[] {
            "Hz",
            "kHz",
            "MHz"});
            this.cboxFreUnit.Location = new System.Drawing.Point(739, 321);
            this.cboxFreUnit.Name = "cboxFreUnit";
            this.cboxFreUnit.Size = new System.Drawing.Size(55, 22);
            this.cboxFreUnit.TabIndex = 157;
            this.cboxFreUnit.WaterColor = System.Drawing.Color.Transparent;
            this.cboxFreUnit.WaterText = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(753, 361);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 18);
            this.label1.TabIndex = 158;
            this.label1.Text = "Baud";
            // 
            // ArbitraryWave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1280, 513);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboxFreUnit);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDetermine);
            this.Controls.Add(this.cboxModuType);
            this.Controls.Add(this.cboxSymbolNum);
            this.Controls.Add(this.cboxDataSource);
            this.Controls.Add(this.lalAeroUpdateUnit);
            this.Controls.Add(this.tboxFrequency);
            this.Controls.Add(this.tboxDutyCycle);
            this.Controls.Add(this.tboxSymbolRate);
            this.Controls.Add(this.cboxFilterType);
            this.Controls.Add(this.cboxSignalType);
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

        private CCWin.SkinControl.SkinComboBox cboxSignalType;
        private CCWin.SkinControl.SkinComboBox cboxFilterType;
        private System.Windows.Forms.TextBox tboxSymbolRate;
        private System.Windows.Forms.TextBox tboxDutyCycle;
        private System.Windows.Forms.TextBox tboxFrequency;
        private System.Windows.Forms.Label lalAeroUpdateUnit;
        private CCWin.SkinControl.SkinComboBox cboxDataSource;
        private CCWin.SkinControl.SkinComboBox cboxSymbolNum;
        private CCWin.SkinControl.SkinComboBox cboxModuType;
        private System.Windows.Forms.ErrorProvider errorShow;
        private CCWin.SkinControl.SkinButton btnCancel;
        private CCWin.SkinControl.SkinButton btnDetermine;
        private System.ComponentModel.BackgroundWorker bgwDmaTransfer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private CCWin.SkinControl.SkinComboBox cboxFreUnit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;

    }
}