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
    public partial class WaitBox : Form
    {
        public WaitBox()
        {
            InitializeComponent();
        }
        public void SetInformation(string str)
        {
            lalInformation.Text = str;
        }
    }
}
