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

        private string[] typeOfPSK = { "BPSK", "QPSK", "8PSK", "16PSK", "32PSK" };
        private string[] typeOfQAM = { "QAM", "16QAM", "32QAM", "64QAM", "128QAM", "256QAM" };
        private enum ArbiWavePara{Fre,Width,DutyCycle,Depth};
        public enum InputMod { Int, UInt, Float, UFloat };

        private Dictionary<string, double> refModNum = new Dictionary<string, double>() { { "BPSK", 2 }, { "QPSK", 4 }, { "8PSK", 8 }, { "16PSK", 16 }, { "32PSK", 32 },
        {"QAM",4} ,{"16QAM",16}, { "32QAM", 32}, { "64QAM", 64 }, { "128QAM", 128 }, { "256QAM", 256 } };

        public string strSignalName;
         private string strDefaultPath = System.AppDomain.CurrentDomain.BaseDirectory;
        public string strWaveFilePath;
        private string lastError;
        private uint myFlagNum = 0;

        #region 参数上下限
        private double minFre = 1;
        private double maxFre = 5e7;
        private uint minWidth = 0;
        private uint maxWidth = 20;
        private uint minDutyCycle = 0;
        private uint maxDutyCycle = 50;
        private double minDepth = 0;
        private double maxDepth = 1;
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
            cboFreUnit.SelectedIndex = 1;
            cboxRateUnit.SelectedIndex = 1;
            cboSignalType.SelectedIndex = 0;
            cboModuType.SelectedIndex = 0;
            cboxShapingFilter.SelectedIndex = 0;

            myFlagNum = 1;
        }

        #region 接口
        public void SetMainPage(Form1 mpage)
        {
            mainPage = mpage;
        }
        //public void SetPara(Form1 mpage, WaveFileGen wGen)
        //{
        //    mainPage = mpage;
        //    waveGen = wGen;
        //}

        public string GetStrFilePath()
        {
            return strWaveFilePath;
        }

        #endregion

        #region 控件操作
        private void cboAeroPolar_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string errorMsg;
           // lalArbitraryWave.Text = "";
            if (myFlagNum ==0)
            {
                return;
            }

            if (cboSignalType.Text == "PSK调制信号")
            {
                cboModuType.Enabled = true;
                cboModuType.Items.Clear();
                cboModuType.Items.AddRange(typeOfPSK);
                // cboModulationType.SelectedIndex = 0;
                txtSignFre.Enabled = false;
                txtSymbolRate.Enabled = true;
                txtPulseWidth.Enabled = false;
                txtDutyCycle.Enabled = false;
                txtModuDepth.Enabled = false;
                cboxShapingFilter.Enabled = true;
                strSignalName = cboModuType.Text;
            }
            else if (cboSignalType.Text == "QAM调整信号")
            {
                cboModuType.Enabled = true;
                cboModuType.Items.Clear();
                cboModuType.Items.AddRange(typeOfQAM);
                txtSignFre.Enabled = false;
                txtSymbolRate.Enabled = true;
                txtPulseWidth.Enabled = false;
                txtDutyCycle.Enabled = false;
                txtModuDepth.Enabled = false;
                cboxShapingFilter.Enabled = true;
                strSignalName = cboModuType.Text;
            }
            else if (cboSignalType.Text == "方波")	
            {
                cboModuType.Enabled = false;
                txtSignFre.Enabled = true;
                txtSymbolRate.Enabled = false;
                txtPulseWidth.Enabled = false;
                txtDutyCycle.Enabled = true;
                txtModuDepth.Enabled = false;
                cboxShapingFilter.Enabled = false;
	            strSignalName = cboSignalType.Text;
            }
            else if (cboSignalType.Text == "脉冲信号")
	        {
                cboModuType.Enabled = false;
                txtSignFre.Enabled = true;
                txtSymbolRate.Enabled = false;
                txtPulseWidth.Enabled = true;
                txtDutyCycle.Enabled = false;
                txtModuDepth.Enabled = false;
                cboxShapingFilter.Enabled = false;
		        strSignalName = cboSignalType.Text;
	        }
                else if (cboSignalType.Text == "2ASK")
	        {
                cboModuType.Enabled = false;
                txtSignFre.Enabled = false;
                txtSymbolRate.Enabled = true;
                txtPulseWidth.Enabled = false;
                txtDutyCycle.Enabled = false;
                txtModuDepth.Enabled = true;
                cboxShapingFilter.Enabled = true;
	            strSignalName = cboSignalType.Text;
	        }
            else if (cboSignalType.Text == "自定义")
	        {
                cboModuType.Enabled = false;
                txtSignFre.Enabled = false;
                txtSymbolRate.Enabled = false;
                txtPulseWidth.Enabled = false;
                txtDutyCycle.Enabled = false;
                txtModuDepth.Enabled = false;
                cboxShapingFilter.Enabled = false;
                strSignalName = cboSignalType.Text;
		 
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
            else
            {
                cboModuType.Items.Clear();
                cboModuType.Enabled = false;
                //lalArbitraryWave.Text = ComBoxWave.Text;
                cboModuType.Enabled = false;
                txtSignFre.Enabled = true;
                txtSymbolRate.Enabled = false;
                txtPulseWidth.Enabled = false;
                txtDutyCycle.Enabled = false;
                txtModuDepth.Enabled = false;
                cboxShapingFilter.Enabled = false;

                strSignalName = cboSignalType.Text;

               
            }
        }

        private void cboModuType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (myFlagNum == 0)
            {
                return;
            }

            strSignalName = cboModuType.Text;
        }

        #endregion

        #region 输入限制
        private void txtSignFre_TextChanged(object sender, EventArgs e)
        {
            bool isOK = true;
            double dbl,dbl_unit;

            if (cboModuType.Enabled)
	        {
                switch (cboxRateUnit.Text)
	            {
                    case "MBaud":dbl_unit = 1e6;break;
                    case "kBaud":dbl_unit = 1e3;break;
                    case "Baud":dbl_unit = 1;break;
		            default:
                        MessageBox.Show("配置参数错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                      break;
	            }
            
                if (!double.TryParse(txtSymbolRate.Text, out dbl) || !ParaLimitEst(dbl*dbl_unit, ArbiWavePara.Fre))
                {
                    errorShow.SetError(txtSymbolRate, ParaLimitError(ArbiWavePara.Fre));
                    isOK = false;
                }
                else
                {
                    errorShow.SetError(txtSignFre, null);
                }
		 
	        }
            else	
            {
                    switch (cboFreUnit.Text)
	            {
                    case "MHz":dbl_unit = 1e6;break;
                    case "kHz":dbl_unit = 1e3;break;
                    case "Hz":dbl_unit = 1;break;
		            default:
                        MessageBox.Show("配置参数错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                      break;
	            }
            
                if (!double.TryParse(txtSignFre.Text, out dbl) || !ParaLimitEst(dbl*dbl_unit, ArbiWavePara.Fre))
                {
                    errorShow.SetError(txtSignFre, ParaLimitError(ArbiWavePara.Fre));
                    isOK = false;
                }
                else
                {
                    errorShow.SetError(txtSignFre, null);
                }	
            }

            if (!double.TryParse(txtPulseWidth.Text, out dbl) || !ParaLimitEst(dbl, ArbiWavePara.Width))
            {
                errorShow.SetError(txtPulseWidth, ParaLimitError(ArbiWavePara.Width));
                isOK = false;
            }
            else
            {
                errorShow.SetError(txtPulseWidth, null);
            }

            if (!double.TryParse(txtDutyCycle.Text, out dbl) || !ParaLimitEst(dbl, ArbiWavePara.DutyCycle))
            {
                errorShow.SetError(txtDutyCycle, ParaLimitError(ArbiWavePara.DutyCycle));
                isOK = false;
            }
            else
            {
                errorShow.SetError(txtDutyCycle, null);
            }

            if (!double.TryParse(txtModuDepth.Text, out dbl) || !ParaLimitEst(dbl, ArbiWavePara.Depth))
            {
                errorShow.SetError(txtModuDepth, ParaLimitError(ArbiWavePara.Depth));
                isOK = false;
            }
            else
            {
                errorShow.SetError(txtModuDepth, null);
            }

            btnDetermine.Enabled = isOK;
        }
        private bool ParaLimitEst(double para, ArbiWavePara arbiWave)
        {
            switch (arbiWave)
            {
                case ArbiWavePara.Fre:
                    {
                        if (para < minFre || para > maxFre) return false;
                        break;
                    }
                case ArbiWavePara.Depth:
                    {
                        if (para < minDepth || para >maxDepth) return false;
                        break;
                    }
                case ArbiWavePara.DutyCycle:
                    {
                        if (para < minDutyCycle || para > maxDutyCycle) return false;
                        break;
                    }
                case ArbiWavePara.Width:
                    {
                        if (para <minWidth || para >maxWidth) return false;
                        break;
                    }
                default:
                    {
                        return false;
                        //break;
                    }

            }
            return true;
        }

        private string ParaLimitError(ArbiWavePara arbiWave)
        {
            string strMessage = "";
            switch (arbiWave)
            {
                case ArbiWavePara.Fre:
                    strMessage = "输入值应在" + minFre.ToString() + "～" + maxFre.ToString() + "之间";
                    break;
                case ArbiWavePara.Width:
                    strMessage = "输入值应在" + minWidth.ToString() + "～" + maxWidth.ToString() + "之间";
                    break;
                case ArbiWavePara.DutyCycle:
                    strMessage = "输入值应在" + minDutyCycle.ToString() + "～" + maxDutyCycle.ToString() + "之间";
                    break;
                case ArbiWavePara.Depth:
                    strMessage = "输入值应在" + minDepth.ToString() + "～" + maxDepth.ToString() + "之间";
                    break;
                default:
                    break;
            }
            return strMessage;
        }


         private void txtInputUFloat_KeyPress(object sender, KeyPressEventArgs e)
        {
;
            TextBox tBox = sender as TextBox;
            InputLimit(tBox, e,InputMod.UFloat);
        }
        private void txtInputUInt_KeyPress(object sender, KeyPressEventArgs e)
        {

            InputLimit(sender as TextBox, e, InputMod.UInt);
        }
        /// <summary>
        /// 输入限制
        /// </summary>
        static public void InputLimit(TextBox textBox, KeyPressEventArgs e,InputMod inputMod)
        {
            string strStart,strEnd;

            e.Handled = false;
            if (e.KeyChar == '\b')
                return;

            strStart = textBox.Text.Substring(0, textBox.SelectionStart);
            strEnd = textBox.Text.Substring(textBox.SelectionStart + textBox.SelectionLength,
                textBox.Text.Length - textBox.SelectionStart - textBox.SelectionLength);

            switch (inputMod)
            {
                case InputMod.Int:
                    {
                        int data;

                        if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '-')
                        {
                            e.Handled = true;
                            return;
                        }

                        if (!int.TryParse(strStart + e.KeyChar + strEnd, out data) && (strStart + strEnd) != "")
                        {
                            e.Handled = true;
                            return;
                        }
                        break;
                    }
                case InputMod.UInt:
                    {
                        if (!Char.IsDigit(e.KeyChar))
                        {
                            e.Handled = true;
                            return;
                        }
                        break;
                    }
                case InputMod.Float:
                    {
                        float data;

                        if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != '.')
                        {
                            e.Handled = true;
                            return;
                        }

                        if (!float.TryParse(strStart + e.KeyChar + strEnd, out data) 
                            && (strStart + strEnd) != ""
                            && (strStart + e.KeyChar + strEnd) != "-.")
                        {
                            e.Handled = true;
                            return;
                        }
                        break;
                    }
                case InputMod.UFloat:
                    {
                        float data;

                        if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                        {
                            e.Handled = true;
                            return;
                        }

                        if (!float.TryParse(strStart + e.KeyChar + strEnd, out data)
                              && (strStart + strEnd) != "")
                        {
                            e.Handled = true;
                            return;
                        }
                        break;
                    }
                default:e.Handled = true;break;
            }
        }
        #endregion

        //#region 调用Matlab产生文件
        //private void btnDetermine_Click(object sender, EventArgs e)
        //{
        //    ArrayList lit = new ArrayList();//zhu 会反复进行装箱拆箱
        //    double dbl_Temp; //获取控件中参数的中间量


        //    if (errorShow.GetError(txtSignFre) != "" ||
        //        errorShow.GetError(txtModuDepth) != "" ||
        //        errorShow.GetError(txtSymbolRate) != "" ||
        //        errorShow.GetError(txtPulseWidth) != "" ||
        //        errorShow.GetError(txtDutyCycle) != "")
        //    {
        //        MessageBox.Show("配置参数错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    //频率/码元速率
        //    if (cboModuType.Enabled)
        //    {
        //        if (!double.TryParse(txtSymbolRate.Text, out dbl_Temp))
        //        {
        //            MessageBox.Show("载波参数配置错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }
        //        switch (cboxRateUnit.Text)
        //        {
        //            case "MBaud": dbl_Temp *= 1e+6; break;
        //            case "kBaud": dbl_Temp *= 1e+3; break;
        //            case "Baud": break;
        //            default:
        //                {
        //                    MessageBox.Show("载波参数单位配置错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                    return;
        //                    break;
        //                }

        //        }
        //    }
        //    else
        //    {
        //        if (!double.TryParse(txtSignFre.Text, out dbl_Temp))
        //        {
        //            MessageBox.Show("频率参数配置错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }
        //        switch (cboFreUnit.Text)
        //        {
        //            case "MHz": dbl_Temp *= 1e+6; break;
        //            case "kHz": dbl_Temp *= 1e+3; break;
        //            case "Hz": break;
        //            default:
        //                {
        //                    MessageBox.Show("频率参数单位配置错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                    return;
        //                    break;
        //                }

        //        }
        //    }
        //    lit.Add(dbl_Temp);

        //    //波形
        //    dbl_Temp = (int)cboSignalType.SelectedIndex + 1; 
        //    lit.Add(dbl_Temp);

        //    //调制码数
        //    if (cboSignalType.Text == "2ASK")
        //    {		        
        //        dbl_Temp = 2;
        //    }
        //    else if(cboModuType.Enabled)
        //    {                        
        //        dbl_Temp = refModNum[cboModuType.Text];
        //    }
        //    else
        //    {
        //        dbl_Temp = 0;
        //    }
        //    lit.Add(dbl_Temp);

        //    //调整深度
        //    if (!double.TryParse(txtModuDepth.Text, out dbl_Temp))
        //    {
        //        MessageBox.Show("载波参数配置错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }
        //    lit.Add(dbl_Temp);

        //    //脉冲宽度
        //    if (!double.TryParse(txtPulseWidth.Text, out dbl_Temp))
        //    {
        //        MessageBox.Show("载波参数配置错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }
        //    lit.Add(dbl_Temp);
        //    //占空比
        //    if (!double.TryParse(txtDutyCycle.Text, out dbl_Temp))
        //    {
        //        MessageBox.Show("载波参数配置错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }
        //    lit.Add(dbl_Temp);

        //    //滤波器
        //    dbl_Temp = (double)cboxShapingFilter.SelectedIndex;
        //    lit.Add(dbl_Temp);

        //    //输出文件路径
        //    strWaveFilePath = strDefaultPath + "Output\\ArbitraryWave.bin";
        //    lit.Add(strWaveFilePath);

        //    bgwMatlabGen.RunWorkerAsync(lit);

            

        //    waitBox.SetInformation("正在处理，请稍候...");
        //    this.DialogResult = DialogResult.OK;
        //    waitBox.ShowDialog(this);
        //}

        //private void bgwMatlabGen_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    ArrayList lit = e.Argument as ArrayList;
        //    e.Result = true;

        //    try
        //    {

        //        MWNumericArray fc             = (double)lit[0],
        //                       funcNum        = (double)lit[1],
        //                       ModNum         = (double)lit[2],
        //                       ModulationDeep = (double)lit[3],
        //                       pWidth         = (double)lit[4],
        //                       sWidth         = (double)lit[5],
        //                       filter         = (double)lit[6];
        //        MWCharArray filename = lit[7] as string;

        //        MWArray[] matlabRlt = waveGen.ArbitraryWaveGen(2, fc, funcNum, ModNum, ModulationDeep, pWidth, sWidth, filename);
        //        if ((matlabRlt[0] as MWNumericArray).ToScalarInteger() != 0)
        //        {
        //            e.Result = false;
        //            lastError = matlabRlt[1].ToString();
        //            return;
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        e.Result = false;
        //        lastError = "调用Matlab失败！";
        //    }

        //}

        //private void bgwMatlabGen_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{

        //    //waitBox.Hide();

        //    if ((bool)e.Result == true)
        //    {
        //        //this.Hide();
        //        mainPage.lalArbitraryWave.Text = strSignalName;


        //        FileInfo fi;
        //        fi = new FileInfo(strWaveFilePath);
        //        if (!mainPage.SetPcieReg(Form1.PcieReg.DDRReset, 1, out lastError))
        //        {
        //            MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }

        //        if (!mainPage.SetPcieReg(Form1.PcieReg.ArbWaveSize, (uint)fi.Length, out lastError))
        //        {
        //            MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }
        //        if (!mainPage.SetPcieReg(Form1.PcieReg.FileMode, 0, out lastError))
        //        {
        //            MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }
        //        if (!mainPage.SetPcieReg(Form1.PcieReg.DDRReset, 0, out lastError))
        //        {
        //            MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }
        //        bgwDmaTransfer.RunWorkerAsync(strWaveFilePath);
        //    }
        //    else
        //        MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //}

        //#endregion

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
