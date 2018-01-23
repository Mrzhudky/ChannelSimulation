namespace ChanSimSource
{
    partial class FadingWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FadingWindow));
            this.txtAeroUpdate = new System.Windows.Forms.TextBox();
            this.lalAeroUpdateUnit = new System.Windows.Forms.Label();
            this.txtAeroTrace = new System.Windows.Forms.TextBox();
            this.txtAeroCarrierFre = new System.Windows.Forms.TextBox();
            this.txtAeroLaunAnte = new System.Windows.Forms.TextBox();
            this.txtAeroRecvAnte = new System.Windows.Forms.TextBox();
            this.errorShow = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnDetermine = new CCWin.SkinControl.SkinButton();
            this.btnCancel = new CCWin.SkinControl.SkinButton();
            this.bgwMatlabGen = new System.ComponentModel.BackgroundWorker();
            this.bgwMatlabInit = new System.ComponentModel.BackgroundWorker();
            this.cboAeroChanModel = new CCWin.SkinControl.SkinComboBox();
            this.cboAeroPolar = new CCWin.SkinControl.SkinComboBox();
            this.cboAeroRefEnv = new CCWin.SkinControl.SkinComboBox();
            this.cboAeroRefMod = new CCWin.SkinControl.SkinComboBox();
            this.btnAeroTrace = new CCWin.SkinControl.SkinButton();
            this.btnAeroLaunAnte = new CCWin.SkinControl.SkinButton();
            this.btnAeroRecvAnte = new CCWin.SkinControl.SkinButton();
            this.TipShow = new System.Windows.Forms.ToolTip(this.components);
            this.cboAeroCarrierFre = new CCWin.SkinControl.SkinComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorShow)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAeroUpdate
            // 
            this.txtAeroUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.txtAeroUpdate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAeroUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtAeroUpdate.ForeColor = System.Drawing.Color.White;
            this.txtAeroUpdate.Location = new System.Drawing.Point(397, 360);
            this.txtAeroUpdate.Name = "txtAeroUpdate";
            this.txtAeroUpdate.Size = new System.Drawing.Size(211, 17);
            this.txtAeroUpdate.TabIndex = 131;
            this.txtAeroUpdate.Text = "10";
            this.txtAeroUpdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAeroUpdate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxKeyPress);
            // 
            // lalAeroUpdateUnit
            // 
            this.lalAeroUpdateUnit.AutoSize = true;
            this.lalAeroUpdateUnit.BackColor = System.Drawing.Color.Transparent;
            this.lalAeroUpdateUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.lalAeroUpdateUnit.ForeColor = System.Drawing.Color.White;
            this.lalAeroUpdateUnit.Location = new System.Drawing.Point(619, 359);
            this.lalAeroUpdateUnit.Name = "lalAeroUpdateUnit";
            this.lalAeroUpdateUnit.Size = new System.Drawing.Size(31, 18);
            this.lalAeroUpdateUnit.TabIndex = 133;
            this.lalAeroUpdateUnit.Text = "ms";
            // 
            // txtAeroTrace
            // 
            this.txtAeroTrace.AllowDrop = true;
            this.txtAeroTrace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.txtAeroTrace.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorShow.SetError(this.txtAeroTrace, "文件不存在");
            this.txtAeroTrace.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtAeroTrace.ForeColor = System.Drawing.Color.White;
            this.txtAeroTrace.Location = new System.Drawing.Point(397, 193);
            this.txtAeroTrace.Name = "txtAeroTrace";
            this.txtAeroTrace.Size = new System.Drawing.Size(208, 18);
            this.txtAeroTrace.TabIndex = 115;
            this.txtAeroTrace.TextChanged += new System.EventHandler(this.txtFileExist_TextChanged);
            // 
            // txtAeroCarrierFre
            // 
            this.txtAeroCarrierFre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.txtAeroCarrierFre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAeroCarrierFre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtAeroCarrierFre.ForeColor = System.Drawing.Color.White;
            this.txtAeroCarrierFre.Location = new System.Drawing.Point(397, 318);
            this.txtAeroCarrierFre.Name = "txtAeroCarrierFre";
            this.txtAeroCarrierFre.Size = new System.Drawing.Size(211, 17);
            this.txtAeroCarrierFre.TabIndex = 120;
            this.txtAeroCarrierFre.Text = "800";
            this.txtAeroCarrierFre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAeroCarrierFre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxKeyPress);
            // 
            // txtAeroLaunAnte
            // 
            this.txtAeroLaunAnte.AllowDrop = true;
            this.txtAeroLaunAnte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.txtAeroLaunAnte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorShow.SetError(this.txtAeroLaunAnte, "文件不存在");
            this.txtAeroLaunAnte.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtAeroLaunAnte.ForeColor = System.Drawing.Color.White;
            this.txtAeroLaunAnte.Location = new System.Drawing.Point(397, 234);
            this.txtAeroLaunAnte.Name = "txtAeroLaunAnte";
            this.txtAeroLaunAnte.Size = new System.Drawing.Size(208, 18);
            this.txtAeroLaunAnte.TabIndex = 116;
            this.txtAeroLaunAnte.TextChanged += new System.EventHandler(this.txtFileExist_TextChanged);
            // 
            // txtAeroRecvAnte
            // 
            this.txtAeroRecvAnte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.txtAeroRecvAnte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorShow.SetError(this.txtAeroRecvAnte, "文件不存在");
            this.txtAeroRecvAnte.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtAeroRecvAnte.ForeColor = System.Drawing.Color.White;
            this.txtAeroRecvAnte.Location = new System.Drawing.Point(400, 278);
            this.txtAeroRecvAnte.Name = "txtAeroRecvAnte";
            this.txtAeroRecvAnte.Size = new System.Drawing.Size(208, 17);
            this.txtAeroRecvAnte.TabIndex = 117;
            this.txtAeroRecvAnte.TextChanged += new System.EventHandler(this.txtFileExist_TextChanged);
            // 
            // errorShow
            // 
            this.errorShow.BlinkRate = 0;
            this.errorShow.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorShow.ContainerControl = this;
            this.errorShow.RightToLeft = true;
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
            this.btnDetermine.Location = new System.Drawing.Point(880, 113);
            this.btnDetermine.MouseBack = null;
            this.btnDetermine.MouseBaseColor = System.Drawing.Color.Transparent;
            this.btnDetermine.Name = "btnDetermine";
            this.btnDetermine.NormlBack = null;
            this.btnDetermine.Size = new System.Drawing.Size(75, 29);
            this.btnDetermine.TabIndex = 2;
            this.btnDetermine.Text = "确定";
            this.btnDetermine.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDetermine.UseVisualStyleBackColor = false;
            this.btnDetermine.Click += new System.EventHandler(this.btnDetermine_Click);
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
            this.btnCancel.Location = new System.Drawing.Point(976, 113);
            this.btnCancel.MouseBack = null;
            this.btnCancel.MouseBaseColor = System.Drawing.Color.Transparent;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormlBack = null;
            this.btnCancel.Radius = 20;
            this.btnCancel.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnCancel.Size = new System.Drawing.Size(75, 29);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // bgwMatlabGen
            // 
            this.bgwMatlabGen.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwMatlabGen_DoWork);
            this.bgwMatlabGen.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwMatlabGen_RunWorkerCompleted);
            // 
            // cboAeroChanModel
            // 
            this.cboAeroChanModel.ArrowColor = System.Drawing.Color.White;
            this.cboAeroChanModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboAeroChanModel.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboAeroChanModel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboAeroChanModel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboAeroChanModel.DropBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboAeroChanModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAeroChanModel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboAeroChanModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.cboAeroChanModel.ForeColor = System.Drawing.Color.White;
            this.cboAeroChanModel.FormattingEnabled = true;
            this.cboAeroChanModel.Items.AddRange(new object[] {
            "空-空",
            "空-地",
            "地-空"});
            this.cboAeroChanModel.Location = new System.Drawing.Point(793, 231);
            this.cboAeroChanModel.Name = "cboAeroChanModel";
            this.cboAeroChanModel.Size = new System.Drawing.Size(253, 25);
            this.cboAeroChanModel.TabIndex = 127;
            this.cboAeroChanModel.WaterColor = System.Drawing.Color.Transparent;
            this.cboAeroChanModel.WaterText = "";
            // 
            // cboAeroPolar
            // 
            this.cboAeroPolar.ArrowColor = System.Drawing.Color.White;
            this.cboAeroPolar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboAeroPolar.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboAeroPolar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboAeroPolar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboAeroPolar.DropBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboAeroPolar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAeroPolar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboAeroPolar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.cboAeroPolar.ForeColor = System.Drawing.Color.White;
            this.cboAeroPolar.FormattingEnabled = true;
            this.cboAeroPolar.Items.AddRange(new object[] {
            "水平极化",
            "垂直极化"});
            this.cboAeroPolar.Location = new System.Drawing.Point(793, 190);
            this.cboAeroPolar.Name = "cboAeroPolar";
            this.cboAeroPolar.Size = new System.Drawing.Size(253, 25);
            this.cboAeroPolar.TabIndex = 134;
            this.cboAeroPolar.WaterColor = System.Drawing.Color.Transparent;
            this.cboAeroPolar.WaterText = "";
            // 
            // cboAeroRefEnv
            // 
            this.cboAeroRefEnv.ArrowColor = System.Drawing.Color.White;
            this.cboAeroRefEnv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboAeroRefEnv.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboAeroRefEnv.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboAeroRefEnv.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboAeroRefEnv.DropBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboAeroRefEnv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAeroRefEnv.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboAeroRefEnv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.cboAeroRefEnv.ForeColor = System.Drawing.Color.White;
            this.cboAeroRefEnv.FormattingEnabled = true;
            this.cboAeroRefEnv.Items.AddRange(new object[] {
            "郊区",
            "城市",
            "森林",
            "海洋",
            "自定义"});
            this.cboAeroRefEnv.Location = new System.Drawing.Point(793, 315);
            this.cboAeroRefEnv.Name = "cboAeroRefEnv";
            this.cboAeroRefEnv.Size = new System.Drawing.Size(253, 25);
            this.cboAeroRefEnv.TabIndex = 135;
            this.cboAeroRefEnv.WaterColor = System.Drawing.Color.Transparent;
            this.cboAeroRefEnv.WaterText = "";
            this.cboAeroRefEnv.SelectedIndexChanged += new System.EventHandler(this.cboAeroRefEnv_SelectedIndexChanged);
            this.cboAeroRefEnv.SelectionChangeCommitted += new System.EventHandler(this.cboAeroRefEnv_SelectionChangeCommitted);
            // 
            // cboAeroRefMod
            // 
            this.cboAeroRefMod.ArrowColor = System.Drawing.Color.White;
            this.cboAeroRefMod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboAeroRefMod.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboAeroRefMod.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboAeroRefMod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboAeroRefMod.DropBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboAeroRefMod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAeroRefMod.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboAeroRefMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.cboAeroRefMod.ForeColor = System.Drawing.Color.White;
            this.cboAeroRefMod.FormattingEnabled = true;
            this.cboAeroRefMod.Items.AddRange(new object[] {
            "干燥地面",
            "中等地面",
            "潮湿地面"});
            this.cboAeroRefMod.Location = new System.Drawing.Point(793, 356);
            this.cboAeroRefMod.Name = "cboAeroRefMod";
            this.cboAeroRefMod.Size = new System.Drawing.Size(253, 25);
            this.cboAeroRefMod.TabIndex = 136;
            this.cboAeroRefMod.WaterColor = System.Drawing.Color.Transparent;
            this.cboAeroRefMod.WaterText = "";
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
            this.btnAeroTrace.Location = new System.Drawing.Point(615, 183);
            this.btnAeroTrace.MouseBack = null;
            this.btnAeroTrace.MouseBaseColor = System.Drawing.Color.Transparent;
            this.btnAeroTrace.Name = "btnAeroTrace";
            this.btnAeroTrace.NormlBack = null;
            this.btnAeroTrace.Radius = 4;
            this.btnAeroTrace.Size = new System.Drawing.Size(37, 36);
            this.btnAeroTrace.TabIndex = 137;
            this.btnAeroTrace.Text = "...";
            this.btnAeroTrace.UseVisualStyleBackColor = false;
            this.btnAeroTrace.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // btnAeroLaunAnte
            // 
            this.btnAeroLaunAnte.BackColor = System.Drawing.Color.Transparent;
            this.btnAeroLaunAnte.BaseColor = System.Drawing.Color.Transparent;
            this.btnAeroLaunAnte.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnAeroLaunAnte.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnAeroLaunAnte.DownBack = null;
            this.btnAeroLaunAnte.DownBaseColor = System.Drawing.Color.Transparent;
            this.btnAeroLaunAnte.FadeGlow = false;
            this.btnAeroLaunAnte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAeroLaunAnte.GlowColor = System.Drawing.Color.Transparent;
            this.btnAeroLaunAnte.InnerBorderColor = System.Drawing.Color.Transparent;
            this.btnAeroLaunAnte.IsDrawGlass = false;
            this.btnAeroLaunAnte.Location = new System.Drawing.Point(615, 225);
            this.btnAeroLaunAnte.MouseBack = null;
            this.btnAeroLaunAnte.MouseBaseColor = System.Drawing.Color.Transparent;
            this.btnAeroLaunAnte.Name = "btnAeroLaunAnte";
            this.btnAeroLaunAnte.NormlBack = null;
            this.btnAeroLaunAnte.Radius = 4;
            this.btnAeroLaunAnte.Size = new System.Drawing.Size(37, 36);
            this.btnAeroLaunAnte.TabIndex = 138;
            this.btnAeroLaunAnte.Text = "...";
            this.btnAeroLaunAnte.UseVisualStyleBackColor = false;
            this.btnAeroLaunAnte.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // btnAeroRecvAnte
            // 
            this.btnAeroRecvAnte.BackColor = System.Drawing.Color.Transparent;
            this.btnAeroRecvAnte.BaseColor = System.Drawing.Color.Transparent;
            this.btnAeroRecvAnte.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnAeroRecvAnte.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnAeroRecvAnte.DownBack = null;
            this.btnAeroRecvAnte.DownBaseColor = System.Drawing.Color.Transparent;
            this.btnAeroRecvAnte.FadeGlow = false;
            this.btnAeroRecvAnte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAeroRecvAnte.GlowColor = System.Drawing.Color.Transparent;
            this.btnAeroRecvAnte.InnerBorderColor = System.Drawing.Color.Transparent;
            this.btnAeroRecvAnte.IsDrawGlass = false;
            this.btnAeroRecvAnte.Location = new System.Drawing.Point(615, 267);
            this.btnAeroRecvAnte.MouseBack = null;
            this.btnAeroRecvAnte.MouseBaseColor = System.Drawing.Color.Transparent;
            this.btnAeroRecvAnte.Name = "btnAeroRecvAnte";
            this.btnAeroRecvAnte.NormlBack = null;
            this.btnAeroRecvAnte.Radius = 4;
            this.btnAeroRecvAnte.Size = new System.Drawing.Size(37, 36);
            this.btnAeroRecvAnte.TabIndex = 139;
            this.btnAeroRecvAnte.Text = "...";
            this.btnAeroRecvAnte.UseVisualStyleBackColor = false;
            this.btnAeroRecvAnte.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // TipShow
            // 
            this.TipShow.ShowAlways = true;
            // 
            // cboAeroCarrierFre
            // 
            this.cboAeroCarrierFre.ArrowColor = System.Drawing.Color.White;
            this.cboAeroCarrierFre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboAeroCarrierFre.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboAeroCarrierFre.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboAeroCarrierFre.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboAeroCarrierFre.DropBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.cboAeroCarrierFre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAeroCarrierFre.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboAeroCarrierFre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.cboAeroCarrierFre.ForeColor = System.Drawing.Color.White;
            this.cboAeroCarrierFre.FormattingEnabled = true;
            this.cboAeroCarrierFre.Items.AddRange(new object[] {
            "GHz",
            "MHz",
            "KHz",
            "Hz"});
            this.cboAeroCarrierFre.Location = new System.Drawing.Point(586, 314);
            this.cboAeroCarrierFre.Name = "cboAeroCarrierFre";
            this.cboAeroCarrierFre.Size = new System.Drawing.Size(65, 25);
            this.cboAeroCarrierFre.TabIndex = 141;
            this.cboAeroCarrierFre.WaterColor = System.Drawing.Color.Transparent;
            this.cboAeroCarrierFre.WaterText = "";
            // 
            // FadingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1280, 514);
            this.ControlBox = false;
            this.Controls.Add(this.cboAeroCarrierFre);
            this.Controls.Add(this.btnAeroRecvAnte);
            this.Controls.Add(this.btnAeroLaunAnte);
            this.Controls.Add(this.btnAeroTrace);
            this.Controls.Add(this.cboAeroRefMod);
            this.Controls.Add(this.cboAeroRefEnv);
            this.Controls.Add(this.cboAeroPolar);
            this.Controls.Add(this.cboAeroChanModel);
            this.Controls.Add(this.lalAeroUpdateUnit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDetermine);
            this.Controls.Add(this.txtAeroUpdate);
            this.Controls.Add(this.txtAeroTrace);
            this.Controls.Add(this.txtAeroLaunAnte);
            this.Controls.Add(this.txtAeroRecvAnte);
            this.Controls.Add(this.txtAeroCarrierFre);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FadingWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.FadingWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAeroUpdate;
        private System.Windows.Forms.Label lalAeroUpdateUnit;
        private System.Windows.Forms.TextBox txtAeroTrace;
        private System.Windows.Forms.TextBox txtAeroCarrierFre;
        private System.Windows.Forms.TextBox txtAeroLaunAnte;
        private System.Windows.Forms.TextBox txtAeroRecvAnte;
        private System.Windows.Forms.ErrorProvider errorShow;
        private CCWin.SkinControl.SkinButton btnCancel;
        private CCWin.SkinControl.SkinButton btnDetermine;
        private System.ComponentModel.BackgroundWorker bgwMatlabGen;
        private System.ComponentModel.BackgroundWorker bgwMatlabInit;
        private CCWin.SkinControl.SkinComboBox cboAeroChanModel;
        private CCWin.SkinControl.SkinComboBox cboAeroPolar;
        private CCWin.SkinControl.SkinButton btnAeroTrace;
        private CCWin.SkinControl.SkinComboBox cboAeroRefMod;
        private CCWin.SkinControl.SkinComboBox cboAeroRefEnv;
        private CCWin.SkinControl.SkinButton btnAeroRecvAnte;
        private CCWin.SkinControl.SkinButton btnAeroLaunAnte;
        private System.Windows.Forms.ToolTip TipShow;
        private CCWin.SkinControl.SkinComboBox cboAeroCarrierFre;

    }
}