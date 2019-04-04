using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDevTools
{
    static class Program
    {
        private const String appIdentifier = "{A9A11995-1570-4CDE-8EF0-17488D77629D}";

        /// <summary>
        /// 应用程序的主入口点。 单线程
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                bool createdNew = false;
                ErrorReport.Attach();
                using (Mutex mutext = new Mutex(true, appIdentifier, out createdNew))
                {
                    if (createdNew)
                    {
                        Application.Run(new Form1());
                        mutext.ReleaseMutex();
                    }
                    else
                    {
                        MessageBox.Show("已经有一个实例在运行了！", "温馨提示");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
                var b = new LogProvider.LogSaveLocalhostProvider()
                    .SaveLog(LogProvider.Factories.LogEntityFactory.Create(ex))
                    .Result;
            }
        }
    }
}
