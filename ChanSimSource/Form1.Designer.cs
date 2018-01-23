namespace ChanSimSource
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.chkFading = new CCWin.SkinControl.SkinCheckBox();
            this.PicBoxFading = new CCWin.SkinControl.SkinPictureBox();
            this.ConMenuStripFading = new CCWin.SkinControl.SkinContextMenuStrip();
            this.动态衰落ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.静态衰落ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lalState = new CCWin.SkinControl.SkinLabel();
            this.chkBoxFading = new CCWin.SkinControl.SkinCheckBox();
            this.PicBoxLossing = new CCWin.SkinControl.SkinPictureBox();
            this.PicBoxNoise = new CCWin.SkinControl.SkinPictureBox();
            this.chkBoxLoss = new CCWin.SkinControl.SkinCheckBox();
            this.chkBoxNoise = new CCWin.SkinControl.SkinCheckBox();
            this.PicBoxArbitraryWave = new CCWin.SkinControl.SkinPictureBox();
            this.skinToolStrip1 = new CCWin.SkinControl.SkinToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolButDownload = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolBtnStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolBtnQuit = new System.Windows.Forms.ToolStripButton();
            this.bgwMatlabInit = new System.ComponentModel.BackgroundWorker();
            this.bgwDmaTransfer = new System.ComponentModel.BackgroundWorker();
            this.lalLoss = new CCWin.SkinControl.SkinLabel();
            this.lalArbitraryWave = new CCWin.SkinControl.SkinLabel();
            this.lalFading = new CCWin.SkinControl.SkinLabel();
            this.lalNoise = new CCWin.SkinControl.SkinLabel();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxFading)).BeginInit();
            this.ConMenuStripFading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxLossing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxNoise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxArbitraryWave)).BeginInit();
            this.skinToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkFading
            // 
            this.chkFading.BackColor = System.Drawing.Color.Transparent;
            this.chkFading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chkFading.BaseColor = System.Drawing.Color.Transparent;
            this.chkFading.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.chkFading.DefaultCheckButtonWidth = 20;
            this.chkFading.DownBack = global::ChanSimSource.Properties.Resources.未选中;
            this.chkFading.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkFading.LightEffect = false;
            this.chkFading.LightEffectBack = System.Drawing.Color.Transparent;
            this.chkFading.Location = new System.Drawing.Point(425, 461);
            this.chkFading.MouseBack = global::ChanSimSource.Properties.Resources.未选中;
            this.chkFading.Name = "chkFading";
            this.chkFading.NormlBack = global::ChanSimSource.Properties.Resources.未选中;
            this.chkFading.SelectedDownBack = global::ChanSimSource.Properties.Resources.选中;
            this.chkFading.SelectedMouseBack = global::ChanSimSource.Properties.Resources.选中;
            this.chkFading.SelectedNormlBack = global::ChanSimSource.Properties.Resources.选中;
            this.chkFading.Size = new System.Drawing.Size(25, 29);
            this.chkFading.TabIndex = 2;
            this.chkFading.UseVisualStyleBackColor = false;
            this.chkFading.CheckedChanged += new System.EventHandler(this.chkFading_CheckedChanged);
            // 
            // PicBoxFading
            // 
            this.PicBoxFading.BackColor = System.Drawing.Color.Transparent;
            this.PicBoxFading.ContextMenuStrip = this.ConMenuStripFading;
            this.PicBoxFading.Location = new System.Drawing.Point(367, 455);
            this.PicBoxFading.Name = "PicBoxFading";
            this.PicBoxFading.Size = new System.Drawing.Size(144, 166);
            this.PicBoxFading.TabIndex = 5;
            this.PicBoxFading.TabStop = false;
            // 
            // ConMenuStripFading
            // 
            this.ConMenuStripFading.Arrow = System.Drawing.Color.White;
            this.ConMenuStripFading.Back = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.ConMenuStripFading.BackRadius = 4;
            this.ConMenuStripFading.Base = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.ConMenuStripFading.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.ConMenuStripFading.Fore = System.Drawing.Color.White;
            this.ConMenuStripFading.HoverFore = System.Drawing.Color.White;
            this.ConMenuStripFading.ItemAnamorphosis = false;
            this.ConMenuStripFading.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.ConMenuStripFading.ItemBorderShow = false;
            this.ConMenuStripFading.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.ConMenuStripFading.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.ConMenuStripFading.ItemRadius = 4;
            this.ConMenuStripFading.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.ConMenuStripFading.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.动态衰落ToolStripMenuItem,
            this.静态衰落ToolStripMenuItem});
            this.ConMenuStripFading.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.ConMenuStripFading.Name = "ConMenuStripFading";
            this.ConMenuStripFading.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.ConMenuStripFading.Size = new System.Drawing.Size(125, 48);
            this.ConMenuStripFading.SkinAllColor = true;
            this.ConMenuStripFading.TitleAnamorphosis = false;
            this.ConMenuStripFading.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.ConMenuStripFading.TitleRadius = 7;
            this.ConMenuStripFading.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.Bottom;
            // 
            // 动态衰落ToolStripMenuItem
            // 
            this.动态衰落ToolStripMenuItem.Name = "动态衰落ToolStripMenuItem";
            this.动态衰落ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.动态衰落ToolStripMenuItem.Text = "动态衰落";
            this.动态衰落ToolStripMenuItem.Click += new System.EventHandler(this.动态衰落ToolStripMenuItem_Click);
            // 
            // 静态衰落ToolStripMenuItem
            // 
            this.静态衰落ToolStripMenuItem.Name = "静态衰落ToolStripMenuItem";
            this.静态衰落ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.静态衰落ToolStripMenuItem.Text = "静态衰落";
            this.静态衰落ToolStripMenuItem.Click += new System.EventHandler(this.静态衰落ToolStripMenuItem_Click);
            // 
            // lalState
            // 
            this.lalState.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.Forme;
            this.lalState.BackColor = System.Drawing.Color.Transparent;
            this.lalState.BorderColor = System.Drawing.Color.White;
            this.lalState.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lalState.Location = new System.Drawing.Point(466, 641);
            this.lalState.Name = "lalState";
            this.lalState.Size = new System.Drawing.Size(341, 23);
            this.lalState.TabIndex = 8;
            this.lalState.Text = "正在初始化...";
            this.lalState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkBoxFading
            // 
            this.chkBoxFading.BackColor = System.Drawing.Color.Transparent;
            this.chkBoxFading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chkBoxFading.BaseColor = System.Drawing.Color.Transparent;
            this.chkBoxFading.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.chkBoxFading.DefaultCheckButtonWidth = 20;
            this.chkBoxFading.DownBack = global::ChanSimSource.Properties.Resources.未选中;
            this.chkBoxFading.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkBoxFading.LightEffect = false;
            this.chkBoxFading.LightEffectBack = System.Drawing.Color.Transparent;
            this.chkBoxFading.Location = new System.Drawing.Point(424, 444);
            this.chkBoxFading.MouseBack = global::ChanSimSource.Properties.Resources.未选中;
            this.chkBoxFading.Name = "chkBoxFading";
            this.chkBoxFading.NormlBack = global::ChanSimSource.Properties.Resources.未选中;
            this.chkBoxFading.SelectedDownBack = global::ChanSimSource.Properties.Resources.选中;
            this.chkBoxFading.SelectedMouseBack = global::ChanSimSource.Properties.Resources.选中;
            this.chkBoxFading.SelectedNormlBack = global::ChanSimSource.Properties.Resources.选中;
            this.chkBoxFading.Size = new System.Drawing.Size(25, 29);
            this.chkBoxFading.TabIndex = 9;
            this.chkBoxFading.UseVisualStyleBackColor = false;
            this.chkBoxFading.CheckedChanged += new System.EventHandler(this.chkFading_CheckedChanged);
            // 
            // PicBoxLossing
            // 
            this.PicBoxLossing.BackColor = System.Drawing.Color.Transparent;
            this.PicBoxLossing.Location = new System.Drawing.Point(563, 143);
            this.PicBoxLossing.Name = "PicBoxLossing";
            this.PicBoxLossing.Size = new System.Drawing.Size(143, 166);
            this.PicBoxLossing.TabIndex = 11;
            this.PicBoxLossing.TabStop = false;
            this.PicBoxLossing.Click += new System.EventHandler(this.PicBoxLossing_Click);
            // 
            // PicBoxNoise
            // 
            this.PicBoxNoise.BackColor = System.Drawing.Color.Transparent;
            this.PicBoxNoise.Location = new System.Drawing.Point(772, 454);
            this.PicBoxNoise.Name = "PicBoxNoise";
            this.PicBoxNoise.Size = new System.Drawing.Size(144, 166);
            this.PicBoxNoise.TabIndex = 12;
            this.PicBoxNoise.TabStop = false;
            this.PicBoxNoise.Click += new System.EventHandler(this.PicBoxNoise_Click);
            // 
            // chkBoxLoss
            // 
            this.chkBoxLoss.BackColor = System.Drawing.Color.Transparent;
            this.chkBoxLoss.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chkBoxLoss.BaseColor = System.Drawing.Color.Transparent;
            this.chkBoxLoss.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.chkBoxLoss.DefaultCheckButtonWidth = 20;
            this.chkBoxLoss.DownBack = global::ChanSimSource.Properties.Resources.未选中;
            this.chkBoxLoss.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkBoxLoss.LightEffect = false;
            this.chkBoxLoss.LightEffectBack = System.Drawing.Color.Transparent;
            this.chkBoxLoss.Location = new System.Drawing.Point(627, 293);
            this.chkBoxLoss.MouseBack = global::ChanSimSource.Properties.Resources.未选中;
            this.chkBoxLoss.Name = "chkBoxLoss";
            this.chkBoxLoss.NormlBack = global::ChanSimSource.Properties.Resources.未选中;
            this.chkBoxLoss.SelectedDownBack = global::ChanSimSource.Properties.Resources.选中;
            this.chkBoxLoss.SelectedMouseBack = global::ChanSimSource.Properties.Resources.选中;
            this.chkBoxLoss.SelectedNormlBack = global::ChanSimSource.Properties.Resources.选中;
            this.chkBoxLoss.Size = new System.Drawing.Size(25, 29);
            this.chkBoxLoss.TabIndex = 13;
            this.chkBoxLoss.UseVisualStyleBackColor = false;
            this.chkBoxLoss.CheckedChanged += new System.EventHandler(this.chkLoss_CheckedChanged);
            // 
            // chkBoxNoise
            // 
            this.chkBoxNoise.BackColor = System.Drawing.Color.Transparent;
            this.chkBoxNoise.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chkBoxNoise.BaseColor = System.Drawing.Color.Transparent;
            this.chkBoxNoise.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.chkBoxNoise.DefaultCheckButtonWidth = 20;
            this.chkBoxNoise.DownBack = global::ChanSimSource.Properties.Resources.未选中;
            this.chkBoxNoise.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkBoxNoise.LightEffect = false;
            this.chkBoxNoise.LightEffectBack = System.Drawing.Color.Transparent;
            this.chkBoxNoise.Location = new System.Drawing.Point(833, 445);
            this.chkBoxNoise.MouseBack = global::ChanSimSource.Properties.Resources.未选中;
            this.chkBoxNoise.Name = "chkBoxNoise";
            this.chkBoxNoise.NormlBack = global::ChanSimSource.Properties.Resources.未选中;
            this.chkBoxNoise.SelectedDownBack = global::ChanSimSource.Properties.Resources.选中;
            this.chkBoxNoise.SelectedMouseBack = global::ChanSimSource.Properties.Resources.选中;
            this.chkBoxNoise.SelectedNormlBack = global::ChanSimSource.Properties.Resources.选中;
            this.chkBoxNoise.Size = new System.Drawing.Size(25, 29);
            this.chkBoxNoise.TabIndex = 14;
            this.chkBoxNoise.UseVisualStyleBackColor = false;
            this.chkBoxNoise.CheckedChanged += new System.EventHandler(this.chkNoise_CheckedChanged);
            // 
            // PicBoxArbitraryWave
            // 
            this.PicBoxArbitraryWave.BackColor = System.Drawing.Color.Transparent;
            this.PicBoxArbitraryWave.Image = global::ChanSimSource.Properties.Resources.任意波;
            this.PicBoxArbitraryWave.Location = new System.Drawing.Point(113, 296);
            this.PicBoxArbitraryWave.Name = "PicBoxArbitraryWave";
            this.PicBoxArbitraryWave.Size = new System.Drawing.Size(143, 170);
            this.PicBoxArbitraryWave.TabIndex = 15;
            this.PicBoxArbitraryWave.TabStop = false;
            this.PicBoxArbitraryWave.Click += new System.EventHandler(this.PicBoxArbitraryWave_Click);
            // 
            // skinToolStrip1
            // 
            this.skinToolStrip1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.skinToolStrip1.Arrow = System.Drawing.Color.White;
            this.skinToolStrip1.AutoSize = false;
            this.skinToolStrip1.Back = System.Drawing.Color.Transparent;
            this.skinToolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.skinToolStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("skinToolStrip1.BackgroundImage")));
            this.skinToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.skinToolStrip1.BackRadius = 4;
            this.skinToolStrip1.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.skinToolStrip1.Base = System.Drawing.Color.Transparent;
            this.skinToolStrip1.BaseFore = System.Drawing.Color.White;
            this.skinToolStrip1.BaseForeAnamorphosis = false;
            this.skinToolStrip1.BaseForeAnamorphosisBorder = 4;
            this.skinToolStrip1.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.skinToolStrip1.BaseForeOffset = new System.Drawing.Point(0, 0);
            this.skinToolStrip1.BaseHoverFore = System.Drawing.Color.White;
            this.skinToolStrip1.BaseItemAnamorphosis = false;
            this.skinToolStrip1.BaseItemBorder = System.Drawing.Color.Transparent;
            this.skinToolStrip1.BaseItemBorderShow = true;
            this.skinToolStrip1.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("skinToolStrip1.BaseItemDown")));
            this.skinToolStrip1.BaseItemHover = System.Drawing.Color.Transparent;
            this.skinToolStrip1.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("skinToolStrip1.BaseItemMouse")));
            this.skinToolStrip1.BaseItemNorml = null;
            this.skinToolStrip1.BaseItemPressed = System.Drawing.Color.Transparent;
            this.skinToolStrip1.BaseItemRadius = 4;
            this.skinToolStrip1.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip1.BaseItemSplitter = System.Drawing.Color.Transparent;
            this.skinToolStrip1.BindTabControl = null;
            this.skinToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.skinToolStrip1.DropDownImageSeparator = System.Drawing.Color.Transparent;
            this.skinToolStrip1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.skinToolStrip1.Fore = System.Drawing.Color.White;
            this.skinToolStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.skinToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.skinToolStrip1.HoverFore = System.Drawing.Color.White;
            this.skinToolStrip1.ItemAnamorphosis = false;
            this.skinToolStrip1.ItemBorder = System.Drawing.Color.Transparent;
            this.skinToolStrip1.ItemBorderShow = false;
            this.skinToolStrip1.ItemHover = System.Drawing.Color.Transparent;
            this.skinToolStrip1.ItemPressed = System.Drawing.Color.Transparent;
            this.skinToolStrip1.ItemRadius = 4;
            this.skinToolStrip1.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolButDownload,
            this.toolStripButton3,
            this.toolBtnStart,
            this.toolStripButton5,
            this.toolBtnQuit});
            this.skinToolStrip1.Location = new System.Drawing.Point(560, 89);
            this.skinToolStrip1.Name = "skinToolStrip1";
            this.skinToolStrip1.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip1.Size = new System.Drawing.Size(160, 25);
            this.skinToolStrip1.SkinAllColor = true;
            this.skinToolStrip1.TabIndex = 17;
            this.skinToolStrip1.TitleAnamorphosis = false;
            this.skinToolStrip1.TitleColor = System.Drawing.Color.Transparent;
            this.skinToolStrip1.TitleRadius = 4;
            this.skinToolStrip1.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Enabled = false;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolButDownload
            // 
            this.toolButDownload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButDownload.Image = global::ChanSimSource.Properties.Resources.下载;
            this.toolButDownload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButDownload.Name = "toolButDownload";
            this.toolButDownload.Size = new System.Drawing.Size(23, 22);
            this.toolButDownload.Text = "配置参数";
            this.toolButDownload.Click += new System.EventHandler(this.toolButDownload_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Enabled = false;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // toolBtnStart
            // 
            this.toolBtnStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnStart.Image = global::ChanSimSource.Properties.Resources.runWhite;
            this.toolBtnStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnStart.Name = "toolBtnStart";
            this.toolBtnStart.Size = new System.Drawing.Size(23, 22);
            this.toolBtnStart.Text = "启动设备";
            this.toolBtnStart.Click += new System.EventHandler(this.toolBtnStart_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Enabled = false;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "toolStripButton5";
            // 
            // toolBtnQuit
            // 
            this.toolBtnQuit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnQuit.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnQuit.Image")));
            this.toolBtnQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnQuit.Name = "toolBtnQuit";
            this.toolBtnQuit.Size = new System.Drawing.Size(23, 22);
            this.toolBtnQuit.Text = "退出";
            this.toolBtnQuit.Click += new System.EventHandler(this.toolBtnQuit_Click);
            // 
            // bgwMatlabInit
            // 
            this.bgwMatlabInit.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwMatlabInit_DoWork);
            this.bgwMatlabInit.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwMatlabInit_RunWorkerCompleted);
            // 
            // bgwDmaTransfer
            // 
            this.bgwDmaTransfer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwDmaTransfer_DoWork);
            this.bgwDmaTransfer.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwDmaTransfer_RunWorkerCompleted);
            // 
            // lalLoss
            // 
            this.lalLoss.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.lalLoss.BackColor = System.Drawing.Color.Transparent;
            this.lalLoss.BorderColor = System.Drawing.Color.White;
            this.lalLoss.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lalLoss.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lalLoss.Location = new System.Drawing.Point(570, 270);
            this.lalLoss.Name = "lalLoss";
            this.lalLoss.Size = new System.Drawing.Size(132, 23);
            this.lalLoss.TabIndex = 22;
            this.lalLoss.Text = "0dB";
            this.lalLoss.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lalArbitraryWave
            // 
            this.lalArbitraryWave.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.lalArbitraryWave.BackColor = System.Drawing.Color.Transparent;
            this.lalArbitraryWave.BorderColor = System.Drawing.Color.White;
            this.lalArbitraryWave.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lalArbitraryWave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lalArbitraryWave.Location = new System.Drawing.Point(118, 423);
            this.lalArbitraryWave.Name = "lalArbitraryWave";
            this.lalArbitraryWave.Size = new System.Drawing.Size(132, 23);
            this.lalArbitraryWave.TabIndex = 23;
            this.lalArbitraryWave.Text = "任意波";
            this.lalArbitraryWave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lalFading
            // 
            this.lalFading.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.lalFading.BackColor = System.Drawing.Color.Transparent;
            this.lalFading.BorderColor = System.Drawing.Color.White;
            this.lalFading.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lalFading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lalFading.Location = new System.Drawing.Point(373, 584);
            this.lalFading.Name = "lalFading";
            this.lalFading.Size = new System.Drawing.Size(132, 23);
            this.lalFading.TabIndex = 24;
            this.lalFading.Text = "衰落";
            this.lalFading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lalNoise
            // 
            this.lalNoise.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.lalNoise.BackColor = System.Drawing.Color.Transparent;
            this.lalNoise.BorderColor = System.Drawing.Color.White;
            this.lalNoise.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lalNoise.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lalNoise.Location = new System.Drawing.Point(778, 584);
            this.lalNoise.Name = "lalNoise";
            this.lalNoise.Size = new System.Drawing.Size(132, 23);
            this.lalNoise.TabIndex = 25;
            this.lalNoise.Text = "信噪比";
            this.lalNoise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Back = ((System.Drawing.Image)(resources.GetObject("$this.Back")));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.ControlBox = false;
            this.Controls.Add(this.lalNoise);
            this.Controls.Add(this.lalFading);
            this.Controls.Add(this.lalArbitraryWave);
            this.Controls.Add(this.lalLoss);
            this.Controls.Add(this.skinToolStrip1);
            this.Controls.Add(this.PicBoxArbitraryWave);
            this.Controls.Add(this.chkBoxNoise);
            this.Controls.Add(this.chkBoxLoss);
            this.Controls.Add(this.PicBoxNoise);
            this.Controls.Add(this.PicBoxLossing);
            this.Controls.Add(this.chkBoxFading);
            this.Controls.Add(this.lalState);
            this.Controls.Add(this.PicBoxFading);
            this.Controls.Add(this.chkFading);
            this.Mobile = CCWin.MobileStyle.None;
            this.Name = "Form1";
            this.Shadow = false;
            this.ShowDrawIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxFading)).EndInit();
            this.ConMenuStripFading.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxLossing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxNoise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxArbitraryWave)).EndInit();
            this.skinToolStrip1.ResumeLayout(false);
            this.skinToolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinCheckBox chkFading;
        private CCWin.SkinControl.SkinPictureBox PicBoxFading;
        private CCWin.SkinControl.SkinContextMenuStrip ConMenuStripFading;
        private System.Windows.Forms.ToolStripMenuItem 动态衰落ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 静态衰落ToolStripMenuItem;
        private CCWin.SkinControl.SkinCheckBox chkBoxFading;
        private CCWin.SkinControl.SkinPictureBox PicBoxLossing;
        private CCWin.SkinControl.SkinPictureBox PicBoxNoise;
        private CCWin.SkinControl.SkinCheckBox chkBoxLoss;
        private CCWin.SkinControl.SkinCheckBox chkBoxNoise;
        private CCWin.SkinControl.SkinPictureBox PicBoxArbitraryWave;
        public CCWin.SkinControl.SkinLabel lalState;
        private CCWin.SkinControl.SkinToolStrip skinToolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolButDownload;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolBtnStart;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolBtnQuit;
        private System.ComponentModel.BackgroundWorker bgwMatlabInit;
        private System.ComponentModel.BackgroundWorker bgwDmaTransfer;
        public CCWin.SkinControl.SkinLabel lalLoss;
        public CCWin.SkinControl.SkinLabel lalArbitraryWave;
        public CCWin.SkinControl.SkinLabel lalFading;
        public CCWin.SkinControl.SkinLabel lalNoise;
    }
}

