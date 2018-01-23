using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ChanSimSource
{
    public partial class RiceBox : Form
    {
        #region 限制输入范围
        private enum RicePara { RiceK, RiceAOA };

        private const double minGeneRiceK = -60;           // hu 单位:dB
        private const double maxGeneRiceK = 60;            // hu 单位:dB
        private const double minGeneRiceAOA = 0;           // hu 单位:deg
        private const double maxGeneRiceAOA = 360;         // hu 单位:deg

        private bool ParaLimitEst(double para, RicePara ricePara)
        {
            switch (ricePara)
            {
                case RicePara.RiceK:
                    {
                        if (para < minGeneRiceK || para > maxGeneRiceK)
                            return false;
                        break;
                    }
                case RicePara.RiceAOA:
                    {
                        if (para < minGeneRiceAOA || para >= maxGeneRiceAOA)
                            return false;
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

        private string ParaLimitError(RicePara ricePara)
        {
            string strMessage = "";
            switch (ricePara)
            {
                case RicePara.RiceK:
                    return "输入值应在" + minGeneRiceK.ToString() + "～" + maxGeneRiceK.ToString() + "之间";
                case RicePara.RiceAOA:
                    return "输入值应在" + minGeneRiceAOA.ToString() + "～" + maxGeneRiceAOA.ToString() + "之间";
                default:
                    break;
            }
            return strMessage;
        }
        #endregion

        #region 输入限制
        public enum InputMod { Int, UInt, Float, UFloat };

        private void InputLimit(TextBox tBox, KeyPressEventArgs e, InputMod inputMod)
        {
            string strStart, strEnd;
            int data;

            e.Handled = false;
            if (e.KeyChar == '\b') return; //'b'为退格键

            strStart = tBox.Text.Substring(0, tBox.SelectionStart);
            strEnd = tBox.Text.Substring(tBox.SelectionStart + tBox.SelectionLength, tBox.Text.Length - tBox.SelectionStart - tBox.SelectionLength);


            switch (inputMod)
            {
                case InputMod.Int:
                    {
                        

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
                default: e.Handled = true; break;
            }
        }
        #endregion


        public string GetRiceK()
        {
            return lalGeneRiceK.Text;
        }
        public void GetRiceK(out string name, out string unit)
        {
            name = lalGeneRiceK.Text;
            unit = lalGeneRiceKUnit.Text;
        }

        public string GetRiceAOA()
        {
            return lalGeneRiceAOA.Text;
        }
        public void GetRiceAOA(out string name, out string unit)
        {
            name = lalGeneRiceAOA.Text;
            unit = lalGeneRiceAOAUnit.Text;
        }

        public bool SetPara(double riceK, double riceAOA)
        {
            if ( !ParaLimitEst(riceK, RicePara.RiceK) || !ParaLimitEst(riceAOA, RicePara.RiceAOA))
                return false;

            txtGeneRiceK.Text = riceK.ToString();
            txtGeneRiceAOA.Text = riceAOA.ToString();
            return true;
        }

        public bool GetPara(out double riceK, out double riceAOA)
        {
            bool isSucceed = true;
            if (!double.TryParse(txtGeneRiceK.Text, out riceK))
                isSucceed = false;
            if (!double.TryParse(txtGeneRiceAOA.Text, out riceAOA))
                isSucceed = false;
            return isSucceed;
        }

        public RiceBox()
        {
            InitializeComponent();
        }

        public RiceBox(double riceK, double riceAOA)
        {
            InitializeComponent();

            txtGeneRiceK.Text = riceK.ToString();
            txtGeneRiceAOA.Text = riceAOA.ToString();
        }

        private void txtInputLimit_TextChanged(object sender, EventArgs e)
        {
            bool isOK = true;
            double dbl;

            if (!double.TryParse(txtGeneRiceK.Text, out dbl) || !ParaLimitEst(dbl, RicePara.RiceK))
            {
                errorShow.SetError(txtGeneRiceK, ParaLimitError(RicePara.RiceK));
                isOK = false;
            }
            else
                errorShow.SetError(txtGeneRiceK, null);

            if (!double.TryParse(txtGeneRiceAOA.Text, out dbl) || !ParaLimitEst(dbl, RicePara.RiceAOA))
            {
                errorShow.SetError(txtGeneRiceAOA, ParaLimitError(RicePara.RiceAOA));
                isOK = false;
            }
            else
                errorShow.SetError(txtGeneRiceAOA, null);

            btnGeneOk.Enabled = isOK;
        }


        private void textBoxKeyPress(object sender, KeyPressEventArgs e)
        {                        

            if (e.KeyChar == '\b') return; //'b'为退格键

            InputLimit inputLimit = new TextBoxInputLimit(sender);
            inputLimit = new NumberType(inputLimit);
            inputLimit = new PositiveType(inputLimit);

            if( !inputLimit.InputCheck(e.KeyChar) )
            {
                e.Handled = true;
            }
        }


        private void txtGeneAOA_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputLimit(sender as TextBox, e, InputMod.UInt);
        }
    }
}
