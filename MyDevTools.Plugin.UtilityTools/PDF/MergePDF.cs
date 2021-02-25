using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDevTools.Plugin.UtilityTools.PDF
{
    public partial class MergePDF : Form
    {
        public string SaveFilePath { get; private set; }
        public MergePDF()
        {
            InitializeComponent();
            saveFileDialog1.FileOk += SaveFileDialog1_FileOk;
            openFileDialog1.FileOk += OpenFileDialog1_FileOk;
        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var filaName in openFileDialog1.FileNames) {
                sb.Append($"{filaName};");
            }
            txtLoadPath1.Text = sb.ToString();
        }

        private void SaveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                PdfHelper.MyPdfHelper.MergePDFAndSave(saveFileDialog1.FileName, openFileDialog1.FileNames);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("合并完成！");
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void btnLoadPath_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }
    }
}
