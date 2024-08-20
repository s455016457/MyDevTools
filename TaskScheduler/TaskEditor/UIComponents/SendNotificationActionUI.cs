using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Microsoft.Win32.TaskScheduler.UIComponents
{
    [DefaultEvent("KeyValueChanged"), DefaultProperty("Action")]
    public partial class SendNotificationActionUI : UserControl, IActionHandler
    {
        private string workingDirectory = string.Empty;
        public SendNotificationActionUI()
        {
            InitializeComponent();
            workingDirectory = Path.Combine(new FileInfo(Application.ExecutablePath).Directory.FullName,"可执行文件", "ToastContentConsole");
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Action Action
        {
            get { return new ExecAction("ToastContentConsole.exe", $"ShowNotification -m {msgMsgText.Text} -t {msgTitleText.Text}", workingDirectory); }
            set
            {
                var ma = value as ExecAction;
                if (ma == null) return;

                var match = System.Text.RegularExpressions.Regex.Match(ma.Arguments, "^ShowNotification -m (?<m>[^']*) -t (?<t>[^']*);?\\s*$");
                msgMsgText.Text = match.Groups["m"].Success ? match.Groups["m"].Value : null;
                msgTitleText.Text = match.Groups["t"].Success ? match.Groups["t"].Value : null;
            }
        }

        public bool CanValidate => msgMsgText.TextLength > 0;

        public event EventHandler KeyValueChanged;

        public void Run()
        {
            var p = new Process();
            p.StartInfo.FileName = Path.Combine(workingDirectory, "ToastContentConsole.exe");
            p.StartInfo.Arguments = $"ShowNotification -m {msgMsgText.Text} -t {msgTitleText.Text}";
            p.Start();
        }

        public bool ValidateFields() => true;

        private void msgMsgText_TextChanged(object sender, EventArgs e)
        {
            KeyValueChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
