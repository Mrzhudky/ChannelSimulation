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
    public partial class NoiseBox : Form
    {
        Form1 mainPage;

        public NoiseBox()
        {
            InitializeComponent();
        }


        #region 接口
        public string GetStrSNR()
        {
            return txtGeneSNR.Text;
        }
        public double GetSNR()
        {
            double dbl;
            if ((txtGeneSNR.Text == null) || (!double.TryParse(txtGeneSNR.Text, out dbl)) || !(dbl > 0))
            {
                return -1;
            }
            else 
            {
                return dbl;
            }

        }

        public void SetMainpage(Form1 mPage)
        {

            mainPage = mPage;
        }
        #endregion
        private void btnDetermine_Click(object sender, EventArgs e)
        {
            mainPage.lalNoise.Text = "信噪比：" + txtGeneSNR.Text + "dB"; 
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //mainPage.lalNoise.Text = "信噪比：" + txtGeneSNR.Text + "dB"; 
            this.Close();
        }

        private void txtGeneSNR_TextChanged(object sender, EventArgs e)
        {
            //bool isOK = true;
            double dbl;

            if ( (txtGeneSNR.Text==null) || (!double.TryParse(txtGeneSNR.Text, out dbl)) )
            {
                errorShow.SetError(txtGeneSNR, "输入错误");
                btnDetermine.Enabled = false;
            }
            else
            {
                errorShow.SetError(txtGeneSNR, null);
                btnDetermine.Enabled = true;
            }

        }

        private void txtInputUFloat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')//'b'为退格键,一般退格键是一定会有效的，认为是不变的部分
            {
                return;
            }

            InputLimit inputLimit = new TextBoxInputLimit(sender);
            inputLimit = new NumberType(inputLimit);

            if (!inputLimit.InputCheck(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void NoiseBox_Load(object sender, EventArgs e)
        {
            btnDetermine.Enabled = false;
        }
    }
}
