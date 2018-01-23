namespace ChanSimSource
{
    partial class StaticFading
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaticFading));
            this.chkGeneShadow = new System.Windows.Forms.CheckBox();
            this.txtGeneShadow = new System.Windows.Forms.TextBox();
            this.lalGeneShadowUnit = new System.Windows.Forms.Label();
            this.lalGeneDecorLenUnit = new System.Windows.Forms.Label();
            this.txtGeneDecorLen = new System.Windows.Forms.TextBox();
            this.lalGeneHill = new System.Windows.Forms.Label();
            this.lalGeneBad = new System.Windows.Forms.Label();
            this.lalGeneOutskirts = new System.Windows.Forms.Label();
            this.rdoGeneBad = new System.Windows.Forms.RadioButton();
            this.rdoCost259 = new System.Windows.Forms.RadioButton();
            this.rdoGeneHill = new System.Windows.Forms.RadioButton();
            this.rdoGeneOutskirts = new System.Windows.Forms.RadioButton();
            this.chkGeneChanMod = new System.Windows.Forms.CheckBox();
            this.bgwMatlabGen = new System.ComponentModel.BackgroundWorker();
            this.bgwMatlabInit = new System.ComponentModel.BackgroundWorker();
            this.tabGeneMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.载入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvGeneChan = new System.Windows.Forms.DataGridView();
            this.errorShow = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnCancel = new CCWin.SkinControl.SkinButton();
            this.btnDetermine = new CCWin.SkinControl.SkinButton();
            this.colGeneDelay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGeneLoss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGeneFad = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colGeneDoppler = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colGeneFdMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGeneFdOffset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabGeneMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGeneChan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorShow)).BeginInit();
            this.SuspendLayout();
            // 
            // chkGeneShadow
            // 
            this.chkGeneShadow.AutoSize = true;
            this.chkGeneShadow.Location = new System.Drawing.Point(260, 93);
            this.chkGeneShadow.Name = "chkGeneShadow";
            this.chkGeneShadow.Size = new System.Drawing.Size(15, 14);
            this.chkGeneShadow.TabIndex = 0;
            this.chkGeneShadow.UseVisualStyleBackColor = true;
            this.chkGeneShadow.CheckedChanged += new System.EventHandler(this.chkGeneShadow_CheckedChanged);
            // 
            // txtGeneShadow
            // 
            this.txtGeneShadow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.txtGeneShadow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGeneShadow.Enabled = false;
            this.txtGeneShadow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtGeneShadow.ForeColor = System.Drawing.Color.White;
            this.txtGeneShadow.Location = new System.Drawing.Point(379, 129);
            this.txtGeneShadow.Name = "txtGeneShadow";
            this.txtGeneShadow.Size = new System.Drawing.Size(220, 17);
            this.txtGeneShadow.TabIndex = 102;
            this.txtGeneShadow.Text = "5";
            this.txtGeneShadow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lalGeneShadowUnit
            // 
            this.lalGeneShadowUnit.AutoSize = true;
            this.lalGeneShadowUnit.BackColor = System.Drawing.Color.Transparent;
            this.lalGeneShadowUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.lalGeneShadowUnit.ForeColor = System.Drawing.Color.White;
            this.lalGeneShadowUnit.Location = new System.Drawing.Point(604, 129);
            this.lalGeneShadowUnit.Name = "lalGeneShadowUnit";
            this.lalGeneShadowUnit.Size = new System.Drawing.Size(28, 18);
            this.lalGeneShadowUnit.TabIndex = 103;
            this.lalGeneShadowUnit.Text = "dB";
            // 
            // lalGeneDecorLenUnit
            // 
            this.lalGeneDecorLenUnit.AutoSize = true;
            this.lalGeneDecorLenUnit.BackColor = System.Drawing.Color.Transparent;
            this.lalGeneDecorLenUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.lalGeneDecorLenUnit.ForeColor = System.Drawing.Color.White;
            this.lalGeneDecorLenUnit.Location = new System.Drawing.Point(1005, 127);
            this.lalGeneDecorLenUnit.Name = "lalGeneDecorLenUnit";
            this.lalGeneDecorLenUnit.Size = new System.Drawing.Size(22, 18);
            this.lalGeneDecorLenUnit.TabIndex = 106;
            this.lalGeneDecorLenUnit.Text = "m";
            // 
            // txtGeneDecorLen
            // 
            this.txtGeneDecorLen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.txtGeneDecorLen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGeneDecorLen.Enabled = false;
            this.txtGeneDecorLen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtGeneDecorLen.ForeColor = System.Drawing.Color.White;
            this.txtGeneDecorLen.Location = new System.Drawing.Point(773, 128);
            this.txtGeneDecorLen.Name = "txtGeneDecorLen";
            this.txtGeneDecorLen.Size = new System.Drawing.Size(230, 17);
            this.txtGeneDecorLen.TabIndex = 105;
            this.txtGeneDecorLen.Text = "5";
            this.txtGeneDecorLen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lalGeneHill
            // 
            this.lalGeneHill.AutoSize = true;
            this.lalGeneHill.BackColor = System.Drawing.Color.Transparent;
            this.lalGeneHill.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.lalGeneHill.ForeColor = System.Drawing.Color.White;
            this.lalGeneHill.Location = new System.Drawing.Point(581, 55);
            this.lalGeneHill.Name = "lalGeneHill";
            this.lalGeneHill.Size = new System.Drawing.Size(72, 18);
            this.lalGeneHill.TabIndex = 110;
            this.lalGeneHill.Text = "丘陵地区";
            this.lalGeneHill.Visible = false;
            // 
            // lalGeneBad
            // 
            this.lalGeneBad.AutoSize = true;
            this.lalGeneBad.BackColor = System.Drawing.Color.Transparent;
            this.lalGeneBad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.lalGeneBad.ForeColor = System.Drawing.Color.White;
            this.lalGeneBad.Location = new System.Drawing.Point(535, 55);
            this.lalGeneBad.Name = "lalGeneBad";
            this.lalGeneBad.Size = new System.Drawing.Size(40, 18);
            this.lalGeneBad.TabIndex = 109;
            this.lalGeneBad.Text = "恶劣";
            this.lalGeneBad.Visible = false;
            // 
            // lalGeneOutskirts
            // 
            this.lalGeneOutskirts.AutoSize = true;
            this.lalGeneOutskirts.BackColor = System.Drawing.Color.Transparent;
            this.lalGeneOutskirts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.lalGeneOutskirts.ForeColor = System.Drawing.Color.White;
            this.lalGeneOutskirts.Location = new System.Drawing.Point(445, 55);
            this.lalGeneOutskirts.Name = "lalGeneOutskirts";
            this.lalGeneOutskirts.Size = new System.Drawing.Size(72, 18);
            this.lalGeneOutskirts.TabIndex = 108;
            this.lalGeneOutskirts.Text = "远郊典型";
            this.lalGeneOutskirts.Visible = false;
            // 
            // rdoGeneBad
            // 
            this.rdoGeneBad.AutoSize = true;
            this.rdoGeneBad.BackColor = System.Drawing.Color.Transparent;
            this.rdoGeneBad.Enabled = false;
            this.rdoGeneBad.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold);
            this.rdoGeneBad.ForeColor = System.Drawing.Color.White;
            this.rdoGeneBad.Location = new System.Drawing.Point(494, 196);
            this.rdoGeneBad.Name = "rdoGeneBad";
            this.rdoGeneBad.Size = new System.Drawing.Size(113, 22);
            this.rdoGeneBad.TabIndex = 4;
            this.rdoGeneBad.TabStop = true;
            this.rdoGeneBad.Text = "COST207恶劣";
            this.rdoGeneBad.UseVisualStyleBackColor = false;
            this.rdoGeneBad.CheckedChanged += new System.EventHandler(this.rdoGeneChanMod_CheckedChanged);
            // 
            // rdoCost259
            // 
            this.rdoCost259.AutoSize = true;
            this.rdoCost259.BackColor = System.Drawing.Color.Transparent;
            this.rdoCost259.Enabled = false;
            this.rdoCost259.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold);
            this.rdoCost259.ForeColor = System.Drawing.Color.White;
            this.rdoCost259.Location = new System.Drawing.Point(914, 196);
            this.rdoCost259.Name = "rdoCost259";
            this.rdoCost259.Size = new System.Drawing.Size(79, 22);
            this.rdoCost259.TabIndex = 3;
            this.rdoCost259.TabStop = true;
            this.rdoCost259.Text = "COST259";
            this.rdoCost259.UseVisualStyleBackColor = false;
            this.rdoCost259.CheckedChanged += new System.EventHandler(this.rdoGeneChanMod_CheckedChanged);
            // 
            // rdoGeneHill
            // 
            this.rdoGeneHill.AutoSize = true;
            this.rdoGeneHill.BackColor = System.Drawing.Color.Transparent;
            this.rdoGeneHill.Enabled = false;
            this.rdoGeneHill.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold);
            this.rdoGeneHill.ForeColor = System.Drawing.Color.White;
            this.rdoGeneHill.Location = new System.Drawing.Point(704, 196);
            this.rdoGeneHill.Name = "rdoGeneHill";
            this.rdoGeneHill.Size = new System.Drawing.Size(147, 22);
            this.rdoGeneHill.TabIndex = 2;
            this.rdoGeneHill.TabStop = true;
            this.rdoGeneHill.Text = "COST207丘陵地区";
            this.rdoGeneHill.UseVisualStyleBackColor = false;
            this.rdoGeneHill.CheckedChanged += new System.EventHandler(this.rdoGeneChanMod_CheckedChanged);
            // 
            // rdoGeneOutskirts
            // 
            this.rdoGeneOutskirts.AutoSize = true;
            this.rdoGeneOutskirts.BackColor = System.Drawing.Color.Transparent;
            this.rdoGeneOutskirts.Checked = true;
            this.rdoGeneOutskirts.Enabled = false;
            this.rdoGeneOutskirts.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold);
            this.rdoGeneOutskirts.ForeColor = System.Drawing.Color.White;
            this.rdoGeneOutskirts.Location = new System.Drawing.Point(284, 196);
            this.rdoGeneOutskirts.Name = "rdoGeneOutskirts";
            this.rdoGeneOutskirts.Size = new System.Drawing.Size(147, 22);
            this.rdoGeneOutskirts.TabIndex = 1;
            this.rdoGeneOutskirts.TabStop = true;
            this.rdoGeneOutskirts.Text = "COST207远郊典型";
            this.rdoGeneOutskirts.UseVisualStyleBackColor = false;
            this.rdoGeneOutskirts.CheckedChanged += new System.EventHandler(this.rdoGeneChanMod_CheckedChanged);
            // 
            // chkGeneChanMod
            // 
            this.chkGeneChanMod.AutoSize = true;
            this.chkGeneChanMod.Location = new System.Drawing.Point(260, 168);
            this.chkGeneChanMod.Name = "chkGeneChanMod";
            this.chkGeneChanMod.Size = new System.Drawing.Size(15, 14);
            this.chkGeneChanMod.TabIndex = 0;
            this.chkGeneChanMod.UseVisualStyleBackColor = true;
            this.chkGeneChanMod.CheckedChanged += new System.EventHandler(this.chkGeneChanMod_CheckedChanged);
            // 
            // bgwMatlabGen
            // 
            this.bgwMatlabGen.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwMatlabGen_DoWork);
            this.bgwMatlabGen.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwMatlabGen_RunWorkerCompleted);
            // 
            // tabGeneMenu
            // 
            this.tabGeneMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tabGeneMenu.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabGeneMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.保存ToolStripMenuItem,
            this.载入ToolStripMenuItem});
            this.tabGeneMenu.Name = "tabMenu";
            this.tabGeneMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tabGeneMenu.Size = new System.Drawing.Size(101, 92);
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
            // dgvGeneChan
            // 
            this.dgvGeneChan.AllowDrop = true;
            this.dgvGeneChan.AllowUserToAddRows = false;
            this.dgvGeneChan.AllowUserToDeleteRows = false;
            this.dgvGeneChan.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(73)))), ((int)(((byte)(130)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvGeneChan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGeneChan.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(65)))), ((int)(((byte)(116)))));
            this.dgvGeneChan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(114)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(167)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGeneChan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGeneChan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGeneChan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colGeneDelay,
            this.colGeneLoss,
            this.colGeneFad,
            this.colGeneDoppler,
            this.colGeneFdMax,
            this.colGeneFdOffset});
            this.dgvGeneChan.ContextMenuStrip = this.tabGeneMenu;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(114)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(167)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGeneChan.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvGeneChan.EnableHeadersVisualStyles = false;
            this.dgvGeneChan.GridColor = System.Drawing.Color.MediumTurquoise;
            this.dgvGeneChan.Location = new System.Drawing.Point(254, 237);
            this.dgvGeneChan.Name = "dgvGeneChan";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(114)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(167)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGeneChan.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvGeneChan.RowHeadersWidth = 120;
            this.dgvGeneChan.RowTemplate.Height = 32;
            this.dgvGeneChan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGeneChan.Size = new System.Drawing.Size(774, 235);
            this.dgvGeneChan.TabIndex = 128;
            this.dgvGeneChan.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.dgvGeneChan_CellStateChanged);
            this.dgvGeneChan.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGeneChan_CellValueChanged);
            this.dgvGeneChan.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvGeneChan_DataError);
            this.dgvGeneChan.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvTab_EditingControlShowing);
            this.dgvGeneChan.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvGeneChan_RowsAdded);
            this.dgvGeneChan.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvGeneChan_RowsRemoved);
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
            this.btnCancel.Font = new System.Drawing.Font("Microsoft YaHei", 10F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.GlowColor = System.Drawing.Color.Transparent;
            this.btnCancel.InnerBorderColor = System.Drawing.Color.Transparent;
            this.btnCancel.IsDrawBorder = false;
            this.btnCancel.IsDrawGlass = false;
            this.btnCancel.Location = new System.Drawing.Point(952, 44);
            this.btnCancel.MouseBack = null;
            this.btnCancel.MouseBaseColor = System.Drawing.Color.Transparent;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormlBack = null;
            this.btnCancel.Radius = 20;
            this.btnCancel.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnCancel.Size = new System.Drawing.Size(75, 29);
            this.btnCancel.TabIndex = 142;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this.btnDetermine.Font = new System.Drawing.Font("Microsoft YaHei", 10F);
            this.btnDetermine.ForeColor = System.Drawing.Color.White;
            this.btnDetermine.GlowColor = System.Drawing.Color.Transparent;
            this.btnDetermine.InnerBorderColor = System.Drawing.Color.Transparent;
            this.btnDetermine.IsDrawBorder = false;
            this.btnDetermine.IsDrawGlass = false;
            this.btnDetermine.Location = new System.Drawing.Point(860, 44);
            this.btnDetermine.MouseBack = null;
            this.btnDetermine.MouseBaseColor = System.Drawing.Color.Transparent;
            this.btnDetermine.Name = "btnDetermine";
            this.btnDetermine.NormlBack = null;
            this.btnDetermine.Size = new System.Drawing.Size(75, 29);
            this.btnDetermine.TabIndex = 141;
            this.btnDetermine.Text = "确定";
            this.btnDetermine.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDetermine.UseVisualStyleBackColor = false;
            this.btnDetermine.Click += new System.EventHandler(this.btnDetermine_Click);
            // 
            // colGeneDelay
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.NullValue = "0";
            this.colGeneDelay.DefaultCellStyle = dataGridViewCellStyle3;
            this.colGeneDelay.HeaderText = "路径延迟(ms)";
            this.colGeneDelay.Name = "colGeneDelay";
            this.colGeneDelay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colGeneDelay.Width = 104;
            // 
            // colGeneLoss
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.NullValue = "0";
            this.colGeneLoss.DefaultCellStyle = dataGridViewCellStyle4;
            this.colGeneLoss.HeaderText = "相对损耗(dB)";
            this.colGeneLoss.Name = "colGeneLoss";
            this.colGeneLoss.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colGeneLoss.Width = 104;
            // 
            // colGeneFad
            // 
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.NullValue = "瑞利衰落";
            this.colGeneFad.DefaultCellStyle = dataGridViewCellStyle5;
            this.colGeneFad.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colGeneFad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.colGeneFad.HeaderText = "衰落类型";
            this.colGeneFad.Items.AddRange(new object[] {
            "瑞利衰落",
            "莱斯衰落",
            "纯多普勒"});
            this.colGeneFad.Name = "colGeneFad";
            this.colGeneFad.Width = 110;
            // 
            // colGeneDoppler
            // 
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.NullValue = "平坦";
            this.colGeneDoppler.DefaultCellStyle = dataGridViewCellStyle6;
            this.colGeneDoppler.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colGeneDoppler.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.colGeneDoppler.HeaderText = "频谱形状";
            this.colGeneDoppler.Items.AddRange(new object[] {
            "经典3dB",
            "经典6dB",
            "平坦",
            "圆形",
            "Jakes经典",
            "Jakes圆形",
            "高斯",
            "高斯I",
            "高斯II"});
            this.colGeneDoppler.Name = "colGeneDoppler";
            this.colGeneDoppler.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colGeneDoppler.Width = 116;
            // 
            // colGeneFdMax
            // 
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.NullValue = "1";
            this.colGeneFdMax.DefaultCellStyle = dataGridViewCellStyle7;
            this.colGeneFdMax.HeaderText = "多普勒频率(Hz)";
            this.colGeneFdMax.Name = "colGeneFdMax";
            this.colGeneFdMax.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colGeneFdMax.Width = 110;
            // 
            // colGeneFdOffset
            // 
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.NullValue = "0";
            this.colGeneFdOffset.DefaultCellStyle = dataGridViewCellStyle8;
            this.colGeneFdOffset.HeaderText = "多普勒偏移(Hz)";
            this.colGeneFdOffset.Name = "colGeneFdOffset";
            this.colGeneFdOffset.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colGeneFdOffset.Width = 110;
            // 
            // StaticFading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1280, 513);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDetermine);
            this.Controls.Add(this.lalGeneHill);
            this.Controls.Add(this.lalGeneBad);
            this.Controls.Add(this.lalGeneOutskirts);
            this.Controls.Add(this.txtGeneShadow);
            this.Controls.Add(this.rdoGeneBad);
            this.Controls.Add(this.lalGeneDecorLenUnit);
            this.Controls.Add(this.rdoCost259);
            this.Controls.Add(this.rdoGeneHill);
            this.Controls.Add(this.txtGeneDecorLen);
            this.Controls.Add(this.rdoGeneOutskirts);
            this.Controls.Add(this.chkGeneShadow);
            this.Controls.Add(this.lalGeneShadowUnit);
            this.Controls.Add(this.chkGeneChanMod);
            this.Controls.Add(this.dgvGeneChan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StaticFading";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.StaticFading_Load);
            this.tabGeneMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGeneChan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkGeneShadow;
        private System.Windows.Forms.TextBox txtGeneShadow;
        private System.Windows.Forms.Label lalGeneShadowUnit;
        private System.Windows.Forms.Label lalGeneDecorLenUnit;
        private System.Windows.Forms.TextBox txtGeneDecorLen;
        private System.Windows.Forms.Label lalGeneHill;
        private System.Windows.Forms.Label lalGeneBad;
        private System.Windows.Forms.Label lalGeneOutskirts;
        private System.Windows.Forms.RadioButton rdoGeneBad;
        private System.Windows.Forms.RadioButton rdoCost259;
        private System.Windows.Forms.RadioButton rdoGeneHill;
        private System.Windows.Forms.RadioButton rdoGeneOutskirts;
        private System.Windows.Forms.CheckBox chkGeneChanMod;
        private System.ComponentModel.BackgroundWorker bgwMatlabGen;
        private System.ComponentModel.BackgroundWorker bgwMatlabInit;
        private System.Windows.Forms.ContextMenuStrip tabGeneMenu;
        private System.Windows.Forms.ToolStripMenuItem 添加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 载入ToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvGeneChan;
        private System.Windows.Forms.ErrorProvider errorShow;
        private CCWin.SkinControl.SkinButton btnCancel;
        private CCWin.SkinControl.SkinButton btnDetermine;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGeneDelay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGeneLoss;
        private System.Windows.Forms.DataGridViewComboBoxColumn colGeneFad;
        private System.Windows.Forms.DataGridViewComboBoxColumn colGeneDoppler;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGeneFdMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGeneFdOffset;
    }
}