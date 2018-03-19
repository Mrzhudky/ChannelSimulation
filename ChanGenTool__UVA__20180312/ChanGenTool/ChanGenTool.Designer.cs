namespace ChanGenTool
{
    partial class ChanGenTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChanGenTool));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainToolMenu = new System.Windows.Forms.ToolStrip();
            this.btnSaveCfg = new System.Windows.Forms.ToolStripButton();
            this.btnLoadCfg = new System.Windows.Forms.ToolStripButton();
            this.btnOutputSet = new System.Windows.Forms.ToolStripButton();
            this.btnOutputCover = new System.Windows.Forms.ToolStripButton();
            this.btnQuit = new System.Windows.Forms.ToolStripButton();
            this.btnChanGen = new System.Windows.Forms.ToolStripButton();
            this.btnCfgFPGA = new System.Windows.Forms.ToolStripButton();
            this.btnRunFPGA = new System.Windows.Forms.ToolStripButton();
            this.btnChanFig = new System.Windows.Forms.ToolStripButton();
            this.statusShow = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lalOutputPath = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDateNow = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.载入配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.输出配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.输出路径ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.输出覆盖ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.信道仿真ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.配置硬件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.启动设备ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.画图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.收发端轨迹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.天线增益ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.发射端ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.接收端ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于软件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkAeroAWGN = new System.Windows.Forms.CheckBox();
            this.txtAeroSNR = new System.Windows.Forms.TextBox();
            this.lalAeroSNR = new System.Windows.Forms.Label();
            this.lalAeroUpdateUnit = new System.Windows.Forms.Label();
            this.txtAeroUpdate = new System.Windows.Forms.TextBox();
            this.lalAeroUpdate = new System.Windows.Forms.Label();
            this.lalAeroRecvAnte = new System.Windows.Forms.Label();
            this.lalAeroLaunAnte = new System.Windows.Forms.Label();
            this.lalAeroTrace = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lalAeroStep = new System.Windows.Forms.Label();
            this.btnAeroPlay = new System.Windows.Forms.Button();
            this.btnAeroForward = new System.Windows.Forms.Button();
            this.btnAeroBackward = new System.Windows.Forms.Button();
            this.btnAeroStop = new System.Windows.Forms.Button();
            this.lalAeroTimes = new System.Windows.Forms.Label();
            this.tkbrAeroChan = new System.Windows.Forms.TrackBar();
            this.btnAeroRecvAnte = new System.Windows.Forms.Button();
            this.btnAeroLaunAnte = new System.Windows.Forms.Button();
            this.txtAeroRecvAnte = new System.Windows.Forms.TextBox();
            this.txtAeroLaunAnte = new System.Windows.Forms.TextBox();
            this.grpAeroEnv = new System.Windows.Forms.GroupBox();
            this.cboAeroRefEnv = new System.Windows.Forms.ComboBox();
            this.lalAeroRefEnv = new System.Windows.Forms.Label();
            this.cboAeroRefMod = new System.Windows.Forms.ComboBox();
            this.lalAeroRefMod = new System.Windows.Forms.Label();
            this.txtAeroCarrierFre = new System.Windows.Forms.TextBox();
            this.lalAeroCarrierFre = new System.Windows.Forms.Label();
            this.cboAeroCarrierFre = new System.Windows.Forms.ComboBox();
            this.lalAeroCommuScnr = new System.Windows.Forms.Label();
            this.cboAeroCommuScnr = new System.Windows.Forms.ComboBox();
            this.lalAeroPolar = new System.Windows.Forms.Label();
            this.cboAeroPolar = new System.Windows.Forms.ComboBox();
            this.btnAeroTrace = new System.Windows.Forms.Button();
            this.txtAeroTrace = new System.Windows.Forms.TextBox();
            this.dgvAeroChan = new System.Windows.Forms.DataGridView();
            this.colAeroDelay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAeroDoppler = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAeroGain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAeroAOA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAeroEOA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabAeroMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.载入文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabGeneMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.载入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TipShow = new System.Windows.Forms.ToolTip(this.components);
            this.errorShow = new System.Windows.Forms.ErrorProvider(this.components);
            this.picNUAA = new System.Windows.Forms.PictureBox();
            this.picCEIE = new System.Windows.Forms.PictureBox();
            this.bgwMatlabInit = new System.ComponentModel.BackgroundWorker();
            this.bgwMatlabFig = new System.ComponentModel.BackgroundWorker();
            this.bgwMatlabGen = new System.ComponentModel.BackgroundWorker();
            this.tmrAeroPlay = new System.Windows.Forms.Timer(this.components);
            this.bgwDmaTransfer = new System.ComponentModel.BackgroundWorker();
            this.pageAeroChan = new System.Windows.Forms.Panel();
            this.cboxSignalType = new System.Windows.Forms.ComboBox();
            this.lalSignalType = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MainToolMenu.SuspendLayout();
            this.statusShow.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbrAeroChan)).BeginInit();
            this.grpAeroEnv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAeroChan)).BeginInit();
            this.tabAeroMenu.SuspendLayout();
            this.tabGeneMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNUAA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCEIE)).BeginInit();
            this.pageAeroChan.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainToolMenu
            // 
            this.MainToolMenu.BackColor = System.Drawing.Color.Transparent;
            this.MainToolMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSaveCfg,
            this.btnLoadCfg,
            this.btnOutputSet,
            this.btnOutputCover,
            this.btnQuit,
            this.btnChanGen,
            this.btnCfgFPGA,
            this.btnRunFPGA,
            this.btnChanFig});
            this.MainToolMenu.Location = new System.Drawing.Point(0, 25);
            this.MainToolMenu.Name = "MainToolMenu";
            this.MainToolMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MainToolMenu.Size = new System.Drawing.Size(798, 25);
            this.MainToolMenu.TabIndex = 0;
            // 
            // btnSaveCfg
            // 
            this.btnSaveCfg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveCfg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSaveCfg.ForeColor = System.Drawing.Color.Black;
            this.btnSaveCfg.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveCfg.Image")));
            this.btnSaveCfg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveCfg.Name = "btnSaveCfg";
            this.btnSaveCfg.Size = new System.Drawing.Size(23, 22);
            this.btnSaveCfg.Tag = "";
            this.btnSaveCfg.ToolTipText = "保存当前页面配置";
            // 
            // btnLoadCfg
            // 
            this.btnLoadCfg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLoadCfg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLoadCfg.ForeColor = System.Drawing.Color.Black;
            this.btnLoadCfg.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadCfg.Image")));
            this.btnLoadCfg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoadCfg.Name = "btnLoadCfg";
            this.btnLoadCfg.Size = new System.Drawing.Size(23, 22);
            this.btnLoadCfg.Tag = "";
            this.btnLoadCfg.ToolTipText = "载入当前页面配置";
            // 
            // btnOutputSet
            // 
            this.btnOutputSet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOutputSet.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOutputSet.ForeColor = System.Drawing.Color.Black;
            this.btnOutputSet.Image = ((System.Drawing.Image)(resources.GetObject("btnOutputSet.Image")));
            this.btnOutputSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOutputSet.Name = "btnOutputSet";
            this.btnOutputSet.Size = new System.Drawing.Size(23, 22);
            this.btnOutputSet.Tag = "";
            this.btnOutputSet.ToolTipText = "设置文件输出目录";
            this.btnOutputSet.Click += new System.EventHandler(this.输出路径ToolStripMenuItem_Click);
            // 
            // btnOutputCover
            // 
            this.btnOutputCover.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOutputCover.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOutputCover.ForeColor = System.Drawing.Color.Black;
            this.btnOutputCover.Image = global::ChanGenTool.Properties.Resources.checked_checkbox;
            this.btnOutputCover.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOutputCover.Name = "btnOutputCover";
            this.btnOutputCover.Size = new System.Drawing.Size(23, 22);
            this.btnOutputCover.Tag = "";
            this.btnOutputCover.ToolTipText = "设置输出文件是否覆盖上一次运行结果";
            this.btnOutputCover.Click += new System.EventHandler(this.输出覆盖ToolStripMenuItem_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnQuit.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuit.ForeColor = System.Drawing.Color.Black;
            this.btnQuit.Image = ((System.Drawing.Image)(resources.GetObject("btnQuit.Image")));
            this.btnQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(23, 22);
            this.btnQuit.Tag = "";
            this.btnQuit.ToolTipText = "退出程序";
            this.btnQuit.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // btnChanGen
            // 
            this.btnChanGen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnChanGen.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnChanGen.ForeColor = System.Drawing.Color.Black;
            this.btnChanGen.Image = ((System.Drawing.Image)(resources.GetObject("btnChanGen.Image")));
            this.btnChanGen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnChanGen.Name = "btnChanGen";
            this.btnChanGen.Size = new System.Drawing.Size(23, 22);
            this.btnChanGen.Tag = "";
            this.btnChanGen.ToolTipText = "通过信道参数对信道进行仿真";
            this.btnChanGen.Click += new System.EventHandler(this.信道仿真ToolStripMenuItem_Click);
            // 
            // btnCfgFPGA
            // 
            this.btnCfgFPGA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCfgFPGA.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCfgFPGA.ForeColor = System.Drawing.Color.Black;
            this.btnCfgFPGA.Image = ((System.Drawing.Image)(resources.GetObject("btnCfgFPGA.Image")));
            this.btnCfgFPGA.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCfgFPGA.Name = "btnCfgFPGA";
            this.btnCfgFPGA.Size = new System.Drawing.Size(23, 22);
            this.btnCfgFPGA.Tag = "";
            this.btnCfgFPGA.ToolTipText = "配置硬件";
            this.btnCfgFPGA.Click += new System.EventHandler(this.配置硬件ToolStripMenuItem_Click);
            // 
            // btnRunFPGA
            // 
            this.btnRunFPGA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRunFPGA.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRunFPGA.ForeColor = System.Drawing.Color.Black;
            this.btnRunFPGA.Image = global::ChanGenTool.Properties.Resources.runFPGA;
            this.btnRunFPGA.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRunFPGA.Name = "btnRunFPGA";
            this.btnRunFPGA.Size = new System.Drawing.Size(23, 22);
            this.btnRunFPGA.Tag = "";
            this.btnRunFPGA.ToolTipText = "启动或停止设备";
            this.btnRunFPGA.Click += new System.EventHandler(this.启动设备ToolStripMenuItem_Click);
            // 
            // btnChanFig
            // 
            this.btnChanFig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnChanFig.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnChanFig.ForeColor = System.Drawing.Color.Black;
            this.btnChanFig.Image = ((System.Drawing.Image)(resources.GetObject("btnChanFig.Image")));
            this.btnChanFig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnChanFig.Name = "btnChanFig";
            this.btnChanFig.Size = new System.Drawing.Size(23, 22);
            this.btnChanFig.Tag = "";
            this.btnChanFig.ToolTipText = "查看最近一次浏览过的图像";
            this.btnChanFig.Click += new System.EventHandler(this.收发端轨迹ToolStripMenuItem_Click);
            // 
            // statusShow
            // 
            this.statusShow.AutoSize = false;
            this.statusShow.BackColor = System.Drawing.Color.Transparent;
            this.statusShow.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.statusShow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lalOutputPath,
            this.lblDateNow});
            this.statusShow.Location = new System.Drawing.Point(0, 570);
            this.statusShow.Name = "statusShow";
            this.statusShow.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusShow.Size = new System.Drawing.Size(798, 30);
            this.statusShow.SizingGrip = false;
            this.statusShow.TabIndex = 24;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = false;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(70, 25);
            this.lblStatus.Text = "Busy";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lalOutputPath
            // 
            this.lalOutputPath.ActiveLinkColor = System.Drawing.Color.Teal;
            this.lalOutputPath.AutoToolTip = true;
            this.lalOutputPath.BackColor = System.Drawing.Color.Transparent;
            this.lalOutputPath.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lalOutputPath.ForeColor = System.Drawing.Color.Black;
            this.lalOutputPath.IsLink = true;
            this.lalOutputPath.LinkColor = System.Drawing.Color.Black;
            this.lalOutputPath.Name = "lalOutputPath";
            this.lalOutputPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lalOutputPath.Size = new System.Drawing.Size(25, 25);
            this.lalOutputPath.Text = "C:\\";
            this.lalOutputPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lalOutputPath.Click += new System.EventHandler(this.lalWorkPath_Click);
            // 
            // lblDateNow
            // 
            this.lblDateNow.BackColor = System.Drawing.Color.Transparent;
            this.lblDateNow.ForeColor = System.Drawing.Color.Black;
            this.lblDateNow.Name = "lblDateNow";
            this.lblDateNow.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDateNow.Size = new System.Drawing.Size(688, 25);
            this.lblDateNow.Spring = true;
            this.lblDateNow.Text = "2016年09月03日";
            this.lblDateNow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.Transparent;
            this.MainMenu.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.工具ToolStripMenuItem,
            this.画图ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.MainMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MainMenu.Size = new System.Drawing.Size(798, 25);
            this.MainMenu.TabIndex = 37;
            this.MainMenu.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存配置ToolStripMenuItem,
            this.载入配置ToolStripMenuItem,
            this.输出配置ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 保存配置ToolStripMenuItem
            // 
            this.保存配置ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.保存配置ToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.保存配置ToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.保存配置ToolStripMenuItem.Name = "保存配置ToolStripMenuItem";
            this.保存配置ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.保存配置ToolStripMenuItem.Text = "保存配置";
            this.保存配置ToolStripMenuItem.Click += new System.EventHandler(this.全部ToolStripMenuItem_Click);
            // 
            // 载入配置ToolStripMenuItem
            // 
            this.载入配置ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.载入配置ToolStripMenuItem.Name = "载入配置ToolStripMenuItem";
            this.载入配置ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.载入配置ToolStripMenuItem.Text = "载入配置";
            this.载入配置ToolStripMenuItem.Click += new System.EventHandler(this.全部ToolStripMenuItem1_Click);
            // 
            // 输出配置ToolStripMenuItem
            // 
            this.输出配置ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.输出配置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.输出路径ToolStripMenuItem,
            this.输出覆盖ToolStripMenuItem});
            this.输出配置ToolStripMenuItem.Name = "输出配置ToolStripMenuItem";
            this.输出配置ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.输出配置ToolStripMenuItem.Text = "输出配置";
            // 
            // 输出路径ToolStripMenuItem
            // 
            this.输出路径ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.输出路径ToolStripMenuItem.Name = "输出路径ToolStripMenuItem";
            this.输出路径ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.输出路径ToolStripMenuItem.Text = "输出路径";
            this.输出路径ToolStripMenuItem.Click += new System.EventHandler(this.输出路径ToolStripMenuItem_Click);
            // 
            // 输出覆盖ToolStripMenuItem
            // 
            this.输出覆盖ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.输出覆盖ToolStripMenuItem.Checked = true;
            this.输出覆盖ToolStripMenuItem.CheckOnClick = true;
            this.输出覆盖ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.输出覆盖ToolStripMenuItem.Name = "输出覆盖ToolStripMenuItem";
            this.输出覆盖ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.输出覆盖ToolStripMenuItem.Text = "结果覆盖";
            this.输出覆盖ToolStripMenuItem.Click += new System.EventHandler(this.输出覆盖ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 工具ToolStripMenuItem
            // 
            this.工具ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.信道仿真ToolStripMenuItem,
            this.配置硬件ToolStripMenuItem,
            this.启动设备ToolStripMenuItem});
            this.工具ToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.工具ToolStripMenuItem.Text = "运行";
            // 
            // 信道仿真ToolStripMenuItem
            // 
            this.信道仿真ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.信道仿真ToolStripMenuItem.Name = "信道仿真ToolStripMenuItem";
            this.信道仿真ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.信道仿真ToolStripMenuItem.Text = "信道仿真";
            this.信道仿真ToolStripMenuItem.Click += new System.EventHandler(this.信道仿真ToolStripMenuItem_Click);
            // 
            // 配置硬件ToolStripMenuItem
            // 
            this.配置硬件ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.配置硬件ToolStripMenuItem.Name = "配置硬件ToolStripMenuItem";
            this.配置硬件ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.配置硬件ToolStripMenuItem.Text = "配置硬件";
            this.配置硬件ToolStripMenuItem.Click += new System.EventHandler(this.配置硬件ToolStripMenuItem_Click);
            // 
            // 启动设备ToolStripMenuItem
            // 
            this.启动设备ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.启动设备ToolStripMenuItem.Name = "启动设备ToolStripMenuItem";
            this.启动设备ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.启动设备ToolStripMenuItem.Text = "启动设备";
            this.启动设备ToolStripMenuItem.Click += new System.EventHandler(this.启动设备ToolStripMenuItem_Click);
            // 
            // 画图ToolStripMenuItem
            // 
            this.画图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.收发端轨迹ToolStripMenuItem,
            this.天线增益ToolStripMenuItem});
            this.画图ToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.画图ToolStripMenuItem.Name = "画图ToolStripMenuItem";
            this.画图ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.画图ToolStripMenuItem.Text = "画图";
            // 
            // 收发端轨迹ToolStripMenuItem
            // 
            this.收发端轨迹ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.收发端轨迹ToolStripMenuItem.Name = "收发端轨迹ToolStripMenuItem";
            this.收发端轨迹ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.收发端轨迹ToolStripMenuItem.Text = "收发端轨迹";
            this.收发端轨迹ToolStripMenuItem.Click += new System.EventHandler(this.收发端轨迹ToolStripMenuItem_Click);
            // 
            // 天线增益ToolStripMenuItem
            // 
            this.天线增益ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.天线增益ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.发射端ToolStripMenuItem,
            this.接收端ToolStripMenuItem});
            this.天线增益ToolStripMenuItem.Name = "天线增益ToolStripMenuItem";
            this.天线增益ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.天线增益ToolStripMenuItem.Text = "天线增益";
            // 
            // 发射端ToolStripMenuItem
            // 
            this.发射端ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.发射端ToolStripMenuItem.Name = "发射端ToolStripMenuItem";
            this.发射端ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.发射端ToolStripMenuItem.Text = "发射端";
            this.发射端ToolStripMenuItem.Click += new System.EventHandler(this.发射端ToolStripMenuItem_Click);
            // 
            // 接收端ToolStripMenuItem
            // 
            this.接收端ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.接收端ToolStripMenuItem.Name = "接收端ToolStripMenuItem";
            this.接收端ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.接收端ToolStripMenuItem.Text = "接收端";
            this.接收端ToolStripMenuItem.Click += new System.EventHandler(this.接收端ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看帮助ToolStripMenuItem,
            this.关于软件ToolStripMenuItem});
            this.帮助ToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 查看帮助ToolStripMenuItem
            // 
            this.查看帮助ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.查看帮助ToolStripMenuItem.Name = "查看帮助ToolStripMenuItem";
            this.查看帮助ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.查看帮助ToolStripMenuItem.Text = "查看帮助";
            this.查看帮助ToolStripMenuItem.Click += new System.EventHandler(this.查看帮助ToolStripMenuItem_Click);
            // 
            // 关于软件ToolStripMenuItem
            // 
            this.关于软件ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.关于软件ToolStripMenuItem.Name = "关于软件ToolStripMenuItem";
            this.关于软件ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.关于软件ToolStripMenuItem.Text = "关于软件";
            this.关于软件ToolStripMenuItem.Click += new System.EventHandler(this.关于软件ToolStripMenuItem_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.chkAeroAWGN);
            this.groupBox4.Controls.Add(this.txtAeroSNR);
            this.groupBox4.Controls.Add(this.lalAeroSNR);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.groupBox4.ForeColor = System.Drawing.Color.Black;
            this.groupBox4.Location = new System.Drawing.Point(536, 201);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(246, 83);
            this.groupBox4.TabIndex = 113;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "                            ";
            // 
            // chkAeroAWGN
            // 
            this.chkAeroAWGN.AutoSize = true;
            this.chkAeroAWGN.BackColor = System.Drawing.Color.Transparent;
            this.chkAeroAWGN.Location = new System.Drawing.Point(10, 0);
            this.chkAeroAWGN.Name = "chkAeroAWGN";
            this.chkAeroAWGN.Size = new System.Drawing.Size(139, 22);
            this.chkAeroAWGN.TabIndex = 0;
            this.chkAeroAWGN.Text = "加性高斯白噪声";
            this.chkAeroAWGN.UseVisualStyleBackColor = false;
            this.chkAeroAWGN.CheckedChanged += new System.EventHandler(this.chkAWGN_CheckedChanged);
            // 
            // txtAeroSNR
            // 
            this.txtAeroSNR.Enabled = false;
            this.txtAeroSNR.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtAeroSNR.Location = new System.Drawing.Point(119, 35);
            this.txtAeroSNR.Name = "txtAeroSNR";
            this.txtAeroSNR.Size = new System.Drawing.Size(55, 25);
            this.txtAeroSNR.TabIndex = 102;
            this.txtAeroSNR.Text = "5";
            this.txtAeroSNR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAeroSNR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAeroSNR_KeyPress);
            // 
            // lalAeroSNR
            // 
            this.lalAeroSNR.AutoSize = true;
            this.lalAeroSNR.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.lalAeroSNR.ForeColor = System.Drawing.Color.Black;
            this.lalAeroSNR.Location = new System.Drawing.Point(23, 40);
            this.lalAeroSNR.Name = "lalAeroSNR";
            this.lalAeroSNR.Size = new System.Drawing.Size(56, 18);
            this.lalAeroSNR.TabIndex = 101;
            this.lalAeroSNR.Text = "信噪比";
            // 
            // lalAeroUpdateUnit
            // 
            this.lalAeroUpdateUnit.AutoSize = true;
            this.lalAeroUpdateUnit.BackColor = System.Drawing.Color.Transparent;
            this.lalAeroUpdateUnit.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold);
            this.lalAeroUpdateUnit.ForeColor = System.Drawing.Color.Black;
            this.lalAeroUpdateUnit.Location = new System.Drawing.Point(477, 256);
            this.lalAeroUpdateUnit.Name = "lalAeroUpdateUnit";
            this.lalAeroUpdateUnit.Size = new System.Drawing.Size(26, 18);
            this.lalAeroUpdateUnit.TabIndex = 88;
            this.lalAeroUpdateUnit.Text = "ms";
            // 
            // txtAeroUpdate
            // 
            this.txtAeroUpdate.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtAeroUpdate.Location = new System.Drawing.Point(369, 251);
            this.txtAeroUpdate.Name = "txtAeroUpdate";
            this.txtAeroUpdate.Size = new System.Drawing.Size(105, 25);
            this.txtAeroUpdate.TabIndex = 86;
            this.txtAeroUpdate.Text = "10";
            this.txtAeroUpdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAeroUpdate.TextChanged += new System.EventHandler(this.txtLimit_TextChanged);
            this.txtAeroUpdate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInputUFloat_KeyPress);
            // 
            // lalAeroUpdate
            // 
            this.lalAeroUpdate.AutoSize = true;
            this.lalAeroUpdate.BackColor = System.Drawing.Color.Transparent;
            this.lalAeroUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.lalAeroUpdate.ForeColor = System.Drawing.Color.Black;
            this.lalAeroUpdate.Location = new System.Drawing.Point(233, 255);
            this.lalAeroUpdate.Name = "lalAeroUpdate";
            this.lalAeroUpdate.Size = new System.Drawing.Size(104, 18);
            this.lalAeroUpdate.TabIndex = 87;
            this.lalAeroUpdate.Text = "状态更新速率";
            // 
            // lalAeroRecvAnte
            // 
            this.lalAeroRecvAnte.AutoSize = true;
            this.lalAeroRecvAnte.BackColor = System.Drawing.Color.Transparent;
            this.lalAeroRecvAnte.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.lalAeroRecvAnte.ForeColor = System.Drawing.Color.Black;
            this.lalAeroRecvAnte.Location = new System.Drawing.Point(21, 163);
            this.lalAeroRecvAnte.Name = "lalAeroRecvAnte";
            this.lalAeroRecvAnte.Size = new System.Drawing.Size(104, 18);
            this.lalAeroRecvAnte.TabIndex = 83;
            this.lalAeroRecvAnte.Text = "接收天线增益";
            // 
            // lalAeroLaunAnte
            // 
            this.lalAeroLaunAnte.AutoSize = true;
            this.lalAeroLaunAnte.BackColor = System.Drawing.Color.Transparent;
            this.lalAeroLaunAnte.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.lalAeroLaunAnte.ForeColor = System.Drawing.Color.Black;
            this.lalAeroLaunAnte.Location = new System.Drawing.Point(21, 113);
            this.lalAeroLaunAnte.Name = "lalAeroLaunAnte";
            this.lalAeroLaunAnte.Size = new System.Drawing.Size(104, 18);
            this.lalAeroLaunAnte.TabIndex = 82;
            this.lalAeroLaunAnte.Text = "发射天线增益";
            // 
            // lalAeroTrace
            // 
            this.lalAeroTrace.AutoSize = true;
            this.lalAeroTrace.BackColor = System.Drawing.Color.Transparent;
            this.lalAeroTrace.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.lalAeroTrace.ForeColor = System.Drawing.Color.Black;
            this.lalAeroTrace.Location = new System.Drawing.Point(21, 67);
            this.lalAeroTrace.Name = "lalAeroTrace";
            this.lalAeroTrace.Size = new System.Drawing.Size(88, 18);
            this.lalAeroTrace.TabIndex = 1;
            this.lalAeroTrace.Text = "收发端轨迹";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lalAeroStep);
            this.panel1.Controls.Add(this.btnAeroPlay);
            this.panel1.Controls.Add(this.btnAeroForward);
            this.panel1.Controls.Add(this.btnAeroBackward);
            this.panel1.Controls.Add(this.btnAeroStop);
            this.panel1.Controls.Add(this.lalAeroTimes);
            this.panel1.Controls.Add(this.tkbrAeroChan);
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(9, 458);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(774, 56);
            this.panel1.TabIndex = 80;
            // 
            // lalAeroStep
            // 
            this.lalAeroStep.AutoSize = true;
            this.lalAeroStep.BackColor = System.Drawing.Color.Transparent;
            this.lalAeroStep.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.lalAeroStep.ForeColor = System.Drawing.Color.Black;
            this.lalAeroStep.Location = new System.Drawing.Point(145, 29);
            this.lalAeroStep.Name = "lalAeroStep";
            this.lalAeroStep.Size = new System.Drawing.Size(23, 17);
            this.lalAeroStep.TabIndex = 86;
            this.lalAeroStep.Text = "X1";
            this.lalAeroStep.TextChanged += new System.EventHandler(this.lalAeroStep_TextChanged);
            // 
            // btnAeroPlay
            // 
            this.btnAeroPlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAeroPlay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAeroPlay.BackgroundImage")));
            this.btnAeroPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAeroPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAeroPlay.Enabled = false;
            this.btnAeroPlay.FlatAppearance.BorderSize = 0;
            this.btnAeroPlay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAeroPlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAeroPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAeroPlay.Font = new System.Drawing.Font("Calibri", 10.8F);
            this.btnAeroPlay.ForeColor = System.Drawing.Color.Black;
            this.btnAeroPlay.Location = new System.Drawing.Point(18, 26);
            this.btnAeroPlay.Margin = new System.Windows.Forms.Padding(0);
            this.btnAeroPlay.Name = "btnAeroPlay";
            this.btnAeroPlay.Size = new System.Drawing.Size(25, 25);
            this.btnAeroPlay.TabIndex = 85;
            this.btnAeroPlay.TabStop = false;
            this.TipShow.SetToolTip(this.btnAeroPlay, "播放/暂停");
            this.btnAeroPlay.UseVisualStyleBackColor = false;
            this.btnAeroPlay.Click += new System.EventHandler(this.btnAChanPlay_Click);
            // 
            // btnAeroForward
            // 
            this.btnAeroForward.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAeroForward.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAeroForward.BackgroundImage")));
            this.btnAeroForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAeroForward.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAeroForward.Enabled = false;
            this.btnAeroForward.FlatAppearance.BorderSize = 0;
            this.btnAeroForward.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAeroForward.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAeroForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAeroForward.Font = new System.Drawing.Font("Calibri", 10.8F);
            this.btnAeroForward.ForeColor = System.Drawing.Color.Black;
            this.btnAeroForward.Location = new System.Drawing.Point(111, 26);
            this.btnAeroForward.Name = "btnAeroForward";
            this.btnAeroForward.Size = new System.Drawing.Size(25, 25);
            this.btnAeroForward.TabIndex = 84;
            this.btnAeroForward.TabStop = false;
            this.TipShow.SetToolTip(this.btnAeroForward, "快放");
            this.btnAeroForward.UseVisualStyleBackColor = false;
            this.btnAeroForward.Click += new System.EventHandler(this.btnAeroPlaySpeedCtrl_Click);
            // 
            // btnAeroBackward
            // 
            this.btnAeroBackward.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAeroBackward.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAeroBackward.BackgroundImage")));
            this.btnAeroBackward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAeroBackward.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAeroBackward.Enabled = false;
            this.btnAeroBackward.FlatAppearance.BorderSize = 0;
            this.btnAeroBackward.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAeroBackward.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAeroBackward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAeroBackward.Font = new System.Drawing.Font("Calibri", 10.8F);
            this.btnAeroBackward.ForeColor = System.Drawing.Color.Black;
            this.btnAeroBackward.Location = new System.Drawing.Point(80, 26);
            this.btnAeroBackward.Name = "btnAeroBackward";
            this.btnAeroBackward.Size = new System.Drawing.Size(25, 25);
            this.btnAeroBackward.TabIndex = 83;
            this.btnAeroBackward.TabStop = false;
            this.TipShow.SetToolTip(this.btnAeroBackward, "慢放");
            this.btnAeroBackward.UseVisualStyleBackColor = false;
            this.btnAeroBackward.Click += new System.EventHandler(this.btnAeroPlaySpeedCtrl_Click);
            // 
            // btnAeroStop
            // 
            this.btnAeroStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAeroStop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAeroStop.BackgroundImage")));
            this.btnAeroStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAeroStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAeroStop.Enabled = false;
            this.btnAeroStop.FlatAppearance.BorderSize = 0;
            this.btnAeroStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAeroStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAeroStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAeroStop.Font = new System.Drawing.Font("Calibri", 10.8F);
            this.btnAeroStop.ForeColor = System.Drawing.Color.Black;
            this.btnAeroStop.Location = new System.Drawing.Point(49, 26);
            this.btnAeroStop.Name = "btnAeroStop";
            this.btnAeroStop.Size = new System.Drawing.Size(25, 25);
            this.btnAeroStop.TabIndex = 82;
            this.btnAeroStop.TabStop = false;
            this.TipShow.SetToolTip(this.btnAeroStop, "停止");
            this.btnAeroStop.UseVisualStyleBackColor = false;
            this.btnAeroStop.Click += new System.EventHandler(this.btnAChanStop_Click);
            // 
            // lalAeroTimes
            // 
            this.lalAeroTimes.BackColor = System.Drawing.Color.Transparent;
            this.lalAeroTimes.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.lalAeroTimes.ForeColor = System.Drawing.Color.Black;
            this.lalAeroTimes.Location = new System.Drawing.Point(402, 29);
            this.lalAeroTimes.Name = "lalAeroTimes";
            this.lalAeroTimes.Size = new System.Drawing.Size(355, 21);
            this.lalAeroTimes.TabIndex = 81;
            this.lalAeroTimes.Text = "0.000/99.999";
            this.lalAeroTimes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tkbrAeroChan
            // 
            this.tkbrAeroChan.AutoSize = false;
            this.tkbrAeroChan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tkbrAeroChan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tkbrAeroChan.Enabled = false;
            this.tkbrAeroChan.Location = new System.Drawing.Point(7, -1);
            this.tkbrAeroChan.Margin = new System.Windows.Forms.Padding(0);
            this.tkbrAeroChan.Maximum = 1000;
            this.tkbrAeroChan.Name = "tkbrAeroChan";
            this.tkbrAeroChan.Size = new System.Drawing.Size(761, 28);
            this.tkbrAeroChan.TabIndex = 76;
            this.tkbrAeroChan.TabStop = false;
            this.tkbrAeroChan.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tkbrAeroChan.ValueChanged += new System.EventHandler(this.tkbrAeroChan_ValueChanged);
            // 
            // btnAeroRecvAnte
            // 
            this.btnAeroRecvAnte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAeroRecvAnte.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAeroRecvAnte.ForeColor = System.Drawing.Color.Black;
            this.btnAeroRecvAnte.Location = new System.Drawing.Point(443, 151);
            this.btnAeroRecvAnte.Name = "btnAeroRecvAnte";
            this.btnAeroRecvAnte.Size = new System.Drawing.Size(37, 37);
            this.btnAeroRecvAnte.TabIndex = 74;
            this.btnAeroRecvAnte.TabStop = false;
            this.btnAeroRecvAnte.Text = "...";
            this.btnAeroRecvAnte.UseVisualStyleBackColor = false;
            this.btnAeroRecvAnte.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // btnAeroLaunAnte
            // 
            this.btnAeroLaunAnte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAeroLaunAnte.Font = new System.Drawing.Font("Calibri", 10.8F);
            this.btnAeroLaunAnte.ForeColor = System.Drawing.Color.Black;
            this.btnAeroLaunAnte.Location = new System.Drawing.Point(443, 103);
            this.btnAeroLaunAnte.Name = "btnAeroLaunAnte";
            this.btnAeroLaunAnte.Size = new System.Drawing.Size(37, 37);
            this.btnAeroLaunAnte.TabIndex = 73;
            this.btnAeroLaunAnte.TabStop = false;
            this.btnAeroLaunAnte.Text = "...";
            this.btnAeroLaunAnte.UseVisualStyleBackColor = false;
            this.btnAeroLaunAnte.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // txtAeroRecvAnte
            // 
            this.txtAeroRecvAnte.AllowDrop = true;
            this.errorShow.SetError(this.txtAeroRecvAnte, "文件不存在");
            this.txtAeroRecvAnte.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtAeroRecvAnte.Location = new System.Drawing.Point(167, 157);
            this.txtAeroRecvAnte.Name = "txtAeroRecvAnte";
            this.txtAeroRecvAnte.Size = new System.Drawing.Size(270, 25);
            this.txtAeroRecvAnte.TabIndex = 4;
            this.txtAeroRecvAnte.TextChanged += new System.EventHandler(this.txtFileExist_TextChanged);
            this.txtAeroRecvAnte.DragDrop += new System.Windows.Forms.DragEventHandler(this.fileDrag_DragDrop);
            this.txtAeroRecvAnte.DragEnter += new System.Windows.Forms.DragEventHandler(this.fileDrag_DragEnter);
            // 
            // txtAeroLaunAnte
            // 
            this.txtAeroLaunAnte.AllowDrop = true;
            this.errorShow.SetError(this.txtAeroLaunAnte, "文件不存在");
            this.txtAeroLaunAnte.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtAeroLaunAnte.Location = new System.Drawing.Point(167, 108);
            this.txtAeroLaunAnte.Name = "txtAeroLaunAnte";
            this.txtAeroLaunAnte.Size = new System.Drawing.Size(270, 25);
            this.txtAeroLaunAnte.TabIndex = 3;
            this.txtAeroLaunAnte.TextChanged += new System.EventHandler(this.txtFileExist_TextChanged);
            this.txtAeroLaunAnte.DragDrop += new System.Windows.Forms.DragEventHandler(this.fileDrag_DragDrop);
            this.txtAeroLaunAnte.DragEnter += new System.Windows.Forms.DragEventHandler(this.fileDrag_DragEnter);
            // 
            // grpAeroEnv
            // 
            this.grpAeroEnv.BackColor = System.Drawing.Color.Transparent;
            this.grpAeroEnv.Controls.Add(this.cboAeroRefEnv);
            this.grpAeroEnv.Controls.Add(this.lalAeroRefEnv);
            this.grpAeroEnv.Controls.Add(this.cboAeroRefMod);
            this.grpAeroEnv.Controls.Add(this.lalAeroRefMod);
            this.grpAeroEnv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.grpAeroEnv.ForeColor = System.Drawing.Color.Black;
            this.grpAeroEnv.Location = new System.Drawing.Point(521, 62);
            this.grpAeroEnv.Name = "grpAeroEnv";
            this.grpAeroEnv.Size = new System.Drawing.Size(267, 124);
            this.grpAeroEnv.TabIndex = 60;
            this.grpAeroEnv.TabStop = false;
            this.grpAeroEnv.Text = "地面特性";
            // 
            // cboAeroRefEnv
            // 
            this.cboAeroRefEnv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cboAeroRefEnv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAeroRefEnv.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboAeroRefEnv.ForeColor = System.Drawing.Color.Black;
            this.cboAeroRefEnv.FormattingEnabled = true;
            this.cboAeroRefEnv.Items.AddRange(new object[] {
            "郊区",
            "城市",
            "森林",
            "海洋",
            "自定义"});
            this.cboAeroRefEnv.Location = new System.Drawing.Point(132, 30);
            this.cboAeroRefEnv.Name = "cboAeroRefEnv";
            this.cboAeroRefEnv.Size = new System.Drawing.Size(92, 25);
            this.cboAeroRefEnv.TabIndex = 12;
            this.cboAeroRefEnv.SelectedIndexChanged += new System.EventHandler(this.cboRefEnv_SelectedIndexChanged);
            this.cboAeroRefEnv.SelectionChangeCommitted += new System.EventHandler(this.cboAeroRefEnv_SelectionChangeCommitted);
            // 
            // lalAeroRefEnv
            // 
            this.lalAeroRefEnv.AutoSize = true;
            this.lalAeroRefEnv.ForeColor = System.Drawing.Color.Black;
            this.lalAeroRefEnv.Location = new System.Drawing.Point(25, 35);
            this.lalAeroRefEnv.Name = "lalAeroRefEnv";
            this.lalAeroRefEnv.Size = new System.Drawing.Size(72, 18);
            this.lalAeroRefEnv.TabIndex = 67;
            this.lalAeroRefEnv.Text = "散射环境";
            // 
            // cboAeroRefMod
            // 
            this.cboAeroRefMod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cboAeroRefMod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAeroRefMod.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboAeroRefMod.ForeColor = System.Drawing.Color.Black;
            this.cboAeroRefMod.FormattingEnabled = true;
            this.cboAeroRefMod.Items.AddRange(new object[] {
            "干燥地面",
            "中等地面",
            "潮湿地面"});
            this.cboAeroRefMod.Location = new System.Drawing.Point(132, 77);
            this.cboAeroRefMod.Name = "cboAeroRefMod";
            this.cboAeroRefMod.Size = new System.Drawing.Size(107, 25);
            this.cboAeroRefMod.TabIndex = 9;
            this.cboAeroRefMod.SelectedIndexChanged += new System.EventHandler(this.cboRefMed_SelectedIndexChanged);
            // 
            // lalAeroRefMod
            // 
            this.lalAeroRefMod.AutoSize = true;
            this.lalAeroRefMod.ForeColor = System.Drawing.Color.Black;
            this.lalAeroRefMod.Location = new System.Drawing.Point(25, 81);
            this.lalAeroRefMod.Name = "lalAeroRefMod";
            this.lalAeroRefMod.Size = new System.Drawing.Size(72, 18);
            this.lalAeroRefMod.TabIndex = 43;
            this.lalAeroRefMod.Text = "反射媒质";
            // 
            // txtAeroCarrierFre
            // 
            this.txtAeroCarrierFre.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAeroCarrierFre.Location = new System.Drawing.Point(332, 204);
            this.txtAeroCarrierFre.Name = "txtAeroCarrierFre";
            this.txtAeroCarrierFre.Size = new System.Drawing.Size(105, 25);
            this.txtAeroCarrierFre.TabIndex = 7;
            this.txtAeroCarrierFre.Text = "100";
            this.txtAeroCarrierFre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAeroCarrierFre.TextChanged += new System.EventHandler(this.txtLimit_TextChanged);
            this.txtAeroCarrierFre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInputUFloat_KeyPress);
            // 
            // lalAeroCarrierFre
            // 
            this.lalAeroCarrierFre.AutoSize = true;
            this.lalAeroCarrierFre.BackColor = System.Drawing.Color.Transparent;
            this.lalAeroCarrierFre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.lalAeroCarrierFre.ForeColor = System.Drawing.Color.Black;
            this.lalAeroCarrierFre.Location = new System.Drawing.Point(231, 208);
            this.lalAeroCarrierFre.Name = "lalAeroCarrierFre";
            this.lalAeroCarrierFre.Size = new System.Drawing.Size(72, 18);
            this.lalAeroCarrierFre.TabIndex = 53;
            this.lalAeroCarrierFre.Text = "载波频率";
            // 
            // cboAeroCarrierFre
            // 
            this.cboAeroCarrierFre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cboAeroCarrierFre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAeroCarrierFre.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboAeroCarrierFre.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold);
            this.cboAeroCarrierFre.ForeColor = System.Drawing.Color.Black;
            this.cboAeroCarrierFre.FormattingEnabled = true;
            this.cboAeroCarrierFre.Items.AddRange(new object[] {
            "GHz",
            "MHz",
            "KHz",
            "Hz"});
            this.cboAeroCarrierFre.Location = new System.Drawing.Point(441, 204);
            this.cboAeroCarrierFre.Name = "cboAeroCarrierFre";
            this.cboAeroCarrierFre.Size = new System.Drawing.Size(62, 25);
            this.cboAeroCarrierFre.TabIndex = 8;
            // 
            // lalAeroCommuScnr
            // 
            this.lalAeroCommuScnr.AutoSize = true;
            this.lalAeroCommuScnr.BackColor = System.Drawing.Color.Transparent;
            this.lalAeroCommuScnr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.lalAeroCommuScnr.ForeColor = System.Drawing.Color.Black;
            this.lalAeroCommuScnr.Location = new System.Drawing.Point(21, 208);
            this.lalAeroCommuScnr.Name = "lalAeroCommuScnr";
            this.lalAeroCommuScnr.Size = new System.Drawing.Size(72, 18);
            this.lalAeroCommuScnr.TabIndex = 59;
            this.lalAeroCommuScnr.Text = "信道模型";
            // 
            // cboAeroCommuScnr
            // 
            this.cboAeroCommuScnr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cboAeroCommuScnr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAeroCommuScnr.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboAeroCommuScnr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.cboAeroCommuScnr.ForeColor = System.Drawing.Color.Black;
            this.cboAeroCommuScnr.FormattingEnabled = true;
            this.cboAeroCommuScnr.Items.AddRange(new object[] {
            "空-空",
            "空-地",
            "地-空"});
            this.cboAeroCommuScnr.Location = new System.Drawing.Point(123, 205);
            this.cboAeroCommuScnr.Name = "cboAeroCommuScnr";
            this.cboAeroCommuScnr.Size = new System.Drawing.Size(84, 25);
            this.cboAeroCommuScnr.TabIndex = 5;
            // 
            // lalAeroPolar
            // 
            this.lalAeroPolar.AutoSize = true;
            this.lalAeroPolar.BackColor = System.Drawing.Color.Transparent;
            this.lalAeroPolar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.lalAeroPolar.ForeColor = System.Drawing.Color.Black;
            this.lalAeroPolar.Location = new System.Drawing.Point(21, 255);
            this.lalAeroPolar.Name = "lalAeroPolar";
            this.lalAeroPolar.Size = new System.Drawing.Size(72, 18);
            this.lalAeroPolar.TabIndex = 63;
            this.lalAeroPolar.Text = "极化方式";
            // 
            // cboAeroPolar
            // 
            this.cboAeroPolar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cboAeroPolar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAeroPolar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboAeroPolar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.cboAeroPolar.ForeColor = System.Drawing.Color.Black;
            this.cboAeroPolar.FormattingEnabled = true;
            this.cboAeroPolar.Items.AddRange(new object[] {
            "水平极化",
            "垂直极化"});
            this.cboAeroPolar.Location = new System.Drawing.Point(123, 252);
            this.cboAeroPolar.Name = "cboAeroPolar";
            this.cboAeroPolar.Size = new System.Drawing.Size(105, 25);
            this.cboAeroPolar.TabIndex = 6;
            // 
            // btnAeroTrace
            // 
            this.btnAeroTrace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAeroTrace.Font = new System.Drawing.Font("Calibri", 10.8F);
            this.btnAeroTrace.ForeColor = System.Drawing.Color.Black;
            this.btnAeroTrace.Location = new System.Drawing.Point(443, 57);
            this.btnAeroTrace.Name = "btnAeroTrace";
            this.btnAeroTrace.Size = new System.Drawing.Size(37, 37);
            this.btnAeroTrace.TabIndex = 58;
            this.btnAeroTrace.TabStop = false;
            this.btnAeroTrace.Text = "...";
            this.btnAeroTrace.UseVisualStyleBackColor = false;
            this.btnAeroTrace.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // txtAeroTrace
            // 
            this.txtAeroTrace.AllowDrop = true;
            this.errorShow.SetError(this.txtAeroTrace, "文件不存在");
            this.txtAeroTrace.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtAeroTrace.Location = new System.Drawing.Point(168, 62);
            this.txtAeroTrace.Name = "txtAeroTrace";
            this.txtAeroTrace.Size = new System.Drawing.Size(269, 25);
            this.txtAeroTrace.TabIndex = 2;
            this.txtAeroTrace.TextChanged += new System.EventHandler(this.txtFileExist_TextChanged);
            this.txtAeroTrace.DragDrop += new System.Windows.Forms.DragEventHandler(this.fileDrag_DragDrop);
            this.txtAeroTrace.DragEnter += new System.Windows.Forms.DragEventHandler(this.fileDrag_DragEnter);
            // 
            // dgvAeroChan
            // 
            this.dgvAeroChan.AllowDrop = true;
            this.dgvAeroChan.AllowUserToAddRows = false;
            this.dgvAeroChan.AllowUserToDeleteRows = false;
            this.dgvAeroChan.AllowUserToResizeRows = false;
            this.dgvAeroChan.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.dgvAeroChan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAeroChan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAeroChan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAeroChan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAeroDelay,
            this.colAeroDoppler,
            this.colAeroGain,
            this.colAeroAOA,
            this.colAeroEOA});
            this.dgvAeroChan.ContextMenuStrip = this.tabAeroMenu;
            this.dgvAeroChan.EnableHeadersVisualStyles = false;
            this.dgvAeroChan.GridColor = System.Drawing.Color.Teal;
            this.dgvAeroChan.Location = new System.Drawing.Point(11, 290);
            this.dgvAeroChan.Name = "dgvAeroChan";
            this.dgvAeroChan.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAeroChan.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvAeroChan.RowHeadersWidth = 117;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.NullValue = "N/A";
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvAeroChan.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvAeroChan.RowTemplate.Height = 30;
            this.dgvAeroChan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAeroChan.Size = new System.Drawing.Size(774, 164);
            this.dgvAeroChan.TabIndex = 1;
            this.dgvAeroChan.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvAeroChan_RowsAdded);
            this.dgvAeroChan.DragDrop += new System.Windows.Forms.DragEventHandler(this.fileDrag_DragDrop);
            this.dgvAeroChan.DragEnter += new System.Windows.Forms.DragEventHandler(this.fileDrag_DragEnter);
            // 
            // colAeroDelay
            // 
            this.colAeroDelay.HeaderText = "时延(us)";
            this.colAeroDelay.Name = "colAeroDelay";
            this.colAeroDelay.ReadOnly = true;
            this.colAeroDelay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAeroDelay.Width = 130;
            // 
            // colAeroDoppler
            // 
            this.colAeroDoppler.HeaderText = "多普勒频率(Hz)";
            this.colAeroDoppler.Name = "colAeroDoppler";
            this.colAeroDoppler.ReadOnly = true;
            this.colAeroDoppler.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAeroDoppler.Width = 137;
            // 
            // colAeroGain
            // 
            this.colAeroGain.HeaderText = "增益(dB)";
            this.colAeroGain.Name = "colAeroGain";
            this.colAeroGain.ReadOnly = true;
            this.colAeroGain.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAeroGain.Width = 130;
            // 
            // colAeroAOA
            // 
            this.colAeroAOA.HeaderText = "到达角(rad)";
            this.colAeroAOA.Name = "colAeroAOA";
            this.colAeroAOA.ReadOnly = true;
            this.colAeroAOA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAeroAOA.Width = 130;
            // 
            // colAeroEOA
            // 
            this.colAeroEOA.HeaderText = "俯仰角(rad)";
            this.colAeroEOA.Name = "colAeroEOA";
            this.colAeroEOA.ReadOnly = true;
            this.colAeroEOA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAeroEOA.Width = 130;
            // 
            // tabAeroMenu
            // 
            this.tabAeroMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tabAeroMenu.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabAeroMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.载入文件ToolStripMenuItem,
            this.打开目录ToolStripMenuItem});
            this.tabAeroMenu.Name = "tabMenu";
            this.tabAeroMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tabAeroMenu.Size = new System.Drawing.Size(125, 48);
            // 
            // 载入文件ToolStripMenuItem
            // 
            this.载入文件ToolStripMenuItem.Name = "载入文件ToolStripMenuItem";
            this.载入文件ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.载入文件ToolStripMenuItem.Text = "载入文件";
            this.载入文件ToolStripMenuItem.Click += new System.EventHandler(this.载入文件ToolStripMenuItem_Click);
            // 
            // 打开目录ToolStripMenuItem
            // 
            this.打开目录ToolStripMenuItem.Name = "打开目录ToolStripMenuItem";
            this.打开目录ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.打开目录ToolStripMenuItem.Text = "打开目录";
            this.打开目录ToolStripMenuItem.Click += new System.EventHandler(this.打开目录ToolStripMenuItem_Click);
            // 
            // tabGeneMenu
            // 
            this.tabGeneMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tabGeneMenu.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabGeneMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.保存ToolStripMenuItem,
            this.载入ToolStripMenuItem});
            this.tabGeneMenu.Name = "tabMenu";
            this.tabGeneMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tabGeneMenu.Size = new System.Drawing.Size(101, 92);
            this.tabGeneMenu.Opening += new System.ComponentModel.CancelEventHandler(this.tabMenu_Opening);
            // 
            // 添加ToolStripMenuItem
            // 
            this.添加ToolStripMenuItem.Name = "添加ToolStripMenuItem";
            this.添加ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.添加ToolStripMenuItem.Text = "添加";
            this.添加ToolStripMenuItem.Click += new System.EventHandler(this.添加ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 载入ToolStripMenuItem
            // 
            this.载入ToolStripMenuItem.Name = "载入ToolStripMenuItem";
            this.载入ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.载入ToolStripMenuItem.Text = "载入";
            this.载入ToolStripMenuItem.Click += new System.EventHandler(this.载入ToolStripMenuItem_Click);
            // 
            // TipShow
            // 
            this.TipShow.ShowAlways = true;
            // 
            // errorShow
            // 
            this.errorShow.BlinkRate = 0;
            this.errorShow.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorShow.ContainerControl = this;
            this.errorShow.RightToLeft = true;
            // 
            // picNUAA
            // 
            this.picNUAA.BackColor = System.Drawing.Color.Transparent;
            this.picNUAA.Image = ((System.Drawing.Image)(resources.GetObject("picNUAA.Image")));
            this.picNUAA.Location = new System.Drawing.Point(685, 0);
            this.picNUAA.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.picNUAA.Name = "picNUAA";
            this.picNUAA.Size = new System.Drawing.Size(53, 53);
            this.picNUAA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picNUAA.TabIndex = 117;
            this.picNUAA.TabStop = false;
            // 
            // picCEIE
            // 
            this.picCEIE.BackColor = System.Drawing.Color.Transparent;
            this.picCEIE.Image = ((System.Drawing.Image)(resources.GetObject("picCEIE.Image")));
            this.picCEIE.Location = new System.Drawing.Point(740, 0);
            this.picCEIE.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.picCEIE.Name = "picCEIE";
            this.picCEIE.Size = new System.Drawing.Size(53, 53);
            this.picCEIE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCEIE.TabIndex = 117;
            this.picCEIE.TabStop = false;
            // 
            // bgwMatlabInit
            // 
            this.bgwMatlabInit.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwMatlabInit_DoWork);
            this.bgwMatlabInit.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwMatlabInit_RunWorkerCompleted);
            // 
            // bgwMatlabFig
            // 
            this.bgwMatlabFig.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwMatlabFig_DoWork);
            this.bgwMatlabFig.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwMatlabFig_RunWorkerCompleted);
            // 
            // bgwMatlabGen
            // 
            this.bgwMatlabGen.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwMatlabGen_DoWork);
            this.bgwMatlabGen.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwMatlabGen_RunWorkerCompleted);
            // 
            // tmrAeroPlay
            // 
            this.tmrAeroPlay.Interval = 1000;
            this.tmrAeroPlay.Tick += new System.EventHandler(this.tmrAeroPlay_Tick);
            // 
            // bgwDmaTransfer
            // 
            this.bgwDmaTransfer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwDmaTransfer_DoWork);
            this.bgwDmaTransfer.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwDmaTransfer_RunWorkerCompleted);
            // 
            // pageAeroChan
            // 
            this.pageAeroChan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pageAeroChan.BackgroundImage")));
            this.pageAeroChan.Controls.Add(this.groupBox4);
            this.pageAeroChan.Controls.Add(this.cboxSignalType);
            this.pageAeroChan.Controls.Add(this.txtAeroTrace);
            this.pageAeroChan.Controls.Add(this.lalAeroUpdateUnit);
            this.pageAeroChan.Controls.Add(this.dgvAeroChan);
            this.pageAeroChan.Controls.Add(this.txtAeroUpdate);
            this.pageAeroChan.Controls.Add(this.btnAeroTrace);
            this.pageAeroChan.Controls.Add(this.lalAeroUpdate);
            this.pageAeroChan.Controls.Add(this.cboAeroPolar);
            this.pageAeroChan.Controls.Add(this.lalAeroRecvAnte);
            this.pageAeroChan.Controls.Add(this.lalAeroPolar);
            this.pageAeroChan.Controls.Add(this.lalAeroLaunAnte);
            this.pageAeroChan.Controls.Add(this.cboAeroCommuScnr);
            this.pageAeroChan.Controls.Add(this.lalAeroTrace);
            this.pageAeroChan.Controls.Add(this.lalAeroCommuScnr);
            this.pageAeroChan.Controls.Add(this.panel1);
            this.pageAeroChan.Controls.Add(this.cboAeroCarrierFre);
            this.pageAeroChan.Controls.Add(this.btnAeroRecvAnte);
            this.pageAeroChan.Controls.Add(this.lalSignalType);
            this.pageAeroChan.Controls.Add(this.lalAeroCarrierFre);
            this.pageAeroChan.Controls.Add(this.btnAeroLaunAnte);
            this.pageAeroChan.Controls.Add(this.txtAeroCarrierFre);
            this.pageAeroChan.Controls.Add(this.txtAeroRecvAnte);
            this.pageAeroChan.Controls.Add(this.grpAeroEnv);
            this.pageAeroChan.Controls.Add(this.txtAeroLaunAnte);
            this.pageAeroChan.Location = new System.Drawing.Point(5, 53);
            this.pageAeroChan.Name = "pageAeroChan";
            this.pageAeroChan.Size = new System.Drawing.Size(788, 517);
            this.pageAeroChan.TabIndex = 118;
            // 
            // cboxSignalType
            // 
            this.cboxSignalType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cboxSignalType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSignalType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboxSignalType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.cboxSignalType.ForeColor = System.Drawing.Color.Black;
            this.cboxSignalType.FormattingEnabled = true;
            this.cboxSignalType.Items.AddRange(new object[] {
            "单音",
            "双音",
            "脉冲",
            "QPSK",
            "16QAM"});
            this.cboxSignalType.Location = new System.Drawing.Point(98, 18);
            this.cboxSignalType.Name = "cboxSignalType";
            this.cboxSignalType.Size = new System.Drawing.Size(120, 25);
            this.cboxSignalType.TabIndex = 122;
            this.cboxSignalType.SelectedIndexChanged += new System.EventHandler(this.cboxSignalType_SelectedIndexChanged);
            // 
            // lalSignalType
            // 
            this.lalSignalType.AutoSize = true;
            this.lalSignalType.BackColor = System.Drawing.Color.Transparent;
            this.lalSignalType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.lalSignalType.ForeColor = System.Drawing.Color.Black;
            this.lalSignalType.Location = new System.Drawing.Point(20, 22);
            this.lalSignalType.Name = "lalSignalType";
            this.lalSignalType.Size = new System.Drawing.Size(72, 18);
            this.lalSignalType.TabIndex = 114;
            this.lalSignalType.Text = "信号类型";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(185, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 18);
            this.label1.TabIndex = 103;
            this.label1.Text = "dB";
            // 
            // ChanGenTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(798, 600);
            this.ControlBox = false;
            this.Controls.Add(this.pageAeroChan);
            this.Controls.Add(this.picCEIE);
            this.Controls.Add(this.picNUAA);
            this.Controls.Add(this.statusShow);
            this.Controls.Add(this.MainToolMenu);
            this.Controls.Add(this.MainMenu);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.Name = "ChanGenTool";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "信道建模与仿真软件";
            this.Load += new System.EventHandler(this.ChanGenTool_Load);
            this.MainToolMenu.ResumeLayout(false);
            this.MainToolMenu.PerformLayout();
            this.statusShow.ResumeLayout(false);
            this.statusShow.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbrAeroChan)).EndInit();
            this.grpAeroEnv.ResumeLayout(false);
            this.grpAeroEnv.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAeroChan)).EndInit();
            this.tabAeroMenu.ResumeLayout(false);
            this.tabGeneMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNUAA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCEIE)).EndInit();
            this.pageAeroChan.ResumeLayout(false);
            this.pageAeroChan.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip MainToolMenu;
        private System.Windows.Forms.ToolStripButton btnLoadCfg;
        private System.Windows.Forms.ToolStripButton btnSaveCfg;
        private System.Windows.Forms.ToolStripButton btnQuit;
        private System.Windows.Forms.ToolStripButton btnChanGen;
        private System.Windows.Forms.ToolStripButton btnRunFPGA;
        private System.Windows.Forms.StatusStrip statusShow;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblDateNow;
        private System.Windows.Forms.ToolStripButton btnChanFig;
        private System.Windows.Forms.ToolStripButton btnCfgFPGA;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 载入配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 启动设备ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 信道仿真ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 配置硬件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 画图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于软件ToolStripMenuItem;
        private System.Windows.Forms.Button btnAeroRecvAnte;
        private System.Windows.Forms.Button btnAeroLaunAnte;
        private System.Windows.Forms.TextBox txtAeroRecvAnte;
        private System.Windows.Forms.TextBox txtAeroLaunAnte;
        private System.Windows.Forms.GroupBox grpAeroEnv;
        private System.Windows.Forms.ComboBox cboAeroRefMod;
        private System.Windows.Forms.Label lalAeroRefMod;
        private System.Windows.Forms.TextBox txtAeroCarrierFre;
        private System.Windows.Forms.Label lalAeroCarrierFre;
        private System.Windows.Forms.ComboBox cboAeroCarrierFre;
        private System.Windows.Forms.Label lalAeroCommuScnr;
        private System.Windows.Forms.ComboBox cboAeroCommuScnr;
        private System.Windows.Forms.Label lalAeroPolar;
        private System.Windows.Forms.ComboBox cboAeroPolar;
        private System.Windows.Forms.Button btnAeroTrace;
        private System.Windows.Forms.TextBox txtAeroTrace;
        private System.Windows.Forms.DataGridView dgvAeroChan;
        private System.Windows.Forms.ToolStripMenuItem 收发端轨迹ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 天线增益ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 发射端ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 接收端ToolStripMenuItem;
        private System.Windows.Forms.TrackBar tkbrAeroChan;
        private System.Windows.Forms.ToolStripStatusLabel lalOutputPath;
        private System.Windows.Forms.ToolTip TipShow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lalAeroTimes;
        private System.Windows.Forms.Button btnAeroForward;
        private System.Windows.Forms.Button btnAeroBackward;
        private System.Windows.Forms.Button btnAeroStop;
        private System.Windows.Forms.Button btnAeroPlay;
        private System.Windows.Forms.Label lalAeroStep;
        private System.Windows.Forms.Label lalAeroTrace;
        private System.Windows.Forms.Label lalAeroLaunAnte;
        private System.Windows.Forms.Label lalAeroRecvAnte;
        private System.Windows.Forms.ToolStripButton btnOutputSet;
        private System.Windows.Forms.ToolStripMenuItem 输出配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 输出路径ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 输出覆盖ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnOutputCover;
        private System.Windows.Forms.ComboBox cboAeroRefEnv;
        private System.Windows.Forms.Label lalAeroRefEnv;
        private System.Windows.Forms.ContextMenuStrip tabGeneMenu;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 载入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ErrorProvider errorShow;
        private System.Windows.Forms.PictureBox picNUAA;
        private System.Windows.Forms.PictureBox picCEIE;
        private System.Windows.Forms.Label lalAeroUpdateUnit;
        private System.Windows.Forms.TextBox txtAeroUpdate;
        private System.Windows.Forms.Label lalAeroUpdate;
        private System.ComponentModel.BackgroundWorker bgwMatlabInit;
        private System.ComponentModel.BackgroundWorker bgwMatlabFig;
        private System.ComponentModel.BackgroundWorker bgwMatlabGen;
        private System.Windows.Forms.Timer tmrAeroPlay;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkAeroAWGN;
        private System.Windows.Forms.TextBox txtAeroSNR;
        private System.Windows.Forms.Label lalAeroSNR;
        private System.Windows.Forms.ContextMenuStrip tabAeroMenu;
        private System.Windows.Forms.ToolStripMenuItem 载入文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开目录ToolStripMenuItem;
        private System.Windows.Forms.Panel pageAeroChan;
        private System.Windows.Forms.ComboBox cboxSignalType;
        private System.Windows.Forms.Label lalSignalType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAeroDelay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAeroDoppler;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAeroGain;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAeroAOA;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAeroEOA;
        public System.ComponentModel.BackgroundWorker bgwDmaTransfer;
        private System.Windows.Forms.Label label1;
    }
}

