namespace ChanGenTool
{
    partial class WaveTool
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
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboxFrequencyUnit = new System.Windows.Forms.ComboBox();
            this.cboxSymbolNumber = new System.Windows.Forms.ComboBox();
            this.tboxSymbolRate = new System.Windows.Forms.TextBox();
            this.tboxFrequency = new System.Windows.Forms.TextBox();
            this.cboxModulationType = new System.Windows.Forms.ComboBox();
            this.tboxDutyCycle = new System.Windows.Forms.TextBox();
            this.cboxFilterType = new System.Windows.Forms.ComboBox();
            this.lalSymbolNum = new System.Windows.Forms.Label();
            this.lalSymbolRate = new System.Windows.Forms.Label();
            this.cboxDataSource = new System.Windows.Forms.ComboBox();
            this.lalCutyCycle = new System.Windows.Forms.Label();
            this.lalFiterType = new System.Windows.Forms.Label();
            this.lalSignalFre = new System.Windows.Forms.Label();
            this.lalDataSource = new System.Windows.Forms.Label();
            this.lalModuType = new System.Windows.Forms.Label();
            this.tboxWaveFilePath = new System.Windows.Forms.TextBox();
            this.btnWaveFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SetTool = new System.Windows.Forms.TabControl();
            this.WaveSetPage = new System.Windows.Forms.TabPage();
            this.cboxSignalType = new System.Windows.Forms.ComboBox();
            this.lalSignalType = new System.Windows.Forms.Label();
            this.ChannelSetTool = new System.Windows.Forms.TabPage();
            this.ckboxIsRun = new System.Windows.Forms.CheckBox();
            this.ckboxAddFad = new System.Windows.Forms.CheckBox();
            this.ckboxAddNoise = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAeroSNR = new System.Windows.Forms.TextBox();
            this.lalAeroSNR = new System.Windows.Forms.Label();
            this.SetTool.SuspendLayout();
            this.WaveSetPage.SuspendLayout();
            this.ChannelSetTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(202, 174);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 18);
            this.label10.TabIndex = 152;
            this.label10.Text = "%";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(210, 247);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 18);
            this.label9.TabIndex = 151;
            this.label9.Text = "Baud";
            // 
            // cboxFrequencyUnit
            // 
            this.cboxFrequencyUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxFrequencyUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxFrequencyUnit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboxFrequencyUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.cboxFrequencyUnit.ForeColor = System.Drawing.Color.White;
            this.cboxFrequencyUnit.FormattingEnabled = true;
            this.cboxFrequencyUnit.Items.AddRange(new object[] {
            "Hz",
            "kHz",
            "MHz"});
            this.cboxFrequencyUnit.Location = new System.Drawing.Point(202, 212);
            this.cboxFrequencyUnit.Name = "cboxFrequencyUnit";
            this.cboxFrequencyUnit.Size = new System.Drawing.Size(84, 25);
            this.cboxFrequencyUnit.TabIndex = 150;
            this.cboxFrequencyUnit.SelectedIndexChanged += new System.EventHandler(this.cboxFrequencyUnit_SelectedIndexChanged);
            // 
            // cboxSymbolNumber
            // 
            this.cboxSymbolNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxSymbolNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSymbolNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboxSymbolNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.cboxSymbolNumber.ForeColor = System.Drawing.Color.White;
            this.cboxSymbolNumber.FormattingEnabled = true;
            this.cboxSymbolNumber.Items.AddRange(new object[] {
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
            this.cboxSymbolNumber.Location = new System.Drawing.Point(104, 282);
            this.cboxSymbolNumber.Name = "cboxSymbolNumber";
            this.cboxSymbolNumber.Size = new System.Drawing.Size(113, 25);
            this.cboxSymbolNumber.TabIndex = 149;
            this.cboxSymbolNumber.SelectedIndexChanged += new System.EventHandler(this.cboxSymbolNumber_SelectedIndexChanged);
            // 
            // tboxSymbolRate
            // 
            this.tboxSymbolRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.tboxSymbolRate.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxSymbolRate.ForeColor = System.Drawing.Color.White;
            this.tboxSymbolRate.Location = new System.Drawing.Point(105, 243);
            this.tboxSymbolRate.Name = "tboxSymbolRate";
            this.tboxSymbolRate.Size = new System.Drawing.Size(105, 25);
            this.tboxSymbolRate.TabIndex = 148;
            this.tboxSymbolRate.Text = "100";
            this.tboxSymbolRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tboxSymbolRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxSymbolRate_KeyPress);
            // 
            // tboxFrequency
            // 
            this.tboxFrequency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.tboxFrequency.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxFrequency.ForeColor = System.Drawing.Color.White;
            this.tboxFrequency.Location = new System.Drawing.Point(105, 212);
            this.tboxFrequency.Name = "tboxFrequency";
            this.tboxFrequency.Size = new System.Drawing.Size(91, 25);
            this.tboxFrequency.TabIndex = 146;
            this.tboxFrequency.Text = "100";
            this.tboxFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tboxFrequency.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxFrequency_KeyPress);
            this.tboxFrequency.Leave += new System.EventHandler(this.tboxFrequency_Leave);
            // 
            // cboxModulationType
            // 
            this.cboxModulationType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxModulationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxModulationType.Enabled = false;
            this.cboxModulationType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboxModulationType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.cboxModulationType.ForeColor = System.Drawing.Color.White;
            this.cboxModulationType.FormattingEnabled = true;
            this.cboxModulationType.Items.AddRange(new object[] {
            "空-空",
            "空-地",
            "地-空"});
            this.cboxModulationType.Location = new System.Drawing.Point(105, 50);
            this.cboxModulationType.Name = "cboxModulationType";
            this.cboxModulationType.Size = new System.Drawing.Size(120, 25);
            this.cboxModulationType.TabIndex = 143;
            this.cboxModulationType.SelectedIndexChanged += new System.EventHandler(this.cboxModulationType_SelectedIndexChanged);
            // 
            // tboxDutyCycle
            // 
            this.tboxDutyCycle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.tboxDutyCycle.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxDutyCycle.ForeColor = System.Drawing.Color.White;
            this.tboxDutyCycle.Location = new System.Drawing.Point(105, 171);
            this.tboxDutyCycle.Name = "tboxDutyCycle";
            this.tboxDutyCycle.Size = new System.Drawing.Size(91, 25);
            this.tboxDutyCycle.TabIndex = 147;
            this.tboxDutyCycle.Text = "50";
            this.tboxDutyCycle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tboxDutyCycle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxDutyCycle_KeyPress);
            // 
            // cboxFilterType
            // 
            this.cboxFilterType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxFilterType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboxFilterType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.cboxFilterType.ForeColor = System.Drawing.Color.White;
            this.cboxFilterType.FormattingEnabled = true;
            this.cboxFilterType.Items.AddRange(new object[] {
            "升余弦",
            "根升余弦"});
            this.cboxFilterType.Location = new System.Drawing.Point(105, 132);
            this.cboxFilterType.Name = "cboxFilterType";
            this.cboxFilterType.Size = new System.Drawing.Size(120, 25);
            this.cboxFilterType.TabIndex = 145;
            this.cboxFilterType.SelectedIndexChanged += new System.EventHandler(this.cboxFilterType_SelectedIndexChanged);
            // 
            // lalSymbolNum
            // 
            this.lalSymbolNum.AutoSize = true;
            this.lalSymbolNum.BackColor = System.Drawing.Color.Transparent;
            this.lalSymbolNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.lalSymbolNum.ForeColor = System.Drawing.Color.White;
            this.lalSymbolNum.Location = new System.Drawing.Point(26, 285);
            this.lalSymbolNum.Name = "lalSymbolNum";
            this.lalSymbolNum.Size = new System.Drawing.Size(72, 18);
            this.lalSymbolNum.TabIndex = 142;
            this.lalSymbolNum.Text = "码元数量";
            // 
            // lalSymbolRate
            // 
            this.lalSymbolRate.AutoSize = true;
            this.lalSymbolRate.BackColor = System.Drawing.Color.Transparent;
            this.lalSymbolRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.lalSymbolRate.ForeColor = System.Drawing.Color.White;
            this.lalSymbolRate.Location = new System.Drawing.Point(21, 247);
            this.lalSymbolRate.Name = "lalSymbolRate";
            this.lalSymbolRate.Size = new System.Drawing.Size(72, 18);
            this.lalSymbolRate.TabIndex = 141;
            this.lalSymbolRate.Text = "码元速率";
            // 
            // cboxDataSource
            // 
            this.cboxDataSource.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxDataSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxDataSource.Enabled = false;
            this.cboxDataSource.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboxDataSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
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
            this.cboxDataSource.Location = new System.Drawing.Point(105, 91);
            this.cboxDataSource.Name = "cboxDataSource";
            this.cboxDataSource.Size = new System.Drawing.Size(120, 25);
            this.cboxDataSource.TabIndex = 144;
            this.cboxDataSource.SelectedIndexChanged += new System.EventHandler(this.cboxDataSource_SelectedIndexChanged);
            // 
            // lalCutyCycle
            // 
            this.lalCutyCycle.AutoSize = true;
            this.lalCutyCycle.BackColor = System.Drawing.Color.Transparent;
            this.lalCutyCycle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.lalCutyCycle.ForeColor = System.Drawing.Color.White;
            this.lalCutyCycle.Location = new System.Drawing.Point(24, 174);
            this.lalCutyCycle.Name = "lalCutyCycle";
            this.lalCutyCycle.Size = new System.Drawing.Size(56, 18);
            this.lalCutyCycle.TabIndex = 140;
            this.lalCutyCycle.Text = "占空比";
            // 
            // lalFiterType
            // 
            this.lalFiterType.AutoSize = true;
            this.lalFiterType.BackColor = System.Drawing.Color.Transparent;
            this.lalFiterType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.lalFiterType.ForeColor = System.Drawing.Color.White;
            this.lalFiterType.Location = new System.Drawing.Point(24, 136);
            this.lalFiterType.Name = "lalFiterType";
            this.lalFiterType.Size = new System.Drawing.Size(72, 18);
            this.lalFiterType.TabIndex = 137;
            this.lalFiterType.Text = "滤波类型";
            // 
            // lalSignalFre
            // 
            this.lalSignalFre.AutoSize = true;
            this.lalSignalFre.BackColor = System.Drawing.Color.Transparent;
            this.lalSignalFre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.lalSignalFre.ForeColor = System.Drawing.Color.White;
            this.lalSignalFre.Location = new System.Drawing.Point(24, 214);
            this.lalSignalFre.Name = "lalSignalFre";
            this.lalSignalFre.Size = new System.Drawing.Size(72, 18);
            this.lalSignalFre.TabIndex = 139;
            this.lalSignalFre.Text = "信号频率";
            // 
            // lalDataSource
            // 
            this.lalDataSource.AutoSize = true;
            this.lalDataSource.BackColor = System.Drawing.Color.Transparent;
            this.lalDataSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.lalDataSource.ForeColor = System.Drawing.Color.White;
            this.lalDataSource.Location = new System.Drawing.Point(27, 93);
            this.lalDataSource.Name = "lalDataSource";
            this.lalDataSource.Size = new System.Drawing.Size(56, 18);
            this.lalDataSource.TabIndex = 138;
            this.lalDataSource.Text = "数据源";
            // 
            // lalModuType
            // 
            this.lalModuType.AutoSize = true;
            this.lalModuType.BackColor = System.Drawing.Color.Transparent;
            this.lalModuType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.lalModuType.ForeColor = System.Drawing.Color.White;
            this.lalModuType.Location = new System.Drawing.Point(26, 57);
            this.lalModuType.Name = "lalModuType";
            this.lalModuType.Size = new System.Drawing.Size(72, 18);
            this.lalModuType.TabIndex = 136;
            this.lalModuType.Text = "调制类型";
            // 
            // tboxWaveFilePath
            // 
            this.tboxWaveFilePath.AllowDrop = true;
            this.tboxWaveFilePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.tboxWaveFilePath.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold);
            this.tboxWaveFilePath.ForeColor = System.Drawing.Color.White;
            this.tboxWaveFilePath.Location = new System.Drawing.Point(104, 319);
            this.tboxWaveFilePath.Name = "tboxWaveFilePath";
            this.tboxWaveFilePath.ReadOnly = true;
            this.tboxWaveFilePath.Size = new System.Drawing.Size(269, 25);
            this.tboxWaveFilePath.TabIndex = 154;
            // 
            // btnWaveFile
            // 
            this.btnWaveFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnWaveFile.Enabled = false;
            this.btnWaveFile.Font = new System.Drawing.Font("Calibri", 10.8F);
            this.btnWaveFile.ForeColor = System.Drawing.Color.Black;
            this.btnWaveFile.Location = new System.Drawing.Point(379, 313);
            this.btnWaveFile.Name = "btnWaveFile";
            this.btnWaveFile.Size = new System.Drawing.Size(37, 37);
            this.btnWaveFile.TabIndex = 155;
            this.btnWaveFile.TabStop = false;
            this.btnWaveFile.Text = "...";
            this.btnWaveFile.UseVisualStyleBackColor = false;
            this.btnWaveFile.Click += new System.EventHandler(this.btnWaveFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 326);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 18);
            this.label1.TabIndex = 153;
            this.label1.Text = "任意波文件";
            // 
            // SetTool
            // 
            this.SetTool.Controls.Add(this.WaveSetPage);
            this.SetTool.Controls.Add(this.ChannelSetTool);
            this.SetTool.Location = new System.Drawing.Point(1, 0);
            this.SetTool.Name = "SetTool";
            this.SetTool.SelectedIndex = 0;
            this.SetTool.Size = new System.Drawing.Size(506, 383);
            this.SetTool.TabIndex = 156;
            // 
            // WaveSetPage
            // 
            this.WaveSetPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.WaveSetPage.Controls.Add(this.cboxSignalType);
            this.WaveSetPage.Controls.Add(this.lalSignalType);
            this.WaveSetPage.Controls.Add(this.cboxModulationType);
            this.WaveSetPage.Controls.Add(this.tboxWaveFilePath);
            this.WaveSetPage.Controls.Add(this.lalModuType);
            this.WaveSetPage.Controls.Add(this.btnWaveFile);
            this.WaveSetPage.Controls.Add(this.lalDataSource);
            this.WaveSetPage.Controls.Add(this.label1);
            this.WaveSetPage.Controls.Add(this.lalSignalFre);
            this.WaveSetPage.Controls.Add(this.label10);
            this.WaveSetPage.Controls.Add(this.lalFiterType);
            this.WaveSetPage.Controls.Add(this.label9);
            this.WaveSetPage.Controls.Add(this.lalCutyCycle);
            this.WaveSetPage.Controls.Add(this.cboxFrequencyUnit);
            this.WaveSetPage.Controls.Add(this.cboxDataSource);
            this.WaveSetPage.Controls.Add(this.cboxSymbolNumber);
            this.WaveSetPage.Controls.Add(this.lalSymbolRate);
            this.WaveSetPage.Controls.Add(this.tboxSymbolRate);
            this.WaveSetPage.Controls.Add(this.lalSymbolNum);
            this.WaveSetPage.Controls.Add(this.tboxFrequency);
            this.WaveSetPage.Controls.Add(this.cboxFilterType);
            this.WaveSetPage.Controls.Add(this.tboxDutyCycle);
            this.WaveSetPage.ForeColor = System.Drawing.Color.White;
            this.WaveSetPage.Location = new System.Drawing.Point(4, 22);
            this.WaveSetPage.Name = "WaveSetPage";
            this.WaveSetPage.Padding = new System.Windows.Forms.Padding(3);
            this.WaveSetPage.Size = new System.Drawing.Size(498, 357);
            this.WaveSetPage.TabIndex = 0;
            this.WaveSetPage.Text = "任意波配置";
            // 
            // cboxSignalType
            // 
            this.cboxSignalType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboxSignalType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSignalType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboxSignalType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.cboxSignalType.ForeColor = System.Drawing.Color.White;
            this.cboxSignalType.FormattingEnabled = true;
            this.cboxSignalType.Items.AddRange(new object[] {
            "单音",
            "双音",
            "脉冲",
            "PSK调制信号",
            "QAM调制信号",
            "自定义"});
            this.cboxSignalType.Location = new System.Drawing.Point(105, 10);
            this.cboxSignalType.Name = "cboxSignalType";
            this.cboxSignalType.Size = new System.Drawing.Size(120, 25);
            this.cboxSignalType.TabIndex = 157;
            this.cboxSignalType.SelectedIndexChanged += new System.EventHandler(this.cboxSignalType_SelectedIndexChanged);
            // 
            // lalSignalType
            // 
            this.lalSignalType.AutoSize = true;
            this.lalSignalType.BackColor = System.Drawing.Color.Transparent;
            this.lalSignalType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.lalSignalType.ForeColor = System.Drawing.Color.White;
            this.lalSignalType.Location = new System.Drawing.Point(27, 14);
            this.lalSignalType.Name = "lalSignalType";
            this.lalSignalType.Size = new System.Drawing.Size(72, 18);
            this.lalSignalType.TabIndex = 156;
            this.lalSignalType.Text = "信号类型";
            // 
            // ChannelSetTool
            // 
            this.ChannelSetTool.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ChannelSetTool.Controls.Add(this.label2);
            this.ChannelSetTool.Controls.Add(this.txtAeroSNR);
            this.ChannelSetTool.Controls.Add(this.lalAeroSNR);
            this.ChannelSetTool.Controls.Add(this.ckboxAddNoise);
            this.ChannelSetTool.Controls.Add(this.ckboxAddFad);
            this.ChannelSetTool.Controls.Add(this.ckboxIsRun);
            this.ChannelSetTool.Location = new System.Drawing.Point(4, 22);
            this.ChannelSetTool.Name = "ChannelSetTool";
            this.ChannelSetTool.Padding = new System.Windows.Forms.Padding(3);
            this.ChannelSetTool.Size = new System.Drawing.Size(498, 357);
            this.ChannelSetTool.TabIndex = 1;
            this.ChannelSetTool.Text = "信道配置";
            // 
            // ckboxIsRun
            // 
            this.ckboxIsRun.AutoSize = true;
            this.ckboxIsRun.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckboxIsRun.ForeColor = System.Drawing.Color.White;
            this.ckboxIsRun.Location = new System.Drawing.Point(35, 43);
            this.ckboxIsRun.Name = "ckboxIsRun";
            this.ckboxIsRun.Size = new System.Drawing.Size(59, 20);
            this.ckboxIsRun.TabIndex = 0;
            this.ckboxIsRun.Text = "运行";
            this.ckboxIsRun.UseVisualStyleBackColor = true;
            this.ckboxIsRun.CheckedChanged += new System.EventHandler(this.ckboxIsRun_CheckedChanged);
            // 
            // ckboxAddFad
            // 
            this.ckboxAddFad.AutoSize = true;
            this.ckboxAddFad.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckboxAddFad.ForeColor = System.Drawing.Color.White;
            this.ckboxAddFad.Location = new System.Drawing.Point(35, 90);
            this.ckboxAddFad.Name = "ckboxAddFad";
            this.ckboxAddFad.Size = new System.Drawing.Size(75, 20);
            this.ckboxAddFad.TabIndex = 1;
            this.ckboxAddFad.Text = "加衰落";
            this.ckboxAddFad.UseVisualStyleBackColor = true;
            this.ckboxAddFad.CheckedChanged += new System.EventHandler(this.ckboxAddFad_CheckedChanged);
            // 
            // ckboxAddNoise
            // 
            this.ckboxAddNoise.AutoSize = true;
            this.ckboxAddNoise.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckboxAddNoise.ForeColor = System.Drawing.Color.White;
            this.ckboxAddNoise.Location = new System.Drawing.Point(35, 140);
            this.ckboxAddNoise.Name = "ckboxAddNoise";
            this.ckboxAddNoise.Size = new System.Drawing.Size(75, 20);
            this.ckboxAddNoise.TabIndex = 2;
            this.ckboxAddNoise.Text = "加噪声";
            this.ckboxAddNoise.UseVisualStyleBackColor = true;
            this.ckboxAddNoise.CheckedChanged += new System.EventHandler(this.ckboxAddNoise_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(187, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 106;
            this.label2.Text = "dB";
            // 
            // txtAeroSNR
            // 
            this.txtAeroSNR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.txtAeroSNR.Enabled = false;
            this.txtAeroSNR.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAeroSNR.ForeColor = System.Drawing.Color.White;
            this.txtAeroSNR.Location = new System.Drawing.Point(116, 179);
            this.txtAeroSNR.Name = "txtAeroSNR";
            this.txtAeroSNR.Size = new System.Drawing.Size(55, 26);
            this.txtAeroSNR.TabIndex = 105;
            this.txtAeroSNR.Text = "5";
            this.txtAeroSNR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAeroSNR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAeroSNR_KeyPress);
            // 
            // lalAeroSNR
            // 
            this.lalAeroSNR.AutoSize = true;
            this.lalAeroSNR.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lalAeroSNR.ForeColor = System.Drawing.Color.White;
            this.lalAeroSNR.Location = new System.Drawing.Point(54, 184);
            this.lalAeroSNR.Name = "lalAeroSNR";
            this.lalAeroSNR.Size = new System.Drawing.Size(56, 16);
            this.lalAeroSNR.TabIndex = 104;
            this.lalAeroSNR.Text = "信噪比";
            // 
            // WaveTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 395);
            this.Controls.Add(this.SetTool);
            this.Name = "WaveTool";
            this.Text = "WaveTool";
            this.SetTool.ResumeLayout(false);
            this.WaveSetPage.ResumeLayout(false);
            this.WaveSetPage.PerformLayout();
            this.ChannelSetTool.ResumeLayout(false);
            this.ChannelSetTool.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboxFrequencyUnit;
        private System.Windows.Forms.ComboBox cboxSymbolNumber;
        private System.Windows.Forms.TextBox tboxSymbolRate;
        private System.Windows.Forms.TextBox tboxFrequency;
        private System.Windows.Forms.ComboBox cboxModulationType;
        private System.Windows.Forms.TextBox tboxDutyCycle;
        private System.Windows.Forms.ComboBox cboxFilterType;
        private System.Windows.Forms.Label lalSymbolNum;
        private System.Windows.Forms.Label lalSymbolRate;
        private System.Windows.Forms.ComboBox cboxDataSource;
        private System.Windows.Forms.Label lalCutyCycle;
        private System.Windows.Forms.Label lalFiterType;
        private System.Windows.Forms.Label lalSignalFre;
        private System.Windows.Forms.Label lalDataSource;
        private System.Windows.Forms.Label lalModuType;
        private System.Windows.Forms.TextBox tboxWaveFilePath;
        private System.Windows.Forms.Button btnWaveFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl SetTool;
        private System.Windows.Forms.TabPage WaveSetPage;
        private System.Windows.Forms.TabPage ChannelSetTool;
        private System.Windows.Forms.ComboBox cboxSignalType;
        private System.Windows.Forms.Label lalSignalType;
        private System.Windows.Forms.CheckBox ckboxAddNoise;
        private System.Windows.Forms.CheckBox ckboxAddFad;
        private System.Windows.Forms.CheckBox ckboxIsRun;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAeroSNR;
        private System.Windows.Forms.Label lalAeroSNR;
    }
}