using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDevTools
{
    public partial class ErrorReport : Form
    {
        /// <summary>
        /// 是否已附加
        /// </summary>
        private static Boolean _attached = false;
        private static Object _lockObj = new Object();

        private Boolean _isRestart = false;
        /// <summary>
        /// 异常消息
        /// </summary>
        public String ExceptionMessage { get; private set; }

        /// <summary>
        /// 是否需要重启
        /// </summary>
        public Boolean NeedRestart { get; private set; }

        private ErrorReport()
        {
            InitializeComponent();
            base.VisibleChanged += ErrorReport_VisibleChanged;
            base.FormClosed += new FormClosedEventHandler(ErrorReport_FormClosed);
        }

        private void ErrorReport_FormClosed(Object sender, FormClosedEventArgs e)
        {
            if (NeedRestart && !_isRestart)
            {
                System.Environment.Exit(Environment.ExitCode);
            }
        }

        private void ErrorReport_VisibleChanged(Object s, EventArgs e)
        {
            if (base.Visible)
            {
                if (NeedRestart)
                {
                    this.Text = "异常将导致程序关闭";
                    this.lbNote.Text = "很抱歉，我们遇到了尚未能处理的异常，异常将导致程序关闭，请点击重启程序按钮以重新启动程序，或者手动重启程序。异常信息显示在下面，请将这些信息连同关于您的操作的描述一起反馈给我们以帮助我们解决问题，谢谢。";
                    this.btnReStart.Visible = true;
                }
                else
                {
                    this.Text = "应用程序异常";
                    this.lbNote.Text = "很抱歉，我们遇到了尚未能处理的异常。异常信息显示在下面，请将这些信息连同关于您的操作的描述一起反馈给我们以帮助我们解决问题，谢谢。";
                    this.btnReStart.Visible = false;
                }

                this.rtbErrors.Text = "正在收集异常信息，请稍等.....";
                this.GenerateReport();
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(this.rtbErrors.Text);
                FormHelper.ShowInfo("异常信息已经成功复制到剪贴板中了。");
            }
            catch (Exception)
            {
                FormHelper.ShowWarning("无法复制异常信息到剪贴板，请手动复制。");
            }
        }

        private void btnReStart_Click(object sender, EventArgs e)
        {
            _isRestart = true;
            System.Diagnostics.Process.Start(Application.ExecutablePath, "restart");
            System.Environment.Exit(Environment.ExitCode);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(Environment.ExitCode);
        }

        private void GenerateReport()
        {
            StringBuilder sb = new StringBuilder();
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.RunWorkerCompleted += delegate (object s, RunWorkerCompletedEventArgs e)
            {
                this.rtbErrors.Text = sb.ToString();
                this.btnCopy.Enabled = true;
            };
            bgw.DoWork += delegate (object s, DoWorkEventArgs e)
            {
                sb.AppendLine("异常信息");
                sb.AppendLine("-----------------------------------------------------");
                sb.AppendLine(this.ExceptionMessage);
                sb.AppendLine();
                sb.AppendLine();
                sb.AppendLine("运行环境");
                sb.AppendLine("-----------------------------------------------------");
                sb.AppendLine("操作系统版本：" + Environment.OSVersion);
                sb.AppendLine("程序运行目录：" + Application.StartupPath);
                sb.AppendLine();
                sb.AppendLine();
                sb.AppendLine("加载模块");
                sb.AppendLine("-----------------------------------------------------");
                Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
                for (int i = 0; i < assemblies.Length; i++)
                {
                    sb.AppendLine(string.Format("[{0}]. {1} , {2}", i.ToString("000"), assemblies[i].FullName, assemblies[i].Location));
                }
            };
            bgw.RunWorkerAsync();
        }

        /// <summary>
        /// 附加到主程序中
        /// </summary>
        public static void Attach()
        {
            if (!_attached)
            {
                lock (_lockObj)
                {
                    if (_attached)
                    {
                        return;
                    }

                    if (SystemInformation.UserInteractive)
                    {
                        var exceptionForm = new ErrorReport();
                        Int32 threadId = Thread.CurrentThread.ManagedThreadId;
                        Action<String, Boolean> exceptionHander = (String errorMessage, Boolean forceRestart) =>
                        {
                            //当错误不是主线程产生的时候 必须要重启程序
                            forceRestart = threadId != Thread.CurrentThread.ManagedThreadId || forceRestart;
                            exceptionForm.ExceptionMessage = errorMessage;
                            exceptionForm.NeedRestart = forceRestart;
                            exceptionForm.ShowDialog();
                        };

                        //附加到线程异常事件
                        Application.ThreadException += delegate (object s, ThreadExceptionEventArgs e)
                        {
                            exceptionHander(e.Exception.ToString(), false);
                        };

                        //附加到未处理异常事件
                        AppDomain.CurrentDomain.UnhandledException += delegate (object d, UnhandledExceptionEventArgs f)
                        {
                            Exception ex = f.ExceptionObject as Exception;
                            if (ex != null)
                            {
                                exceptionHander(ex.ToString(), false);
                            }
                        };

                        _attached = true;
                    }
                }
            }
        }
    }
}
