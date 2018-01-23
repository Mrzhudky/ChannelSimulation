using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;
using System.Collections;
using MathWorks.MATLAB.NET.Utility;
using MathWorks.MATLAB.NET.Arrays;
using AeroChanFun;
using System.Text.RegularExpressions;
using System.IO;
//using pcieDriverHelper;

namespace ChanSimSource
{
    public partial class FadingWindow : Form
    {
        private Form1 mainPage;

        private GroundParaBox groParaBox = new GroundParaBox();
        private WaitBox waitBox = new WaitBox();
        private AeroChan aeroChan;

        private string lastError;
        private string strDefaultPath = System.AppDomain.CurrentDomain.BaseDirectory;
        //private string aeroChanParaPath;
        private string strChanFilePath;

        ////驱动操作相关地址
        //private enum PcieReg
        //{
        //    IsRun = 0x100,
        //    AddNoise = 0x104,
        //    SNR = 0x108,
        //    DMASize = 0x10c
        //}

        #region 理论相关固定值

        private Dictionary<string, double[]> refModDef = new Dictionary<string, double[]>()
        {{"干燥地面",new double[]{3,0.0033}},{"中等地面",new double[]{15,0.08}},
         {"潮湿地面",new double[]{30,0.3}},  {"海洋",new double[]{70,5.5}}};
        private Dictionary<string, double> refEnvDef = new Dictionary<string, double>() { { "郊区", 1 }, { "城市", 2 }, { "森林", 3 }, { "海洋", 4 } };
        #endregion

        #region 理论相关极限值

        private const int    maxAeroCluNum = 4;
        private const double minAeroUpdate = 10;           //  单位:ms
        private const double maxAeroUpdate = 1000;         //  单位:ms
        private const double stepAeroUpdate = 10;          //  单位:ms

        private const double minAeroCarrierFre = 0;        //  单位:deg
        #endregion

        public FadingWindow()
        {
            InitializeComponent();

        }
        public FadingWindow(Form1 mpage)
        {
            InitializeComponent();
            mainPage = mpage;
        }
        public void SetMainPage(Form1 mpage)
        {
            mainPage = mpage;
        }
        public void SetPara(Form1 mpage, AeroChan aChan)
        {
            mainPage = mpage;
            aeroChan = aChan;
        }

        public string GetStrFilePath()
        {
            return strChanFilePath;
        }
        /// <summary>
        /// 说好的load函数，完全没吊用，好像理解错了ORZ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FadingWindow_Load(object sender, EventArgs e)
        {
            //控件初始化
            cboAeroRefMod.SelectedIndex = 0;
            cboAeroRefEnv.SelectedIndex = 0;
            cboAeroChanModel.SelectedIndex = 0;
            cboAeroPolar.SelectedIndex = 0;
            cboAeroCarrierFre.SelectedIndex = 1;

            //Matlab初始化
           // bgwMatlabInit.RunWorkerAsync();
            strChanFilePath = strDefaultPath + "Output\\AeroChanData.ach";
        }

        #region 调用Matlab产生文件
        private void btnDetermine_Click(object sender, EventArgs e)
        {
            ArrayList lit = new ArrayList();//zhu 会反复进行装箱拆箱
            double dbl_Temp, dbl_Temp1, dbl_Temp2; //获取控件中参数的中间量


            if (errorShow.GetError(txtAeroTrace)      != "" ||
                errorShow.GetError(txtAeroLaunAnte)   != "" ||
                errorShow.GetError(txtAeroRecvAnte)   != "" ||
                errorShow.GetError(txtAeroCarrierFre) != "" ||
                errorShow.GetError(txtAeroUpdate)     != ""   )
            {
                MessageBox.Show("配置参数错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //载波频率
            if (!double.TryParse(txtAeroCarrierFre.Text, out dbl_Temp))
            {
                MessageBox.Show("载波参数配置错误！","警告",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            switch (cboAeroCarrierFre.Text)
	        {
                case "GHz":dbl_Temp *=1e+9;break;
                case "MHz":dbl_Temp *=1e+6;break;
                case "KHz":dbl_Temp *=1e+3;break;
                case "Hz":break;
		        default:
                {
                    MessageBox.Show("载波参数单位配置错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                    break;
                }
         
	        }
            lit.Add(dbl_Temp);

            //状态更新速率
            if (!double.TryParse(txtAeroUpdate.Text,out dbl_Temp))
            {
                MessageBox.Show("状态更新速率配置错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            lit.Add(dbl_Temp);

            //极化方式
            switch (cboAeroPolar.Text)
            {
                case "水平极化": dbl_Temp = 0; break;
                case "垂直极化": dbl_Temp = 1; break;
                default:
                    {
                        MessageBox.Show("极化方式配置错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
            }
            lit.Add(dbl_Temp);

            //环境参数  角度扩展
            groParaBox.GetPara(out dbl_Temp, out dbl_Temp1, out dbl_Temp2);
            lit.Add(new double[2] { dbl_Temp, dbl_Temp1 });
            lit.Add(dbl_Temp2);  

            //信道模型
            switch (cboAeroChanModel.Text)
            {
                case "空-空": dbl_Temp = 0; break;
                case "空-地":dbl_Temp =1;break;
                case "地-空":dbl_Temp =2;break;
                default:
                {                      
                    MessageBox.Show("配置参数错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);                            
                    return;
                    break;
                }
            }
            lit.Add(dbl_Temp);

            //输入文件路径
            lit.Add(txtAeroTrace.Text);
            lit.Add(txtAeroLaunAnte.Text);
            lit.Add(txtAeroRecvAnte.Text);
            
            //输出文件路径
            lit.Add(strDefaultPath +  "Output\\AeroChanPara.acp");
            lit.Add(strChanFilePath);
            //lit.Add("D:\\Code\\VS2010_Pros\\4_HuaweiContest\\Output\\AeroChanPara.acp");

           // lit.Add("D:\\Code\\VS2010_Pros\\4_HuaweiContest\\Output\\AeroChanData.ach");

            //if (bgwMatlabInit.IsBusy == true)
            //{
            //    MessageBox.Show("正在初始化Matlab，请稍后再试！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            bgwMatlabGen.RunWorkerAsync(lit);


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

                MWNumericArray fc_Hz = (double)lit[0],
                                chanUpdate_ms = (double)lit[1],
                                polarMod = (double)lit[2],
                                mediaPara = (double[])lit[3],
                                angSpread_deg = (double)lit[4],
                                chanMod = (double)lit[5];
                MWCharArray traFilePath = lit[6] as string,
                            launAnteFilePath = lit[7] as string,
                            recvAnteFilePath = lit[8] as string,
                            chanParaSavePath = lit[9] as string,
                            chanSavePath = lit[10] as string;

                MWArray[] matlabRlt = aeroChan.AeroChanGenerate(2, fc_Hz, chanUpdate_ms, polarMod, mediaPara, angSpread_deg, chanMod, traFilePath, launAnteFilePath, recvAnteFilePath, chanParaSavePath, chanSavePath);
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

            //lblStatus.Text = "Ready";
        }
        #endregion

        #region 控件操作
        /// <summary>
        /// 选择文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            OpenFileDialog fileDialog = new OpenFileDialog();

            if (btn.Name == btnAeroTrace.Name)
                fileDialog.Filter = "tra files(*.tra)|*.tra";
            else if (btn.Name == btnAeroLaunAnte.Name || btn.Name == btnAeroRecvAnte.Name)
                fileDialog.Filter = "ante files(*.ante)|*.ante";

            fileDialog.FilterIndex = 1;
            //fileDialog.InitialDirectory =
            fileDialog.RestoreDirectory = true;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (btn.Name == btnAeroTrace.Name)
                    txtAeroTrace.Text = fileDialog.FileName;
                else if (btn.Name == btnAeroLaunAnte.Name)
                    txtAeroLaunAnte.Text = fileDialog.FileName;
                else if (btn.Name == btnAeroRecvAnte.Name)
                    txtAeroRecvAnte.Text = fileDialog.FileName;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void cboAeroRefEnv_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strEnvironment = cboAeroRefEnv.SelectedItem.ToString();
            
            double dblDC, dblCond, dblAngleSp;

            if (strEnvironment == "海洋")
            {
                cboAeroRefMod.Enabled = false;
                cboAeroRefMod.SelectedIndex = -1;
                if (!refModDef.ContainsKey(strEnvironment) || !refEnvDef.ContainsKey(strEnvironment))
                {
                    MessageBox.Show("环境参数设置错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                dblDC = refModDef[strEnvironment][0];
                dblCond = refModDef[strEnvironment][1];
                dblAngleSp = refEnvDef[strEnvironment];
                groParaBox.SetPara(dblDC, dblCond, dblAngleSp);
            }
            else
            {
                string strMedium = cboAeroRefMod.SelectedItem.ToString();
                cboAeroRefMod.Enabled = true;
                string strRefMod = cboAeroRefMod.SelectedItem.ToString();

                if (!refEnvDef.ContainsKey(strEnvironment) || !refModDef.ContainsKey(strMedium))
                {
                    MessageBox.Show("环境参数设置错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dblDC = refModDef[strMedium][0];
                dblCond = refModDef[strMedium][1];
                dblAngleSp = refEnvDef[strEnvironment];
                groParaBox.SetPara(dblDC, dblCond, dblAngleSp);
            }
        }

        private void cboAeroRefEnv_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox cbo = sender as ComboBox;
            string strRefEnv = cbo.SelectedItem.ToString();

            if (strRefEnv == "自定义")
            {
                if (DialogResult.OK != groParaBox.ShowDialog(this))
                {
                    Match mch = Regex.Match(TipShow.GetToolTip(cboAeroRefEnv), @"^[\u4e00-\u9fa5]+");
                    cboAeroRefEnv.Text = mch.Groups[0].Value;
                }
            }
        }

        private void txtFileExist_TextChanged(object sender, EventArgs e)
        {
            Match mch;
            TextBox txt = sender as TextBox;

           // TipShow.SetToolTip(txt, txt.Text);

            if (!txt.Focused)
                txt.SelectionStart = txt.Text.Length;

            if (txt.Name == txtAeroTrace.Name)
                mch = Regex.Match(txt.Text, @"\.tra$", RegexOptions.IgnoreCase);
            else if (txt.Name == txtAeroLaunAnte.Name || txt.Name == txtAeroRecvAnte.Name)
                mch = Regex.Match(txt.Text, @"\.ante$", RegexOptions.IgnoreCase);
            else
                return;

            errorShow.SetError(txt, null);
            if (!mch.Groups[0].Success || !File.Exists(txt.Text))
                errorShow.SetError(txt, "文件不存在");
        }

        private void textBoxKeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == '\b') return; //'b'为退格键

            InputLimit inputLimit = new TextBoxInputLimit(sender);
            inputLimit = new NumberType(inputLimit);
            inputLimit = new PositiveType(inputLimit);

            if (!inputLimit.InputCheck(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion
       
    }
}
