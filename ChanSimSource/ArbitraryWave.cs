using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using pcieDriverHelper;
using MathWorks.MATLAB.NET.Utility;
using MathWorks.MATLAB.NET.Arrays;


namespace ChanSimSource
{
    public partial class ArbitraryWave : Form
    {
        private WaitBox waitBox = new WaitBox();
        private Form1 mainPage;

        private string[] typeOfPSK = { "BPSK", "QPSK","OPSK", "8PSK", "16PSK" };
        private string[] typeOfQAM = { "4QAM", "16QAM", "32QAM", "64QAM", "128QAM", "256QAM","512QAM" };
        //private enum ArbiWavePara{Fre,Width,DutyCycle,Depth};
        //public enum InputMod { Int, UInt, Float, UFloat };

        private Dictionary<string, double> refModNum = new Dictionary<string, double>() { { "BPSK", 2 }, { "QPSK", 4 }, { "OPSK", 4 },{ "8PSK", 8 }, { "16PSK", 16 }, { "32PSK", 32 },
        {"QAM",4} ,{"16QAM",16}, { "32QAM", 32}, { "64QAM", 64 }, { "128QAM", 128 }, { "256QAM", 256 }, { "512QAM", 512 } };

        public string strSignalName;
        private string strDefaultPath = System.AppDomain.CurrentDomain.BaseDirectory;
        public string strWaveFilePath;
        private string lastError;
        private uint baseData = 0; //基带模式各级基础数据
       // private uint myFlagNum = 0;

        #region 参数上下限
        private double minDcOffset = 0;
        private double maxDcOffset = 2.5;
        #endregion

        public ArbitraryWave()
        {
            InitializeComponent();
        }

        public ArbitraryWave(Form1 mpage)
        {
            InitializeComponent();
            mainPage = mpage;
        }
        private void ArbitraryWave_Load(object sender, EventArgs e)
        {
            //cboxDataSource.SelectedIndex = 1;
            //cboxSymbolNum.SelectedIndex = 1;
            //cboxSignalType.SelectedIndex = 0;
            ////cboxModuType.SelectedIndex = 0;
            //cboxFilterType.SelectedIndex = 0;
        }

        #region 接口
        public void SetMainPage(Form1 mpage)
        {
            mainPage = mpage;
        }

        public string GetStrFilePath()
        {
            return strWaveFilePath;
        }

        #endregion

        #region 控件操作
        private void cboxSignalType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string msg;
            if (cboxSignalType.Text == "单音")
            {
                cboxModuType.Enabled = false;
                cboxDataSource.Enabled = false;
                cboxSymbolNum.Enabled = false;
                tboxFrequency.Enabled = true;
                cboxFreUnit.Enabled = true;
                tboxDutyCycle.Enabled = false;
                tboxSymbolRate.Enabled = false;
                cboxFilterType.Enabled = false;
                strSignalName = cboxModuType.Text;

                if (!mainPage.SetPcieReg(Form1.PcieReg.SignalType, 1, out msg))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (cboxSignalType.Text == "双音")
            {
                cboxModuType.Enabled = false;
                cboxDataSource.Enabled = false;
                cboxSymbolNum.Enabled = false;
                tboxFrequency.Enabled = true;
                cboxFreUnit.Enabled = true;
                tboxDutyCycle.Enabled = false;
                tboxSymbolRate.Enabled = false;
                cboxFilterType.Enabled = false;
                strSignalName = cboxModuType.Text;
                if (!mainPage.SetPcieReg(Form1.PcieReg.SignalType, 2, out msg))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (cboxSignalType.Text == "脉冲")
	        {
                cboxModuType.Enabled = false;
                cboxDataSource.Enabled = false;
                cboxSymbolNum.Enabled = false;
                tboxFrequency.Enabled = false;
                cboxFreUnit.Enabled = false;
                tboxDutyCycle.Enabled = true;
                tboxSymbolRate.Enabled = false;
                cboxFilterType.Enabled = false;
                strSignalName = cboxModuType.Text;
                if (!mainPage.SetPcieReg(Form1.PcieReg.SignalType, 3, out msg))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
	        }
            else if (cboxSignalType.Text == "PSK调制信号") 
            {
                baseData = 0;
                cboxModuType.Enabled = true;
                cboxModuType.Items.Clear();
                cboxModuType.Items.AddRange(typeOfPSK);
                cboxDataSource.Enabled = true;
                cboxSymbolNum.Enabled = true;
                tboxFrequency.Enabled = false;
                cboxFreUnit.Enabled = false;
                tboxDutyCycle.Enabled = false;
                tboxSymbolRate.Enabled = true;
                cboxFilterType.Enabled = true;
                strSignalName = cboxModuType.Text;
                if (!mainPage.SetPcieReg(Form1.PcieReg.SignalType, 4, out msg))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (cboxSignalType.Text == "QAM调制信号") 
            {
                baseData = 5;
                cboxModuType.Enabled = true;
                cboxModuType.Items.Clear();
                cboxModuType.Items.AddRange(typeOfQAM);
                cboxDataSource.Enabled = true;
                cboxSymbolNum.Enabled = true;
                tboxFrequency.Enabled = false;
                cboxFreUnit.Enabled = false;
                tboxDutyCycle.Enabled = false;
                tboxSymbolRate.Enabled = true;
                cboxFilterType.Enabled = true;
                strSignalName = cboxModuType.Text;
                if (!mainPage.SetPcieReg(Form1.PcieReg.SignalType, 4, out msg))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (cboxSignalType.Text == "任意波")
	        {
                cboxModuType.Enabled = false;
                cboxModuType.Enabled = false;
                cboxDataSource.Enabled = false;
                cboxSymbolNum.Enabled = false;
                tboxFrequency.Enabled = false;
                cboxFreUnit.Enabled = false;
                tboxDutyCycle.Enabled = false;
                tboxSymbolRate.Enabled = false;
                cboxFilterType.Enabled = false;
                strSignalName = cboxSignalType.Text;
                if (!mainPage.SetPcieReg(Form1.PcieReg.SignalType, 5, out msg))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
		 
                 ConfigBox readBinBox = new ConfigBox();


                strWaveFilePath = strDefaultPath + "file";
                readBinBox.SetDefDir(strDefaultPath + "file");

                readBinBox.SetFilter("bin files(*.bin)|*.bin");
                readBinBox.SetRegex(@"\.bin$");
                readBinBox.SetPath(strWaveFilePath);

                if (DialogResult.OK == readBinBox.ShowDialog(this))
                {
                    mainPage.lalState.Text = "Busy";
                    strWaveFilePath = readBinBox.GetPath();

                    FileInfo fi;
                    fi = new FileInfo(readBinBox.GetPath());
                    if (!mainPage.SetPcieReg(Form1.PcieReg.DDRReset, 1, out lastError))
                    {
                        MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!mainPage.SetPcieReg(Form1.PcieReg.ArbWaveSize, (uint)fi.Length, out lastError))
                    {
                        MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (!mainPage.SetPcieReg(Form1.PcieReg.FileMode, 0, out lastError))
                    {
                        MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (!mainPage.SetPcieReg(Form1.PcieReg.DDRReset, 0, out lastError))
                    {
                        MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    bgwDmaTransfer.RunWorkerAsync(readBinBox.GetPath());

                    mainPage.lalState.Text = "正在配置任意波至硬件...";
                    waitBox.SetInformation("正在配置任意波至硬件...");
                    waitBox.ShowDialog();
                }
	        }
        }

        private void cboModuType_SelectedIndexChanged(object sender, EventArgs e)
        {
            strSignalName = cboxModuType.Text;
            string errorMsg;
            uint data = 0;
            int getData = cboxModuType.SelectedIndex + (int)baseData;

            if (getData < 13 && getData > -1)
            {
                data = (uint)getData;
            }
            if (!mainPage.SetPcieReg(Form1.PcieReg.ModulateType, data, out errorMsg))
            {
                MessageBox.Show(errorMsg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }            

            //string filePath = strDefaultPath + "file\\"+ strSignalName + ".txt";

            //StreamReader sr = new StreamReader(filePath,Encoding.Default);
            //String line;
            //UInt32 hexData = 0;
            //for (int i = 0; i < refModNum[cboxModuType.Text]; i++)
            //{
            //    line = sr.ReadLine();
            //    if(line != ""){
            //        hexData = Convert.ToUInt32(line,16);
            //        if (!mainPage.SetPcieReg(Form1.PcieReg.MappingData+4*i, hexData, out lastError))
            //        {
            //            MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return;
            //        }
            //    }                
            //}            
        }

        private void cboxDataSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            string errorMsg;
            uint data = 0;
            int getData = cboxDataSource.SelectedIndex;

            if (getData < 10 && getData > -1)
            {
                data = (uint)getData;
            }

            if (!mainPage.SetPcieReg(Form1.PcieReg.DataSource, data, out errorMsg))
            {
                MessageBox.Show(errorMsg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void cboxFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string errorMsg;
            uint data = (uint)cboxFilterType.SelectedIndex;

            if (!mainPage.SetPcieReg(Form1.PcieReg.FilterType, data, out errorMsg))
            {
                MessageBox.Show(errorMsg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            if (!mainPage.SetPcieReg(Form1.PcieReg.FilterTimes, 3, out errorMsg))
            {
                MessageBox.Show(errorMsg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void cboxSymbolNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            string errorMsg;
            uint data = 0;
            int getData = cboxSymbolNum.SelectedIndex;

            if (getData < 11 && getData > -1)
            {
                data = (uint)getData;
            }
            if (!mainPage.SetPcieReg(Form1.PcieReg.SymbolNum, data, out errorMsg))
            {
                MessageBox.Show(errorMsg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void btnDetermine_Click(object sender, EventArgs e)
        {
            string errorMsg = "";
            UInt32 data = 0;
            decimal fre = 0;
            
            if (tboxFrequency.Enabled)
            {
                
                if (!decimal.TryParse(tboxFrequency.Text, out fre))
                {
                    MessageBox.Show("频率参数配置错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                fre = fre * (decimal)Math.Pow(1000, (double)cboxFreUnit.SelectedIndex);
                decimal tempFre;
                tempFre= fre / 200000000 * (decimal)Math.Pow(2, 32);
                data = (UInt32)Math.Floor(tempFre);
                if (!mainPage.SetPcieReg(Form1.PcieReg.Frequency, data, out errorMsg))
                {
                    MessageBox.Show(errorMsg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (tboxDutyCycle.Enabled)
            {
                decimal dutyCycle;
                if (!decimal.TryParse(tboxDutyCycle.Text, out dutyCycle))
                {
                    MessageBox.Show("占空比参数配置错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                dutyCycle = 200000000 / fre / 100 * dutyCycle;
                data = (UInt32)Math.Floor(dutyCycle);
                if (!mainPage.SetPcieReg(Form1.PcieReg.DutyCycle, data, out errorMsg))
                {
                    MessageBox.Show(errorMsg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (tboxSymbolRate.Enabled)
            {
                decimal rate = 0;
                if (!decimal.TryParse(tboxSymbolRate.Text, out rate))
                {
                    MessageBox.Show("码元速率参数配置错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                rate = ((decimal)Math.Pow(2, 32)/200*4)*rate;
                data = (UInt32)Math.Round(rate);
                if (!mainPage.SetPcieReg(Form1.PcieReg.DecimalInter, data, out errorMsg))
                {
                    MessageBox.Show(errorMsg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            Close();
        }

        #endregion

        #region 输入限制
        private void tboxPositiveNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b') return;

            TextBox tbox = sender as TextBox;
            InputLimit inputLimit = new TextBoxInputLimit(tbox);
            inputLimit = new NumberType(inputLimit);
            inputLimit = new PositiveType(inputLimit);
            if (!inputLimit.InputCheck(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tboxIntegerNum_KeyPress(object sender, KeyPressEventArgs e) 
        {
            if (e.KeyChar == '\b') return;
            TextBox tbox = sender as TextBox;
            InputLimit inputLimit = new TextBoxInputLimit(tbox);
            inputLimit = new NumberType(inputLimit);
            inputLimit = new PositiveType(inputLimit);
            inputLimit = new IntegerType(inputLimit);

            if (!inputLimit.InputCheck(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion

       

        #region 驱动DMA传输
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
                mainPage.lalState.Text = "配置硬件失败！";
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

            mainPage.lalState.Text = "Ready";

            this.Hide();
        }
        #endregion



       

        
    }
}
