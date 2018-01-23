using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;
using MathWorks.MATLAB.NET.Utility;
using MathWorks.MATLAB.NET.Arrays;
using GeneChanFun;
using System.Collections;
using System.Xml;
using System.Text.RegularExpressions;
using System.Diagnostics;
//using pcieDriverHelper;
using System.IO;


namespace ChanSimSource
{
    public partial class StaticFading : Form
    {
        private Form1 mainPage;

        WaitBox waitBox = new WaitBox();
        RiceBox riceBox = new RiceBox();
        DooplerBox dopplerBox = new DooplerBox();

        public enum InputMod { Int, UInt, Float, UFloat };
        private enum ChanPara
        {
            RiceK,RiceAOA, DopplerFre, CluDelay, CluLoss, MaxDoppler,
            PhaseShift, Shadow, DecorLen, Loss
        };
        //private enum PcieReg
        //{
        //    IsRun = 0x100,
        //    AddNoise = 0x104,
        //    SNR = 0x108,
        //    DMASize = 0x10c
        //}

        private GeneChan geneChan;
        private DataGridView dgvTmp;

        private List<Dictionary<string, double>> geneFad = new List<Dictionary<string, double>>();

        string lastError;
        //private string defaultSavName = "GenePara.xml";
        private string strDefaultPath = System.AppDomain.CurrentDomain.BaseDirectory;
        private string strChanFilePath ;

        #region 理论参数极限
        private const int maxGeneCluNum = 6;
        private const double minGeneShadow = 0;            // hu 单位:dB
        private const double maxGeneShadow = 12;           // hu 单位:dB
        //private const double minGenePS = 0;                // hu 单位:deg
        //private const double maxGenePS = 360;              // hu 单位:deg
        private const double minGeneDecorLen = 1;          // hu 单位:m
        private const double maxGeneDecorLen = 400;        // hu 单位:m
        private const double maxGeneCluGain = 0;           // hu 单位:dB
        private const double minCluDelay = 0;              // hu 单位:ms
        private const double maxCluDelay = 10;             // hu 单位:ms
        private const double minGeneMaxDoppler = 0;        // hu 单位:Hz
        private const double maxGeneMaxDoppler = 2400;     // hu 单位:Hz
        private const double minGeneDopplerFre = 0;        // hu 单位:Hz
        private const double minGeneGain = 0;              // hu 单位:dB
        private const double maxGeneGain = 60;             // hu 单位:dB
        #endregion


        public StaticFading()
        {
            InitializeComponent();
        }

        public StaticFading(Form1 mpage)
        {
            InitializeComponent();
            mainPage = mpage;
        }

        public void SetMainPage(Form1 mpage)
        {
            mainPage = mpage;
        }

        public void SetPara(Form1 mpage, GeneChan gchan)
        {
            mainPage = mpage;
            geneChan = gchan;
        }
        public string GetStrFilePath()
        {
            return strChanFilePath;
        }

        private void StaticFading_Load(object sender, EventArgs e)
        {
            dgvGeneChan.RowCount = maxGeneCluNum;;

            strChanFilePath = strDefaultPath + "Output\\GeneChanData.gch";
            // hu 载入配置文件
           // LoadGeneCfg(strDefaultPath + defaultSavName);
        }

        //#region Matlab初始化
        ///// <summary>
        ///// 给Form1调用的Matlab初始化
        ///// </summary>
        //public void CustomInitMatlab()
        //{
        //    //Matlab初始化
        //    LoadGeneCfg(strDefaultPath + defaultSavName);
        //    bgwMatlabInit.RunWorkerAsync(); 
            
        //}
        
        //private void bgwMatlabInit_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    e.Result = true;
        //    try
        //    {
        //        geneChan = new GeneChan();
        //    }
        //    catch
        //    {
        //        e.Result = false;
        //        lastError = "初始化Matlab运行环境失败！";
        //    }
        //}

        //private void bgwMatlabInit_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    if ((bool)e.Result == false)
        //        MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    mainPage.lalState.Text = "Ready";
        //}
        //#endregion

        #region 特定功能
        /// <summary>
        /// 输入限制
        /// </summary>
        static public void InputLimit(TextBox textBox, KeyPressEventArgs e, InputMod inputMod)
        {
            string strStart, strEnd;

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
                default: e.Handled = true; break;
            }
        }

        private string ParaLimitError(ChanPara chanPara)
        {
            switch (chanPara)
            {
                case ChanPara.DopplerFre:
                    return "输入值应大于等于" + minGeneDopplerFre.ToString();
                case ChanPara.CluDelay:
                    return "输入值应在" + minCluDelay.ToString() + "～" + maxCluDelay.ToString() + "之间";
                case ChanPara.CluLoss:
                    return "输入值应小于等于" + maxGeneCluGain.ToString();
                case ChanPara.MaxDoppler:
                    return "输入值应在" + minGeneMaxDoppler.ToString() + "～" + maxGeneMaxDoppler.ToString() + "之间";
                //case ChanPara.PhaseShift:
                //    return "输入值应在" + minGenePS.ToString() + "～" + maxGenePS.ToString() + "之间";
                case ChanPara.Shadow:
                    return "输入值应在" + minGeneShadow.ToString() + "～" + maxGeneShadow.ToString() + "之间";
                case ChanPara.DecorLen:
                    return "输入值应在" + minGeneDecorLen.ToString() + "～" + maxGeneDecorLen.ToString() + "之间";
                case ChanPara.Loss:
                    return "输入值应在" + minGeneGain.ToString() + "～" + maxGeneGain.ToString() + "之间";
                default: return "";
            }
        }

        private bool ParaLimitEst(double para, ChanPara chanPara)
        {
            switch (chanPara)
            {
                case ChanPara.CluDelay:
                    {
                        if (para < minCluDelay || para > maxCluDelay)
                            return false;
                        break;
                    }
                case ChanPara.CluLoss:
                    {
                        if (para > maxGeneCluGain)
                            return false;
                        break;
                    }
                case ChanPara.MaxDoppler:
                    {
                        if (para <= minGeneMaxDoppler || para > maxGeneMaxDoppler)
                            return false;
                        break;
                    }
                //case ChanPara.PhaseShift:
                //    {
                //        if (para < minGenePS || para >= maxGenePS)
                //            return false;
                //        break;
                //    }
                case ChanPara.Shadow:
                    {
                        if (para < minGeneShadow || para > maxGeneShadow)
                            return false;
                        break;
                    }
                case ChanPara.DecorLen:
                    {
                        if (para < minGeneDecorLen || para > maxGeneDecorLen)
                            return false;
                        break;
                    }
                case ChanPara.Loss:
                    {
                        if (para < minGeneGain || para > maxGeneGain)
                            return false;
                        break;
                    }
                default: return false;
            }

            return true;
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
            int maxLen = 0, len;
            strOut = new string[strTitle.Length];

            if (strTitle.Length != strData.Length)
                return false;

            foreach (string str in strTitle)
            {
                len = Encoding.Default.GetBytes(str).Length;
                if (maxLen < len)
                    maxLen = len;
            }

            for (int ii = 0; ii < strTitle.Length; ii++)
            {
                strOut[ii] = AddSpace(strTitle[ii], maxLen) + "\t" + strData[ii];
            }
            return true;
        }

        /// <summary>
        /// 在气泡中显示多径衰落参数
        /// </summary>
        private bool GeneFadShow(DataGridViewCell dgvc, Dictionary<string, double> fad)
        {
            string name, unit, strData;
            string[] title, data;

            if (!fad.ContainsKey(dgvc.EditedFormattedValue.ToString()))
                return false;

            if (dgvc.EditedFormattedValue.ToString() == "纯多普勒")
            {
                title = new string[1];
                data = new string[1];

                dopplerBox.GetDoppler(out name, out unit);
                if (!fad.ContainsKey(name))
                    return false;

                title[0] = name + ":";
                data[0] = fad[name].ToString() + unit;
            }
            else if (dgvc.EditedFormattedValue.ToString() == "莱斯衰落")
            {
                title = new string[2];
                data = new string[2];

                riceBox.GetRiceK(out name, out unit);
                if (!fad.ContainsKey(name))
                    return false;

                title[0] = name + ":";
                data[0] = fad[name].ToString() + unit;

                riceBox.GetRiceAOA(out name, out unit);
                if (!fad.ContainsKey(name))
                    return false;

                title[1] = name + ":";
                data[1] = fad[name].ToString() + unit;
            }
            else if (dgvc.EditedFormattedValue.ToString() == "瑞利衰落")
            {
                title = new string[0];
                data = new string[0];
            }
            else
                return false;

            strData = dgvc.EditedFormattedValue.ToString();
            if (!TabString(title, data, out data))
                return false;
            foreach (string str in data)
            {
                strData += "\n" + str;
            }
            dgvc.ToolTipText = strData;

            return true;
        }
        #endregion

        #region 功能按键
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        #endregion

        #region 调用Matlab参数文件
        private void btnDetermine_Click(object sender, EventArgs e)
        {
            ArrayList lit = new ArrayList();
            double dbl;
            double[] dblPathDelay = new double[6];
            uint[] uintPathDelay = new uint[6];
            List<double[]> dblList = new List<double[]>();


            if (chkGeneShadow.Checked)
            {
                if (errorShow.GetError(txtGeneShadow) != "" ||
                    errorShow.GetError(txtGeneDecorLen) != "")
                {
                    MessageBox.Show("配置参数错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            for (int ii = 0; ii < dgvGeneChan.RowCount; ii++)
            {
                if (dgvGeneChan["colGeneLoss", ii].ErrorText != "" ||
                    dgvGeneChan["colGeneFdMax", ii].ErrorText != "" ||
                    dgvGeneChan["colGeneFdOffset", ii].ErrorText != "")
                {
                    MessageBox.Show("配置参数错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            
            if (chkGeneShadow.Checked)
            {
                dbl = 1;
                lit.Add(dbl); //lognMod -- 是否有阴影衰落

                if (!double.TryParse(txtGeneShadow.Text, out dbl))
                {
                    MessageBox.Show("配置参数错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                lit.Add(dbl); //lognSigma_dB -- 阴影衰落标准差

                if (!double.TryParse(txtGeneDecorLen.Text, out dbl))
                {
                    MessageBox.Show("配置参数错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                lit.Add(dbl); //lognCorrDist_m -- 阴影衰落解相关长度
            }
            else
            {
                dbl = 0;
                lit.Add(dbl);//lognMod -- 是否有阴影衰落
                lit.Add(dbl);//lognSigma_dB -- 阴影衰落标准差
                lit.Add(dbl);//lognCorrDist_m -- 阴影衰落解相关长度
            }

            
            for (int ii = 0; ii < 8; ii++)
            {
                dblList.Add(new double[dgvGeneChan.RowCount]);
            }

            for (int ii = 0; ii < dgvGeneChan.RowCount; ii++)
            {
                if (!double.TryParse(dgvGeneChan["colGeneLoss", ii].FormattedValue.ToString(), out dblList[0][ii]))
                {
                    MessageBox.Show("配置参数错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!double.TryParse(dgvGeneChan["colGeneDelay", ii].FormattedValue.ToString(), out dblPathDelay[ii]))
                {
                    MessageBox.Show("配置参数错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                uintPathDelay[ii] = (uint)(dblPathDelay[ii]*1000);

                if (!double.TryParse(dgvGeneChan["colGeneFdMax", ii].FormattedValue.ToString(), out dblList[1][ii]))
                {
                    MessageBox.Show("配置参数错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!double.TryParse(dgvGeneChan["colGeneFdOffset", ii].FormattedValue.ToString(), out dblList[2][ii]))
                {
                    MessageBox.Show("配置参数错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                switch (dgvGeneChan["colGeneDoppler", ii].FormattedValue.ToString())
                {
                    case "经典3dB": dblList[3][ii] = 0; break;
                    case "经典6dB": dblList[3][ii] = 1; break;
                    case "平坦": dblList[3][ii] = 2; break;
                    case "圆形": dblList[3][ii] = 3; break;
                    case "Jakes经典": dblList[3][ii] = 4; break;
                    case "Jakes圆形": dblList[3][ii] = 5; break;
                    case "高斯": dblList[3][ii] = 6; break;
                    case "高斯I": dblList[3][ii] = 7; break;
                    case "高斯II": dblList[3][ii] = 8; break;
                    default:
                        {
                            MessageBox.Show("配置参数错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                }

                switch (dgvGeneChan["colGeneFad", ii].FormattedValue.ToString())
                {
                    case "瑞利衰落": dblList[4][ii] = 0; break;
                    case "莱斯衰落": dblList[4][ii] = 1; break;
                    case "纯多普勒": dblList[4][ii] = 2; break;
                    default:
                        {
                            MessageBox.Show("配置参数错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                }

                if (!geneFad[ii].ContainsKey(dgvGeneChan["colGeneFad", ii].FormattedValue.ToString()))
                {
                    MessageBox.Show("配置参数错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (geneFad[ii].ContainsKey("纯多普勒"))
                {
                    if (!geneFad[ii].ContainsKey(dopplerBox.GetDoppler()))
                    {
                        MessageBox.Show("配置参数错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    dblList[5][ii] = geneFad[ii][dopplerBox.GetDoppler()];
                    dblList[6][ii] = 0;
                    dblList[7][ii] = 0;
                }
                else if (geneFad[ii].ContainsKey("莱斯衰落"))
                {
                    if (!geneFad[ii].ContainsKey(riceBox.GetRiceK()) || !geneFad[ii].ContainsKey(riceBox.GetRiceAOA()))
                    {
                        MessageBox.Show("配置参数错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    dblList[5][ii] = 0;
                    dblList[6][ii] = geneFad[ii][riceBox.GetRiceAOA()];
                    dblList[7][ii] = geneFad[ii][riceBox.GetRiceK()];
                }
                else
                {
                    dblList[5][ii] = 0;
                    dblList[6][ii] = 0;
                    dblList[7][ii] = 0;
                }
            }

            foreach (double[] dblArr in dblList)
            {
                lit.Add(dblArr);
            }

            strChanFilePath = strDefaultPath + "Output\\GeneChanData.gch";  //GetOutputPath(mod);

            lit.Add(strChanFilePath);

            if (bgwMatlabInit.IsBusy == true)
            {
                MessageBox.Show("正在初始化Matlab，请稍后再试！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bgwMatlabGen.RunWorkerAsync(lit);


            if (!mainPage.SetPcieReg(Form1.PcieReg.FirstDelay, uintPathDelay[0], out lastError))
            {
                MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!mainPage.SetPcieReg(Form1.PcieReg.SecondDelay, uintPathDelay[1], out lastError))
            {
                MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!mainPage.SetPcieReg(Form1.PcieReg.ThirdDelay, uintPathDelay[2], out lastError))
            {
                MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!mainPage.SetPcieReg(Form1.PcieReg.FourthDelay, uintPathDelay[3], out lastError))
            {
                MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!mainPage.SetPcieReg(Form1.PcieReg.FifthDelay, uintPathDelay[4], out lastError))
            {
                MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!mainPage.SetPcieReg(Form1.PcieReg.SixthDelay, uintPathDelay[5], out lastError))
            {
                MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            waitBox.SetInformation("正在计算信道衰落参数...");
            this.DialogResult = DialogResult.OK;
            waitBox.ShowDialog(this);

        }

        private void bgwMatlabGen_DoWork(object sender, DoWorkEventArgs e)
        {
            ArrayList lit = e.Argument as ArrayList;
            e.Result = true;
            try
            {
                MWNumericArray lognMod = (double)lit[0],
                lognSigma_dB           = (double)lit[1],
                lognCorrDist_m         = (double)lit[2],
                relaLoss_dB            = (double[])lit[3],
                fdMax_Hz               = (double[])lit[4],
                fdOffset_Hz            = (double[])lit[5],
                dopplerMod             = (double[])lit[6],
                fadMod                 = (double[])lit[7],
                fd_Hz                  = (double[])lit[8],
                riceAOA_deg            = (double[])lit[9],
                riceK_dB               = (double[])lit[10];

                MWCharArray chanSavePath = lit[11] as string;

                MWArray[] matlabRlt = geneChan.GeneChanGenerate(2, lognMod, lognSigma_dB, lognCorrDist_m, relaLoss_dB, fdMax_Hz, fdOffset_Hz, dopplerMod, fadMod, fd_Hz, riceAOA_deg, riceK_dB, chanSavePath);
                if ((matlabRlt[0] as MWNumericArray).ToScalarInteger() != 0)
                {
                    e.Result = false;
                    lastError = matlabRlt[1].ToString();
                    return;
                }
            }
            catch (Exception ex)
            {
                e.Result = false;
                lastError = "调用Matlab失败！";
            }
        }

        private void bgwMatlabGen_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            waitBox.Hide();

            if ((bool)e.Result == true)
            {
                
                this.Hide();
            }
            else
                MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion

        #region 表格参数操作
        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int addRowsNum, rowStart;
            int[] rowsIdx = new int[dgvGeneChan.SelectedRows.Count];

            rowStart = dgvGeneChan.Rows.Count;
            for (int ii = 0; ii < dgvGeneChan.SelectedRows.Count; ii++)
                rowsIdx[ii] = dgvGeneChan.SelectedRows[ii].Index;
            Array.Sort(rowsIdx);

            if (dgvGeneChan.RowCount + dgvGeneChan.SelectedRows.Count > maxGeneCluNum)
                addRowsNum = maxGeneCluNum - dgvGeneChan.RowCount;
            else
                addRowsNum = dgvGeneChan.SelectedRows.Count;

            dgvGeneChan.RowCount += addRowsNum;

            for (int ii = 0; ii < addRowsNum; ii++)
            {
               // geneFad[rowStart + ii] = geneFad[rowsIdx[ii]];
                dgvGeneChan["colGeneFad", rowStart + ii].ToolTipText = dgvGeneChan["colGeneFad", rowsIdx[ii]].ToolTipText;

                for (int jj = 0; jj < dgvGeneChan.ColumnCount; jj++)
                    dgvGeneChan[jj, rowStart + ii].Value = dgvGeneChan[jj, rowsIdx[ii]].EditedFormattedValue.ToString();
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] rowsIdx = new int[dgvGeneChan.SelectedRows.Count];
            int leaveRow = 0;
            for (int ii = 0; ii < dgvGeneChan.SelectedRows.Count; ii++)
                rowsIdx[ii] = dgvGeneChan.SelectedRows[ii].Index;
            Array.Sort(rowsIdx);

            if (rowsIdx.Length == dgvGeneChan.RowCount)
                leaveRow = 1;

            for (int ii = rowsIdx.Length - 1; ii >= leaveRow; ii--)
            {
                dgvGeneChan.Rows.RemoveAt(rowsIdx[ii]);
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog savFilDia = new SaveFileDialog();
            savFilDia.Filter = "xml files(*.xml)|*.xml";
            savFilDia.FilterIndex = 1;          // hu 设置默认文件类型显示顺序
            savFilDia.InitialDirectory = strDefaultPath;
            savFilDia.RestoreDirectory = true;  // hu 保存对话框是否记忆上次打开的目录
            if (savFilDia.ShowDialog() == DialogResult.OK)
            {
                dgvTmp = dgvGeneChan;
               
                if (!SaveChanParaTabXml(savFilDia.FileName, dgvTmp))
                    MessageBox.Show("保存信道参数表格文件失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }
        }

        private void 载入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opeFilDia = new OpenFileDialog();
            opeFilDia.Filter = "xml files(*.xml)|*.xml";
            opeFilDia.FilterIndex = 1;
            opeFilDia.InitialDirectory = strDefaultPath;
            opeFilDia.RestoreDirectory = true;
            if (opeFilDia.ShowDialog() == DialogResult.OK)
            {
                dgvTmp= dgvGeneChan;

                if (!LoadChanParaTabXml(opeFilDia.FileName, dgvTmp))
                    MessageBox.Show("载入信道参数表格文件失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        #endregion 

        #region 保存载入配置操作
        /// <summary>
        /// 保存通用信道配置
        /// </summary>
        private void SaveGeneCfg(string strXmlPath,DataGridView dgv)
        {
            try
            {
                XmlElement rootEle, xmlEle1, xmlEle2;

                if (dgv.Name != dgvGeneChan.Name)
                    return ;

                XmlDocument xmlDoc = new XmlDocument();
                XmlDeclaration dec = xmlDoc.CreateXmlDeclaration("1.0", "gb2312", null);
                xmlDoc.AppendChild(dec);

                // <静态衰落> ... </静态衰落>
                rootEle = xmlDoc.CreateElement("静态衰落");//创建节点
                xmlDoc.AppendChild(rootEle);
                ////<路径损耗 value="10" unit="dB"/>
                //xmlEle1 = xmlDoc.CreateElement(lalGenePathLoss.Text);
                //xmlEle1.SetAttribute("value", txtGenePathLoss.Text);
                //xmlEle1.SetAttribute("unit", lalGenePathLossUnit.Text);
                //rootEle.AppendChild(xmlEle1);
                //<相移 value="20" unit="deg"/>
                //xmlEle1 = xmlDoc.CreateElement(lalGenePS.Text);
                //xmlEle1.SetAttribute("value", txtGenePS.Text);
                //xmlEle1.SetAttribute("unit", lalGenePSUnit.Text);
                //rootEle.AppendChild(xmlEle1);
                //<阴影衰落 value="True">...</阴影衰落>
                xmlEle1 = xmlDoc.CreateElement("阴影衰落");
                xmlEle1.SetAttribute("value", chkGeneShadow.Checked.ToString());
                rootEle.AppendChild(xmlEle1);
                //<标准差 value="5" unit="dB"/>                
                xmlEle2 = xmlDoc.CreateElement("标准差");
                xmlEle2.SetAttribute("value", txtGeneShadow.Text);
                xmlEle2.SetAttribute("unit", lalGeneShadowUnit.Text);
                xmlEle1.AppendChild(xmlEle2);
                //<解相关长度 value="10" unit="m"/>
                xmlEle2 = xmlDoc.CreateElement("解相关长度");
                xmlEle2.SetAttribute("value", txtGeneDecorLen.Text);
                xmlEle2.SetAttribute("unit", lalGeneDecorLenUnit.Text);
                xmlEle1.AppendChild(xmlEle2);

                SaveChanParaTab(xmlDoc, ref rootEle, dgvGeneChan);

                //<预定义信道模型 value="False">...</预定义信道模型>
                xmlEle1 = xmlDoc.CreateElement("预定义信道");
                xmlEle1.SetAttribute("value", chkGeneChanMod.Checked.ToString());
                rootEle.AppendChild(xmlEle1);
                //<COST207远郊典型 value="False"/>
                xmlEle2 = xmlDoc.CreateElement(rdoGeneOutskirts.Text + lalGeneOutskirts.Text);
                xmlEle2.SetAttribute("value", rdoGeneOutskirts.Checked.ToString());
                xmlEle1.AppendChild(xmlEle2);
                //<COST207恶劣 value="False"/>
                xmlEle2 = xmlDoc.CreateElement(rdoGeneBad.Text + lalGeneBad.Text);
                xmlEle2.SetAttribute("value", rdoGeneBad.Checked.ToString());
                xmlEle1.AppendChild(xmlEle2);
                //<COST207丘陵地区 value="True"/>
                xmlEle2 = xmlDoc.CreateElement(rdoGeneHill.Text + lalGeneHill.Text);
                xmlEle2.SetAttribute("value", rdoGeneHill.Checked.ToString());
                xmlEle1.AppendChild(xmlEle2);
                //<COST259 value="False"/>
                xmlEle2 = xmlDoc.CreateElement(rdoCost259.Text);
                xmlEle2.SetAttribute("value", rdoCost259.Checked.ToString());
                xmlEle1.AppendChild(xmlEle2);
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// 载入通用信道配置
        /// </summary>
        private bool LoadGeneCfg(string strXmlPath)//(XmlDocument xmlDoc)            
        {
            bool isSucceed = true;
            XmlNode node;
            string nodePath = "/静态衰落/" + "/";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(strXmlPath);

            ////路径损耗
            //node = xmlDoc.SelectSingleNode(nodePath + lalGenePathLoss.Text);
            //if (node != null)
            //    txtGenePathLoss.Text = node.Attributes["value"].Value;
            //else
            //    isSucceed = false;
            //相位
            //node = xmlDoc.SelectSingleNode(nodePath + lalGenePS.Text);
            //if (node != null)
            //    txtGenePS.Text = node.Attributes["value"].Value;
            //else
            //    isSucceed = false;
            //阴影衰落
            node = xmlDoc.SelectSingleNode(nodePath + "阴影衰落");
            if (node != null)
                chkGeneShadow.Checked = bool.Parse(node.Attributes["value"].Value);
            else
                isSucceed = false;

            node = xmlDoc.SelectSingleNode(nodePath + "阴影衰落" + "/" + "标准差");
            if (node != null)
                txtGeneShadow.Text = node.Attributes["value"].Value;
            else
                isSucceed = false;

            node = xmlDoc.SelectSingleNode(nodePath + "阴影衰落" + "/" + "解相关长度");
            if (node != null)
                txtGeneDecorLen.Text = node.Attributes["value"].Value;
            else
                isSucceed = false;

            if (!LoadChanParaTab(xmlDoc, dgvGeneChan))
                isSucceed = false;

            node = xmlDoc.SelectSingleNode(nodePath + "预定义信道");
            if (node != null)
                chkGeneChanMod.Checked = bool.Parse(node.Attributes["value"].Value);
            else
                isSucceed = false;

            node = xmlDoc.SelectSingleNode(nodePath + "预定义信道" + "/" + rdoGeneOutskirts.Text + lalGeneOutskirts.Text);
            if (node != null)
                rdoGeneOutskirts.Checked = bool.Parse(node.Attributes["value"].Value);
            else
                isSucceed = false;

            node = xmlDoc.SelectSingleNode(nodePath + "预定义信道" + "/" + rdoGeneBad.Text + lalGeneBad.Text);
            if (node != null)
                rdoGeneBad.Checked = bool.Parse(node.Attributes["value"].Value);
            else
                isSucceed = false;

            node = xmlDoc.SelectSingleNode(nodePath + "预定义信道" + "/" + rdoGeneHill.Text + lalGeneHill.Text);
            if (node != null)
                rdoGeneHill.Checked = bool.Parse(node.Attributes["value"].Value);
            else
                isSucceed = false;

            node = xmlDoc.SelectSingleNode(nodePath + "预定义信道" + "/" + rdoCost259.Text);
            if (node != null)
                rdoCost259.Checked = bool.Parse(node.Attributes["value"].Value);
            else
                isSucceed = false;

            return isSucceed;
        }

        /// <summary>
        /// 保存信道参数表格
        /// </summary>
        private void SaveChanParaTab(XmlDocument xmlDoc, ref XmlElement rootEle, DataGridView dgv)
        {
            XmlElement xmlEle1, xmlEle2, xmlEle3;
            Match mchTitle, mchData;
            string[] strFad;

            //<表格参数 rowCount="5" colCount="6">...</表格参数>
            xmlEle1 = xmlDoc.CreateElement("表格参数");
            xmlEle1.SetAttribute("rowCount", dgv.RowCount.ToString());
            xmlEle1.SetAttribute("colCount", dgv.ColumnCount.ToString());
            rootEle.AppendChild(xmlEle1);

            for (int ii = 0; ii < dgv.RowCount; ii++)
            {
                //<衰落路径1 路径延迟="0.0002ms" 相对损耗="-2dB" 衰落类型="瑞利衰落" 频谱形状="经典3dB" 多普勒频率="1Hz" 多普勒偏移="1Hz">
                xmlEle2 = xmlDoc.CreateElement(dgv.Rows[ii].HeaderCell.Value.ToString());

                for (int jj = 0; jj < dgv.ColumnCount; jj++)
                {
                    mchTitle = Regex.Match(dgv.Columns[jj].HeaderText, @"^[\u4e00-\u9fa5]+");
                    mchData = Regex.Match(dgv.Columns[jj].HeaderText, @"[a-zA-Z]+");
                    xmlEle2.SetAttribute(mchTitle.Groups[0].Value, dgv[jj, ii].FormattedValue.ToString() + mchData.Groups[0].Value);
                }

                strFad = dgv["colGeneFad", ii].ToolTipText.Split('\n');

                xmlEle3 = xmlDoc.CreateElement(strFad[0]);

                for (int jj = 1; jj < strFad.Length; jj++)
                {
                    mchTitle = Regex.Match(strFad[jj], @"^[\u4e00-\u9fa5a-zA-Z]+");
                    mchData = Regex.Match(strFad[jj], @"[+-]?(\d+\.?\d*|\d*\.?\d+)[a-zA-Z]+$");
                    xmlEle3.SetAttribute(mchTitle.Groups[0].Value, mchData.Groups[0].Value);
                }
                xmlEle2.AppendChild(xmlEle3);
                xmlEle1.AppendChild(xmlEle2);
            }
        }

        /// <summary>
        /// 载入通用信道表格 --》待改《-- 
        /// </summary>
        private bool LoadChanParaTab(XmlDocument xmlDoc, DataGridView dgv)
        {
            int intData;
            double dblData, dblData2;
            Match mchTitle, mchData;
            XmlNode node;
            string nodePath;

            if (dgv.Name != dgvGeneChan.Name)
                return false;

            nodePath = "/静态衰落/"+ "/表格参数";

            node = xmlDoc.SelectSingleNode(nodePath);
            if (node == null)
                return false;
            if (!int.TryParse(node.Attributes["rowCount"].Value, out intData) || intData > maxGeneCluNum)
                return false;
            dgv.RowCount = intData;

            nodePath += "/";
            bool isSucceed = true;

            for (int ii = 0; ii < dgv.RowCount; ii++)
            {
                node = xmlDoc.SelectSingleNode(nodePath + dgv.Rows[ii].HeaderCell.Value.ToString());

                for (int jj = 0; jj < dgv.ColumnCount; jj++)
                {
                    mchTitle = Regex.Match(dgv.Columns[jj].HeaderText, @"^[\u4e00-\u9fa5]+");
                    mchData = Regex.Match(dgv.Columns[jj].HeaderText, @"[a-zA-Z]+");
                    if (node.Attributes[mchTitle.Groups[0].Value] != null)
                    {
                        if (mchData.Groups[0].Value == string.Empty)
                            dgv[jj, ii].Value = node.Attributes[mchTitle.Groups[0].Value].Value;
                        else
                            dgv[jj, ii].Value = node.Attributes[mchTitle.Groups[0].Value].Value.Replace(mchData.Groups[0].Value, null);
                    }
                    else
                        isSucceed = false;
                }

                if (node.FirstChild != null)
                {
                    if (node.FirstChild.Name == "瑞利衰落")
                    {
                        geneFad[ii] = new Dictionary<string, double>();
                        geneFad[ii].Add(node.FirstChild.Name, 0);

                        GeneFadShow(dgv["colGeneFad", ii], geneFad[dgv["colGeneFad", ii].RowIndex]);
                    }
                    else if (node.FirstChild.Name == "莱斯衰落")
                    {
                        if (node.FirstChild == null)
                            return false;

                        mchData = Regex.Match(node.FirstChild.Attributes[riceBox.GetRiceK()].Value, @"^[+-]?(\d+\.?\d*|\d*\.?\d+)");
                        if (!double.TryParse(mchData.Groups[0].Value, out dblData))
                            return false;
                        mchData = Regex.Match(node.FirstChild.Attributes[riceBox.GetRiceAOA()].Value, @"^[+-]?(\d+\.?\d*|\d*\.?\d+)");
                        if (!double.TryParse(mchData.Groups[0].Value, out dblData2))
                            return false;

                        riceBox.SetPara(dblData, dblData2);

                        geneFad[ii] = new Dictionary<string, double>();
                        geneFad[ii].Add(node.FirstChild.Name, 0);
                        geneFad[ii].Add(riceBox.GetRiceK(), dblData);
                        geneFad[ii].Add(riceBox.GetRiceAOA(), dblData2);

                        GeneFadShow(dgv["colGeneFad", ii], geneFad[dgv["colGeneFad", ii].RowIndex]);
                    }
                    else if (node.FirstChild.Name == "纯多普勒")
                    {
                        if (node.FirstChild == null)
                            return false;

                        mchData = Regex.Match(node.FirstChild.Attributes[dopplerBox.GetDoppler()].Value, @"^[+-]?(\d+\.?\d*|\d*\.?\d+)");
                        if (!double.TryParse(mchData.Groups[0].Value, out dblData))
                            return false;

                        dopplerBox.SetDoppler(dblData);

                        geneFad[ii] = new Dictionary<string, double>();
                        geneFad[ii].Add(node.FirstChild.Name, 0);
                        geneFad[ii].Add(dopplerBox.GetDoppler(), dblData);

                        GeneFadShow(dgv["colGeneFad", ii], geneFad[dgv["colGeneFad", ii].RowIndex]);
                    }
                }
                else
                    isSucceed = false;
            }
            return isSucceed;
        }

        /// <summary>
        /// 保存通用信道表格文件
        /// </summary>
        private bool SaveChanParaTabXml(string strXmlPath, DataGridView dgv)
        {
            try
            {
                XmlElement xmlEle1;

                if (dgv.Name != dgvGeneChan.Name)
                    return false;

                XmlDocument xmlDoc = new XmlDocument();
                XmlDeclaration xmlDecl = xmlDoc.CreateXmlDeclaration("1.0", "gb2312", null);
                xmlDoc.AppendChild(xmlDecl);

                xmlEle1 = xmlDoc.CreateElement("静态衰落");
                xmlDoc.AppendChild(xmlEle1);

                SaveChanParaTab(xmlDoc, ref xmlEle1, dgv);

                xmlDoc.Save(strXmlPath);
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// 载入通用信道表格文件
        /// </summary>
        private bool LoadChanParaTabXml(string strXmlPath, DataGridView dgv)
        {
        //    try
        //    {
                if (dgv.Name != dgvGeneChan.Name)
                    return false;

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(strXmlPath);

                if (!LoadChanParaTab(xmlDoc, dgv))
                    return false;

                return true;
            //}
            //catch { return false; }
        }
        #endregion

        #region 表格编辑控件相关
        private void dgvTab_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            dgvTmp = sender as DataGridView;
            if ("colGeneFad" == dgvTmp.Columns[dgvTmp.CurrentCell.ColumnIndex].Name)
            {
                ComboBox cbo = e.Control as ComboBox;
                cbo.SelectedIndexChanged += new EventHandler(ComboBoxEditingControl_SelectedIndexChanged);
                cbo.VisibleChanged += new EventHandler(ComboBoxEditingControl_VisibleChanged);
            }
            else if (e.Control is DataGridViewTextBoxEditingControl)
            {
                TextBox txt = e.Control as TextBox;
                txt.VisibleChanged += new EventHandler(TextBoxEditingControl_VisibleChanged);
                txt.KeyPress += new KeyPressEventHandler(TextBoxEditingControl_KeyPress);
            }
        }

        private void ComboBoxEditingControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvTmp.Name == dgvGeneChan.Name)
            {
                ComboBox cbo = sender as ComboBox;
                double dbl, dbl2;

                if (cbo.Text == "莱斯衰落")
                {
                    if (geneFad[dgvTmp.CurrentCell.RowIndex].ContainsKey("莱斯衰落"))
                    {
                        if (!geneFad[dgvTmp.CurrentCell.RowIndex].ContainsKey(riceBox.GetRiceK()) ||
                            !geneFad[dgvTmp.CurrentCell.RowIndex].ContainsKey(riceBox.GetRiceAOA()))
                        {
                            Match mch = Regex.Match(dgvTmp.CurrentCell.ToolTipText, @"^[\u4e00-\u9fa5]+");
                            cbo.SelectedIndexChanged -= new EventHandler(ComboBoxEditingControl_SelectedIndexChanged);
                            cbo.Text = mch.Groups[0].Value;
                            cbo.SelectedIndexChanged += new EventHandler(ComboBoxEditingControl_SelectedIndexChanged);

                            MessageBox.Show("参数设置失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        riceBox.SetPara(geneFad[dgvTmp.CurrentCell.RowIndex][riceBox.GetRiceK()],
                                        geneFad[dgvTmp.CurrentCell.RowIndex][riceBox.GetRiceAOA()]);
                    }

                    if (DialogResult.OK == riceBox.ShowDialog(this) && riceBox.GetPara(out dbl, out dbl2))
                    {
                        geneFad[dgvTmp.CurrentCell.RowIndex] = new Dictionary<string, double>();
                        geneFad[dgvTmp.CurrentCell.RowIndex].Add(cbo.Text, 0);
                        geneFad[dgvTmp.CurrentCell.RowIndex].Add(riceBox.GetRiceK(), dbl);
                        geneFad[dgvTmp.CurrentCell.RowIndex].Add(riceBox.GetRiceAOA(), dbl2);

                        GeneFadShow(dgvTmp.CurrentCell, geneFad[dgvTmp.CurrentCell.RowIndex]);
                    }
                    else
                    {
                        Match mch = Regex.Match(dgvTmp.CurrentCell.ToolTipText, @"^[\u4e00-\u9fa5]+");
                        cbo.SelectedIndexChanged -= new EventHandler(ComboBoxEditingControl_SelectedIndexChanged);
                        cbo.Text = mch.Groups[0].Value;
                        cbo.SelectedIndexChanged += new EventHandler(ComboBoxEditingControl_SelectedIndexChanged);
                    }
                }
                else if (cbo.Text == "纯多普勒")
                {
                    if (geneFad[dgvTmp.CurrentCell.RowIndex].ContainsKey("纯多普勒"))
                    {
                        if (!geneFad[dgvTmp.CurrentCell.RowIndex].ContainsKey(dopplerBox.GetDoppler()))
                        {
                            Match mch = Regex.Match(dgvTmp.CurrentCell.ToolTipText, @"^[\u4e00-\u9fa5]+");
                            cbo.SelectedIndexChanged -= new EventHandler(ComboBoxEditingControl_SelectedIndexChanged);
                            cbo.Text = mch.Groups[0].Value;
                            cbo.SelectedIndexChanged += new EventHandler(ComboBoxEditingControl_SelectedIndexChanged);

                            MessageBox.Show("参数设置失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        dopplerBox.SetDoppler(geneFad[dgvTmp.CurrentCell.RowIndex][dopplerBox.GetDoppler()]);
                    }

                    if (DialogResult.OK == dopplerBox.ShowDialog(this) && dopplerBox.GetDoppler(out dbl))
                    {
                        geneFad[dgvTmp.CurrentCell.RowIndex] = new Dictionary<string, double>();
                        geneFad[dgvTmp.CurrentCell.RowIndex].Add(cbo.Text, 0);
                        geneFad[dgvTmp.CurrentCell.RowIndex].Add(dopplerBox.GetDoppler(), dbl);

                        GeneFadShow(dgvTmp.CurrentCell, geneFad[dgvTmp.CurrentCell.RowIndex]);
                    }
                    else
                    {
                        Match mch = Regex.Match(dgvTmp.CurrentCell.ToolTipText, @"^[\u4e00-\u9fa5]+");
                        cbo.SelectedIndexChanged -= new EventHandler(ComboBoxEditingControl_SelectedIndexChanged);
                        cbo.Text = mch.Groups[0].Value;
                        cbo.SelectedIndexChanged += new EventHandler(ComboBoxEditingControl_SelectedIndexChanged);
                    }
                }
                else if (cbo.Text == "瑞利衰落")
                {
                    geneFad[dgvTmp.CurrentCell.RowIndex] = new Dictionary<string, double>();
                    geneFad[dgvTmp.CurrentCell.RowIndex].Add(cbo.Text, 0);

                    GeneFadShow(dgvTmp.CurrentCell, geneFad[dgvTmp.CurrentCell.RowIndex]);
                }
            }
        }

        private void ComboBoxEditingControl_VisibleChanged(object sender, EventArgs e)
        {
            ComboBox cbo = sender as ComboBox;
            if (cbo.Visible == false)
            {
                cbo.SelectedIndexChanged -= new EventHandler(ComboBoxEditingControl_SelectedIndexChanged);
                cbo.VisibleChanged -= new EventHandler(ComboBoxEditingControl_VisibleChanged);
            }
        }

        private void TextBoxEditingControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if ("colGeneLoss" == dgvTmp.Columns[dgvTmp.CurrentCell.ColumnIndex].Name ||
                "colGeneFdOffset" == dgvTmp.Columns[dgvTmp.CurrentCell.ColumnIndex].Name)
                InputLimit(txt, e, InputMod.Float);
            else if ("colGeneFdMax" == dgvTmp.Columns[dgvTmp.CurrentCell.ColumnIndex].Name)
                InputLimit(txt, e, InputMod.UInt);
            else
                InputLimit(txt, e, InputMod.UFloat);
        }

        private void TextBoxEditingControl_VisibleChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt.Visible == false)
            {
                txt.VisibleChanged -= new EventHandler(TextBoxEditingControl_VisibleChanged);
                txt.KeyPress -= new KeyPressEventHandler(TextBoxEditingControl_KeyPress);
            }
        }
        

        private void dgvGeneChan_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                double dblData;
                DataGridView dgv = sender as DataGridView;

                dgv[e.ColumnIndex, e.RowIndex].ErrorText = null;
                if ("colGeneDelay" == dgv.Columns[e.ColumnIndex].Name)
                {
                    if (!double.TryParse(dgv[e.ColumnIndex, e.RowIndex].FormattedValue.ToString(), out dblData) || !ParaLimitEst(dblData, ChanPara.CluDelay))
                        dgv[e.ColumnIndex, e.RowIndex].ErrorText = ParaLimitError(ChanPara.CluDelay);
                }
                else if ("colGeneLoss" == dgv.Columns[e.ColumnIndex].Name)
                {
                    if (!double.TryParse(dgv[e.ColumnIndex, e.RowIndex].FormattedValue.ToString(), out dblData) || !ParaLimitEst(dblData, ChanPara.CluLoss))
                        dgv[e.ColumnIndex, e.RowIndex].ErrorText = ParaLimitError(ChanPara.CluLoss);
                }
                else if ("colGeneFdMax" == dgv.Columns[e.ColumnIndex].Name)
                {
                    if (!double.TryParse(dgv[e.ColumnIndex, e.RowIndex].FormattedValue.ToString(), out dblData) || !ParaLimitEst(dblData, ChanPara.MaxDoppler))
                        dgv[e.ColumnIndex, e.RowIndex].ErrorText = ParaLimitError(ChanPara.MaxDoppler);
                }
                else if ("colGeneFad" == dgv.Columns[e.ColumnIndex].Name)
                {
                    if (dgv[e.ColumnIndex, e.RowIndex].FormattedValue.ToString() == "纯多普勒")
                    {
                        if (!chkGeneChanMod.Checked)
                            dgv["colGeneDoppler", e.RowIndex].ReadOnly = true;
                        dgv["colGeneFdMax", e.RowIndex].ReadOnly = true;
                        dgv["colGeneFdOffset", e.RowIndex].ReadOnly = true;
                    }
                    else
                    {
                        if (!chkGeneChanMod.Checked)
                            dgv["colGeneDoppler", e.RowIndex].ReadOnly = false;
                        dgv["colGeneFdMax", e.RowIndex].ReadOnly = false;
                        dgv["colGeneFdOffset", e.RowIndex].ReadOnly = false;
                    }
                }
            }
        }

        private void dgvGeneChan_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            if (dgv.Name == dgvGeneChan.Name)
            {
                for (int ii = 0; ii < e.RowCount; ii++)
                {
                    geneFad.Add(new Dictionary<string, double>());
                    geneFad[geneFad.Count - 1].Add("瑞利衰落", 0);

                    GeneFadShow(dgv["colGeneFad", geneFad.Count - 1], geneFad[geneFad.Count - 1]);
                }
            }

            for (int ii = e.RowIndex; ii < e.RowIndex + e.RowCount; ii++)
            {
                dgv.Rows[ii].HeaderCell.Value = "衰落路径" + (ii + 1).ToString();
            }
        }

        private void dgvGeneChan_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            if (dgv.Name == dgvGeneChan.Name)
                geneFad.RemoveAt(e.RowIndex);

            for (int ii = e.RowIndex; ii < dgvGeneChan.RowCount; ii++)
            {
                dgv.Rows[ii].HeaderCell.Value = "衰落路径" + (ii + 1).ToString();
            }
        }

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
                        if (dgv["colGeneFad", e.Cell.RowIndex].FormattedValue.ToString() == "纯多普勒")
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

        private void dgvGeneChan_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            if (dgv.Columns[e.ColumnIndex].Name == "colGeneFad")
                dgv[e.ColumnIndex, e.RowIndex].Value = "瑞利衰落";
            else if (dgv.Columns[e.ColumnIndex].Name == "colGeneDoppler")
                dgv[e.ColumnIndex, e.RowIndex].Value = "经典3dB";
        }
        #endregion

        #region 预定义信道
        private void chkGeneChanMod_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            if (chk.Checked)
            {
                rdoGeneOutskirts.Enabled = true;
                rdoGeneBad.Enabled = true;
                rdoGeneHill.Enabled = true;
                rdoCost259.Enabled = true;

                for (int ii = 0; ii < dgvGeneChan.RowCount; ii++)
                {
                    dgvGeneChan["colGeneDelay", ii].ReadOnly = true;
                    dgvGeneChan["colGeneLoss", ii].ReadOnly = true;
                    dgvGeneChan["colGeneDoppler", ii].ReadOnly = true;
                }
            }
            else
            {
                rdoGeneOutskirts.Enabled = false;
                rdoGeneBad.Enabled = false;
                rdoGeneHill.Enabled = false;
                rdoCost259.Enabled = false;

                for (int ii = 0; ii < dgvGeneChan.RowCount; ii++)
                {
                    dgvGeneChan["colGeneDelay", ii].ReadOnly = false;
                    dgvGeneChan["colGeneLoss", ii].ReadOnly = false;
                    dgvGeneChan["colGeneDoppler", ii].ReadOnly = false;
                }
            }
        }

        private void rdoGeneChanMod_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = sender as RadioButton;

            if (chkGeneChanMod.Checked && rdo.Checked)
            {
                string geneChanName = "";

                if (sender.Equals(rdoGeneOutskirts))
                    geneChanName = rdo.Text + ".xml";// + lalGeneOutskirts.Text
                else if (sender.Equals(rdoGeneBad))
                    geneChanName = rdo.Text + ".xml";//+ lalGeneBad.Text 
                else if (sender.Equals(rdoGeneHill))
                    geneChanName = rdo.Text + ".xml";//lalGeneHill.Text +
                else if (sender.Equals(rdoCost259))
                    geneChanName = rdo.Text + ".xml";

                LoadGeneCfg(strDefaultPath + geneChanName);
            }
        }
        #endregion

        private void chkGeneShadow_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            if (chk.Checked)
            {
                txtGeneShadow.Enabled = true;
                txtGeneDecorLen.Enabled = true;
            }
            else
            {
                txtGeneShadow.Enabled = false;
                txtGeneDecorLen.Enabled = false;
            }
        }
        //#region 驱动相关

        //private void btnDownloadData_Click(object sender, EventArgs e)
        //{
        //    string errorMsg;
        //    FileInfo fi;

        //    mainPage.lalState.Text = "Busy";

        //    fi = new FileInfo(strChanFilePath);
        //    if (!SetPcieReg(PcieReg.DMASize, (uint)fi.Length, out errorMsg))
        //    {
        //        MessageBox.Show(errorMsg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }
        //    waitBox.ShowDialog(this);
        //    bgwDmaTransfer.RunWorkerAsync(strChanFilePath);
        //}

        ///// <summary>
        ///// 设置Pcie设备寄存器值
        ///// </summary>
        //private bool SetPcieReg(PcieReg regAddr, uint regData, out string errorMsg)
        //{
        //    switch (regAddr)
        //    {
        //        case PcieReg.IsRun:
        //            {
        //                if (!PcieDriver.SetDeviceRegister((uint)regAddr, regData))
        //                {
        //                    errorMsg = PcieDriver.GetLastDeviceError();
        //                    return false;
        //                }
        //                errorMsg = "";
        //                break;
        //            }
        //        case PcieReg.DMASize:
        //            {
        //                if (!PcieDriver.SetDeviceRegister((uint)regAddr, regData * 8 / 512 - 1))
        //                {
        //                    errorMsg = PcieDriver.GetLastDeviceError();
        //                    return false;
        //                }
        //                errorMsg = "";
        //                break;
        //            }
        //        default:
        //            {
        //                errorMsg = "";
        //                return false;
        //            }
        //    }
        //    return true;
        //}


        //private void bgwDmaTransfer_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    FileStream fs = null;
        //    BinaryReader br = null;
        //    e.Result = true;

        //    try
        //    {
        //        byte[] buf;
        //        long bufSizeMax;
        //        uint bufCount, lenExtra, alignByte = 0x400;

        //        string dmaFilePath = e.Argument as string;
        //        bufSizeMax = PcieDriver.MAX_BUF_SIZE;

        //        fs = new FileStream(dmaFilePath, FileMode.Open, FileAccess.Read);
        //        br = new BinaryReader(fs);

        //        bufCount = (uint)(fs.Length / bufSizeMax);
        //        lenExtra = (uint)(fs.Length % bufSizeMax);
        //        if ((lenExtra & (alignByte - 1)) != 0)
        //            lenExtra = (lenExtra & ~(alignByte - 1)) + alignByte;

        //        if (bufCount > 0)
        //        {
        //            for (uint ii = 0; ii < bufCount; ii++)
        //            {

        //                buf = new byte[bufSizeMax];
        //                buf = br.ReadBytes(buf.Length);

        //                if (PcieDriver.DmaToDevice(buf) == false)
        //                {
        //                    e.Result = false;
        //                    lastError = PcieDriver.GetLastDeviceError();
        //                    return;
        //                }
        //            }
        //        }

        //        if (lenExtra > 0)
        //        {
        //            buf = new byte[lenExtra];
        //            br.ReadBytes((int)lenExtra).CopyTo(buf, 0);

        //            if (PcieDriver.DmaToDevice(buf) == false)
        //            {
        //                e.Result = false;
        //                lastError = PcieDriver.GetLastDeviceError();
        //                return;
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        e.Result = false;
        //        lastError = "配置硬件失败！";
        //    }
        //    finally
        //    {
        //        if (br != null)
        //            br.Close();
        //        if (fs != null)
        //            fs.Close();
        //    }
        //}

        //private void bgwDmaTransfer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    waitBox.Hide();
        //    if ((bool)e.Result == false)
        //        MessageBox.Show(lastError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        //    mainPage.lalState.Text = "Ready";
        //}
        //#endregion

        
    }
}
