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
    public partial class RemovePDFPages : Form
    {
        private List<int> indexs = new List<int>();
        public RemovePDFPages()
        {
            InitializeComponent();
            openFileDialog1.FileOk += OpenFileDialog1_FileOk;
            saveFileDialog1.FileOk += SaveFileDialog1_FileOk;
        }

        private void SaveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                PdfHelper.MyPdfHelper.RemovePageAndSave(openFileDialog1.FileName, saveFileDialog1.FileName, indexs.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("删除完成！");
        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            txtLoadPath1.Text = openFileDialog1.FileName;
        }

        private void btnLoadPath_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string strIndex = txtIndexs.Text;
            if (string.IsNullOrEmpty(strIndex))
            {
                MessageBox.Show("请输入要删除的页");
                return;
            }
            var strIndexs = strIndex.Split('|');
            indexs.Clear();
            foreach (var stri in strIndexs)
            {
                if(!int.TryParse(stri,out int i))
                {
                    MessageBox.Show("输入的页码必须为正整数");
                    return;
                }
                if (i < 0)
                {
                    MessageBox.Show("输入的页码必须为正整数");
                    return;
                }
                indexs.Add(i);
            }
            saveFileDialog1.ShowDialog();
        }
    }
}
