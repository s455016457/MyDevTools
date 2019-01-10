using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDevTools.Plugin.UtilityTools.DownloadImage
{
    public partial class DownloadForm : Form
    {
        DownloadHelper downloadHelper;
        public DownloadForm()
        {
            InitializeComponent();
            downloadHelper = new DownloadHelper();
            fileTypeComboBox.SelectedIndex = 0;
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            String urlPath = textBoxUrlPath.Text.Trim();
            if (String.IsNullOrWhiteSpace(urlPath))
            {
                MessageBox.Show("请输入图片地址");
                return;
            }

            folderBrowserDialog1.ShowDialog();
            String saveFilePath = folderBrowserDialog1.SelectedPath;
            if (saveFilePath.Length <= 0) return;

            String[] strs = urlPath.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            await Task.Factory.StartNew(() =>
            {
                foreach (var path in strs)
                {
                    stringBuilder.AppendLine(String.Format("开始下载：{0}", path));
                    textBoxLog.Text = stringBuilder.ToString();
                    downloadHelper.Download(path, saveFilePath, fileTypeComboBox.SelectedItem.ToString());
                }
                stringBuilder.AppendLine("下载完成");
                textBoxLog.Text = stringBuilder.ToString();
                MessageBox.Show("下载完成！");
            });
        }
    }
}
