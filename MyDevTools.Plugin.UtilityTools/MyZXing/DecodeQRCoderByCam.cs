using MyDevTools.Plugin.UtilityTools.Utility;
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
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

namespace MyDevTools.Plugin.UtilityTools.MyZXing
{
    public partial class DecodeQRCoderByCam : Form
    {
        /// <summary>
        /// 临时文件夹地址
        /// </summary>
        private string _tempPath;
        /// <summary>
        /// 相机
        /// </summary>
        private CamWorker _camWorker;

        private System.Timers.Timer _timer;

        private int _doCount;
        private int _failedCount=0;

        public DecodeQRCoderByCam()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _tempPath = Path.Combine(Application.StartupPath, "temp");

            if (Directory.Exists(_tempPath))
            {
                var files = Directory.GetFiles(_tempPath);
                for (int i = 0; i < files.Length; i++)
                {
                    File.Delete(files[i]);
                }
            }
            else
            {
                Directory.CreateDirectory(_tempPath);
            }

            _camWorker = new CamWorker(panel1.Handle, 0, 0, panel1.Width, panel1.Height);
            _camWorker.Open();
            _labelStatus.Text = "相机已打开";
            if (_timer != null && _timer.Enabled)
            {
                _timer.Stop();
                _timer.Dispose();
            }
            _timer = new System.Timers.Timer(1000);
            _timer.Start();
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(_timer_Elapsed);
        }

        void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _doCount++;
            _labelDoCount.BeginInvoke(new Action(() =>
            {
                _labelDoCount.Text = _doCount.ToString();
            }));
            Bitmap bmap=null;
            Image img = null;
            try
            {
                var fileName = _camWorker.TakePhotos(_tempPath);

                if (!File.Exists(fileName))
                {
                    _labelStatus.BeginInvoke(new Action(() =>
                    {
                        _labelStatus.Text = string.Format("找不到图像:{0}…", fileName);
                    }));
                    return;
                }

                _labelStatus.BeginInvoke(new Action(() =>
                {
                    _labelStatus.Text = string.Format("成功找到图像:{0}，解码中…", fileName);
                }));
                try
                {
                    img = Image.FromFile(fileName);
                }
                catch (OutOfMemoryException)
                {
                    _failedCount++;
                    _labelStatus.BeginInvoke(new Action(() =>
                    {
                        _labelStatus.Text = "图像格式不正确。";
                    }));
                    return;
                }

                try
                {
                    bmap = new Bitmap(img);
                }
                catch (IOException ioe)
                {
                    _failedCount++;
                    _labelStatus.BeginInvoke(new Action(() =>
                    {
                        _labelStatus.Text = ioe.ToString();
                    }));
                    return;
                }

                if (bmap == null)
                {
                    _failedCount++;
                    _labelStatus.BeginInvoke(new Action(() =>
                    {
                        _labelStatus.Text = "无法解码图像";
                    }));
                    return;
                }

                QRCodeReader qRCodeReader = new QRCodeReader();

                var bitmapLuminanceSource = new BitmapLuminanceSource(bmap);
                GlobalHistogramBinarizer globalHistogramBinarizer = new GlobalHistogramBinarizer(bitmapLuminanceSource);
                BinaryBitmap binaryBitmap = new BinaryBitmap(globalHistogramBinarizer);
                Result result = qRCodeReader.decode(binaryBitmap);
                if (result != null)
                {
                    textBox2.BeginInvoke(new Action(() =>
                    {
                        textBox2.Text = result.Text;
                    }));
                    Stop();
                    return;
                }

                _labelStatus.BeginInvoke(new Action(() =>
                {
                    _labelStatus.Text = "无法识别的二维码！";
                }));
                textBox2.BeginInvoke(new Action(() =>
                {
                    textBox2.Text = "";
                }));

            }
            finally
            {
                if (bmap != null)
                    bmap.Dispose();
                if (img != null)
                    img.Dispose();
                if (_failedCount >= 100)
                {
                    _failedCount = 0;
                    Stop();
                    _labelStatus.BeginInvoke(new Action(() =>
                    {
                        _labelStatus.Text = "应用程序强制停止监视器，因为它不能连续100次抓取有效图像。";
                    }));
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void Stop()
        {
            _doCount = 0;
            if (_timer != null && _timer.Enabled)
            {
                _timer.Stop();
                _timer.Dispose();
            }
            _camWorker.Close();
            _labelStatus.BeginInvoke(new Action(() =>
            {
                _labelStatus.Text = "Cameram已经关闭。";
            }));
        }
    }
}
