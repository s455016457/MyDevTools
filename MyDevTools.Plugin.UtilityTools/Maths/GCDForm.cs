using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDevTools.Plugin.UtilityTools.Maths
{
    public partial class GCDForm : Form
    {
        public GCDForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text1 = textBoxNumber1.Text.Trim();
            string text2 = textBoxNumber2.Text.Trim();

            long number1 = 0, number2 = 0;

            if (!long.TryParse(text1, out number1) || number1 == 0)
            {
                richTextBox1.Text = "数字1必须为非零整数！";
                return;
            }
            if (!long.TryParse(text2, out number2) || number2 == 0)
            {
                richTextBox1.Text = "数字2必须为非零整数！";
                return;
            }

            richTextBox1.Text = MathHelper.GetGCD2(number1, number2).ToString();
        }
    }
}
