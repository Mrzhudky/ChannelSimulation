using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChanSimSource
{
    public partial class LossBox : Form
    {
        Form1 mainPage;

        #region 限制输入范围
        private const double minGeneGain = 0;              // hu 单位:dB
        private const double maxGeneGain = 60;             // hu 单位:dB

        private bool ParaLimitEst(double para)
        {
            if (para < minGeneGain || para > maxGeneGain) return false;

            return true;
        }

        private string ParaLimitError()
        {
            string strMessage = "";
            strMessage = "输入值应在" + minGeneGain.ToString() + "～" + maxGeneGain.ToString() + "之间";
            return strMessage;
        }

        #endregion
        public LossBox()
        {
            InitializeComponent();
            //btnDetermine.Enabled = false;
        }


        #region 接口
        public string GetStrLoss()
        {
            return txtArbitraryWave.Text;
        }
        public double GetDblLoss()
        {
            double dbl;
            if ((txtArbitraryWave.Text == null) || (!double.TryParse(txtArbitraryWave.Text, out dbl)) || !ParaLimitEst(dbl))
            {
                return -1;
            }
            else
            {
                return dbl;
            }

        }
        public void SetMainPage(Form1 mPage)
        {
            mainPage = mPage;
        }
        #endregion
        private void btnDetermine_Click(object sender, EventArgs e)
        {
            mainPage.lalLoss.Text = txtArbitraryWave.Text + "dB";
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            mainPage.lalLoss.Text = txtArbitraryWave.Text + "dB";
            this.Close();
        }

        private void txtArbitraryWave_TextChanged(object sender, EventArgs e)
        {
           // bool isOK = true;
            double dbl;

           // btnDetermine.Enabled = false;

            if ( (txtArbitraryWave.Text == null) || (!double.TryParse(txtArbitraryWave.Text, out dbl) || !ParaLimitEst(dbl)))
            {
                errorShow.SetError(txtArbitraryWave, ParaLimitError());
                btnDetermine.Enabled = false;
            }
            else
            {
                errorShow.SetError(txtArbitraryWave, null);
                btnDetermine.Enabled = true;
            }

            
        
        }

        
        private void txtInputUFloat_KeyPress(object sender, KeyPressEventArgs e)
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

        private void LossBox_Load(object sender, EventArgs e)
        {
            btnDetermine.Enabled = false;
        }
    }
}
