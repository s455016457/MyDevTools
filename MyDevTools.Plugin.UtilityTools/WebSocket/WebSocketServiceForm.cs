using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDevTools.Plugin.UtilityTools.WebSocket
{
    public partial class WebSocketServiceForm : Form
    {
        bool serverIsStart = false;
        WebSocketService WebSocketService = null;
        StringWriter stringWriter = new StringWriter();
        public WebSocketServiceForm()
        {
            InitializeComponent();
            setButton1Text();
            Console.SetOut(stringWriter);
            Timer timer = new Timer();
            timer.Interval = 500;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            string value = stringWriter.ToString();
            if (value.Length > richTextBox_Log.MaxLength)
                value = value.Substring(value.Length - richTextBox_Log.MaxLength, richTextBox_Log.MaxLength);
            richTextBox_Log.Text = value;
            richTextBox_Log.SelectionStart = richTextBox_Log.TextLength;
        }

        private void setButton1Text()
        {
            button1.Text = serverIsStart ? "停止" : "开启";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            string ip = textBox_Ip.Text;
            string port = textBox_Port.Text;
            string subProtocol = textBox_SubProtocol.Text;

            errorProvider1.Clear();

            if (string.IsNullOrEmpty(ip))
            {
                errorProvider1.SetError(textBox_Ip, "请输入服务监控的IP");
                button1.Enabled = true;
                return;
            }
            if(string.IsNullOrEmpty(port))
            {
                errorProvider1.SetError(textBox_Port, "请输入服务监控的端口");
                button1.Enabled = true;
                return;
            }


            if (!serverIsStart)
            {
                WebSocketService = new WebSocketService(ip, int.Parse(port), subProtocol);
                WebSocketService.OnAddWebSocket += WebSocketService_OnAddWebSocket;
                WebSocketService.OnAuthentication += WebSocketService_OnAuthentication;
                WebSocketService.OnReceiveMessage += WebSocketService_OnReceiveMessage;
                WebSocketService.OnRemoveWebSocket += WebSocketService_OnRemoveWebSocket;
                WebSocketService.OnWebSocketServiceBeginStart += WebSocketService_OnWebSocketServiceBeginStart;
                WebSocketService.OnWebSocketServiceClose += WebSocketService_OnWebSocketServiceClose;
                WebSocketService.OnWebSocketServiceStart += WebSocketService_OnWebSocketServiceStart;
                WebSocketService.OnWebSocketServiceStop += WebSocketService_OnWebSocketServiceStop;
                WebSocketService.Start();
            }
            else
            {
                WebSocketService.Dispose();
                WebSocketService = null;
            }

            serverIsStart = !serverIsStart;
            setButton1Text();
            button1.Enabled = true;
        }

        private void WebSocketService_OnWebSocketServiceStop(WebSocketService service, System.Net.HttpListener httpListener)
        {
            Console.WriteLine("服务停止");
        }

        private void WebSocketService_OnWebSocketServiceStart(WebSocketService service, System.Net.HttpListener httpListener)
        {
            Console.WriteLine("服务开启");
        }

        private void WebSocketService_OnWebSocketServiceClose()
        {
            Console.WriteLine("服务关闭");
        }

        private void WebSocketService_OnWebSocketServiceBeginStart(WebSocketService service, System.Net.HttpListener httpListener)
        {
            Console.WriteLine("服务准备开启");
        }

        private void WebSocketService_OnRemoveWebSocket(WebSocketContext webSocketContext)
        {
            Console.WriteLine("WebSocketService_OnRemoveWebSocket");
        }

        private void WebSocketService_OnReceiveMessage(WebSocketContext context, string message)
        {
            Console.WriteLine($"服务器接收到消息：{message}");
            context.SendMessageAsync($"服务器接收到消息：{message}").Wait();
        }

        private bool WebSocketService_OnAuthentication(System.Net.HttpListenerContext listenerContext)
        {
            Console.WriteLine("身份验证");
            return true;
        }

        private void WebSocketService_OnAddWebSocket(WebSocketContext webSocketContext)
        {
            if (webSocketContext.HttpListenerWebSocketContext.Headers != null)
            {
                Console.WriteLine("获取到请求头：");
                foreach (var key in webSocketContext.HttpListenerWebSocketContext.Headers.AllKeys)
                {
                    Console.WriteLine($"Key: {key}  Value:{webSocketContext.HttpListenerWebSocketContext.Headers[key]}");
                }
            }
            if (webSocketContext.HttpListenerWebSocketContext.CookieCollection != null)
            {
                Console.WriteLine("获取到cookie：");
                foreach(Cookie cookie in webSocketContext.HttpListenerWebSocketContext.CookieCollection)
                {
                    Console.WriteLine($"Name:{cookie.Name}  Value:{cookie.Value}  Domain:{cookie.Domain}");
                }
            }
            Console.WriteLine("添加WebSocket");
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
    }
}
