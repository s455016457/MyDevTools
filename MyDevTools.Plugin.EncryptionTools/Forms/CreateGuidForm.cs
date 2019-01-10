using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDevTools.Plugin.EncryptionTools.Forms
{
    public partial class CreateGuidForm : Form
    {
        public CreateGuidForm()
        {
            InitializeComponent();

            comboBox_Format.DataSource = new List<KeyValuePair<String, String>>
            {
                new KeyValuePair<String, String>( "N","XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"),
                new KeyValuePair<String, String>( "D","XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"),
                new KeyValuePair<String, String>( "B","{XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}"),
                new KeyValuePair<String, String>( "P","(XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX)"),
                new KeyValuePair<String, String>( "X","{0x00000000,0x0000,0x0000,{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00}}"),
            };
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Guid guid = Guid.NewGuid();
            if (comboBox_Format.SelectedItem != null)
            {
                KeyValuePair<String, String> keyValue = (KeyValuePair<String, String>)comboBox_Format.SelectedItem;

                if (keyValue.Key != null)
                    textBox_Result.Text = guid.ToString(keyValue.Key);
                else
                    textBox_Result.Text = guid.ToString();
            }
            else
            {
                textBox_Result.Text = guid.ToString();
            }

            if (radioButton1.Checked) textBox_Result.Text = textBox_Result.Text.ToUpper();
            else textBox_Result.Text = textBox_Result.Text.ToLower();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
