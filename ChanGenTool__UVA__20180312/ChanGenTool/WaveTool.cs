using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ChanGenTool
{
    public partial class WaveTool : Form
    {
        WaveCon waveCon = new WaveCon();
        string errorMsg;

        ChanGenTool mainPage;

        private string[] typeOfPSK = { "BPSK", "QPSK", "8PSK", "16PSK" };
        private string[] typeOfQAM = { "4QAM", "16QAM", "32QAM", "64QAM", "128QAM", "256QAM", "512QAM" };

        private string strDefaultPath = System.AppDomain.CurrentDomain.BaseDirectory;

        public WaveTool()
        {
            InitializeComponent();
        }
        public WaveTool(ChanGenTool chanGenTool)
        {
            InitializeComponent();
            mainPage = chanGenTool;
        }

        private void cboxModulationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (startFlag == 0)
            //    return;
            ComboBox cbox = sender as ComboBox;
            waveCon.SetModulation(cbox);
        }

        private void cboxFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (startFlag == 0)
            //    return;
            ComboBox cbox = sender as ComboBox;
            waveCon.SetFilterType(cbox);
        }

        private void cboxDataSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (startFlag == 0)
            //    return;
            ComboBox cbox = sender as ComboBox;
            waveCon.SetFilterType(cbox);

        }

        private void tboxFrequency_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b') return;

            ChanGenTool.InputLimit(sender as TextBox, e, ChanGenTool.InputMod.UFloat);

            if (e.KeyChar == '\r')
            {
                cboxFrequencyUnit.Focus();
            }
        }

        private void tboxDutyCycle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b') return;

            

            if (e.KeyChar == '\r')
            {
                waveCon.SetDutyCycle(tboxFrequency, cboxFrequencyUnit, tboxDutyCycle);
            }
        }

        private void tboxSymbolRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b') return;

            ChanGenTool.InputLimit(sender as TextBox, e, ChanGenTool.InputMod.UFloat);

            if (e.KeyChar == '\r')
            {
                waveCon.SetRate(sender as TextBox);
            }
        }

        private void cboxSymbolNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (startFlag == 0)
            //    return;

            waveCon.SetSymbolNumber(sender as ComboBox);
        }

        private void cboxFrequencyUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            waveCon.SetFrequency(tboxFrequency, cboxFrequencyUnit);
        }

        private void cboxSignalType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fileName = "";
            uint data = 0;
            if (cboxSignalType.Text == "单音")
            {
                cboxModulationType.Enabled = false;
                cboxDataSource.Enabled = false;
                cboxSymbolNumber.Enabled = false;
                tboxFrequency.Enabled = true;
                cboxFrequencyUnit.Enabled = true;
                tboxDutyCycle.Enabled = false;
                tboxSymbolRate.Enabled = false;
                cboxFilterType.Enabled = false;
                btnWaveFile.Enabled = false;

                data = 1;
            }
            else if (cboxSignalType.Text == "双音")
            {
                cboxModulationType.Enabled = false;
                cboxDataSource.Enabled = false;
                cboxSymbolNumber.Enabled = false;
                tboxFrequency.Enabled = true;
                cboxFrequencyUnit.Enabled = true;
                tboxDutyCycle.Enabled = false;
                tboxSymbolRate.Enabled = false;
                cboxFilterType.Enabled = false;
                btnWaveFile.Enabled = false;

                data = 2;
            }
            else if (cboxSignalType.Text == "脉冲")
            {
                cboxModulationType.Enabled = false;
                cboxDataSource.Enabled = false;
                cboxSymbolNumber.Enabled = false;
                tboxFrequency.Enabled = true;
                cboxFrequencyUnit.Enabled = true;
                tboxDutyCycle.Enabled = true;
                tboxSymbolRate.Enabled = false;
                cboxFilterType.Enabled = false;
                btnWaveFile.Enabled = false;

                data = 3;
            }
            else if (cboxSignalType.Text == "PSK调制信号")
            {
                cboxModulationType.Enabled = true;
                cboxModulationType.Items.Clear();
                cboxModulationType.Items.AddRange(typeOfPSK);
                cboxDataSource.Enabled = true;
                cboxSymbolNumber.Enabled = true;
                tboxFrequency.Enabled = false;
                cboxFrequencyUnit.Enabled = false;
                tboxDutyCycle.Enabled = false;
                tboxSymbolRate.Enabled = true;
                cboxFilterType.Enabled = true;
                btnWaveFile.Enabled = false;

                data = 4;

            }
            else if (cboxSignalType.Text == "QAM调制信号")
            {
                //baseData = 5;
                cboxModulationType.Enabled = true;
                cboxModulationType.Items.Clear();
                cboxModulationType.Items.AddRange(typeOfQAM);
                cboxDataSource.Enabled = true;
                cboxSymbolNumber.Enabled = true;
                tboxFrequency.Enabled = false;
                cboxFrequencyUnit.Enabled = false;
                tboxDutyCycle.Enabled = false;
                tboxSymbolRate.Enabled = true;
                cboxFilterType.Enabled = true;
                btnWaveFile.Enabled = false;

                data = 4;
            }
            else if (cboxSignalType.Text == "自定义")
            {
                cboxModulationType.Enabled = false;
                cboxModulationType.Enabled = false;
                cboxDataSource.Enabled = false;
                cboxSymbolNumber.Enabled = false;
                tboxFrequency.Enabled = false;
                cboxFrequencyUnit.Enabled = false;
                tboxDutyCycle.Enabled = false;
                tboxSymbolRate.Enabled = false;
                cboxFilterType.Enabled = false;
                btnWaveFile.Enabled = true;

                data = 5;

                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "xml files(*.xml)|*.xml";
                ofd.FilterIndex = 1;
                ofd.InitialDirectory = strDefaultPath + "file\\";
                ofd.RestoreDirectory = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fileName = ofd.FileName;
                }
            }
            if (data < 5)
            {
                waveCon.SignalTypeChoose(data);
            }
            else
            {                
                waveCon.SignalTypeChoose(data, 1, fileName);
                mainPage.bgwDmaTransfer.RunWorkerAsync(fileName);
                mainPage.waitBox.ShowDialog(mainPage);
            }
            
        }

        private void tboxFrequency_Leave(object sender, EventArgs e)
        {                
            waveCon.SetFrequency(tboxFrequency, cboxFrequencyUnit);            
        }

        private void btnWaveFile_Click(object sender, EventArgs e)
        {
            string fileName;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "xml files(*.xml)|*.xml";
            ofd.FilterIndex = 1;
            ofd.InitialDirectory = strDefaultPath + "file\\";
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileName = ofd.FileName;
                tboxWaveFilePath.Text = fileName;
                mainPage.bgwDmaTransfer.RunWorkerAsync(fileName);
                mainPage.waitBox.ShowDialog(mainPage);
            }

        }

        private void ckboxIsRun_CheckedChanged(object sender, EventArgs e)
        {
            waveCon.SetRunSwitch(sender as CheckBox);
        }

        private void ckboxAddFad_CheckedChanged(object sender, EventArgs e)
        {
            waveCon.SetAddFadingSwitch(sender as CheckBox);
        }

        private void ckboxAddNoise_CheckedChanged(object sender, EventArgs e)
        {
            waveCon.SetNoiseSwitch(sender as CheckBox);
        }

        private void txtAeroSNR_KeyPress(object sender, KeyPressEventArgs e)
        {
            waveCon.SetSNR(sender as TextBox);
        }
    }
}
