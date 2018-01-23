using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;
using System.IO;
using pcieDriverHelper;
using MathWorks.MATLAB.NET.Utility;
using MathWorks.MATLAB.NET.Arrays;
using AeroChanFun;
using GeneChanFun;


namespace ChanSimSource
{
    public partial class Form1 : CCSkinMain
    {
        private FadingWindow fadWin = new FadingWindow();
        private StaticFading staticFading = new StaticFading();
        private ArbitraryWave arbitraryWave = new ArbitraryWave();
        private LossBox lossBox = new LossBox();
        private NoiseBox noiseBox = new NoiseBox();
        private WaitBox waitBox = new WaitBox();

        private AeroChan aeroChan;
        private GeneChan geneChan;
       // private WaveFileGen waveGen;

        //private string[] typeOfPSK = { "BPSK", "QPSK", "8PSK", "16PSK", "32PSK" };
        //private string[] typeOfQAM = { "QAM", "16QAM", "32QAM", "64QAM", "128QAM", "256QAM" };
        private string strChanFilePath;
        private string strWaveFilePath;
        private string strDefaultPath = System.AppDomain.CurrentDomain.BaseDirectory;
        private string lastError;
        
        public enum PcieReg
        {
            IsRun = 0x100,    //1启动，0停止
            IsAddNoise = 0x104, //1加噪，0不加噪
            SNR = 0x108,
            IsAddFad = 0x10c, //1--加衰落，0--不加衰落
            FadMode = 0x110,  //1为动态，发0为静态
            DDRReset = 0x114, //发1用于DDR3复位
            FileMode = 0x118, //0--任意波文件 1--衰落文件
            ArbWaveSize = 0x11c, //发32bit文件大小
            FadingSize = 0x120, //衰落文件大小
            FirstDelay = 0x124,
            SecondDelay = 0x128,
            ThirdDelay = 0x12c,
            FourthDelay = 0x130,
            FifthDelay = 0x134,
            SixthDelay = 0x138,
            PathLoss = 0x13c
        }

        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            //fadWin.SetMainPage(this);
            //staticFading.SetMainPage(this);
            
            bgwMatlabInit.RunWorkerAsync();

            //fadWin.CustomInitMatlab();
            //staticFading.CustomInitMatlab();
            PicBoxArbitraryWave.Enabled = false;
            PicBoxFading.Enabled = false;
            PicBoxLossing.Enabled = false;
            PicBoxNoise.Enabled = false;
            chkBoxFading.Enabled = false;
            chkBoxLoss.Enabled = false;
            chkBoxNoise.Enabled = false;

            //ComBoxWave.SelectedIndex = 1;

            //初始化子页面参数
            fadWin.SetPara(this, aeroChan);
            staticFading.SetPara(this, geneChan);

            if (!PcieDriver.OpenPcieDevice())
            {
                MessageBox.Show("打开PCI-E设备失败", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #region 衰落模块
        private void 动态衰落ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int xWidth = SystemInformation.PrimaryMonitorSize.Width;//获取显示器屏幕宽度
            int yHeight = SystemInformation.PrimaryMonitorSize.Height;//高度            
           fadWin.Location = new Point(xWidth / 2 - 640, yHeight / 2 - 260);

           fadWin.SetPara(this, aeroChan);

           lalState.Text = "动态衰落";
           if (DialogResult.OK == fadWin.ShowDialog(this))
           {
               lalFading.Text = "动态衰落";
               strChanFilePath = fadWin.GetStrFilePath();
           }
           //fadWin.ShowDialog();
           lalState.Text = "Ready";
        }

        private void 静态衰落ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // staticFading.Show();
            int xWidth = SystemInformation.PrimaryMonitorSize.Width;//获取显示器屏幕宽度
            int yHeight = SystemInformation.PrimaryMonitorSize.Height;//高度

            //fadWin.Show();
            staticFading.Location = new Point(xWidth / 2 - 640, yHeight / 2 - 260);
            staticFading.SetPara(this, geneChan);

            lalState.Text = "静态衰落";
            if (DialogResult.OK == staticFading.ShowDialog(this))
            {
                lalFading.Text = "静态衰落";
                strChanFilePath = staticFading.GetStrFilePath();
            }
            //staticFading.ShowDialog();
            lalState.Text = "Ready";
        }

        private void chkFading_CheckedChanged(object sender, EventArgs e)
        {
            //if (!SetPcieReg(PcieReg.IsRun, 1, out lastError))
            //{
            //    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            if (chkBoxFading.Checked )
            {
                if (!SetPcieReg(PcieReg.IsAddFad, 1, out lastError))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                lalState.Text = "配置衰落模式";
                PicBoxFading.BackgroundImage = Properties.Resources.衰落选中;

                if (lalFading.Text == "动态衰落")
                {
                    if (!SetPcieReg(PcieReg.FadMode, 1, out lastError))
                    {
                        MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else if (lalFading.Text == "静态衰落")
                {
                    if (!SetPcieReg(PcieReg.FadMode, 0, out lastError))
                    {
                        MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                lalState.Text = "Ready";
            }
            else
            {
                if (!SetPcieReg(PcieReg.IsAddFad, 0, out lastError))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                PicBoxFading.BackgroundImage = null;
            }
        }
        #endregion

        #region 任意波模块
        private void PicBoxArbitraryWave_Click(object sender, EventArgs e)
        {
            int xWidth = SystemInformation.PrimaryMonitorSize.Width;//获取显示器屏幕宽度
            int yHeight = SystemInformation.PrimaryMonitorSize.Height;//高度            
            arbitraryWave.Location = new Point(xWidth / 2 - 640, yHeight / 2 - 260);

            //arbitraryWave.SetPara(this, waveGen);

            lalState.Text = "任意波";
            arbitraryWave.ShowDialog(this);
           // lalFading.Text = arbitraryWave.strSignalName;
            strWaveFilePath = arbitraryWave.GetStrFilePath();
            //fadWin.ShowDialog();
            lalState.Text = "Ready";
        }

            
        

        //private void cboModulationType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    lalArbitraryWave.Text = cboModulationType.Text;

        //    ConfigBox readBinBox = new ConfigBox();


        //    strWaveFilePath = strDefaultPath + "file\\" + cboModulationType.Text + ".bin";
        //    readBinBox.SetDefDir(strDefaultPath + "file");

        //    readBinBox.SetFilter("bin files(*.bin)|*.bin");
        //    readBinBox.SetRegex(@"\.bin$");
        //    readBinBox.SetPath(strWaveFilePath);

        //    if (DialogResult.OK == readBinBox.ShowDialog(this))
        //    {
        //        lalState.Text = "Busy";
        //        strWaveFilePath = readBinBox.GetPath();

        //        //fs = new FileStream(strWaveFilePath, FileMode.Open, FileAccess.Read);
        //        //br = new BinaryReader(fs);
        //        //bufSizeMax = fs.Length;
        //        //buf = new byte[bufSizeMax];
        //        //pMoluData = new uint[bufSizeMax / 4];

        //        //buf = br.ReadBytes(buf.Length);
        //        //for (int i = 0; i < buf.Length / 4; i++)
        //        //{
        //        //    pMoluData[i] = BitConverter.ToUInt32(buf, i * 4);
        //        //}
        //        FileInfo fi;
        //        fi = new FileInfo(readBinBox.GetPath());
        //        if (!SetPcieReg(PcieReg.DDRReset, 1, out lastError))
        //        {
        //            MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }

        //        if (!SetPcieReg(PcieReg.ArbWaveSize, (uint)fi.Length, out lastError))
        //        {
        //            MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }
        //        if (!SetPcieReg(PcieReg.FileMode, 0, out lastError))
        //        {
        //            MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }
        //        if (!SetPcieReg(PcieReg.DDRReset, 0, out lastError))
        //        {
        //            MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }

        //        bgwDmaTransfer.RunWorkerAsync(readBinBox.GetPath());

        //        lalState.Text = "正在配置任意波致硬件...";
        //        waitBox.ShowDialog();

        //        //transferBox.ShowDialog(this);
                

        //    }
        //}
        #endregion

        #region 噪声模块和损耗模块
        private void PicBoxNoise_Click(object sender, EventArgs e)
        {
            noiseBox.SetMainpage(this);
            noiseBox.ShowDialog();
        }

        private void PicBoxLossing_Click(object sender, EventArgs e)
        {
            lossBox.SetMainPage(this);
            lossBox.ShowDialog();
        }
        private void chkLoss_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxLoss.Checked)
            {
                PicBoxLossing.Image = Properties.Resources.损耗选中;

                double dbl;
                dbl = lossBox.GetDblLoss();
                if (dbl >= 0)
                {
                    if (!SetPcieReg(PcieReg.PathLoss, (uint)dbl, out lastError))
                    {
                        MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }     
            }
            else
            {
                PicBoxLossing.Image = null;
            }
            
        }
        private void chkNoise_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxNoise.Checked)
            {

                PicBoxNoise.Image = Properties.Resources.噪声选中;

                if (!SetPcieReg(PcieReg.IsAddNoise, 1, out lastError))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                double dbl;
                dbl = noiseBox.GetSNR();

                if (!SetPcieReg(PcieReg.SNR, (uint)dbl, out lastError))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                               
            }
            else
            {
                if (!SetPcieReg(PcieReg.IsAddNoise,0,out lastError))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                PicBoxNoise.Image = null;
            }
            
        }
        #endregion

        #region Matlab初始化
        
        private void bgwMatlabInit_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = true;
            try
            {
                aeroChan = new AeroChan();
                geneChan = new GeneChan();
               // waveGen = new WaveFileGen();
            }
            catch
            {
                e.Result = false;
                lastError = "初始化Matlab运行环境失败！";
            }
        }

        private void bgwMatlabInit_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((bool)e.Result == false)
                MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            lalState.Text = "Ready";
            PicBoxArbitraryWave.Enabled = true;
            PicBoxFading.Enabled = true;
            PicBoxLossing.Enabled = true;
            PicBoxNoise.Enabled = true;
            chkBoxFading.Enabled = true;
            chkBoxLoss.Enabled = true;
            chkBoxNoise.Enabled = true;
        }

        #endregion

        #region 控制菜单
        private void toolBtnStart_Click(object sender, EventArgs e)
        {
            if (toolBtnStart.Text == "启动设备")
            {
                if (!SetPcieReg(PcieReg.IsRun, 1, out lastError))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                PicBoxArbitraryWave.Enabled = false;
                PicBoxFading.Enabled = false;
                PicBoxLossing.Enabled = false;
                PicBoxNoise.Enabled = false;
                //chkBoxFading.Enabled = false;
                //chkBoxLoss.Enabled = false;
                //chkBoxNoise.Enabled = false;
                toolButDownload.Enabled = false;
                toolBtnQuit.Enabled = false;

                lalState.Text = "设备正在运行";
                toolBtnStart.Text = "停止设备";
                toolBtnStart.Image = Properties.Resources.stopWhite;
            }
            else if (toolBtnStart.Text == "停止设备")
            {
                if (!SetPcieReg(PcieReg.IsRun, 0, out lastError))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                PicBoxArbitraryWave.Enabled = true;
                PicBoxFading.Enabled = true;
                PicBoxLossing.Enabled = true;
                PicBoxNoise.Enabled = true;
                //chkBoxFading.Enabled = true;
                //chkBoxLoss.Enabled = true;
                //chkBoxNoise.Enabled = true;
                toolButDownload.Enabled = true;
                toolBtnQuit.Enabled = true;

                lalState.Text = "Ready";
                toolBtnStart.Text = "启动设备";
                toolBtnStart.Image = Properties.Resources.runWhite;
            }

        }

        private void toolButDownload_Click(object sender, EventArgs e)
        {
            ChanFileSelect configBox = new ChanFileSelect();
           // string errorMsg;
            FileInfo fi;

            configBox.SetDefDir(strChanFilePath);

            if (lalFading.Text == "动态衰落")
            {
                configBox.SetFilter("ach files(*.ach)|*.ach");
                configBox.SetRegex(@"\.ach$");
                configBox.SetPath(strChanFilePath);
            }
            else if (lalFading.Text == "静态衰落")
            {
                configBox.SetFilter("gch files(*.gch)|*.gch");
                configBox.SetRegex(@"\.gch$");
                configBox.SetPath(strChanFilePath);
            }
            else
                return;

            if (DialogResult.OK == configBox.ShowDialog(this))
            {
                lalState.Text = "Busy";
                strChanFilePath = configBox.GetPath();

                fi = new FileInfo(configBox.GetPath());
                if (!SetPcieReg(PcieReg.DDRReset, 1, out lastError))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!SetPcieReg(PcieReg.FadingSize, (uint)fi.Length, out lastError))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!SetPcieReg(PcieReg.FileMode, 1, out lastError))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!SetPcieReg(PcieReg.DDRReset, 0, out lastError))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bgwDmaTransfer.RunWorkerAsync(configBox.GetPath());

                waitBox.SetInformation("正在配置信道参数...");
                waitBox.ShowDialog(this);
            }
        }

        private void toolBtnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region 驱动相关
        /// <summary>
        /// 设置Pcie设备寄存器值
        /// </summary>
        public bool SetPcieReg(PcieReg regAddr, uint regData, out string errorMsg)
        {
            switch (regAddr)
            {
                case PcieReg.FadingSize:
                    {
                        if (!PcieDriver.SetDeviceRegister((uint)regAddr, regData * 8 / 512 - 1))
                        {
                            errorMsg = PcieDriver.GetLastDeviceError();
                            return false;
                        }
                        errorMsg = "";
                        break;
                    }
                case PcieReg.ArbWaveSize:
                    {
                        if (!PcieDriver.SetDeviceRegister((uint)regAddr, regData * 8 / 512 - 1))
                        {
                            errorMsg = PcieDriver.GetLastDeviceError();
                            return false;
                        }
                        errorMsg = "";
                        break;
                    }
                default:
                    {
                        if (!PcieDriver.SetDeviceRegister((uint)regAddr, regData))
                        {
                            errorMsg = PcieDriver.GetLastDeviceError();
                            return false;
                        }
                        errorMsg = "";
                        break;
                    }
            }
            return true;
        }


        private void bgwDmaTransfer_DoWork(object sender, DoWorkEventArgs e)
        {
            FileStream fs = null;
            BinaryReader br = null;
            e.Result = true;

            try
            {
                byte[] buf;
                long bufSizeMax;
                uint bufCount, lenExtra, alignByte = 0x400;

                string dmaFilePath = e.Argument as string;
                bufSizeMax = PcieDriver.MAX_BUF_SIZE;

                fs = new FileStream(dmaFilePath, FileMode.Open, FileAccess.Read);
                br = new BinaryReader(fs);

                bufCount = (uint)(fs.Length / bufSizeMax);
                lenExtra = (uint)(fs.Length % bufSizeMax);
                if ((lenExtra & (alignByte - 1)) != 0)
                    lenExtra = (lenExtra & ~(alignByte - 1)) + alignByte;

                if (bufCount > 0)
                {
                    for (uint ii = 0; ii < bufCount; ii++)
                    {

                        buf = new byte[bufSizeMax];
                        buf = br.ReadBytes(buf.Length);

                        if (PcieDriver.DmaToDevice(buf) == false)
                        {
                            e.Result = false;
                            lastError = PcieDriver.GetLastDeviceError();
                            return;
                        }
                    }
                }

                if (lenExtra > 0)
                {
                    buf = new byte[lenExtra];
                    br.ReadBytes((int)lenExtra).CopyTo(buf, 0);

                    if (PcieDriver.DmaToDevice(buf) == false)
                    {
                        e.Result = false;
                        lastError = PcieDriver.GetLastDeviceError();
                        return;
                    }
                }
            }
            catch
            {
                e.Result = false;
                lastError = "配置硬件失败！";
                lalState.Text = "配置硬件失败！";
            }
            finally
            {
                if (br != null)
                    br.Close();
                if (fs != null)
                    fs.Close();
            }
        }

        private void bgwDmaTransfer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            waitBox.Hide();
            if ((bool)e.Result == false)
                MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            lalState.Text = "Ready";
        }
        #endregion






    }
}
