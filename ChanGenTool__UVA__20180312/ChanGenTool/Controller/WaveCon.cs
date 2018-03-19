using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ChanGenTool
{
    class WaveCon
    {

        PcieOperation pcie = new PcieOperation();
        string errorMsg;

        private Dictionary<string, uint> refModNum = new Dictionary<string, uint>() { { "BPSK", 2 }, { "QPSK", 4 }, { "OPSK", 4 },{ "8PSK", 8 }, { "16PSK", 16 }, { "32PSK", 32 },
        {"4QAM",4} ,{"16QAM",16}, { "32QAM", 32}, { "64QAM", 64 }, { "128QAM", 128 }, { "256QAM", 256 }, { "512QAM", 512 } };

        private string strDefaultPath = System.AppDomain.CurrentDomain.BaseDirectory;

        #region 任意波
        public void SignalTypeChoose(uint data, int isFile = 0,string fileName = "")
        {          
            if (isFile == 0)
            {
                if (!pcie.SendSignalType(data, out errorMsg))
                {
                    MessageBox.Show(errorMsg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                FileInfo fi = new FileInfo(fileName);
                uint len = (uint)fi.Length;
                if (!pcie.BeforeTransferFile(0,len,out errorMsg))
                {
                    MessageBox.Show(errorMsg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        public void SetModulation(ComboBox cbox)
        {
            string fileName = strDefaultPath + "file\\" + cbox.Text + ".txt";
            if (!pcie.SendMapData(fileName, refModNum[cbox.Text], out errorMsg))
            {
                MessageBox.Show(errorMsg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        public void SetFilterType(ComboBox cbox)
        {
            uint data = (uint)cbox.SelectedIndex;
            if (!pcie.SendFilterType(data, out errorMsg))
            {
                MessageBox.Show(errorMsg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        public void SetDataSource(ComboBox cbox)
        {
            uint data = (uint)cbox.SelectedIndex;
            if (!pcie.SendDataSourceIndex(data, out errorMsg))
            {
                MessageBox.Show(errorMsg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        
        public void SetFrequency(TextBox tboxFre,ComboBox cboxUnit)
        {
            double fre;
            if (!double.TryParse(tboxFre.Text, out fre))
            {
                MessageBox.Show("频率参数配置错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            fre = fre * Math.Pow(1000, (double)cboxUnit.SelectedIndex);
            if (!pcie.SendFrequency(fre,out errorMsg))
            {
                MessageBox.Show(errorMsg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        public void SetRate(TextBox tbox)
        {
            double rate;
            if (!double.TryParse(tbox.Text, out rate))
            {
                MessageBox.Show("频率参数配置错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!pcie.SendDecimalInter(rate, out errorMsg))
            {
                MessageBox.Show(errorMsg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        public void SetDutyCycle(TextBox tboxFre, ComboBox cboxUnit, TextBox tboxDuty)
        {
            double fre;
            if (!double.TryParse(tboxFre.Text, out fre))
            {
                MessageBox.Show("频率参数配置错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            fre = fre * Math.Pow(1000, (double)cboxUnit.SelectedIndex);
            double duty;
            if (!double.TryParse(tboxDuty.Text, out duty))
            {
                MessageBox.Show("频率参数配置错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!pcie.SendDutyCycle(duty, fre, out errorMsg))
            {
                MessageBox.Show(errorMsg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        public void SetSymbolNumber(ComboBox cbox)
        {
            uint data = (uint)cbox.SelectedIndex;
            if (!pcie.SendSymbolNum(data, out errorMsg))
            {
                MessageBox.Show(errorMsg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        #endregion

        #region 信道
        public void SetRunSwitch(CheckBox ckbox)
        {
            if (ckbox.Checked == true)
            {
                ckbox.Checked = false;
                if (!pcie.IsRun(0, out errorMsg))
                {
                    MessageBox.Show(errorMsg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                ckbox.Checked = true;
                if (!pcie.IsRun(1, out errorMsg))
                {
                    MessageBox.Show(errorMsg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        public void SetAddFadingSwitch(CheckBox ckbox)
        {
            if (ckbox.Checked == true)
            {
                ckbox.Checked = false;
                if (!pcie.IsAddFading(0, out errorMsg))
                {
                    MessageBox.Show(errorMsg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                ckbox.Checked = true;
                if (!pcie.IsAddFading(1, out errorMsg))
                {
                    MessageBox.Show(errorMsg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        public void SetNoiseSwitch(CheckBox ckbox)
        {
            if (ckbox.Checked == true)
            {
                if (!pcie.IsAddNoise(1, out errorMsg))
                {
                    MessageBox.Show(errorMsg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                if (!pcie.IsAddNoise(0, out errorMsg))
                {
                    MessageBox.Show(errorMsg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        public void SetSNR(TextBox tbox)
        {
            double snr = 0;
            if (!double.TryParse(tbox.Text,out snr))
            {
                MessageBox.Show("频率参数配置错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!pcie.SendSNR(snr, out errorMsg))
            {
                MessageBox.Show(errorMsg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }
        #endregion

    }
}
