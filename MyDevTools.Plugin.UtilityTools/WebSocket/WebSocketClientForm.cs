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
using System.Net.WebSockets;
using System.Threading;

namespace MyDevTools.Plugin.UtilityTools.WebSocket
{
    public partial class WebSocketClientForm : Form
    {
        WebSocketClient _WebSocketClient;
        StringWriter stringWriter = new StringWriter();
        public WebSocketClientForm()
        {
            InitializeComponent();
            //Console.SetOut(stringWriter);
            //Timer timer = new Timer();
            //timer.Interval = 500;
            //timer.Tick += Timer_Tick;
            //timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            string value = stringWriter.ToString();
            if (value.Length > richTextBox_Log.MaxLength)
                value = value.Substring(value.Length - richTextBox_Log.MaxLength, richTextBox_Log.MaxLength);
            richTextBox_Log.Text = value;
            richTextBox_Log.SelectionStart = richTextBox_Log.TextLength;
        }

        private void textBox_Port_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 非数字输入
            if (57 < e.KeyChar || e.KeyChar < 48)
            {
                // 停止将字符输入控件，因为它是非数值的。
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private async void btnOpen_ClickAsync(object sender, EventArgs e)
        {
            btnOpen.Enabled = false;
            string ip = textBox_Ip.Text;
            string port = textBox_Port.Text;
            string subProtocol = textBox_SubProtocol.Text;

            errorProvider1.Clear();

            if (string.IsNullOrEmpty(ip))
            {
                errorProvider1.SetError(textBox_Ip, "请输入服务监控的IP");
                btnOpen.Enabled = true;
                return;
            }
            if (string.IsNullOrEmpty(port))
            {
                errorProvider1.SetError(textBox_Port, "请输入服务监控的端口");
                btnOpen.Enabled = true;
                return;
            }

            _WebSocketClient = new WebSocketClient("聊天", ip, int.Parse(port), subProtocol);

            var options = _WebSocketClient.ClientWebSocket.Options;
            foreach (DataGridViewRow row in dataGrid_RequestHead.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString().Length > 0)
                    options.SetRequestHeader(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
            }

            options.Cookies = new System.Net.CookieContainer();
                Uri uri = new Uri($"ws://{ip}:{port}/");
            foreach (DataGridViewRow row in dataGrid_RequestCookie.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString().Length > 0)
                    options.Cookies.Add(uri, new System.Net.Cookie(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString()));
            }
            _WebSocketClient.OnReceiveMessage += _WebSocketClient_OnReceiveMessage;
            await _WebSocketClient.OpenAsync();
            ThreadPool.QueueUserWorkItem(new WaitCallback(p => {
                (p as WebSocketClient).ReceiveMessageAsync().Wait();
            }), _WebSocketClient);
        }

        private void _WebSocketClient_OnReceiveMessage(WebSocketClient webSocketClient, string message)
        {
            Console.WriteLine($"接收到消息：{message}");
            richTextBox_Log.AppendText ($"接收到消息：{message}{System.Environment.NewLine}");
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (textBox_Send.Text.Length <= 0) return;
            await _WebSocketClient.SendMassage(textBox_Send.Text);
        }
    }
}
