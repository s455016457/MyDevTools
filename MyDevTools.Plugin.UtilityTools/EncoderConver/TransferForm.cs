using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDevTools.Plugin.UtilityTools.EncoderConver
{
    public partial class TransferForm : Form
    {
        TraditionalToSimplified tran = new TraditionalToSimplified();
        public TransferForm()
        {
            InitializeComponent();
        }

        private void btnToSimplified_Click(object sender, EventArgs e)
        {
            var value = textBoxSource.Text;
            if (value.Length == 0) return;

            textBoxResult.Text = tran.Big5ConvGb2312(value);
        }

        private void btnToTraditional_Click(object sender, EventArgs e)
        {
            var value = textBoxSource.Text;
            if (value.Length == 0) return;

            textBoxResult.Text = tran.Gb2312ConvBig5(value);
        }

        private void btnGenTable_Click(object sender, EventArgs e)
        {
            //System.Drawing.FontFamily.Families[0].
        }
    }
}
