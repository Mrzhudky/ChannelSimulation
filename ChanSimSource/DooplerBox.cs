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
    public partial class DooplerBox : Form
    {
        

        #region 限制输入
        private void txtGeneDoppler_KeyPress(object sender, KeyPressEventArgs e)
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

        #endregion

        public DooplerBox()
        {
            InitializeComponent();
        }
        public DooplerBox(double dopplerFre)
        {
            InitializeComponent();

            txtGeneDoppler.Text = dopplerFre.ToString();
        }

        #region 接口
        public string GetDoppler()
        {
            return lalGeneDoppler.Text;
        }
        public void GetDoppler(out string name, out string unit)
        {
            name = lalGeneDoppler.Text;
            unit = lalGeneDopplerUnit.Text;
        }

        public bool GetDoppler(out double doppler)
        {
            return double.TryParse(txtGeneDoppler.Text, out doppler);
        }

        public bool SetDoppler(double dopplerFre)
        {
            if (!(dopplerFre>0))
                return false;

            txtGeneDoppler.Text = dopplerFre.ToString();
            return true;
        }
        #endregion

         private void txtInputLimit_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            bool isOK = true;
            double dbl;

            if (!double.TryParse(txtGeneDoppler.Text, out dbl) || !(dbl>0))
            {
                errorShow.SetError(txtGeneDoppler, "输入值应大于等于0");
                isOK = false;
            }
            else
                errorShow.SetError(txtGeneDoppler, null);

            btnGeneOk.Enabled = isOK;
        }


    }
}
