using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDevTools.Plugin.UtilityTools.JS混淆
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnConfusion_Click(object sender, EventArgs e)
        {
            if (textBoxSource.Text.Trim().Length == 0) return;
            JSConfusion jSConfusion = new JSConfusion();
            var str = jSConfusion.Confusion(textBoxSource.Text.Trim());
            textBoxResult.Text = str;
        }

        private void btnUnobfuscate_Click(object sender, EventArgs e)
        {
            if (textBoxSource.Text.Trim().Length == 0) return;
            JSConfusion jSConfusion = new JSConfusion();
            var str = jSConfusion.UnObfuscate(textBoxSource.Text.Trim());
            textBoxResult.Text = str;
        }

        private async void btnFileConfusion_ClickAsync(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Js文件(*.js)|*.js|文本文件(*.txt)|*.txt";
            openFileDialog1.Multiselect = true;
            openFileDialog1.Title = "选择待混淆文件";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileNames = openFileDialog1.FileNames;
                foreach (var file in fileNames)
                {
                    await ConfusionFileAsync(file);
                }
            }
        }

        private async void btnFileUnobfuscate_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Js文件(*.js)|*.js|文本文件(*.txt)|*.txt";
            openFileDialog1.Multiselect = true;
            openFileDialog1.Title = "选择待反混淆文件";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileNames = openFileDialog1.FileNames;
                foreach (var file in fileNames)
                {
                    await UnobfuscateFileAsync(file);
                }
            }
        }

        private async Task ConfusionFileAsync(string file)
        {
            string text = string.Empty;
            using (StreamReader sr = new StreamReader(file))
            {
                text = await sr.ReadToEndAsync();
            }
            JSConfusion jSConfusion = new JSConfusion();
            text = jSConfusion.Confusion(text);

            FileInfo fileInfo = new FileInfo(file);
            string newFilePath = Path.Combine(fileInfo.DirectoryName, $"{fileInfo.Name}_Result.{fileInfo.Extension}");
            int i = 1;
            while (File.Exists(newFilePath))
            {
                newFilePath = Path.Combine(fileInfo.DirectoryName, $"{fileInfo.Name}_Result({i++}).{fileInfo.Extension}");
            }
            using (StreamWriter sw = File.CreateText(newFilePath))
            {
                await sw.WriteAsync(text);
            }
        }

        private async Task UnobfuscateFileAsync(string file)
        {
            string text = string.Empty;
            using (StreamReader sr = new StreamReader(file))
            {
                text = await sr.ReadToEndAsync();
            }
            JSConfusion jSConfusion = new JSConfusion();
            text = jSConfusion.UnObfuscate(text);

            FileInfo fileInfo = new FileInfo(file);
            string newFilePath = Path.Combine(fileInfo.DirectoryName, $"{fileInfo.Name}_Result.{fileInfo.Extension}");
            int i = 1;
            while (File.Exists(newFilePath))
            {
                newFilePath = Path.Combine(fileInfo.DirectoryName, $"{fileInfo.Name}_Result({i++}).{fileInfo.Extension}");
            }
            using (StreamWriter sw = File.CreateText(newFilePath))
            {
                await sw.WriteAsync(text);
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (TextBox)sender;
            switch (textBox.Name)
            {
                case "textBoxSource":
                case "textBoxResult":
                    if (e.KeyChar == '\x1')
                    {
                        ((TextBox)sender).SelectAll();
                        e.Handled = true;
                    }
                    break;
            }
        }

        private void buttonCopyResult_Click(object sender, EventArgs e)
        {
            if (textBoxResult.Text.Length == 0) return;
            Clipboard.SetText(textBoxResult.Text);
        }
    }
}
