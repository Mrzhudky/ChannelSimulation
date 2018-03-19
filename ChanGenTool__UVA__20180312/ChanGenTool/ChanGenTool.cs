using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using MathWorks.MATLAB.NET.Utility;
using MathWorks.MATLAB.NET.Arrays;
using AeroChanFun;
using System.Collections;
using MyControl;
using pcieDriverHelper;
using System.Diagnostics;

namespace ChanGenTool
{
    public partial class ChanGenTool : Form
    {
        private AeroChan aeroChan;
        private DataGridView dgvTmp;
        public WaitBox waitBox = new WaitBox();
        private TransferBox transferBox = new TransferBox();
        //private DopplerBox dopplerBox = new DopplerBox();
        private RiceBox riceBox = new RiceBox();
        private RefBox refBox = new RefBox();

        private WaveTool waveTool;
        private WaveCon waveCon;

        private List<Dictionary<string, double>> geneFad = new List<Dictionary<string, double>>();

        private enum SoftCfgMod { aero, gene, all };
        private enum MatlabFig { trace, ante };
        private enum ChanGene { aero, gene };
        public enum InputMod { Int, UInt, Float, UFloat };
        public enum ChanAssign { apDielectric, apConductivity, apAngSp, gpRiceK, gpRiceAOA, gpDopplerFre };
        private enum ChanPara
        {
            apDielectric, apConductivity, apAngSp, apUpdate, apCarrierFre,
            awFreqquency,awDutyCyclt,awSymbolRate
        };

        private string[] listOfPSk = { "BPSK", "QPSK", "8PSK", "16PSK" };
        private string[] listOfQAM = { "4QAM", "16QAM", "32QAM", "64QAM", "128QAM", "256QAM", "512QAM" };
        private Dictionary<string, double> refModNum = new Dictionary<string, double>() { { "BPSK", 2 }, { "QPSK", 4 }, { "OPSK", 4 },{ "8PSK", 8 }, { "16PSK", 16 }, { "32PSK", 32 },
        {"4QAM",4} ,{"16QAM",16}, { "32QAM", 32}, { "64QAM", 64 }, { "128QAM", 128 }, { "256QAM", 256 }, { "512QAM", 512 } };

        //private enum PcieReg
        //{
        //    IsRun = 0x100,
        //    AddNoise = 0x104,
        //    SNR = 0x108,
        //    DMASize = 0x10c
        //}
        private enum PcieReg
        {
            IsRun = 0x100,       //1启动，0停止
            IsAddNoise = 0x104,  //1加噪，0不加噪
            SNR = 0x108,         //信噪比
            IsAddFad = 0x10c,    //1--加衰落，0--不加衰落
            FadMode = 0x110,     //1为动态，发0为静态
            DDRReset = 0x114,    //发1用于DDR3复位
            FileMode = 0x118,    //0--任意波文件 1--衰落文件
            ArbWaveSize = 0x11c, //发32bit文件大小
            FadingSize = 0x120,  //衰落文件大小
            FirstDelay = 0x124,  //第一条径的时延
            SecondDelay = 0x128, //第二条径的时延
            ThirdDelay = 0x12c,  //第三条径的时延
            FourthDelay = 0x130, //第四条径的时延
            FifthDelay = 0x134,  //第五条径的时延
            SixthDelay = 0x138,  //第六条径的时延
            PathLoss = 0x13c,    //损耗
            ModulateType = 0x224,//调制信号类型
            FilterType = 0x228,  //滤波类型
            FilterTimes = 0x22c, //成型滤波器倍数:3
            SignalType = 0x238,  //信号类型
            SymbolNum = 0x23c,   //码元数量:0--10
            DataSource = 0x240,  //数据源
            DecimalInter = 0x258,//小数内插倍数
            MappingData = 0x1000,//内部码元映射寄存器起始地址
            Frequency = 0x2000,  //单音、双音、脉冲的频率
            DutyCycle = 0x2004   //脉冲的占空比
        }

        private string lastError;
        private string defaultSavName = "autoSave.xml";
        private string strDefaultPath = System.AppDomain.CurrentDomain.BaseDirectory;
        private string aeroChanParaPath;
        private string aeroChanPath;
        private string geneChanPath;
        private string waveFilePath;
        private int startFlag = 0;

        #region Matlab输入参数相关

        private const int geneFadParaNum = 8;
        #endregion

        #region 播放相关

        private float aeroUpDate = 0;
        private const float minAeroPlaySpeed = 0.1f;
        private const float maxAeroPlaySpeed = 10;
        private const int aeroPlayDfltPd = 1000;  // hu 单位:ms
        #endregion

        #region 信道参数文件相关信息
        private const int aeroTime = 0;
        private const int uvaDelay    = 1;
        private const int uvaSca1Delay = 2;
        private const int uvaSca2Delay = 3;
        private const int uvaSca3Delay = 4;
        private const int uvaDoppler  = 5;
        private const int uvaGain     = 7;
        private const int uvaSca1Gain = 8; 
        private const int uvaSca2Gain = 9;
        private const int uvaSca3Gain = 10;        
        private const int uvaAOA      = 11;
        private const int uvaSca1AOA  = 12;
        private const int uvaSca2AOA  = 13;
        private const int uvaSca3AOA  = 14;
        private const int uvaEOA      = 15;
        private const int uvaSca1EOA  = 16;
        private const int uvaSca2EOA  = 17;
        private const int uvaSca3EOA  = 18;
        #endregion

        #region 理论相关固定值

        private Dictionary<string, double[]> refModDef = new Dictionary<string, double[]>()
        {{"干燥地面",new double[]{3,0.0033}},{"中等地面",new double[]{15,0.08}},
         {"潮湿地面",new double[]{30,0.3}},  {"海洋",new double[]{70,5.5}}};
        private Dictionary<string, double> refEnvDef = new Dictionary<string, double>()
        {{"郊区",1},{"城市",2},{"森林",3},{"海洋",4}};
        #endregion

        #region 理论相关极限值

        private const int maxAeroCluNum = 4;
        private const double minAeroUpdate = 10;           // hu 单位:ms
        private const double maxAeroUpdate = 1000;         // hu 单位:ms
        private const double stepAeroUpdate = 10;          // hu 单位:ms
        private const double minAeroDielectric = 0;
        private const double minAeroConductivity = 0;
        private const double minAeroAngSp = 0;             // hu 单位:deg
        private const double maxAeroAngSp = 5;             // hu 单位:deg
        private const double minAeroCarrierFre = 0;        // hu 单位:deg

        private const double minDutyCycle = 0;              
        private const double maxDutyCycle = 50;            
        private const double minWaveFrequency = 0;        //  单位:Hz
        private const double maxWaveFrequency = 62500000.0;     // 单位:Hz
        private const double minSymbolRate = 0;        //  单位:Hz
        private const double maxSymbolRate = 62500000.0;     //  单位:Hz
        #endregion

        #region 驱动操作相关
        /// <summary>
        /// 设置Pcie设备寄存器值
        /// </summary>
        private bool SetPcieReg(PcieReg regAddr,uint regData,out string errorMsg)
        {
            switch (regAddr)
            {
                case PcieReg.IsRun:
                    {
                        if (!PcieDriver.SetDeviceRegister((uint)regAddr, regData))
                        {
                            errorMsg = PcieDriver.GetLastDeviceError();
                            return false;
                        }
                        errorMsg = "";
                        break;
                    }
                case PcieReg.ArbWaveSize:
                case PcieReg.FadingSize:
                    {
                        if (!PcieDriver.SetDeviceRegister((uint)regAddr, regData*8/512-1))
                        {
                            errorMsg = PcieDriver.GetLastDeviceError();
                            return false;
                        }
                        errorMsg = "";
                        break;
                    }
                default:
                    {
                        if (PcieDriver.SetDeviceRegister((uint)regAddr, regData))
                        {
                            errorMsg = "";
                            break;
                        }
                        errorMsg = PcieDriver.GetLastDeviceError();
                        return false;
                        
                        //return false;
                    }
            }
            return true;
        }
        #endregion

        #region 特定功能
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

        /// <summary>
        /// 清空btnChanFig的单击事件
        /// </summary>
        private void ClearAllEvent()
        {
            btnChanFig.Click -= new EventHandler(收发端轨迹ToolStripMenuItem_Click);
            btnChanFig.Click -= new EventHandler(发射端ToolStripMenuItem_Click);
            btnChanFig.Click -= new EventHandler(接收端ToolStripMenuItem_Click);
        }

        /// <summary>
        /// 获取空格以填充字符串
        /// </summary>
        static private string AddSpace(string str, int lenFin)
        {
            int len = Encoding.Default.GetBytes(str).Length;
            for (int ii = len; ii < lenFin; ii++)
            {
                str += " ";
            }
            return str;
        }

        /// <summary>
        /// 获取空格以填充字符串
        /// </summary>
        static public bool TabString(string[] strTitle, string[] strData, out string[] strOut)
        {
            int maxLen = 0,len;
            strOut = new string[strTitle.Length];

            if (strTitle.Length != strData.Length)
                return false;

            foreach (string str in strTitle)
            {
                len = Encoding.Default.GetBytes(str).Length;
                if (maxLen < len)
                    maxLen = len;
            }

            for (int ii = 0; ii < strTitle.Length;ii++)
            {
                strOut[ii] = AddSpace(strTitle[ii], maxLen) + "\t" + strData[ii];
            }
            return true;
        }
        #endregion

        #region 理论值范围判断
        /// <summary>
        /// 判断信道相关参数是否在范围内
        /// </summary>        
        public bool ParaLimitEst(double para, ChanAssign chanPara)
        {
            switch (chanPara)
            {
                case ChanAssign.apDielectric:
                    {
                        if (para < minAeroDielectric)
                            return false;
                        break;
                    }
                case ChanAssign.apConductivity:
                    {
                        if (para < minAeroConductivity)
                            return false;
                        break;
                    }
                case ChanAssign.apAngSp:
                    {
                        if (para < minAeroAngSp || para > maxAeroAngSp)
                            return false;
                        break;
                    }
                default: return false;
            }

            return true;
        }
        private bool ParaLimitEst(double para,ChanPara chanPara)
        {
            switch (chanPara)
            {
                case ChanPara.apDielectric:
                    {
                        if (para < minAeroDielectric)
                            return false;
                        break;
                    }
                case ChanPara.apConductivity:
                    {
                        if (para < minAeroConductivity)
                            return false;
                        break;
                    }
                case ChanPara.apAngSp:
                    {
                        if (para < minAeroAngSp || para > maxAeroAngSp)
                            return false;
                        break;
                    }
                case ChanPara.apUpdate:
                    {
                        if (para < minAeroUpdate || para > maxAeroUpdate || para % stepAeroUpdate != 0)
                            return false;
                        break;
                    }
                case ChanPara.apCarrierFre:
                    {
                        if (para < minAeroCarrierFre)
                            return false;
                        break;
                    }

                case ChanPara.awDutyCyclt:
                    {
                        if (para < minDutyCycle || para > maxDutyCycle)
                            return false;
                        break;
                    }
                case ChanPara.awFreqquency:
                    {
                        if (para < minWaveFrequency || para >= maxWaveFrequency)
                            return false;
                        break;
                    }
                case ChanPara.awSymbolRate:
                    {
                        if (para < minSymbolRate || para > maxSymbolRate)
                            return false;
                        break;
                    }
                
                default: return false;
            }

            return true;
        }

        /// <summary>
        /// 获取信道相关参数超过范围错误信息
        /// </summary>
        public string ParaLimitError(ChanAssign chanPara)
        {
            switch (chanPara)
            {
                case ChanAssign.apDielectric:
                    return "输入值应大于等于" + minAeroDielectric.ToString();
                case ChanAssign.apConductivity:
                    return "输入值应大于等于" + minAeroConductivity.ToString();
                case ChanAssign.apAngSp:
                    return "输入值应在" + minAeroAngSp.ToString() + "～" + maxAeroAngSp.ToString() + "之间";

                //case ChanAssign.gpRiceK:
                //    return "输入值应在" + minGeneRiceK.ToString() + "～" + maxGeneRiceK.ToString() + "之间";
                //case ChanAssign.gpRiceAOA:
                //    return "输入值应在" + minGeneRiceAOA.ToString() + "～" + maxGeneRiceAOA.ToString() + "之间";
                //case ChanAssign.gpDopplerFre:
                //    return "输入值应大于等于" + minGeneDopplerFre.ToString();
                default: return "";
            }
        }
        private string ParaLimitError(ChanPara chanPara)
        {
            switch (chanPara)
            {
                case ChanPara.apDielectric:
                    return "输入值应大于等于" + minAeroDielectric.ToString();
                case ChanPara.apConductivity:
                    return "输入值应大于等于" + minAeroConductivity.ToString();
                case ChanPara.apAngSp:
                    return "输入值应在" + minAeroAngSp.ToString() + "～" + maxAeroAngSp.ToString() + "之间";
                case ChanPara.apUpdate:
                    return "输入值应在" + minAeroUpdate.ToString() + "～" + maxAeroUpdate.ToString() + "之间，且为" + stepAeroUpdate.ToString() + "的整倍数";
                case ChanPara.apCarrierFre:
                    return "输入值应大于等于" + minAeroCarrierFre.ToString();

                case ChanPara.awFreqquency:
                    return "输入值应在" + minWaveFrequency.ToString() + "Hz～" + maxWaveFrequency.ToString() + "Hz之间";
                case ChanPara.awSymbolRate:
                    return "输入值应在" + minSymbolRate.ToString() + "～" + maxSymbolRate.ToString() + "之间";
                case ChanPara.awDutyCyclt:
                    return "输入值应在" + minDutyCycle.ToString() + "～" + maxDutyCycle.ToString() + "之间";
                default: return "";
            }
        }
        #endregion

        #region 控件显示
        /// <summary>
        /// 在气泡中显示地面特性相关参数
        /// </summary>
        private bool AeroRefEvnShow(double dielectric, double conductivity, double angSp)
        {
            string name, unit, strData;
            string[] title = new string[3];
            string[] data = new string[3];

            title[0] = refBox.GetDielectric() + ":";
            data[0] = dielectric.ToString();

            title[1] = refBox.GetConductivity() + ":";
            data[1] = conductivity.ToString();

            refBox.GetAngSp(out name, out unit);
            title[2] = name + ":";
            data[2] = angSp.ToString() + unit;

            if (!TabString(title, data, out data))
                return false;

            strData = cboAeroRefEnv.Text;
            if (cboAeroRefMod.Enabled)
                strData += "(" + cboAeroRefMod.Text + ")";
            foreach (string str in data)
            {
                strData += "\n" + str;
            }
            TipShow.SetToolTip(cboAeroRefEnv, strData);
            TipShow.SetToolTip(cboAeroRefMod, strData);

            return true;
        }

        /// <summary>
        /// 在气泡中显示多径衰落参数
        /// </summary>
        //private bool GeneFadShow(DataGridViewCell dgvc,Dictionary<string,double> fad)
        //{
        //    string name, unit, strData;
        //    string[] title, data;

        //    if (!fad.ContainsKey(dgvc.EditedFormattedValue.ToString()))
        //        return false;

        //    //if (dgvc.EditedFormattedValue.ToString() == "纯多普勒")
        //    //{
        //    //    title = new string[1];
        //    //    data = new string[1];

        //    //    dopplerBox.GetDoppler(out name, out unit);
        //    //    if (!fad.ContainsKey(name))
        //    //        return false;

        //    //    title[0] = name + ":";
        //    //    data[0] = fad[name].ToString() + unit;
        //    //}
        //    //else if (dgvc.EditedFormattedValue.ToString() == "莱斯衰落")
        //    //{
        //    //    title = new string[2];
        //    //    data = new string[2];

        //    //    riceBox.GetRiceK(out name, out unit);
        //    //    if (!fad.ContainsKey(name))
        //    //        return false;

        //    //    title[0] = name + ":";
        //    //    data[0] = fad[name].ToString() + unit;

        //    //    riceBox.GetRiceAOA(out name, out unit);
        //    //    if (!fad.ContainsKey(name))
        //    //        return false;

        //    //    title[1] = name + ":";
        //    //    data[1] = fad[name].ToString() + unit;
        //    //}
        //    //else if (dgvc.EditedFormattedValue.ToString() == "瑞利衰落")
        //    //{
        //    //    title = new string[0];
        //    //    data = new string[0];
        //    //}
        //    //else
        //    //    return false;

        //    strData = dgvc.EditedFormattedValue.ToString();
        //    if (!TabString(title, data, out data))
        //        return false;
        //    foreach (string str in data)
        //    {
        //        strData += "\n" + str;
        //    }
        //    dgvc.ToolTipText = strData;

        //    return true;
        //}
        #endregion

        #region 输出文件相关
        /// <summary>
        /// 显示输出文件路径
        /// </summary>
        private void OutputPathShow(string strOutputDir)
        {
            Graphics graphics = CreateGraphics();
            SizeF sizeWorkPath = graphics.MeasureString(strOutputDir, lalOutputPath.Font);
            SizeF sizeDateNow = graphics.MeasureString(lblDateNow.Text, lblDateNow.Font);

            float fltExtraWords = sizeWorkPath.Width - lalOutputPath.Size.Width - lblDateNow.Size.Width + sizeDateNow.Width + 50;
            if (fltExtraWords > 0)
            {
                float fltWordWidth = sizeWorkPath.Width / strOutputDir.Length;
                int uintWordIdx = strOutputDir.Length - Convert.ToInt32(fltExtraWords / fltWordWidth);
                strOutputDir = strOutputDir.Substring(0, uintWordIdx) + "...";
            }
            lalOutputPath.Text = strOutputDir;
        }

        /// <summary>
        /// 获取输出文件名
        /// </summary>
        private string[] GetOutputPath()
        {

            string[] strOutputPath = new string[2];
            if ((string)btnOutputCover.Image.Tag == "不覆盖")
            {
                string strDirPath = lalOutputPath.ToolTipText + DateTime.Now.ToString("yyyy-MM-dd") + "\\";
                if (!Directory.Exists(strDirPath))
                {
                    Directory.CreateDirectory(strDirPath);
                }
                strOutputPath[0] = strDirPath + "AeroChanPara-" + DateTime.Now.ToString("HH-mm-ss") + ".acp";
                strOutputPath[1] = strDirPath + "AeroChanData-" + DateTime.Now.ToString("HH-mm-ss") + ".ach";
            }
            else
            {
                strOutputPath[0] = lalOutputPath.ToolTipText + "AeroChanPara.acp";
                strOutputPath[1] = lalOutputPath.ToolTipText + "AeroChanData.ach";
            }
            return strOutputPath;
          
        }
        #endregion

        #region 播放文件相关
        /// <summary>
        /// 航空信道表格数据显示
        /// </summary>
        private bool AeroTabParaShow(string strFilePath, float posPercent, bool isNext = false)
        {
            StreamReader sr = null;

            try
            {
                string strRead;
                Match mchRead;
                MatchCollection mchReads;
                float flt,fltTimeEnd;
                long lineNum,lineRead;
                int posStart,posOffset;

                sr = new StreamReader(strFilePath);

                strRead = sr.ReadLine();
                posStart = Encoding.Default.GetBytes(strRead + "\r\n").Length;
                mchRead = Regex.Match(strRead, @"[+-]?(\d+\.?\d*|\d*\.?\d+)$");
                if (!float.TryParse(mchRead.Groups[0].Value, out fltTimeEnd))
                    return false;

                strRead = sr.ReadLine();
                posStart += Encoding.Default.GetBytes(strRead + "\r\n").Length;
                mchRead = Regex.Match(strRead, @"\d+$");
                if (!long.TryParse(mchRead.Groups[0].Value, out lineNum))
                    return false;
                aeroUpDate = fltTimeEnd / (lineNum - 1);

                strRead = sr.ReadLine();
                posStart += Encoding.Default.GetBytes(strRead + "\r\n").Length;

                strRead = sr.ReadLine();
                posOffset = Encoding.Default.GetBytes(strRead + "\r\n").Length;

                if (posPercent > 1 || posPercent < 0)
                    return false;
                lineRead = (long)(posPercent * (lineNum-1) + 0.5);
                if (isNext)
                    lineRead++;

                sr.BaseStream.Seek(posStart + lineRead*posOffset, SeekOrigin.Begin);
                Byte[] byteRead = new Byte[posOffset];
                for (int ii = 0; ii < byteRead.Length; ii++)
                {
                    byteRead[ii] = (Byte)sr.BaseStream.ReadByte();
                }
                strRead = Encoding.Default.GetString(byteRead);

                mchReads = Regex.Matches(strRead, @"[+-]?(\d+\.?\d*|\d*\.?\d+)");
                if (mchReads.Count != 19)
                    return false;

                if (!float.TryParse(mchReads[aeroTime].Groups[0].Value, out flt))
                    return false;
                lalAeroTimes.Text = string.Format("{0:N3}/{1:N3}", flt, fltTimeEnd);

                //时延
                if (!float.TryParse(mchReads[uvaDelay].Groups[0].Value, out flt))
                    return false;
                flt *= 1e+6f;
                dgvAeroChan["colAeroDelay", 0].Value = flt;

                if (!float.TryParse(mchReads[uvaSca1Delay].Groups[0].Value, out flt))
                    return false;
                flt *= 1e+6f;
                dgvAeroChan["colAeroDelay", 1].Value = flt;

                if (!float.TryParse(mchReads[uvaSca2Delay].Groups[0].Value, out flt))
                    return false;
                flt *= 1e+6f;
                dgvAeroChan["colAeroDelay", 2].Value = flt;

                if (!float.TryParse(mchReads[uvaSca3Delay].Groups[0].Value, out flt))
                    return false;
                flt *= 1e+6f;
                dgvAeroChan["colAeroDelay", 3].Value = flt;

                //多普勒
                if (!float.TryParse(mchReads[uvaDoppler].Groups[0].Value, out flt))
                    return false;
                dgvAeroChan["colAeroDoppler", 0].Value = flt;

                //增益
                if (!float.TryParse(mchReads[uvaGain].Groups[0].Value, out flt))
                    return false;
                dgvAeroChan["colAeroGain", 0].Value = flt;

                if (!float.TryParse(mchReads[uvaSca1Gain].Groups[0].Value, out flt))
                    return false;
                dgvAeroChan["colAeroGain", 1].Value = flt;

                if (!float.TryParse(mchReads[uvaSca2Gain].Groups[0].Value, out flt))
                    return false;
                dgvAeroChan["colAeroGain", 2].Value = flt;

                if (!float.TryParse(mchReads[uvaSca3Gain].Groups[0].Value, out flt))
                    return false;
                dgvAeroChan["colAeroGain", 3].Value = flt;

                //到达角AOA
                if (!float.TryParse(mchReads[uvaAOA].Groups[0].Value, out flt))
                    return false;
                dgvAeroChan["colAeroAOA", 0].Value = flt;

                if (!float.TryParse(mchReads[uvaSca1AOA].Groups[0].Value, out flt))
                    return false;
                dgvAeroChan["colAeroAOA", 1].Value = flt;

                if (!float.TryParse(mchReads[uvaSca2AOA].Groups[0].Value, out flt))
                    return false;
                dgvAeroChan["colAeroAOA", 2].Value = flt;

                if (!float.TryParse(mchReads[uvaSca3AOA].Groups[0].Value, out flt))
                    return false;
                dgvAeroChan["colAeroAOA", 3].Value = flt;

                //俯仰角EOA
                if (!float.TryParse(mchReads[uvaEOA].Groups[0].Value, out flt))
                    return false;
                dgvAeroChan["colAeroEOA", 0].Value = flt;

                if (!float.TryParse(mchReads[uvaSca1EOA].Groups[0].Value, out flt))
                    return false;
                dgvAeroChan["colAeroEOA", 1].Value = flt;

                if (!float.TryParse(mchReads[uvaSca2EOA].Groups[0].Value, out flt))
                    return false;
                dgvAeroChan["colAeroEOA", 2].Value = flt;

                if (!float.TryParse(mchReads[uvaSca3EOA].Groups[0].Value, out flt))
                    return false;
                dgvAeroChan["colAeroEOA", 3].Value = flt;

                return true;
            }
            catch { return false; }
            finally
            {
                if (sr != null)
                    sr.Close();
            }
        }

        /// <summary>
        /// 航空信道表格数据播放功能使能
        /// </summary>
        private void AeroTabPlayEnable(bool isEnable = true)
        {
            if (isEnable)
            {
                tkbrAeroChan.Enabled = true;
                btnAeroPlay.Enabled = true;
                btnAeroStop.Enabled = true;
                btnAeroBackward.Enabled = true;
                btnAeroForward.Enabled = true;

                if (tkbrAeroChan.Value == 0)
                {
                    if (!AeroTabParaShow(aeroChanParaPath, 0))
                    {
                        AeroTabPlayEnable(false);
                        MessageBox.Show("读取信道参数文件失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                    tkbrAeroChan.Value = 0;
            }
            else
            {
                tkbrAeroChan.Enabled = false;
                btnAeroPlay.Enabled = false;
                btnAeroStop.Enabled = false;
                btnAeroBackward.Enabled = false;
                btnAeroForward.Enabled = false;
            }
        }
        #endregion

        #region 保存载入配置操作

        public void SaveOneLine(XmlDocument xmlDoc, XmlElement xeParent, string name, string value)
        {
            XmlElement xeChild = xmlDoc.CreateElement(name);
            xeChild.SetAttribute("value", value);
            xeParent.AppendChild(xeChild);
        }
        /// <summary>
        /// 保存航空信道配置
        /// </summary>
        private void SaveAeroCfg(XmlDocument xmlDoc, ref XmlElement xmlEle)
        {
            XmlElement xmlEle2, xmlEle3, xmlEle4;
            Match mchTitle, mchData;
            string[] strRef;

            //xmlEle2 = xmlDoc.CreateElement(pageAeroChan.Text);
            //xmlEle.AppendChild(xmlEle2);
            SaveOneLine(xmlDoc, xmlEle, lalSignalType.Text,cboxSignalType.Text);
            //SaveOneLine(xmlDoc, xmlEle, lalModuType.Text, cboxModulationType.Text);
            //SaveOneLine(xmlDoc, xmlEle, lalFiterType.Text,cboxFilterType.Text);
            //SaveOneLine(xmlDoc, xmlEle, lalDataSource.Text, cboxDataSource.Text);
            //SaveOneLine(xmlDoc, xmlEle, lalSymbolNum.Text, cboxSymbolNumber.Text);
            //SaveOneLine(xmlDoc, xmlEle, lalSymbolRate.Text,tboxSymbolRate.Text);
            //SaveOneLine(xmlDoc, xmlEle, lalCutyCycle.Text,tboxDutyCycle.Text);

            //xmlEle3 = xmlDoc.CreateElement(lalSignalFre.Text);
            //xmlEle3.SetAttribute("value", tboxFrequency.Text);
            //xmlEle3.SetAttribute("unit", cboxFrequencyUnit.Text);
            //xmlEle.AppendChild(xmlEle3);

            SaveOneLine(xmlDoc, xmlEle, lalAeroTrace.Text,txtAeroTrace.Text);
            SaveOneLine(xmlDoc, xmlEle, lalAeroLaunAnte.Text,txtAeroLaunAnte.Text);
            SaveOneLine(xmlDoc, xmlEle, lalAeroRecvAnte.Text,txtAeroRecvAnte.Text);
            SaveOneLine(xmlDoc, xmlEle, lalAeroCommuScnr.Text,cboAeroCommuScnr.Text);
            SaveOneLine(xmlDoc, xmlEle, lalAeroPolar.Text, cboAeroPolar.Text);          
            
            xmlEle3 = xmlDoc.CreateElement(lalAeroCarrierFre.Text);
            xmlEle3.SetAttribute("value", txtAeroCarrierFre.Text);
            xmlEle3.SetAttribute("unit", cboAeroCarrierFre.Text);
            xmlEle.AppendChild(xmlEle3);

            xmlEle3 = xmlDoc.CreateElement(lalAeroUpdate.Text);
            xmlEle3.SetAttribute("value", txtAeroUpdate.Text);
            xmlEle3.SetAttribute("unit", lalAeroUpdateUnit.Text);
            xmlEle.AppendChild(xmlEle3);

            strRef = TipShow.GetToolTip(cboAeroRefEnv).Split('\n');
            xmlEle3 = xmlDoc.CreateElement(grpAeroEnv.Text);
            foreach (string str in strRef)
            {
                mchTitle = Regex.Match(str, @"^[\u4e00-\u9fa5a-zA-Z]+");
                mchData = Regex.Match(str, @"[+-]?(\d+\.?\d*|\d*\.?\d+)[a-zA-Z]*$");
                xmlEle3.SetAttribute(mchTitle.Groups[0].Value, mchData.Groups[0].Value);
            }
            xmlEle.AppendChild(xmlEle3);

            SaveOneLine(xmlDoc, xmlEle, lalAeroRefEnv.Text,cboAeroRefEnv.Text);
            SaveOneLine(xmlDoc, xmlEle, lalAeroRefMod.Text,cboAeroRefMod.Text);
            SaveOneLine(xmlDoc, xmlEle, chkAeroAWGN.Text,chkAeroAWGN.Checked.ToString());

            xmlEle4 = xmlDoc.CreateElement(lalAeroSNR.Text);
            xmlEle4.SetAttribute("value", txtAeroSNR.Text);
            //xmlEle4.SetAttribute("unit", cboAeroSNR.Text);
            xmlEle3.AppendChild(xmlEle4);
        }

        /// <summary>
        /// 载入航空信道配置
        /// </summary>
        private bool LoadAeroCfg(XmlDocument xmlDoc)
        {
            bool isSucceed = true;
            XmlNode node;
            Match mch;
            double dbl, dbl2, dbl3;

            string nodePath = "/参数配置/";

            node = xmlDoc.SelectSingleNode(nodePath + lalSignalType.Text);
            if (node != null)
                cboxSignalType.Text = node.Attributes["value"].Value;
            else
                isSucceed = false;
            //node = xmlDoc.SelectSingleNode(nodePath +  lalModuType.Text);
            //if (node != null)
            //    cboxModulationType.Text = node.Attributes["value"].Value;
            //else
            //    isSucceed = false;
            //node = xmlDoc.SelectSingleNode(nodePath + lalFiterType.Text);
            //if (node != null)
            //    cboxFilterType.Text = node.Attributes["value"].Value;
            //else
            //    isSucceed = false;
            //node = xmlDoc.SelectSingleNode(nodePath + lalDataSource.Text);
            //if (node != null)
            //    cboxDataSource.Text = node.Attributes["value"].Value;
            //else
            //    isSucceed = false;
            //node = xmlDoc.SelectSingleNode(nodePath + lalSymbolNum.Text);
            //if (node != null)
            //    cboxSymbolNumber.Text = node.Attributes["value"].Value;
            //else
            //    isSucceed = false;
            //node = xmlDoc.SelectSingleNode(nodePath + lalCutyCycle.Text);
            //if (node != null)
            //     tboxDutyCycle.Text = node.Attributes["value"].Value;
            //else
            //    isSucceed = false;
            //node = xmlDoc.SelectSingleNode(nodePath + lalSymbolRate.Text);
            //if (node != null)
            //     tboxSymbolRate.Text = node.Attributes["value"].Value;
            //else
            //    isSucceed = false;
            //node = xmlDoc.SelectSingleNode(nodePath + lalSignalFre.Text);
            //if (node != null)
            //{
            //    tboxFrequency.Text = node.Attributes["value"].Value;
            //    cboxFrequencyUnit.Text = node.Attributes["unit"].Value;
            //}
            //else
            //    isSucceed = false;

            node = xmlDoc.SelectSingleNode(nodePath + lalAeroTrace.Text);
            if (node != null)
                txtAeroTrace.Text = node.Attributes["value"].Value;
            else
                isSucceed = false;

            node = xmlDoc.SelectSingleNode(nodePath + lalAeroLaunAnte.Text);
            if (node != null)
                txtAeroLaunAnte.Text = node.Attributes["value"].Value;
            else
                isSucceed = false;

            node = xmlDoc.SelectSingleNode(nodePath + lalAeroRecvAnte.Text);
            if (node != null)
                txtAeroRecvAnte.Text = node.Attributes["value"].Value;
            else
                isSucceed = false;

            node = xmlDoc.SelectSingleNode(nodePath + lalAeroCommuScnr.Text);
            if (node != null)
                cboAeroCommuScnr.Text = node.Attributes["value"].Value;
            else
                isSucceed = false;
            
            node = xmlDoc.SelectSingleNode(nodePath + lalAeroPolar.Text);
            if (node != null)
                cboAeroPolar.Text = node.Attributes["value"].Value;
            else
                isSucceed = false;
            
            node = xmlDoc.SelectSingleNode(nodePath + lalAeroCarrierFre.Text);
            if (node != null)
            {
                txtAeroCarrierFre.Text = node.Attributes["value"].Value;
                cboAeroCarrierFre.Text = node.Attributes["unit"].Value;
            }
            else
                isSucceed = false;

            node = xmlDoc.SelectSingleNode(nodePath + lalAeroUpdate.Text);
            if (node != null)
                txtAeroUpdate.Text = node.Attributes["value"].Value;
            else
                isSucceed = false;

            node = xmlDoc.SelectSingleNode(nodePath + grpAeroEnv.Text);
            if (node != null)
            {
                if (!double.TryParse(node.Attributes[refBox.GetDielectric()].Value, out dbl))
                    isSucceed = false;
                if (!double.TryParse(node.Attributes[refBox.GetConductivity()].Value, out dbl2))
                    isSucceed = false;
                mch = Regex.Match(node.Attributes[refBox.GetAngSp()].Value, @"^[+-]?(\d+\.?\d*|\d*\.?\d+)");
                if (!double.TryParse(mch.Groups[0].Value, out dbl3))
                    isSucceed = false;

                refBox.SetPara(dbl, dbl2, dbl3);
            }
            else
                isSucceed = false;

            node = xmlDoc.SelectSingleNode(nodePath + grpAeroEnv.Text + "/" + lalAeroRefEnv.Text);
            if (node != null)
                cboAeroRefEnv.Text = node.Attributes["value"].Value;
            else
                isSucceed = false;

            node = xmlDoc.SelectSingleNode(nodePath + grpAeroEnv.Text + "/" + lalAeroRefMod.Text);
            if (node != null)
                cboAeroRefMod.Text = node.Attributes["value"].Value;
            else
                isSucceed = false;

            node = xmlDoc.SelectSingleNode(nodePath + chkAeroAWGN.Text);
            if (node != null)
                chkAeroAWGN.Checked = bool.Parse(node.Attributes["value"].Value);
            else
                isSucceed = false;

            node = xmlDoc.SelectSingleNode(nodePath + chkAeroAWGN.Text + "/" + lalAeroSNR.Text);
            if (node != null)
            {
                txtAeroSNR.Text = node.Attributes["value"].Value;
                //cboAeroSNR.Text = node.Attributes["unit"].Value;
            }
            else
                isSucceed = false;

            return isSucceed;
        }

        ///// <summary>
        ///// 保存通用信道配置
        ///// </summary>
        //private void SaveGeneCfg(XmlDocument xmlDoc, ref XmlElement xmlEle)
        //{
        //    XmlElement xmlEle2, xmlEle3, xmlEle4;

        //    xmlEle2 = xmlDoc.CreateElement(pageGeneChan.Text);
        //    xmlEle.AppendChild(xmlEle2);

        //    xmlEle3 = xmlDoc.CreateElement(lalGenePathLoss.Text);
        //    xmlEle3.SetAttribute("value", txtGenePathLoss.Text);
        //    xmlEle3.SetAttribute("unit", lalGenePathLossUnit.Text);
        //    xmlEle2.AppendChild(xmlEle3);

        //    xmlEle3 = xmlDoc.CreateElement(lalGenePS.Text);
        //    xmlEle3.SetAttribute("value", txtGenePS.Text);
        //    xmlEle3.SetAttribute("unit", lalGenePSUnit.Text);
        //    xmlEle2.AppendChild(xmlEle3);

        //    xmlEle3 = xmlDoc.CreateElement(chkGeneShadow.Text);
        //    xmlEle3.SetAttribute("value", chkGeneShadow.Checked.ToString());
        //    xmlEle2.AppendChild(xmlEle3);

        //    xmlEle4 = xmlDoc.CreateElement(lalGeneShadow.Text);
        //    xmlEle4.SetAttribute("value", txtGeneShadow.Text);
        //    xmlEle4.SetAttribute("unit", lalGeneShadowUnit.Text);
        //    xmlEle3.AppendChild(xmlEle4);

        //    xmlEle4 = xmlDoc.CreateElement(lalGeneDecorLen.Text);
        //    xmlEle4.SetAttribute("value", txtGeneDecorLen.Text);
        //    xmlEle4.SetAttribute("unit", lalGeneDecorLenUnit.Text);
        //    xmlEle3.AppendChild(xmlEle4);

        //    xmlEle3 = xmlDoc.CreateElement(chkGeneAWGN.Text);
        //    xmlEle3.SetAttribute("value", chkGeneAWGN.Checked.ToString());
        //    xmlEle2.AppendChild(xmlEle3);

        //    xmlEle4 = xmlDoc.CreateElement(lalGeneSNR.Text);
        //    xmlEle4.SetAttribute("value", txtGeneSNR.Text);
        //    xmlEle4.SetAttribute("unit", cboGeneSNR.Text);
        //    xmlEle3.AppendChild(xmlEle4);

        //    SaveChanParaTab(xmlDoc, ref xmlEle2, dgvGeneChan);

        //    xmlEle3 = xmlDoc.CreateElement(chkGeneChanMod.Text);
        //    xmlEle3.SetAttribute("value", chkGeneChanMod.Checked.ToString());
        //    xmlEle2.AppendChild(xmlEle3);

        //    xmlEle4 = xmlDoc.CreateElement(rdoGeneOutskirts.Text + lalGeneOutskirts.Text);
        //    xmlEle4.SetAttribute("value", rdoGeneOutskirts.Checked.ToString());
        //    xmlEle3.AppendChild(xmlEle4);

        //    xmlEle4 = xmlDoc.CreateElement(rdoGeneBad.Text + lalGeneBad.Text);
        //    xmlEle4.SetAttribute("value", rdoGeneBad.Checked.ToString());
        //    xmlEle3.AppendChild(xmlEle4);

        //    xmlEle4 = xmlDoc.CreateElement(rdoGeneHill.Text + lalGeneHill.Text);
        //    xmlEle4.SetAttribute("value", rdoGeneHill.Checked.ToString());
        //    xmlEle3.AppendChild(xmlEle4);

        //    xmlEle4 = xmlDoc.CreateElement(rdoCost259.Text);
        //    xmlEle4.SetAttribute("value", rdoCost259.Checked.ToString());
        //    xmlEle3.AppendChild(xmlEle4);
        //}

        /// <summary>
        /// 载入通用信道配置
        /// </summary>
        //private bool LoadGeneCfg(XmlDocument xmlDoc)
        //{
        //    bool isSucceed = true;
        //    XmlNode node;
        //    string nodePath = "/参数配置/" + pageGeneChan.Text + "/";

        //    node = xmlDoc.SelectSingleNode(nodePath + lalGenePathLoss.Text);
        //    if (node != null)
        //        txtGenePathLoss.Text = node.Attributes["value"].Value;
        //    else
        //        isSucceed = false;

        //    node = xmlDoc.SelectSingleNode(nodePath + lalGenePS.Text);
        //    if (node != null)
        //        txtGenePS.Text = node.Attributes["value"].Value;
        //    else
        //        isSucceed = false;

        //    node = xmlDoc.SelectSingleNode(nodePath + chkGeneShadow.Text);
        //    if (node != null)
        //        chkGeneShadow.Checked = bool.Parse(node.Attributes["value"].Value);
        //    else
        //        isSucceed = false;

        //    node = xmlDoc.SelectSingleNode(nodePath + chkGeneShadow.Text + "/" +lalGeneShadow.Text);
        //    if (node != null)
        //        txtGeneShadow.Text = node.Attributes["value"].Value;
        //    else
        //        isSucceed = false;

        //    node = xmlDoc.SelectSingleNode(nodePath + chkGeneShadow.Text + "/" + lalGeneDecorLen.Text);
        //    if (node != null)
        //        txtGeneDecorLen.Text = node.Attributes["value"].Value;
        //    else
        //        isSucceed = false;

        //    node = xmlDoc.SelectSingleNode(nodePath + chkGeneAWGN.Text);
        //    if (node != null)
        //        chkGeneAWGN.Checked = bool.Parse(node.Attributes["value"].Value);
        //    else
        //        isSucceed = false;

        //    node = xmlDoc.SelectSingleNode(nodePath + chkGeneAWGN.Text + "/" + lalGeneSNR.Text);
        //    if (node != null)
        //    {
        //        txtGeneSNR.Text = node.Attributes["value"].Value;
        //        cboGeneSNR.Text = node.Attributes["unit"].Value;
        //    }
        //    else
        //        isSucceed = false;

        //    if (!LoadChanParaTab(xmlDoc, dgvGeneChan))
        //        isSucceed = false;

        //    node = xmlDoc.SelectSingleNode(nodePath + chkGeneChanMod.Text);
        //    if (node != null)
        //        chkGeneChanMod.Checked = bool.Parse(node.Attributes["value"].Value);
        //    else
        //        isSucceed = false;

        //    node = xmlDoc.SelectSingleNode(nodePath + chkGeneChanMod.Text + "/" + rdoGeneOutskirts.Text + lalGeneOutskirts.Text);
        //    if (node != null)
        //        rdoGeneOutskirts.Checked = bool.Parse(node.Attributes["value"].Value);
        //    else
        //        isSucceed = false;

        //    node = xmlDoc.SelectSingleNode(nodePath + chkGeneChanMod.Text + "/" + rdoGeneBad.Text + lalGeneBad.Text);
        //    if (node != null)
        //        rdoGeneBad.Checked = bool.Parse(node.Attributes["value"].Value);
        //    else
        //        isSucceed = false;

        //    node = xmlDoc.SelectSingleNode(nodePath + chkGeneChanMod.Text + "/" + rdoGeneHill.Text + lalGeneHill.Text);
        //    if (node != null)
        //        rdoGeneHill.Checked = bool.Parse(node.Attributes["value"].Value);
        //    else
        //        isSucceed = false;

        //    node = xmlDoc.SelectSingleNode(nodePath + chkGeneChanMod.Text + "/" + rdoCost259.Text);
        //    if (node != null)
        //        rdoCost259.Checked = bool.Parse(node.Attributes["value"].Value);
        //    else
        //        isSucceed = false;

        //    return isSucceed;
        //}

        /// <summary>
        /// 保存信道参数表格
        /// </summary>
        private void SaveChanParaTab(XmlDocument xmlDoc, ref XmlElement xmlEle, DataGridView dgv)
        {
            XmlElement xmlEle2, xmlEle3, xmlEle4;
            Match mchTitle, mchData;
            string[] strFad;

            xmlEle2 = xmlDoc.CreateElement("表格参数");
            xmlEle2.SetAttribute("rowCount", dgv.RowCount.ToString());
            xmlEle2.SetAttribute("colCount", dgv.ColumnCount.ToString());
            xmlEle.AppendChild(xmlEle2);

            for (int ii = 0; ii < dgv.RowCount; ii++)
            {
                xmlEle3 = xmlDoc.CreateElement(dgv.Rows[ii].HeaderCell.Value.ToString());

                for (int jj = 0; jj < dgv.ColumnCount; jj++)
                {
                    mchTitle = Regex.Match(dgv.Columns[jj].HeaderText, @"^[\u4e00-\u9fa5]+");
                    mchData = Regex.Match(dgv.Columns[jj].HeaderText, @"[a-zA-Z]+");
                    xmlEle3.SetAttribute(mchTitle.Groups[0].Value, dgv[jj, ii].FormattedValue.ToString() + mchData.Groups[0].Value);
                }

                strFad = dgv["colGeneFad", ii].ToolTipText.Split('\n');
                xmlEle4 = xmlDoc.CreateElement(strFad[0]);
                for (int jj = 1; jj < strFad.Length; jj++)
                {
                    mchTitle = Regex.Match(strFad[jj], @"^[\u4e00-\u9fa5a-zA-Z]+");
                    mchData = Regex.Match(strFad[jj], @"[+-]?(\d+\.?\d*|\d*\.?\d+)[a-zA-Z]+$");
                    xmlEle4.SetAttribute(mchTitle.Groups[0].Value, mchData.Groups[0].Value);
                }
                xmlEle3.AppendChild(xmlEle4);
                xmlEle2.AppendChild(xmlEle3);
            }
        }

        /// <summary>
        /// 载入通用信道表格
        /// </summary>
        //private bool LoadChanParaTab(XmlDocument xmlDoc, DataGridView dgv)
        //{
        //    int intData;
        //    double dblData, dblData2;
        //    Match mchTitle, mchData;
        //    XmlNode node;
        //    string nodePath;

        //    nodePath = "/参数配置/"  + "/表格参数";

        //    node = xmlDoc.SelectSingleNode(nodePath);
        //    if (node == null)
        //        return false;
        //    if (!int.TryParse(node.Attributes["rowCount"].Value, out intData) || intData > maxGeneCluNum)
        //        return false;
        //    dgv.RowCount = intData;

        //    nodePath += "/";
        //    bool isSucceed = true;

        //    for (int ii = 0; ii < dgv.RowCount; ii++)
        //    {
        //        node = xmlDoc.SelectSingleNode(nodePath + dgv.Rows[ii].HeaderCell.Value.ToString());

        //        for (int jj = 0; jj < dgv.ColumnCount; jj++)
        //        {
        //            mchTitle = Regex.Match(dgv.Columns[jj].HeaderText, @"^[\u4e00-\u9fa5]+");
        //            mchData = Regex.Match(dgv.Columns[jj].HeaderText, @"[a-zA-Z]+");
        //            if (node.Attributes[mchTitle.Groups[0].Value] != null)
        //            {
        //                if (mchData.Groups[0].Value == string.Empty)
        //                    dgv[jj, ii].Value = node.Attributes[mchTitle.Groups[0].Value].Value;
        //                else
        //                    dgv[jj, ii].Value = node.Attributes[mchTitle.Groups[0].Value].Value.Replace(mchData.Groups[0].Value, null);
        //            }
        //            else
        //                isSucceed = false;
        //        }

        //        if (node.FirstChild != null)
        //        {
        //            if (node.FirstChild.Name == "瑞利衰落")
        //            {
        //                geneFad[ii] = new Dictionary<string, double>();
        //                geneFad[ii].Add(node.FirstChild.Name, 0);

        //                GeneFadShow(dgv["colGeneFad", ii], geneFad[dgv["colGeneFad", ii].RowIndex]);
        //            }
        //            else if (node.FirstChild.Name == "莱斯衰落")
        //            {
        //                if (node.FirstChild == null)
        //                    return false;

        //                mchData = Regex.Match(node.FirstChild.Attributes[riceBox.GetRiceK()].Value, @"^[+-]?(\d+\.?\d*|\d*\.?\d+)");
        //                if (!double.TryParse(mchData.Groups[0].Value, out dblData))
        //                    return false;
        //                mchData = Regex.Match(node.FirstChild.Attributes[riceBox.GetRiceAOA()].Value, @"^[+-]?(\d+\.?\d*|\d*\.?\d+)");
        //                if (!double.TryParse(mchData.Groups[0].Value, out dblData2))
        //                    return false;

        //                riceBox.SetPara(dblData, dblData2);

        //                geneFad[ii] = new Dictionary<string, double>();
        //                geneFad[ii].Add(node.FirstChild.Name,0);
        //                geneFad[ii].Add(riceBox.GetRiceK(), dblData);
        //                geneFad[ii].Add(riceBox.GetRiceAOA(), dblData2);

        //                GeneFadShow(dgv["colGeneFad", ii], geneFad[dgv["colGeneFad", ii].RowIndex]);
        //            }
        //            else if (node.FirstChild.Name == "纯多普勒")
        //            {
        //                if (node.FirstChild == null)
        //                    return false;

        //                mchData = Regex.Match(node.FirstChild.Attributes[dopplerBox.GetDoppler()].Value, @"^[+-]?(\d+\.?\d*|\d*\.?\d+)");
        //                if (!double.TryParse(mchData.Groups[0].Value, out dblData))
        //                    return false;

        //                dopplerBox.SetDoppler(dblData);

        //                geneFad[ii] = new Dictionary<string, double>();
        //                geneFad[ii].Add(node.FirstChild.Name,0);
        //                geneFad[ii].Add(dopplerBox.GetDoppler(), dblData);

        //                GeneFadShow(dgv["colGeneFad", ii], geneFad[dgv["colGeneFad", ii].RowIndex]);
        //            }
        //        }
        //        else
        //            isSucceed = false;
        //    }
        //    return isSucceed;
        //}
        #endregion

        #region 保存载入配置文件
        /// <summary>
        /// 保存信道配置文件
        /// </summary>
        private bool SaveCfgXml(string strXmlPath)
        {
            try
            {
                XmlElement xmlEle1, xmlEle2;

                XmlDocument xmlDoc = new XmlDocument();
                XmlDeclaration xmlDecl = xmlDoc.CreateXmlDeclaration("1.0", "gb2312", null);
                xmlDoc.AppendChild(xmlDecl);

                xmlEle1 = xmlDoc.CreateElement("参数配置");
                xmlDoc.AppendChild(xmlEle1);

                SaveAeroCfg(xmlDoc, ref xmlEle1);
                //switch (softCfgMod)
                //{
                //    case SoftCfgMod.aero:
                //        {
                //            SaveAeroCfg(xmlDoc, ref xmlEle1);
                //            break;
                //        }
                //    case SoftCfgMod.gene:
                //        {
                //            SaveGeneCfg(xmlDoc, ref xmlEle1);
                //            break;
                //        }
                //    case SoftCfgMod.all:
                //        {
                //            SaveAeroCfg(xmlDoc, ref xmlEle1);
                //            SaveGeneCfg(xmlDoc, ref xmlEle1);
                //            break;
                //        }
                //}

                xmlEle2 = xmlDoc.CreateElement(输出覆盖ToolStripMenuItem.Text);
                xmlEle2.SetAttribute("value",btnOutputCover.Image.Tag as string);
                xmlEle1.AppendChild(xmlEle2);

                xmlEle2 = xmlDoc.CreateElement(输出路径ToolStripMenuItem.Text);
                xmlEle2.SetAttribute("value",lalOutputPath.ToolTipText);
                xmlEle1.AppendChild(xmlEle2);

                xmlDoc.Save(strXmlPath);
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// 载入信道配置文件
        /// </summary>
      //  private bool LoadCfgXml(string strXmlPath, SoftCfgMod softCfgMod)
        private bool LoadCfgXml(string strXmlPath )
        {
            try
            {
                bool isSucceed = true;
                XmlNode node;
                string nodePath = "/参数配置/";
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(strXmlPath);

                if (!LoadAeroCfg(xmlDoc))
                    isSucceed = false;
                //switch (softCfgMod)
                //{
                //    case SoftCfgMod.aero:
                //        {
                //            if (!LoadAeroCfg(xmlDoc))
                //                isSucceed = false;
                //            break;
                //        }
                //    case SoftCfgMod.gene:
                //        {
                //            if (!LoadGeneCfg(xmlDoc))
                //                isSucceed = false;
                //            break;
                //        }
                //    case SoftCfgMod.all:
                //        {
                //            if (!LoadAeroCfg(xmlDoc))
                //                isSucceed = false;
                //            if (!LoadGeneCfg(xmlDoc))
                //                isSucceed = false;
                //            break;
                //        }
                //}

                node = xmlDoc.SelectSingleNode(nodePath + 输出覆盖ToolStripMenuItem.Text);
                if (node != null)
                {
                    if (node.Attributes["value"].Value == "不覆盖")
                    {
                        btnOutputCover.Image = Properties.Resources.unchecked_checkbox;
                        btnOutputCover.Image.Tag = "不覆盖";

                        输出覆盖ToolStripMenuItem.Checked = false;
                    }
                    else if (node.Attributes["value"].Value == "覆盖")
                    {
                        btnOutputCover.Image = Properties.Resources.checked_checkbox;
                        btnOutputCover.Image.Tag = "覆盖";

                        输出覆盖ToolStripMenuItem.Checked = true;
                    }
                    else 
                        isSucceed = false;
                }
                else 
                    isSucceed = false;

                node = xmlDoc.SelectSingleNode(nodePath + 输出路径ToolStripMenuItem.Text);
                if (node != null)
                {
                    if (Directory.Exists(node.Attributes["value"].Value))
                    {
                        lalOutputPath.ToolTipText = node.Attributes["value"].Value;
                        OutputPathShow(lalOutputPath.ToolTipText);
                    }
                    else
                        isSucceed = false;
                }
                else
                    isSucceed = false;

                return isSucceed;
            }
            catch { return false; }
        }

        /// <summary>
        /// 保存通用信道表格文件
        /// </summary>
        //private bool SaveChanParaTabXml(string strXmlPath, DataGridView dgv)
        //{
        //    try
        //    {
        //        XmlElement xmlEle1, xmlEle2;

        //        XmlDocument xmlDoc = new XmlDocument();
        //        XmlDeclaration xmlDecl = xmlDoc.CreateXmlDeclaration("1.0", "gb2312", null);
        //        xmlDoc.AppendChild(xmlDecl);

        //        xmlEle1 = xmlDoc.CreateElement("参数配置");
        //        xmlDoc.AppendChild(xmlEle1);

        //        xmlEle2 = xmlDoc.CreateElement(pageGeneChan.Text);
        //        xmlEle1.AppendChild(xmlEle2);

        //        SaveChanParaTab(xmlDoc, ref xmlEle2, dgv);

        //        xmlDoc.Save(strXmlPath);
        //        return true;
        //    }
        //    catch { return false; }
        //}

        /// <summary>
        /// 载入通用信道表格文件
        /// </summary>
        //private bool LoadChanParaTabXml(string strXmlPath, DataGridView dgv)
        //{
        //    try
        //    {
        //        if (dgv.Name != dgvGeneChan.Name)
        //            return false;

        //        XmlDocument xmlDoc = new XmlDocument();
        //        xmlDoc.Load(strXmlPath);

        //        if (!LoadChanParaTab(xmlDoc, dgv))
        //            return false;
                
        //        return true;
        //    }
        //    catch { return false; }
        //}
        #endregion

        public ChanGenTool()
        {
            InitializeComponent();
        }

        private void ChanGenTool_Load(object sender, EventArgs e)
        {
            // hu Matlab初始化
            bgwMatlabInit.RunWorkerAsync();

            #region 控件初始化
            // hu 主界面
            lblDateNow.Text = DateTime.Now.ToString("yyyy年MM月dd日");

            btnOutputCover.Image = Properties.Resources.checked_checkbox;
            btnOutputCover.Image.Tag = "覆盖";
            输出覆盖ToolStripMenuItem.Checked = true;

            lalOutputPath.ToolTipText = strDefaultPath + "Output\\";
            if (!Directory.Exists(lalOutputPath.ToolTipText))
                Directory.CreateDirectory(lalOutputPath.ToolTipText);
            OutputPathShow(lalOutputPath.ToolTipText);

            // hu 航空信道
            dgvAeroChan.RowCount = maxAeroCluNum;

            cboAeroRefMod.SelectedIndex = 0;
            cboAeroCommuScnr.SelectedIndex = 0;
            cboAeroPolar.SelectedIndex = 0;
            cboAeroCarrierFre.SelectedIndex = 0;
            cboAeroRefEnv.SelectedIndex = 0;
            //cboAeroSNR.SelectedIndex = 0;

            btnAeroPlay.BackgroundImage.Tag = "暂停";

            refBox.SetMainFm(this);

            //// hu 通用信道
            //cboGeneSNR.SelectedIndex = 0;

            //dgvGeneChan.RowCount = maxGeneCluNum;

            //dopplerBox.SetMainFm(this);
            //riceBox.SetMainFm(this);

            // hu 载入配置文件
            LoadCfgXml(strDefaultPath + defaultSavName);
            #endregion

            #region 驱动初始化
            if (PcieDriver.OpenPcieDevice() == false)
                MessageBox.Show(PcieDriver.GetLastDeviceError(), "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            #endregion

            startFlag = 1;
        }

        #region 地面特性
        private void cboAeroRefEnv_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox cbo = sender as ComboBox;
            string strRefEnv = cbo.SelectedItem.ToString();

            if (strRefEnv == "自定义")
            {
                if (DialogResult.OK != refBox.ShowDialog(this))
                {
                    Match mch = Regex.Match(TipShow.GetToolTip(cboAeroRefEnv), @"^[\u4e00-\u9fa5]+");
                    cboAeroRefEnv.Text = mch.Groups[0].Value;
                }
            }
        }

        private void cboRefEnv_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbo = sender as ComboBox;
            string strRefEnv = cbo.SelectedItem.ToString();
            double dbl, dbl2, dbl3;

            if (strRefEnv == "自定义")
            {
                cboAeroRefMod.Enabled = false;

                refBox.GetPara(out dbl, out dbl2, out dbl3);
            }
            else if (strRefEnv == "海洋")
            {
                cboAeroRefMod.Enabled = false;

                if (!refModDef.ContainsKey(strRefEnv) || !refEnvDef.ContainsKey(strRefEnv))
                {
                    MessageBox.Show("参数设置失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dbl = refModDef[strRefEnv][0];
                dbl2 = refModDef[strRefEnv][1];
                dbl3 = refEnvDef[strRefEnv];
                refBox.SetPara(dbl, dbl2, dbl3);
            }
            else
            {
                cboAeroRefMod.Enabled = true;
                string strRefMod = cboAeroRefMod.SelectedItem.ToString();

                if (!refEnvDef.ContainsKey(strRefEnv) || !refModDef.ContainsKey(strRefMod))
                {
                    MessageBox.Show("参数设置失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dbl = refModDef[strRefMod][0];
                dbl2 = refModDef[strRefMod][1];
                dbl3 = refEnvDef[strRefEnv];
                refBox.SetPara(dbl, dbl2, dbl3);
            }

            AeroRefEvnShow(dbl, dbl2, dbl3);
        }

        private void cboRefMed_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbo = sender as ComboBox;
            string strRefMod = cbo.SelectedItem.ToString();
            double dbl, dbl2, dbl3;

            if (cbo.Enabled)
            {
                if (!refModDef.ContainsKey(strRefMod))
                {
                    MessageBox.Show("参数设置失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                refBox.SetDielectric(refModDef[strRefMod][0]);
                refBox.SetConductivity(refModDef[strRefMod][1]);
                refBox.GetPara(out dbl, out dbl2, out dbl3);
                AeroRefEvnShow(dbl, dbl2, dbl3);
            }
        }
        #endregion

        #region 输入限制
        private void txtInputUFloat_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputLimit(sender as TextBox, e,InputMod.UFloat);
        }

        private void txtInputUInt_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputLimit(sender as TextBox, e, InputMod.UInt);
        }
        #endregion

        #region 系统控制菜单
        private void 全部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog savFilDia = new SaveFileDialog();
            savFilDia.Filter = "xml files(*.xml)|*.xml";
            savFilDia.FilterIndex = 1;          // hu 设置默认文件类型显示顺序
            savFilDia.InitialDirectory = lalOutputPath.ToolTipText;
            savFilDia.RestoreDirectory = true;  // hu 保存对话框是否记忆上次打开的目录
            if (savFilDia.ShowDialog() == DialogResult.OK)
            {
                if (!SaveCfgXml(savFilDia.FileName))
                    MessageBox.Show("保存配置文件失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //private void 当前页面ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    SaveFileDialog savFilDia = new SaveFileDialog();
        //    savFilDia.Filter = "xml files(*.xml)|*.xml";
        //    savFilDia.FilterIndex = 1;          // hu 设置默认文件类型显示顺序
        //    savFilDia.InitialDirectory = lalOutputPath.ToolTipText;
        //    savFilDia.RestoreDirectory = true;  // hu 保存对话框是否记忆上次打开的目录
        //    if (savFilDia.ShowDialog() == DialogResult.OK)
        //    {
        //        SoftCfgMod mod;

        //        if (tabChan.SelectedTab.Name == pageAeroChan.Name)
        //            mod = SoftCfgMod.aero;
        //        else if (tabChan.SelectedTab.Name == pageGeneChan.Name)
        //            mod = SoftCfgMod.gene;
        //        else
        //            return;

        //        if (!SaveCfgXml(savFilDia.FileName, mod))
        //            MessageBox.Show("保存配置文件失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}

        private void 全部ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opeFilDia = new OpenFileDialog();
            opeFilDia.Filter = "xml files(*.xml)|*.xml";
            opeFilDia.FilterIndex = 1;
            opeFilDia.InitialDirectory = lalOutputPath.ToolTipText;
            opeFilDia.RestoreDirectory = true;
            if (opeFilDia.ShowDialog() == DialogResult.OK)
            {
                if (!LoadCfgXml(opeFilDia.FileName))
                    MessageBox.Show("载入配置文件失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //private void 当前页面ToolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog opeFilDia = new OpenFileDialog();
        //    opeFilDia.Filter = "xml files(*.xml)|*.xml";
        //    opeFilDia.FilterIndex = 1;
        //    opeFilDia.InitialDirectory = lalOutputPath.ToolTipText;
        //    opeFilDia.RestoreDirectory = true;
        //    if (opeFilDia.ShowDialog() == DialogResult.OK)
        //    {
        //        SoftCfgMod mod;

        //        if (tabChan.SelectedTab.Name == pageAeroChan.Name)
        //            mod = SoftCfgMod.aero;
        //        else if (tabChan.SelectedTab.Name == pageGeneChan.Name)
        //            mod = SoftCfgMod.gene;
        //        else
        //            return;

        //        if (!LoadCfgXml(opeFilDia.FileName, mod))
        //            MessageBox.Show("载入配置文件失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}

        private void 输出路径ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择输出文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                lalOutputPath.ToolTipText = dialog.SelectedPath + "\\";
                OutputPathShow(lalOutputPath.ToolTipText);
            }
        }

        private void 输出覆盖ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((string)btnOutputCover.Image.Tag == "覆盖")
            {
                btnOutputCover.Image = Properties.Resources.unchecked_checkbox;
                btnOutputCover.Image.Tag = "不覆盖";

                输出覆盖ToolStripMenuItem.Checked = false;
            }
            else if ((string)btnOutputCover.Image.Tag == "不覆盖")
            {
                btnOutputCover.Image = Properties.Resources.checked_checkbox;
                btnOutputCover.Image.Tag = "覆盖";

                输出覆盖ToolStripMenuItem.Checked = true;
            }
            else
            {
                btnOutputCover.Image = Properties.Resources.checked_checkbox;
                btnOutputCover.Image.Tag = "覆盖";

                输出覆盖ToolStripMenuItem.Checked = true;
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCfgXml(strDefaultPath + defaultSavName);

            PcieDriver.ClosePcieDevice();
            Application.Exit();
        }

        private void 关于软件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutForm = new AboutBox();
            aboutForm.ShowDialog(this);
        }
        #endregion

        #region 理论相关菜单
        private void 信道仿真ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChanGene mod;
            ArrayList lit = new ArrayList();

            //if (tabChan.SelectedTab.Name == pageAeroChan.Name)
            //    mod = ChanGene.aero;
            //else if (tabChan.SelectedTab.Name == pageGeneChan.Name)
            //    mod = ChanGene.gene;
            //else
            //    return;

            #region 获取Matlab参数
            //if (mod == ChanGene.aero)
            //{
            if (errorShow.GetError(txtAeroTrace) != "" ||
                errorShow.GetError(txtAeroLaunAnte) != "" ||
                errorShow.GetError(txtAeroRecvAnte) != "" ||
                errorShow.GetError(txtAeroCarrierFre) != "" ||
                errorShow.GetError(txtAeroUpdate) != "")
            {
                MessageBox.Show("配置参数错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //lit.Add(mod);

            double dbl;
            if (!double.TryParse(txtAeroCarrierFre.Text, out dbl))
            {
                MessageBox.Show("配置参数错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            switch (cboAeroCarrierFre.Text)
            {
                case "GHz": dbl *= 1e+9; break;
                case "MHz": dbl *= 1e+6; break;
                case "KHz": dbl *= 1e+3; break;
                case "Hz": break;
                default:
                    {
                        MessageBox.Show("配置参数错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
            }
            lit.Add(dbl);

            if (!double.TryParse(txtAeroUpdate.Text, out dbl))
            {
                MessageBox.Show("配置参数错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            lit.Add(dbl);

            //switch (cboAeroPolar.Text)
            //{
            //    case "水平极化": dbl = 0; break;
            //    case "垂直极化": dbl = 1; break;
            //    default:
            //        {
            //            MessageBox.Show("配置参数错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return;
            //        }
            //}
            //lit.Add(dbl);

            double dbl2, dbl3;
            refBox.GetPara(out dbl, out dbl2, out dbl3);
            //if (!ParaLimitEst(dbl, ChanPara.apDielectric) ||
            //    !ParaLimitEst(dbl2, ChanPara.apConductivity))
            //{
            //    MessageBox.Show("配置参数错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //lit.Add(new double[2] { dbl, dbl2 });

            if (!ParaLimitEst(dbl3, ChanPara.apAngSp))
            {
                MessageBox.Show("配置参数错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            lit.Add(dbl3);

            switch (cboAeroCommuScnr.Text)
            {
                case "空-空": dbl = 0; break;
                case "空-地": dbl = 1; break;
                case "地-空": dbl = 2; break;
                default:
                    {
                        MessageBox.Show("配置参数错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
            }
            lit.Add(dbl);

            lit.Add(txtAeroTrace.Text);
            //lit.Add(txtAeroLaunAnte.Text);
            //lit.Add(txtAeroRecvAnte.Text);

            string[] strPath = GetOutputPath();
            if (strPath.Length != 2)
            {
                MessageBox.Show("配置参数错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            aeroChanParaPath = strPath[0];
            aeroChanPath = strPath[1];
            lit.Add(aeroChanParaPath);
            lit.Add(aeroChanPath);
           
            #endregion

            if (bgwMatlabInit.IsBusy == true)
            {
                MessageBox.Show("正在初始化Matlab，请稍后再试！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lblStatus.Text = "Busy";

            if ((string)btnAeroPlay.BackgroundImage.Tag == "播放")
                btnAeroPlay.PerformClick();

            bgwMatlabGen.RunWorkerAsync(lit);

            waitBox.ShowDialog(this);
        }

        private void 配置硬件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigBox configBox = new ConfigBox();
            string errorMsg;
            FileInfo fi;

            configBox.SetDefDir(lalOutputPath.ToolTipText);

            //if (tabChan.SelectedTab.Name == pageAeroChan.Name)
            //{
                configBox.SetFilter("ach files(*.ach)|*.ach|bin files(*.bin)|*.bin");
                configBox.SetRegex(@"(\.ach$)|(\.bin$)");
                configBox.SetPath(aeroChanPath);
            //}
            //else if (tabChan.SelectedTab.Name == pageGeneChan.Name)
            //{
            //    configBox.SetFilter("gch files(*.gch)|*.gch");
            //    configBox.SetRegex(@"\.gch$");
            //    configBox.SetPath(geneChanPath);
            //}
            //else
            //    return;

            if (DialogResult.OK == configBox.ShowDialog(this))
            {
                lblStatus.Text = "Busy";

                //if (tabChan.SelectedTab.Name == pageAeroChan.Name)
                    aeroChanPath = configBox.GetPath();
                //else if (tabChan.SelectedTab.Name == pageGeneChan.Name)
                //    geneChanPath = configBox.GetPath();

                fi = new FileInfo(configBox.GetPath());
                uint fileLength = (uint)fi.Length;

                if (!SetPcieReg(PcieReg.DDRReset, 1, out lastError))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!SetPcieReg(PcieReg.ArbWaveSize, fileLength, out lastError))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!SetPcieReg(PcieReg.FileMode, 0, out lastError))
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

                transferBox.ShowDialog(this);
            }
        }

        private void 启动设备ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string errorMsg;

            if (启动设备ToolStripMenuItem.Text == "启动设备")
            {
                if (!SetPcieReg(PcieReg.FadMode, 1, out errorMsg))
                {
                    MessageBox.Show(errorMsg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!SetPcieReg(PcieReg.IsAddFad, 1, out errorMsg))
                {
                    MessageBox.Show(errorMsg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!SetPcieReg(PcieReg.IsRun, 1, out errorMsg))
                {
                    MessageBox.Show(errorMsg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                cboxSignalType.Enabled = false;
                //cboxModulationType.Enabled = false;
                //cboxFilterType.Enabled = false;
                //cboxDataSource.Enabled = false;
                //cboxSymbolNumber.Enabled = false;
                //cboxFrequencyUnit.Enabled = false;
                //tboxFrequency.Enabled = false;
                //tboxSymbolRate.Enabled = false;
                //tboxDutyCycle.Enabled = false;

                //if (tabChan.SelectedTab.Name == pageAeroChan.Name)
                //{

                    txtAeroTrace.Enabled = false;
                    btnAeroTrace.Enabled = false;
                    txtAeroLaunAnte.Enabled = false;
                    btnAeroLaunAnte.Enabled = false;
                    txtAeroRecvAnte.Enabled = false;
                    btnAeroRecvAnte.Enabled = false;
                    cboAeroCommuScnr.Enabled = false;
                    cboAeroPolar.Enabled = false;
                    txtAeroCarrierFre.Enabled = false;
                    cboAeroCarrierFre.Enabled = false;
                    txtAeroUpdate.Enabled = false;
                    cboAeroRefMod.Enabled = false;
                    cboAeroRefEnv.Enabled = false;
                //}
                //else if (tabChan.SelectedTab.Name == pageGeneChan.Name)
                //{
                //    chkGeneChanMod.Enabled = false;

                //    if (chkGeneChanMod.Checked)
                //    {
                //        rdoGeneOutskirts.Enabled = false;
                //        rdoGeneBad.Enabled = false;
                //        rdoGeneHill.Enabled = false;
                //        rdoCost259.Enabled = false;
                //    }
                //    else
                //    {
                //        chkGeneShadow.Enabled = false;
                //        txtGeneShadow.Enabled = false;
                //        txtGeneDecorLen.Enabled = false;

                //        for (int ii = 0; ii < dgvGeneChan.RowCount;ii++ )
                //        {
                //            dgvGeneChan["colGeneLoss",ii].ReadOnly = true;
                //            dgvGeneChan["colGeneFad",ii].ReadOnly = true;
                //            dgvGeneChan["colGeneDoppler",ii].ReadOnly = true;
                //            dgvGeneChan["colGeneFdMax",ii].ReadOnly = true;
                //            dgvGeneChan["colGeneFdOffset",ii].ReadOnly = true;
                //        }
                //    }
                //}
                //else
                //{
                //    MessageBox.Show("启动设备失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                btnSaveCfg.Enabled = false;
                btnLoadCfg.Enabled = false;
                btnOutputSet.Enabled = false;
                btnOutputCover.Enabled = false;
                btnQuit.Enabled = false;
                btnChanGen.Enabled = false;
                btnCfgFPGA.Enabled = false;
                btnChanFig.Enabled = false;

                文件ToolStripMenuItem.Enabled = false;
                信道仿真ToolStripMenuItem.Enabled = false;
                配置硬件ToolStripMenuItem.Enabled = false;
                画图ToolStripMenuItem.Enabled = false;
                帮助ToolStripMenuItem.Enabled = false;

                lblStatus.Text = "Busy";

                启动设备ToolStripMenuItem.Text = "停止设备";
                btnRunFPGA.Image = Properties.Resources.stopFPGA;
            }
            else if (启动设备ToolStripMenuItem.Text == "停止设备")
            {
                if (!SetPcieReg(PcieReg.IsAddFad, 0, out errorMsg))
                {
                    MessageBox.Show(errorMsg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!SetPcieReg(PcieReg.IsRun, 0, out errorMsg))
                {
                    MessageBox.Show(errorMsg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                cboxSignalType.Enabled = true;
                //cboxModulationType.Enabled = true;
                //cboxFilterType.Enabled = true;
                //cboxDataSource.Enabled = true;
                //cboxSymbolNumber.Enabled = true;
                //cboxFrequencyUnit.Enabled = true;
                //tboxFrequency.Enabled = true;
                //tboxSymbolRate.Enabled = true;
                //tboxDutyCycle.Enabled = true;
                //if (tabChan.SelectedTab.Name == pageAeroChan.Name)
                //{
                    txtAeroTrace.Enabled = true;
                    btnAeroTrace.Enabled = true;
                    txtAeroLaunAnte.Enabled = true;
                    btnAeroLaunAnte.Enabled = true;
                    txtAeroRecvAnte.Enabled = true;
                    btnAeroRecvAnte.Enabled = true;
                    cboAeroCommuScnr.Enabled = true;
                    cboAeroPolar.Enabled = true;
                    txtAeroCarrierFre.Enabled = true;
                    cboAeroCarrierFre.Enabled = true;
                    txtAeroUpdate.Enabled = true;
                    cboAeroRefMod.Enabled = true;
                    cboAeroRefEnv.Enabled = true;
                //}
                //else if (tabChan.SelectedTab.Name == pageGeneChan.Name)
                //{
                //    chkGeneChanMod.Enabled = true;

                //    if (chkGeneChanMod.Checked)
                //    {
                //        rdoGeneOutskirts.Enabled = true;
                //        rdoGeneBad.Enabled = true;
                //        rdoGeneHill.Enabled = true;
                //        rdoCost259.Enabled = true;
                //    }
                //    else
                //    {
                //        chkGeneShadow.Enabled = true;
                //        txtGeneShadow.Enabled = true;
                //        txtGeneDecorLen.Enabled = true;

                //        for (int ii = 0; ii < dgvGeneChan.RowCount; ii++)
                //        {
                //            dgvGeneChan["colGeneLoss", ii].ReadOnly = false;
                //            dgvGeneChan["colGeneFad", ii].ReadOnly = false;
                //            dgvGeneChan["colGeneDoppler", ii].ReadOnly = false;
                //            dgvGeneChan["colGeneFdMax", ii].ReadOnly = false;
                //            dgvGeneChan["colGeneFdOffset", ii].ReadOnly = false;
                //        }
                //    }
                //}
                //else
                //{
                //    MessageBox.Show("停止设备失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                btnSaveCfg.Enabled = true;
                btnLoadCfg.Enabled = true;
                btnOutputSet.Enabled = true;
                btnOutputCover.Enabled = true;
                btnQuit.Enabled = true;
                btnChanGen.Enabled = true;
                btnCfgFPGA.Enabled = true;
                btnChanFig.Enabled = true;

                文件ToolStripMenuItem.Enabled = true;
                信道仿真ToolStripMenuItem.Enabled = true;
                配置硬件ToolStripMenuItem.Enabled = true;
                画图ToolStripMenuItem.Enabled = true;
                帮助ToolStripMenuItem.Enabled = true;

                lblStatus.Text = "Ready";

                启动设备ToolStripMenuItem.Text = "启动设备";
                btnRunFPGA.Image = Properties.Resources.runFPGA;
            }
        }
        #endregion

        #region 画图相关菜单
        private void 收发端轨迹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (errorShow.GetError(txtAeroTrace) != "")
            {
                MessageBox.Show("配置参数错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bgwMatlabInit.IsBusy == true)
            {
                MessageBox.Show("正在初始化Matlab，请稍后再试！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lblStatus.Text = "Busy";

            ClearAllEvent();
            btnChanFig.Click += new EventHandler(收发端轨迹ToolStripMenuItem_Click);

            ArrayList lit = new ArrayList();
            lit.Add(MatlabFig.trace);
            lit.Add(txtAeroTrace.Text);
            bgwMatlabFig.RunWorkerAsync(lit);

            waitBox.ShowDialog(this);
        }

        private void 发射端ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (errorShow.GetError(txtAeroLaunAnte) != "")
            {
                MessageBox.Show("配置参数错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bgwMatlabInit.IsBusy == true)
            {
                MessageBox.Show("正在初始化Matlab，请稍后再试！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lblStatus.Text = "Busy";

            ClearAllEvent();
            btnChanFig.Click += new EventHandler(发射端ToolStripMenuItem_Click);

            ArrayList lit = new ArrayList();
            lit.Add(MatlabFig.ante);
            lit.Add(txtAeroLaunAnte.Text);
            bgwMatlabFig.RunWorkerAsync(lit);

            waitBox.ShowDialog(this);
        }

        private void 接收端ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (errorShow.GetError(txtAeroRecvAnte) != "")
            {
                MessageBox.Show("配置参数错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bgwMatlabInit.IsBusy == true)
            {
                MessageBox.Show("正在初始化Matlab，请稍后再试！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lblStatus.Text = "Busy";

            ClearAllEvent();
            btnChanFig.Click += new EventHandler(接收端ToolStripMenuItem_Click);

            ArrayList lit = new ArrayList();
            lit.Add(MatlabFig.ante);
            lit.Add(txtAeroRecvAnte.Text);
            bgwMatlabFig.RunWorkerAsync(lit);

            waitBox.ShowDialog(this);
        }
        #endregion

        #region 其他
        protected override void WndProc(ref Message m)
        {
            // hu 拦截双击标题栏、移动窗体的系统消息
            if (m.Msg != 0xA3)
            {
                base.WndProc(ref m);
            }
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            OpenFileDialog opeFilDia = new OpenFileDialog();
            if (btn.Name == btnAeroTrace.Name)
                opeFilDia.Filter = "tra files(*.tra)|*.tra";
            else if (btn.Name == btnAeroLaunAnte.Name || btn.Name == btnAeroRecvAnte.Name)
                opeFilDia.Filter = "ante files(*.ante)|*.ante";
            opeFilDia.FilterIndex = 1;
            opeFilDia.InitialDirectory = strDefaultPath + "\\file\\";
            opeFilDia.RestoreDirectory = true;
            if (opeFilDia.ShowDialog() == DialogResult.OK)
            {
                if (btn.Name == btnAeroTrace.Name)
                    txtAeroTrace.Text = opeFilDia.FileName;
                else if (btn.Name == btnAeroLaunAnte.Name)
                    txtAeroLaunAnte.Text = opeFilDia.FileName;
                else if (btn.Name == btnAeroRecvAnte.Name)
                    txtAeroRecvAnte.Text = opeFilDia.FileName;
                //else if (btn.Name == btnWaveFile.Name)
                //{
                //    tboxWaveFilePath.Text = opeFilDia.FileName;
                //    waveFilePath = opeFilDia.FileName;
                //    FileInfo fi = new FileInfo(waveFilePath);
                //    uint fileLength = (uint)fi.Length;

                //    if (!SetPcieReg(PcieReg.DDRReset, 1, out lastError))
                //    {
                //        MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return;
                //    }
                //    if (!SetPcieReg(PcieReg.ArbWaveSize, fileLength, out lastError))
                //    {
                //        MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return;
                //    }
                //    if (!SetPcieReg(PcieReg.FileMode, 0, out lastError))
                //    {
                //        MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return;
                //    }
                //    if (!SetPcieReg(PcieReg.DDRReset, 0, out lastError))
                //    {
                //        MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return;
                //    }

                //    bgwDmaTransfer.RunWorkerAsync(waveFilePath);//RunWorkerAsync(waveFilePath);

                //    transferBox.ShowDialog(this);
                //}
            }
        }

        private void tabChan_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (启动设备ToolStripMenuItem.Text == "停止设备")
                e.Cancel = true;
        }

        private void lalWorkPath_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Explorer.exe", lalOutputPath.ToolTipText);
        }
        #endregion

        #region 播放相关
        private void tabChan_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControlEx tab = sender as TabControlEx;
            //if (tab.SelectedTab.Name != pageAeroChan.Name)
            //{
                if ((string)btnAeroPlay.BackgroundImage.Tag == "播放")
                {
                    tmrAeroPlay.Stop();

                    btnAeroPlay.BackgroundImage = Properties.Resources.btnAeroChanPlay;
                    btnAeroPlay.BackgroundImage.Tag = "暂停";
                }
            //}
        }

        private void btnAChanPlay_Click(object sender, EventArgs e)
        {
            if ((string)btnAeroPlay.BackgroundImage.Tag == "暂停")
            {
                tmrAeroPlay.Start();

                btnAeroPlay.BackgroundImage = Properties.Resources.btnAeroChanPause;
                btnAeroPlay.BackgroundImage.Tag = "播放";
            }
            else if ((string)btnAeroPlay.BackgroundImage.Tag == "播放")
            {
                tmrAeroPlay.Stop();

                btnAeroPlay.BackgroundImage = Properties.Resources.btnAeroChanPlay;
                btnAeroPlay.BackgroundImage.Tag = "暂停";
            }
            else
            {
                tmrAeroPlay.Stop();

                btnAeroPlay.BackgroundImage = Properties.Resources.btnAeroChanPlay;
                btnAeroPlay.BackgroundImage.Tag = "暂停";
            }
        }

        private void btnAChanStop_Click(object sender, EventArgs e)
        {
            if ((string)btnAeroPlay.BackgroundImage.Tag == "播放")
                btnAeroPlay.PerformClick();
            lalAeroStep.Text = "X1";
            tkbrAeroChan.Value = 0;
        }

        private void tmrAeroPlay_Tick(object sender, EventArgs e)
        {
            MatchCollection mch;
            float timeNow, timeTotal,posNextPct,lineNextPct;
            long lineMaxIdx,lineNext;
            int changeStep;

            mch = Regex.Matches(lalAeroTimes.Text, @"[+-]?(\d+\.?\d*|\d*\.?\d+)");
            if (mch.Count != 2 ||
                !float.TryParse(mch[0].Groups[0].Value,out timeNow) ||
                !float.TryParse(mch[1].Groups[0].Value, out timeTotal))
            {
                btnAeroStop.PerformClick();
                AeroTabPlayEnable(false);
                MessageBox.Show("读取信道参数文件失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (timeNow == timeTotal)
            {
                btnAeroStop.PerformClick();
                return;
            }

            lineMaxIdx = (long)(timeTotal / aeroUpDate + 0.5);
            lineNext = (long)(timeNow / aeroUpDate + 0.5) + 1;
            lineNextPct = Convert.ToSingle(lineNext) / lineMaxIdx;
            posNextPct = Convert.ToSingle(tkbrAeroChan.Value + tkbrAeroChan.SmallChange) / tkbrAeroChan.Maximum;

            if (lineNextPct >= posNextPct)
            {
                changeStep = (int)((lineNextPct * tkbrAeroChan.Maximum - tkbrAeroChan.Value) / tkbrAeroChan.SmallChange + 0.5);
                tkbrAeroChan.Value += tkbrAeroChan.SmallChange * changeStep;
            }
            else
            {
                if (!AeroTabParaShow(aeroChanParaPath, timeNow / timeTotal, true))
                {
                    btnAeroStop.PerformClick();
                    AeroTabPlayEnable(false);
                    MessageBox.Show("读取信道参数文件失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void tkbrAeroChan_ValueChanged(object sender, EventArgs e)
        {
            TrackBar tkbr = sender as TrackBar;

            if (!AeroTabParaShow(aeroChanParaPath, Convert.ToSingle(tkbr.Value) / tkbr.Maximum))
            {
                btnAeroStop.PerformClick();
                AeroTabPlayEnable(false);
                MessageBox.Show("读取信道参数文件失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAeroPlaySpeedCtrl_Click(object sender, EventArgs e)
        {
            Match mch;
            float speed;
            Button btn = sender as Button;

            mch = Regex.Match(lalAeroStep.Text, @"(\d+\.?\d*|\d*\.?\d+)$");

            if (!float.TryParse(mch.Groups[0].Value, out speed))
                return;

            if (btn.Name == btnAeroBackward.Name)
            {
                if (speed <= 1)
                    speed -= 0.1f;
                else
                    speed--;
            }
            else if (btn.Name == btnAeroForward.Name)
            {
                if (speed < 1)
                    speed += 0.1f;
                else
                    speed++;
            }
            else
                return;

            if (speed < minAeroPlaySpeed || speed > maxAeroPlaySpeed)
                return;

            lalAeroStep.Text = "X" + speed.ToString();
        }

        private void lalAeroStep_TextChanged(object sender, EventArgs e)
        {
            Match mch;
            float speed;
            Label lal = sender as Label;

            mch = Regex.Match(lal.Text, @"(\d+\.?\d*|\d*\.?\d+)$");

            if (!float.TryParse(mch.Groups[0].Value, out speed))
                return;

            tmrAeroPlay.Interval = (int)(aeroPlayDfltPd / speed);
        }
        #endregion

        #region 拖入文件相关
        private void fileDrag_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void fileDrag_DragDrop(object sender, DragEventArgs e)
        {
            string strFilePath = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();

            if (sender.Equals(dgvAeroChan))
            {
                Match mch = Regex.Match(strFilePath, @"\.acp$", RegexOptions.IgnoreCase);
                if (!mch.Groups[0].Success)
                {
                    MessageBox.Show("载入信道参数文件失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if ((string)btnAeroPlay.BackgroundImage.Tag == "播放")
                    btnAeroPlay.PerformClick();
                aeroChanParaPath = strFilePath;
                AeroTabPlayEnable();
            }
            //else if (sender.Equals(dgvGeneChan))
            //{
            //    DataGridView dgv = sender as DataGridView;
            //    Match mch = Regex.Match(strFilePath, @"\.xml$", RegexOptions.IgnoreCase);
            //    if (!mch.Groups[0].Success || !LoadChanParaTabXml(strFilePath, dgv))
            //        MessageBox.Show("载入信道参数表格文件失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            else if (sender.Equals(txtAeroTrace) || 
                     sender.Equals(txtAeroLaunAnte) || 
                     sender.Equals(txtAeroRecvAnte) //||sender.Equals(tboxWaveFilePath)
                     )
            {
                TextBox txt = sender as TextBox;
                txt.Text = strFilePath;
            }
            else if (sender.Equals(pageAeroChan))
            {
                Match mch = Regex.Match(strFilePath, @"\.xml$", RegexOptions.IgnoreCase);

                if (!mch.Groups[0].Success || !LoadCfgXml(strFilePath))
                    MessageBox.Show("载入配置文件失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
        #endregion

        #region 表格编辑控件相关
        //private void dgvTab_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{
        //    dgvTmp = sender as DataGridView;
        //    if ("colGeneFad" == dgvTmp.Columns[dgvTmp.CurrentCell.ColumnIndex].Name)
        //    {
        //        ComboBox cbo = e.Control as ComboBox;
        //        cbo.SelectedIndexChanged += new EventHandler(ComboBoxEditingControl_SelectedIndexChanged);
        //        cbo.VisibleChanged += new EventHandler(ComboBoxEditingControl_VisibleChanged);
        //    }
        //    else if (e.Control is DataGridViewTextBoxEditingControl)
        //    {
        //        TextBox txt = e.Control as TextBox;
        //        txt.VisibleChanged += new EventHandler(TextBoxEditingControl_VisibleChanged);
        //        txt.KeyPress += new KeyPressEventHandler(TextBoxEditingControl_KeyPress);
        //    }
        //}

        //private void ComboBoxEditingControl_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (dgvTmp.Name == dgvGeneChan.Name)
        //    {
        //        ComboBox cbo = sender as ComboBox;
        //        double dbl, dbl2;

        //        if (cbo.Text == "莱斯衰落")
        //        {
        //            if (geneFad[dgvTmp.CurrentCell.RowIndex].ContainsKey("莱斯衰落"))
        //            {
        //                if (!geneFad[dgvTmp.CurrentCell.RowIndex].ContainsKey(riceBox.GetRiceK()) ||
        //                    !geneFad[dgvTmp.CurrentCell.RowIndex].ContainsKey(riceBox.GetRiceAOA()))
        //                {
        //                    Match mch = Regex.Match(dgvTmp.CurrentCell.ToolTipText, @"^[\u4e00-\u9fa5]+");
        //                    cbo.SelectedIndexChanged -= new EventHandler(ComboBoxEditingControl_SelectedIndexChanged);
        //                    cbo.Text = mch.Groups[0].Value;
        //                    cbo.SelectedIndexChanged += new EventHandler(ComboBoxEditingControl_SelectedIndexChanged);

        //                    MessageBox.Show("参数设置失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                    return;
        //                }

        //                riceBox.SetPara(geneFad[dgvTmp.CurrentCell.RowIndex][riceBox.GetRiceK()], 
        //                                geneFad[dgvTmp.CurrentCell.RowIndex][riceBox.GetRiceAOA()]);
        //            }

        //            if (DialogResult.OK == riceBox.ShowDialog(this) && riceBox.GetPara(out dbl, out dbl2))
        //            {
        //                geneFad[dgvTmp.CurrentCell.RowIndex] = new Dictionary<string, double>();
        //                geneFad[dgvTmp.CurrentCell.RowIndex].Add(cbo.Text, 0);
        //                geneFad[dgvTmp.CurrentCell.RowIndex].Add(riceBox.GetRiceK(), dbl);
        //                geneFad[dgvTmp.CurrentCell.RowIndex].Add(riceBox.GetRiceAOA(), dbl2);

        //                GeneFadShow(dgvTmp.CurrentCell, geneFad[dgvTmp.CurrentCell.RowIndex]);
        //            }
        //            else
        //            {
        //                Match mch = Regex.Match(dgvTmp.CurrentCell.ToolTipText, @"^[\u4e00-\u9fa5]+");
        //                cbo.SelectedIndexChanged -= new EventHandler(ComboBoxEditingControl_SelectedIndexChanged);
        //                cbo.Text = mch.Groups[0].Value;
        //                cbo.SelectedIndexChanged += new EventHandler(ComboBoxEditingControl_SelectedIndexChanged);
        //            }
        //        }
        //        else if (cbo.Text == "纯多普勒")
        //        {
        //            if (geneFad[dgvTmp.CurrentCell.RowIndex].ContainsKey("纯多普勒"))
        //            {
        //                if (!geneFad[dgvTmp.CurrentCell.RowIndex].ContainsKey(dopplerBox.GetDoppler()))
        //                {
        //                    Match mch = Regex.Match(dgvTmp.CurrentCell.ToolTipText, @"^[\u4e00-\u9fa5]+");
        //                    cbo.SelectedIndexChanged -= new EventHandler(ComboBoxEditingControl_SelectedIndexChanged);
        //                    cbo.Text = mch.Groups[0].Value;
        //                    cbo.SelectedIndexChanged += new EventHandler(ComboBoxEditingControl_SelectedIndexChanged);

        //                    MessageBox.Show("参数设置失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                    return;
        //                }

        //                dopplerBox.SetDoppler(geneFad[dgvTmp.CurrentCell.RowIndex][dopplerBox.GetDoppler()]);
        //            }

        //            if (DialogResult.OK == dopplerBox.ShowDialog(this) && dopplerBox.GetDoppler(out dbl))
        //            {
        //                geneFad[dgvTmp.CurrentCell.RowIndex] = new Dictionary<string, double>();
        //                geneFad[dgvTmp.CurrentCell.RowIndex].Add(cbo.Text, 0);
        //                geneFad[dgvTmp.CurrentCell.RowIndex].Add(dopplerBox.GetDoppler(), dbl);

        //                GeneFadShow(dgvTmp.CurrentCell, geneFad[dgvTmp.CurrentCell.RowIndex]);
        //            }
        //            else
        //            {
        //                Match mch = Regex.Match(dgvTmp.CurrentCell.ToolTipText, @"^[\u4e00-\u9fa5]+");
        //                cbo.SelectedIndexChanged -= new EventHandler(ComboBoxEditingControl_SelectedIndexChanged);
        //                cbo.Text = mch.Groups[0].Value;
        //                cbo.SelectedIndexChanged += new EventHandler(ComboBoxEditingControl_SelectedIndexChanged);
        //            }
        //        }
        //        else if (cbo.Text == "瑞利衰落")
        //        {
        //            geneFad[dgvTmp.CurrentCell.RowIndex] = new Dictionary<string, double>();
        //            geneFad[dgvTmp.CurrentCell.RowIndex].Add(cbo.Text, 0);

        //            GeneFadShow(dgvTmp.CurrentCell, geneFad[dgvTmp.CurrentCell.RowIndex]);
        //        }
        //    }
        //}

        //private void ComboBoxEditingControl_VisibleChanged(object sender, EventArgs e)
        //{
        //    ComboBox cbo = sender as ComboBox;
        //    if (cbo.Visible == false)
        //    {
        //        cbo.SelectedIndexChanged -= new EventHandler(ComboBoxEditingControl_SelectedIndexChanged);
        //        cbo.VisibleChanged -= new EventHandler(ComboBoxEditingControl_VisibleChanged);
        //    }
        //}

        //private void TextBoxEditingControl_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    TextBox txt = sender as TextBox;
        //    if ("colGeneLoss" == dgvTmp.Columns[dgvTmp.CurrentCell.ColumnIndex].Name ||
        //        "colGeneFdOffset" == dgvTmp.Columns[dgvTmp.CurrentCell.ColumnIndex].Name)
        //        InputLimit(txt, e, InputMod.Float);
        //    else if ("colGeneFdMax" == dgvTmp.Columns[dgvTmp.CurrentCell.ColumnIndex].Name)
        //        InputLimit(txt, e, InputMod.UInt);
        //    else
        //        InputLimit(txt, e, InputMod.UFloat);
        //}

        //private void TextBoxEditingControl_VisibleChanged(object sender, EventArgs e)
        //{
        //    TextBox txt = sender as TextBox;
        //    if (txt.Visible == false)
        //    {
        //        txt.VisibleChanged -= new EventHandler(TextBoxEditingControl_VisibleChanged);
        //        txt.KeyPress -= new KeyPressEventHandler(TextBoxEditingControl_KeyPress);
        //    }
        //}
        #endregion

        #region 信道参数表格相关
        private void dgvAeroChan_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            for (int ii = e.RowIndex; ii < e.RowIndex + e.RowCount; ii++)
            {
                if (ii == 0)
                    dgvAeroChan.Rows[ii].HeaderCell.Value = "直射径";
                else if (ii == 1)
                    dgvAeroChan.Rows[ii].HeaderCell.Value = "反射径";
                else
                    dgvAeroChan.Rows[ii].HeaderCell.Value = "散射径";
            }
        }

        //private void dgvChanPara_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        //{
        //    DataGridView dgv = sender as DataGridView;

        //    if (dgv.Name == dgvGeneChan.Name)
        //    {
        //        for (int ii = 0; ii < e.RowCount; ii++)
        //        {
        //            geneFad.Add(new Dictionary<string, double>());
        //            geneFad[geneFad.Count - 1].Add("瑞利衰落", 0);

        //            GeneFadShow(dgv["colGeneFad", geneFad.Count - 1], geneFad[geneFad.Count - 1]);
        //        }
        //    }

        //    for (int ii = e.RowIndex; ii < e.RowIndex + e.RowCount; ii++)
        //    {
        //        dgv.Rows[ii].HeaderCell.Value = "衰落路径" + (ii + 1).ToString();
        //    }
        //}

        //private void dgvChanPara_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        //{
        //    DataGridView dgv = sender as DataGridView;

        //    if (dgv.Name == dgvGeneChan.Name)
        //        geneFad.RemoveAt(e.RowIndex);
            
        //    for (int ii = e.RowIndex; ii < dgvGeneChan.RowCount; ii++)
        //    {
        //        dgv.Rows[ii].HeaderCell.Value = "衰落路径" + (ii + 1).ToString();
        //    }
        //}

        //private void dgvChanPara_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
        //    {
        //        double dblData;
        //        DataGridView dgv = sender as DataGridView;

        //        dgv[e.ColumnIndex, e.RowIndex].ErrorText = null;
        //        if ("colGeneDelay" == dgv.Columns[e.ColumnIndex].Name)
        //        {
        //            if (!double.TryParse(dgv[e.ColumnIndex, e.RowIndex].FormattedValue.ToString(), out dblData) || !ParaLimitEst(dblData, ChanPara.gpCluDelay))
        //                dgv[e.ColumnIndex, e.RowIndex].ErrorText = ParaLimitError(ChanPara.gpCluDelay);
        //        }
        //        else if ("colGeneLoss" == dgv.Columns[e.ColumnIndex].Name)
        //        {
        //            if (!double.TryParse(dgv[e.ColumnIndex, e.RowIndex].FormattedValue.ToString(), out dblData) || !ParaLimitEst(dblData, ChanPara.gpCluLoss))
        //                dgv[e.ColumnIndex, e.RowIndex].ErrorText = ParaLimitError(ChanPara.gpCluLoss);
        //        }
        //        else if ("colGeneFdMax" == dgv.Columns[e.ColumnIndex].Name)
        //        {
        //            if (!double.TryParse(dgv[e.ColumnIndex, e.RowIndex].FormattedValue.ToString(), out dblData) || !ParaLimitEst(dblData, ChanPara.gpMaxDoppler))
        //                dgv[e.ColumnIndex, e.RowIndex].ErrorText = ParaLimitError(ChanPara.gpMaxDoppler);
        //        }
        //        else if ("colGeneFad" == dgv.Columns[e.ColumnIndex].Name)
        //        {
        //            if (dgv[e.ColumnIndex, e.RowIndex].FormattedValue.ToString() == "纯多普勒")
        //            {
        //                if (!chkGeneChanMod.Checked)
        //                    dgv["colGeneDoppler", e.RowIndex].ReadOnly = true;
        //                dgv["colGeneFdMax", e.RowIndex].ReadOnly = true;
        //                dgv["colGeneFdOffset", e.RowIndex].ReadOnly = true;
        //            }
        //            else
        //            {
        //                if (!chkGeneChanMod.Checked)
        //                    dgv["colGeneDoppler", e.RowIndex].ReadOnly = false;
        //                dgv["colGeneFdMax", e.RowIndex].ReadOnly = false;
        //                dgv["colGeneFdOffset", e.RowIndex].ReadOnly = false;
        //            }
        //        }
        //    }
        //}

        //private void dgvChanPara_DataError(object sender, DataGridViewDataErrorEventArgs e)
        //{
        //    DataGridView dgv = sender as DataGridView;

        //    if (dgv.Columns[e.ColumnIndex].Name == "colGeneFad")
        //        dgv[e.ColumnIndex, e.RowIndex].Value = "瑞利衰落";
        //    else if (dgv.Columns[e.ColumnIndex].Name == "colGeneDoppler")
        //        dgv[e.ColumnIndex, e.RowIndex].Value = "经典3dB";
        //}
        #endregion

        #region 表格右键菜单
        private void 载入文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opeFilDia = new OpenFileDialog();
            opeFilDia.Filter = "acp files(*.acp)|*.acp";
            opeFilDia.FilterIndex = 1;
            opeFilDia.InitialDirectory = lalOutputPath.ToolTipText;
            opeFilDia.RestoreDirectory = true;
            if (opeFilDia.ShowDialog() == DialogResult.OK)
            {
                if ((string)btnAeroPlay.BackgroundImage.Tag == "播放")
                    btnAeroPlay.PerformClick();
                aeroChanParaPath = opeFilDia.FileName;
                AeroTabPlayEnable();
            }
        }

        private void 打开目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Explorer.exe", "/select,"+aeroChanParaPath);
        }

        private void tabMenu_Opening(object sender, CancelEventArgs e)
        {
            ContextMenuStrip ctm = sender as ContextMenuStrip;
            dgvTmp = ctm.SourceControl as DataGridView;
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (dgvTmp.Name == dgvGeneChan.Name)
            //{
            //    int addRowsNum, rowStart;
            //    int[] rowsIdx = new int[dgvTmp.SelectedRows.Count];

            //    rowStart = dgvTmp.Rows.Count;
            //    for (int ii = 0; ii < dgvTmp.SelectedRows.Count; ii++)
            //        rowsIdx[ii] = dgvTmp.SelectedRows[ii].Index;
            //    Array.Sort(rowsIdx);

            //    if (dgvTmp.RowCount + dgvTmp.SelectedRows.Count > maxGeneCluNum)
            //        addRowsNum = maxGeneCluNum - dgvTmp.RowCount;
            //    else
            //        addRowsNum = dgvTmp.SelectedRows.Count;

            //    dgvTmp.RowCount += addRowsNum;

            //    for (int ii = 0; ii < addRowsNum; ii++)
            //    {
            //        geneFad[rowStart + ii] = geneFad[rowsIdx[ii]];
            //        dgvTmp["colGeneFad", rowStart + ii].ToolTipText = dgvTmp["colGeneFad", rowsIdx[ii]].ToolTipText;

            //        for (int jj = 0; jj < dgvTmp.ColumnCount; jj++)
            //            dgvTmp[jj, rowStart + ii].Value = dgvTmp[jj, rowsIdx[ii]].EditedFormattedValue.ToString();
            //    }
            //}
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (dgvTmp.Name == dgvGeneChan.Name)
            //{
            //    int[] rowsIdx = new int[dgvTmp.SelectedRows.Count];
            //    int leaveRow = 0;
            //    for (int ii = 0; ii < dgvTmp.SelectedRows.Count; ii++)
            //        rowsIdx[ii] = dgvTmp.SelectedRows[ii].Index;
            //    Array.Sort(rowsIdx);

            //    if (rowsIdx.Length == dgvTmp.RowCount)
            //        leaveRow = 1;

            //    for (int ii = rowsIdx.Length - 1; ii >= leaveRow; ii--)
            //    {
            //        dgvTmp.Rows.RemoveAt(rowsIdx[ii]);
            //    }
            //}

        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SaveFileDialog savFilDia = new SaveFileDialog();
            //savFilDia.Filter = "xml files(*.xml)|*.xml";
            //savFilDia.FilterIndex = 1;          // hu 设置默认文件类型显示顺序
            //savFilDia.InitialDirectory = lalOutputPath.ToolTipText;
            //savFilDia.RestoreDirectory = true;  // hu 保存对话框是否记忆上次打开的目录
            //if (savFilDia.ShowDialog() == DialogResult.OK)
            //{
            //    if (dgvTmp.Name == dgvGeneChan.Name)
            //    {
            //        if (!SaveChanParaTabXml(savFilDia.FileName, dgvTmp))
            //            MessageBox.Show("保存信道参数表格文件失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //}
        }

        private void 载入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OpenFileDialog opeFilDia = new OpenFileDialog();
            //opeFilDia.Filter = "xml files(*.xml)|*.xml";
            //opeFilDia.FilterIndex = 1;
            //opeFilDia.InitialDirectory = lalOutputPath.ToolTipText;
            //opeFilDia.RestoreDirectory = true;
            //if (opeFilDia.ShowDialog() == DialogResult.OK)
            //{
            //    if (dgvTmp.Name == dgvGeneChan.Name)
            //    {
            //        if (!LoadChanParaTabXml(opeFilDia.FileName, dgvTmp))
            //            MessageBox.Show("载入信道参数表格文件失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //}
        }
        #endregion

        #region 错误提示
        private void txtFileExist_TextChanged(object sender, EventArgs e)
        {
            Match mch;
            TextBox txt = sender as TextBox;

            TipShow.SetToolTip(txt, txt.Text);

            if (!txt.Focused)
                txt.SelectionStart = txt.Text.Length;

            if (txt.Name == txtAeroTrace.Name)
                mch = Regex.Match(txt.Text, @"\.tra$", RegexOptions.IgnoreCase);
            else if (txt.Name == txtAeroLaunAnte.Name || txt.Name == txtAeroRecvAnte.Name)
                mch = Regex.Match(txt.Text, @"\.ante$", RegexOptions.IgnoreCase);
            //else if (txt.Name == tboxWaveFilePath.Name)
            //    mch = Regex.Match(txt.Text, @"\.bin$",RegexOptions.IgnoreCase);
            else
                return;

            errorShow.SetError(txt, null);
            if (!mch.Groups[0].Success || !File.Exists(txt.Text))
                errorShow.SetError(txt, "文件不存在");
        }

        private void txtLimit_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            double dbl;
            ChanPara chanPara;


            if (txt.Name == txtAeroCarrierFre.Name)
                chanPara = ChanPara.apCarrierFre;
            else if (txt.Name == txtAeroUpdate.Name)
                chanPara = ChanPara.apUpdate;
            //else if (txt.Name == tboxDutyCycle.Name)
            //    chanPara = ChanPara.awDutyCyclt;
            //else if (txt.Name == tboxSymbolRate.Name)
            //    chanPara = ChanPara.awSymbolRate;
            //else if (txt.Name == tboxFrequency.Name)
            //    chanPara = ChanPara.awFreqquency;
            else
                return;

            errorShow.SetError(txt, null);
            //if (txt.Name != tboxFrequency.Name)
            //{
            if (!double.TryParse(txt.Text, out dbl) || !ParaLimitEst(dbl, chanPara))
                errorShow.SetError(txt, ParaLimitError(chanPara));
            //}
            //else
            //{
            //    double index = cboxFrequencyUnit.SelectedIndex;
            //    if (index < 0 || index > 3 || !double.TryParse(tboxFrequency.Text, out dbl) || !ParaLimitEst(dbl * Math.Pow(1000, index), chanPara))
            //        errorShow.SetError(txt, ParaLimitError(chanPara));
            //}
            
        }
        #endregion

        #region 勾选
        //private void chkGeneShadow_CheckedChanged(object sender, EventArgs e)
        //{
        //    CheckBox chk = sender as CheckBox;
        //    if (chk.Checked)
        //    {
        //        txtGeneShadow.Enabled = true;
        //        txtGeneDecorLen.Enabled = true;
        //    }
        //    else
        //    {
        //        txtGeneShadow.Enabled = false;
        //        txtGeneDecorLen.Enabled = false;
        //    }
        //}

        private void chkAWGN_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;

            WaveCon waveCon = new WaveCon();
            waveCon.SetNoiseSwitch(chk);
            if (chk.Checked)
            {
                txtAeroSNR.Enabled = true;
                if (txtAeroSNR.Text != "")
                {
                    waveCon.SetSNR(txtAeroSNR);
                }
            }
            else
            {
                txtAeroSNR.Enabled = false;
                
            }

            


        }

        //private void chkGeneChanMod_CheckedChanged(object sender, EventArgs e)
        //{
        //    CheckBox chk = sender as CheckBox;
        //    if (chk.Checked)
        //    {
        //        rdoGeneOutskirts.Enabled = true;
        //        rdoGeneBad.Enabled = true;
        //        rdoGeneHill.Enabled = true;
        //        rdoCost259.Enabled = true;

        //        for (int ii = 0; ii < dgvGeneChan.RowCount; ii++)
        //        {
        //            dgvGeneChan["colGeneDelay", ii].ReadOnly = true;
        //            dgvGeneChan["colGeneLoss", ii].ReadOnly = true;
        //            dgvGeneChan["colGeneDoppler", ii].ReadOnly = true;
        //        }
        //    }
        //    else
        //    {
        //        rdoGeneOutskirts.Enabled = false;
        //        rdoGeneBad.Enabled = false;
        //        rdoGeneHill.Enabled = false;
        //        rdoCost259.Enabled = false;

        //        for (int ii = 0; ii < dgvGeneChan.RowCount; ii++)
        //        {
        //            dgvGeneChan["colGeneDelay", ii].ReadOnly = false;
        //            dgvGeneChan["colGeneLoss", ii].ReadOnly = false;
        //            dgvGeneChan["colGeneDoppler", ii].ReadOnly = false;
        //        }
        //    }
        //}

        //private void rdoGeneChanMod_CheckedChanged(object sender, EventArgs e)
        //{
        //    RadioButton rdo = sender as RadioButton;

        //    if (chkGeneChanMod.Checked && rdo.Checked)
        //    {
        //        string geneChanName = "";

        //        if (sender.Equals(rdoGeneOutskirts))
        //            geneChanName = rdo.Text + lalGeneOutskirts.Text + ".xml";
        //        else if (sender.Equals(rdoGeneBad))
        //            geneChanName = rdo.Text + lalGeneBad.Text + ".xml";
        //        else if (sender.Equals(rdoGeneHill))
        //            geneChanName = rdo.Text + lalGeneHill.Text + ".xml";
        //        else if (sender.Equals(rdoCost259))
        //            geneChanName = rdo.Text + ".xml";

        //        LoadCfgXml(strDefaultPath + geneChanName, SoftCfgMod.gene);
        //    }
        //}
        #endregion

        #region 控件变灰
        private void dgvGeneChan_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (e.StateChanged == DataGridViewElementStates.ReadOnly)
            {
                if (e.Cell.ReadOnly)
                {
                    e.Cell.Style.ForeColor = Color.FromArgb(85, 85, 85);
                    e.Cell.Style.SelectionForeColor = Color.FromArgb(85, 85, 85);
                }
                else
                {
                    if (e.Cell.OwningColumn.Name == "colGeneDoppler" ||
                        e.Cell.OwningColumn.Name == "colGeneFdMax" ||
                        e.Cell.OwningColumn.Name == "colGeneFdOffset")
                    {
                        if (dgv["colGeneFad",e.Cell.RowIndex].FormattedValue.ToString() == "纯多普勒")
                        {
                            e.Cell.ReadOnly = true;
                            return;
                        }
                    }
                    e.Cell.Style.ForeColor = dgv.ColumnHeadersDefaultCellStyle.ForeColor;
                    e.Cell.Style.SelectionForeColor = dgv.ColumnHeadersDefaultCellStyle.ForeColor;
                }
            }
        }

        private void checkMod_EnabledChanged(object sender, EventArgs e)
        {
            //if (sender.Equals(txtGeneShadow) || sender.Equals(txtGeneDecorLen))
            //{
            //    TextBox txt = sender as TextBox;
            //    if (!chkGeneShadow.Checked && txt.Enabled)
            //        txt.Enabled = false;
            //}
            //else if (sender.Equals(txtGeneSNR))
            //{
            //    TextBox txt = sender as TextBox;
            //    if (!chkGeneAWGN.Checked && txt.Enabled)
            //        txt.Enabled = false;
            //}
            //else if (sender.Equals(cboGeneSNR))
            //{
            //    ComboBox cbo = sender as ComboBox;
            //    if (!chkGeneAWGN.Checked && cbo.Enabled)
            //        cbo.Enabled = false;
            //}
        }

        private void rdoGeneMod_EnabledChanged(object sender, EventArgs e)
        {
            //RadioButton rdo = sender as RadioButton;

            //if (rdo.Name == rdoGeneOutskirts.Name)
            //{
            //    if (rdo.Enabled)
            //    {
            //        lalGeneOutskirts.ForeColor = rdo.ForeColor;
            //        if (rdo.Checked)
            //            LoadCfgXml(strDefaultPath + rdo.Text + lalGeneOutskirts.Text + ".xml", SoftCfgMod.gene);
            //    }
            //    else
            //        lalGeneOutskirts.ForeColor = Color.FromArgb(85, 85, 85);
            //}
            //else if (rdo.Name == rdoGeneBad.Name)
            //{
            //    if (rdo.Enabled)
            //    {
            //        lalGeneBad.ForeColor = rdo.ForeColor;
            //        if (rdo.Checked)
            //            LoadCfgXml(strDefaultPath + rdo.Text + lalGeneBad.Text + ".xml", SoftCfgMod.gene);
            //    }
            //    else
            //        lalGeneBad.ForeColor = Color.FromArgb(85, 85, 85);
            //}
            //else if (rdo.Name == rdoGeneHill.Name)
            //{
            //    if (rdo.Enabled)
            //    {
            //        lalGeneHill.ForeColor = rdo.ForeColor;
            //        if (rdo.Checked)
            //            LoadCfgXml(strDefaultPath + rdo.Text + lalGeneHill.Text + ".xml", SoftCfgMod.gene);
            //    }
            //    else
            //        lalGeneHill.ForeColor = Color.FromArgb(85, 85, 85);
            //}
            //else if (rdo.Name == rdoCost259.Name && rdo.Enabled && rdo.Checked)
            //    LoadCfgXml(strDefaultPath + rdo.Text + ".xml", SoftCfgMod.gene);
        }
        #endregion

        #region 预定义信道单选辅助
        //private void lalGeneOutskirts_Click(object sender, EventArgs e)
        //{
        //    if (rdoGeneOutskirts.Enabled)
        //        rdoGeneOutskirts.Checked = true;
        //}

        //private void lalGeneBad_Click(object sender, EventArgs e)
        //{
        //    if (rdoGeneBad.Enabled)
        //        rdoGeneBad.Checked = true;
        //}

        //private void lalGeneHill_Click(object sender, EventArgs e)
        //{
        //    if (rdoGeneHill.Enabled)
        //        rdoGeneHill.Checked = true;
        //}
        #endregion

        #region 后台运行
        public void bgwMatlabInit_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = true;
            try 
            { 
                aeroChan = new AeroChan();
                //geneChan = new GeneChan();
            }
            catch
            {
                e.Result = false;
                lastError = "初始化Matlab运行环境失败！";
            }
        }

        public void bgwMatlabInit_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((bool)e.Result == false)
                MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            lblStatus.Text = "Ready";
        }

        public void bgwMatlabFig_DoWork(object sender, DoWorkEventArgs e)
        {
            ArrayList lit = e.Argument as ArrayList;
            e.Result = true;

            try
            {
                MWCharArray FileName = lit[1] as string;

                switch ((MatlabFig)lit[0])
                {
                    case MatlabFig.trace:
                        {
                            MWArray[] matlabRlt = aeroChan.FigTrace(2, FileName);
                            if ((matlabRlt[0] as MWNumericArray).ToScalarInteger() != 0)
                            {
                                e.Result = false;
                                lastError = matlabRlt[1].ToString();
                                return;
                            }
                            break;
                        }
                    case MatlabFig.ante:
                        {
                            MWArray[] matlabRlt = aeroChan.FigAnteGain(2, FileName);
                            if ((matlabRlt[0] as MWNumericArray).ToScalarInteger() != 0)
                            {
                                e.Result = false;
                                lastError = matlabRlt[1].ToString();
                                return;
                            }
                            break;
                        }
                }
            }
            catch
            {
                e.Result = false;
                lastError = "调用Matlab失败！";
            }
        }

        public void bgwMatlabFig_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            waitBox.Hide();

            if ((bool)e.Result == false)
                MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            lblStatus.Text = "Ready";
        }

        public void bgwMatlabGen_DoWork(object sender, DoWorkEventArgs e)
        {
            ArrayList lit = e.Argument as ArrayList;
            e.Result = true;

            try
            {

                            MWNumericArray fc_Hz         = (double)lit[0],
                                           chanUpdate_ms = (double)lit[1],
                                           angSpread_deg = (double)lit[2],
                                           chanMod       = (double)lit[3];
                            MWCharArray traFilePath      = lit[4] as string,
                                        launAnteFilePath = lit[5] as string,
                                        chanSavePath     = lit[6] as string;

                            MWArray[] matlabRlt = aeroChan.AeroChanGenerate(2, fc_Hz, chanUpdate_ms, angSpread_deg, chanMod, traFilePath, launAnteFilePath, chanSavePath);
                            if ((matlabRlt[0] as MWNumericArray).ToScalarInteger() != 0)
                            {
                                e.Result = false;
                                lastError = matlabRlt[1].ToString();
                                return;
                            }
            }
            catch(Exception ex)
            {
                e.Result = false;
                lastError = "调用Matlab失败！";
            }
        }

        public void bgwMatlabGen_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            waitBox.Hide();

            if ((bool)e.Result == true)
            {
                //if (tabChan.SelectedTab.Name == pageAeroChan.Name)
                    AeroTabPlayEnable();
            }
            else
                MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            lblStatus.Text = "Ready";
        }

        public void bgwDmaTransfer_DoWork(object sender, DoWorkEventArgs e)
        {
            FileStream fs = null;
            BinaryReader br = null;
            e.Result = true;

            try
            {
                byte[] buf;
                long bufSizeMax,lenTotal,lenCompleted;
                uint bufCount, lenExtra, alignByte = 0x400;
                int progMin, progMax, progStep, progNext, progNow, 
                    dmaCompleted,dmaTime;
                double dmaSpeed;
                Stopwatch swDmaTime = new Stopwatch();

                string dmaFilePath = e.Argument as string;
                bufSizeMax = PcieDriver.MAX_BUF_SIZE;
                transferBox.GetProgInfo(out progMin, out progMax, out progStep);
                progNext = progMin + progStep;

                fs = new FileStream(dmaFilePath, FileMode.Open, FileAccess.Read);
                br = new BinaryReader(fs);

                bufCount = (uint)(fs.Length / bufSizeMax);
                lenExtra = (uint)(fs.Length % bufSizeMax);
                if ((lenExtra & (alignByte - 1)) != 0)
                    lenExtra = (lenExtra & ~(alignByte - 1)) + alignByte;
                lenTotal = bufCount * bufSizeMax + lenExtra;

                if (bufCount > 0)
                {
                    for (uint ii = 0; ii < bufCount; ii++)
                    {
                        swDmaTime.Restart();

                        buf = new byte[bufSizeMax];
                        buf = br.ReadBytes(buf.Length);

                        if (PcieDriver.DmaToDevice(buf) == false)
                        {
                            e.Result = false;
                            lastError = PcieDriver.GetLastDeviceError();
                            return;
                        }

                        lenCompleted = (ii + 1) * buf.Length;
                        progNow = (int)(Convert.ToDouble(lenCompleted) / lenTotal * (progMax - progMin) + progMin);
                        if (progNow >= progNext)
                        {
                            swDmaTime.Stop();

                            dmaCompleted = progNow;
                            progNext = progNow + progStep;
                            dmaSpeed = buf.Length / swDmaTime.Elapsed.TotalSeconds;
                            dmaTime = (int)((lenTotal - lenCompleted) / dmaSpeed);
                            dmaSpeed = Math.Round(dmaSpeed / 1024 / 1024, 2);
                            transferBox.BeginInvoke(new Action(() =>
                                transferBox.ShowProg(dmaTime, dmaSpeed, dmaCompleted)));
                        }
                    }
                }

                if (lenExtra > 0)
                {
                    swDmaTime.Restart();

                    buf = new byte[lenExtra];
                    br.ReadBytes((int)lenExtra).CopyTo(buf, 0);

                    if (PcieDriver.DmaToDevice(buf) == false)
                    {
                        e.Result = false;
                        lastError = PcieDriver.GetLastDeviceError();
                        return;
                    }

                    swDmaTime.Stop();

                    dmaTime = 0;
                    dmaCompleted = progMax;
                    dmaSpeed = buf.Length / 1024.0 / 1024.0 / swDmaTime.Elapsed.TotalSeconds;
                    dmaSpeed = Math.Round(dmaSpeed, 2);
                    transferBox.BeginInvoke(new Action(() =>
                        transferBox.ShowProg(dmaTime, dmaSpeed, dmaCompleted)));
                }
            }
            catch
            {
                e.Result = false;
                lastError = "配置硬件失败！";
            }
            finally
            {
                if (br != null)
                    br.Close();
                if (fs != null)
                    fs.Close();
            }
        }

        public void bgwDmaTransfer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            transferBox.Hide();

            if ((bool)e.Result == false)
                MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            lblStatus.Text = "Ready";
        }
        #endregion

        #region 任意波
        private void cboxSignalType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (startFlag == 0)
                return;

            if (cboxSignalType.Text == "单音")
            {
                if (!SetPcieReg(PcieReg.SignalType, 1, out lastError))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                decimal fre = 1000000;
                UInt32 data;
                fre = fre  / 250000000 * (decimal)Math.Pow(2, 32);
                data = (UInt32)Math.Floor(fre);
                if (!SetPcieReg(PcieReg.Frequency, data, out lastError))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                return;
            }
            else if (cboxSignalType.Text == "双音")
            {
                
                if (!SetPcieReg(PcieReg.SignalType, 2, out lastError))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                decimal fre = 1000000;
                UInt32 data;
                fre = fre  / 250000000 * (decimal)Math.Pow(2, 32);
                data = (UInt32)Math.Floor(fre);
                if (!SetPcieReg(PcieReg.Frequency, data, out lastError))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                return;
            }
            else if (cboxSignalType.Text == "脉冲")
            {
               
                if (!SetPcieReg(PcieReg.SignalType, 3, out lastError))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                decimal fre = 1000000;
                UInt32 data;
                fre = fre / 250000000 * (decimal)Math.Pow(2, 32);
                data = (UInt32)Math.Floor(fre);
                if (!SetPcieReg(PcieReg.Frequency, data, out lastError))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                decimal dutyCycle = 250000000 / fre / 100 * 1;
                data = (UInt32)Math.Floor(dutyCycle);
                if (!SetPcieReg(PcieReg.DutyCycle, data, out lastError))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                return;
            }
            else if (cboxSignalType.Text == "QPSK")
            {
                if (!SetPcieReg(PcieReg.SignalType, 4, out lastError))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                decimal rate = 1000000;
                UInt32 data;
                rate = ((decimal)Math.Pow(2, 32) / 250000000 * 4) * rate;
                data = (UInt32)Math.Round(rate);
                if (!SetPcieReg(PcieReg.DecimalInter, data, out lastError))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                if (!SetPcieReg(PcieReg.SymbolNum, 2, out lastError))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!SetPcieReg(PcieReg.DataSource, 6, out lastError))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //配置滤波类型
                if (!SetPcieReg(PcieReg.FilterType, 0, out lastError))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //配置滤波器倍数
                if (!SetPcieReg(PcieReg.FilterTimes, 3, out lastError))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                return;
            }
            else if (cboxSignalType.Text == "16QAM")
            {
                
                if (!SetPcieReg(PcieReg.SignalType, 4, out lastError))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                decimal rate = 1000000;
                UInt32 data;
                rate = ((decimal)Math.Pow(2, 32) / 250000000 * 4) * rate;
                data = (UInt32)Math.Round(rate);
                if (!SetPcieReg(PcieReg.DecimalInter, data, out lastError))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!SetPcieReg(PcieReg.SymbolNum, 4, out lastError))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!SetPcieReg(PcieReg.DataSource, 6, out lastError))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //配置滤波类型
                if (!SetPcieReg(PcieReg.FilterType, 0, out lastError))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //配置滤波器倍数
                if (!SetPcieReg(PcieReg.FilterTimes, 3, out lastError))
                {
                    MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                return;
            }
        }

        private void 查看帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            waveTool = new WaveTool(this);
            waveTool.ShowDialog(this);
        }

        private void txtAeroSNR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                waveCon.SetSNR(txtAeroSNR);
            }
        }

     
        #endregion

        

    }
}
