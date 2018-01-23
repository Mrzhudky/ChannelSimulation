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
    public partial class GroundParaBox : Form
    {

        #region 限制输入范围
        private enum GroundPara{Dielectric,Conductivity,AngleSpread};

        private const double minAeroDielectric = 0;
        private const double minAeroConductivity = 0;
        private const double minAeroAngSp = 0;             //  单位:deg
        private const double maxAeroAngSp = 5;             //  单位:deg

        private bool ParaLimitEst(double para,GroundPara groundPata)
        {
            switch (groundPata)
	        {
		        case GroundPara.Dielectric:
                {
                    if(para<minAeroDielectric) return false;
                    break;
                }
                case GroundPara.Conductivity:
                {
                    if (para < minAeroConductivity) return false;
                    break;
                }
                case GroundPara.AngleSpread:
                {
                    if(para<minAeroAngSp || para>maxAeroAngSp) return false;
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

        private string ParaLimitError(GroundPara groundPara)
        {
            string strMessage = "";
            switch (groundPara)
            {
                case GroundPara.Dielectric:
                    strMessage = "输入值应大于等于" + minAeroDielectric.ToString();
                    break;
                case GroundPara.Conductivity:
                    strMessage = "输入值应大于等于" + minAeroConductivity.ToString();
                    break;
                case GroundPara.AngleSpread:
                    strMessage = "输入值应在" + minAeroAngSp.ToString() + "～" + maxAeroAngSp.ToString() + "之间";
                    break;
                default:
                    break;
            }
            return strMessage;
        }
        #endregion

        public GroundParaBox()
        {
            InitializeComponent();
        }

        #region 接口

        //介电常数
        public double GetDielectric()
        {
            double dblTemp;
            if(!double.TryParse(lalAeroDielectric.Text, out dblTemp))
            {
                MessageBox.Show("介电常数配置错误！","警告",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return 0;
            }
            return dblTemp;
        }

        public bool SetDielectric(double dielectric)
        {
            if (ParaLimitEst(dielectric,GroundPara.Dielectric))
                return false;

            txtAeroDielectric.Text = dielectric.ToString();
            return true;
        }

        //电导率
        public double GetConductivity()
        {
            double dblTemp;
            if(!double.TryParse(lalAeroConductivity.Text, out dblTemp))
            {
                MessageBox.Show("电导率配置错误！","警告",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return 0;
            }
            return dblTemp;
        }

        public bool SetConductivity(double conductivity)
        {
            if (ParaLimitEst(conductivity, GroundPara.Conductivity))
                return false;

            txtAeroConductivity.Text = conductivity.ToString();
            return true;
        }

        //角度扩展
        public double GetAngSp()
        {
            double dblTemp;
            if(!double.TryParse(lalAeroAngSp.Text, out dblTemp))
            {
                MessageBox.Show("角度扩展配置错误！","警告",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return 0;
            }
            return dblTemp;
        }

        public bool SetAngSp(double angSp)
        {
            if (ParaLimitEst(angSp, GroundPara.AngleSpread))
                return false;

            txtAeroAngSp.Text = angSp.ToString();
            return true;
        }


        public bool SetPara(double dielectric, double conductivity, double angSp)
        {
            if (!ParaLimitEst(dielectric,   GroundPara.Dielectric  ) ||
                !ParaLimitEst(conductivity, GroundPara.Conductivity) ||
                !ParaLimitEst(angSp,        GroundPara.AngleSpread )  )
                return false;

            txtAeroDielectric.Text = dielectric.ToString();
            txtAeroConductivity.Text = conductivity.ToString();
            txtAeroAngSp.Text = angSp.ToString();
            return true;
        }

        public bool GetPara(out double dielectric, out double conductivity, out double angSp)
        {
            bool isSucceed = true;
            if (!double.TryParse(txtAeroDielectric.Text, out dielectric))
                isSucceed = false;
            if (!double.TryParse(txtAeroConductivity.Text, out conductivity))
                isSucceed = false;
            if (!double.TryParse(txtAeroAngSp.Text, out angSp))
                isSucceed = false;
            return isSucceed;
        }

        #endregion


        public GroundParaBox(double dielectric, double conductivity, double angSp)
        {
            InitializeComponent();

            txtAeroDielectric.Text = dielectric.ToString();
            txtAeroConductivity.Text = conductivity.ToString();
            txtAeroAngSp.Text = angSp.ToString();
        }

        #region 输入限制
        //private void InputLimit(Text)

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
        #endregion

        private void txt_TextChanged(object sender, EventArgs e)
        {
            bool isOK = true;
            double dbl;

            if (! double.TryParse(txtAeroDielectric.Text, out dbl) || !ParaLimitEst(dbl, GroundPara.Dielectric))
            {
                errorShow.SetError(txtAeroDielectric, ParaLimitError(GroundPara.Dielectric));
                isOK = false;
            }
            else
            {
                errorShow.SetError(txtAeroDielectric, null);
            }

            if (!double.TryParse(txtAeroConductivity.Text, out dbl) || !ParaLimitEst(dbl, GroundPara.Conductivity))
            {
                errorShow.SetError(txtAeroConductivity, ParaLimitError(GroundPara.Conductivity));
                isOK = false;
            }
            else
            {
                errorShow.SetError(txtAeroConductivity, null);
            }

            if (!double.TryParse(txtAeroAngSp.Text, out dbl) || !ParaLimitEst(dbl, GroundPara.AngleSpread))
            {
                errorShow.SetError(txtAeroAngSp, ParaLimitError(GroundPara.AngleSpread));
                isOK = false;
            }
            else
            {
                errorShow.SetError(txtAeroAngSp, null);
            }

            btnOk.Enabled = isOK;
        }

    }
}
