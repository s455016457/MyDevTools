using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyDevTools.Plugin.UtilityTools.WebSocket
{

    public delegate void OnWebSocketServiceBeginStart(WebSocketService service, HttpListener httpListener);
    public delegate void OnWebSocketServiceStart(WebSocketService service, HttpListener httpListener);
    public delegate void OnWebSocketServiceStop(WebSocketService service, HttpListener httpListener);
    public delegate void OnWebSocketServiceClose();

    public delegate bool OnAuthentication(HttpListenerContext listenerContext);
    public delegate void OnAddWebSocket(WebSocketContext webSocketContext);
    public delegate void OnRemoveWebSocket(WebSocketContext webSocketContext);
    public class WebSocketService : IDisposable
    {
        /// <summary>
        /// 预留线程数量
        /// 用于程序临时新增的线程使用
        /// 默认值为2
        /// </summary>
        public static int ReservedThreadsCount { get; set; } = 2;
        #region 私有属性
        IList<WebSocketContext> webSocketContexts = new List<WebSocketContext>();
        HttpListener HttpListener = null;
        CancellationTokenSource CancellationTokenSource = new CancellationTokenSource(); //可以更改CancellationToken的状态
        CancellationToken cancellationToken;
        #endregion

        #region 成员属性
        /// <summary>
        /// 监听IP地址
        /// </summary>
        public string Ip { get; private set; }
        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get; private set; }
        /// <summary>
        /// 子协议
        /// </summary>
        public string SubProtocol { get; private set; }
        /// <summary>
        /// WebSocket集合
        /// </summary>
        public IReadOnlyList<WebSocketContext> WebSocketContexts
        {
            get { return webSocketContexts.ToList().AsReadOnly(); }
        }
        #endregion

        #region 事件
        /// <summary>
        /// WebSocket服务启动前触发
        /// </summary>
        public event OnWebSocketServiceBeginStart OnWebSocketServiceBeginStart;
        /// <summary>
        /// WebSocket服务启动后触发
        /// </summary>
        public event OnWebSocketServiceStart OnWebSocketServiceStart;
        /// <summary>
        /// WebSocket服务停止后触发，停止接受传入的请求
        /// </summary>
        public event OnWebSocketServiceStop OnWebSocketServiceStop;
        /// <summary>
        /// WebSocket服务关闭，释放服务资源
        /// </summary>
        public event OnWebSocketServiceClose OnWebSocketServiceClose;
        /// <summary>
        /// 当服务管理的WebSocket接收到消息时触发
        /// </summary>
        public event OnReceiveMessageHandler OnReceiveMessage;
        /// <summary>
        /// 当服务添加WebSocket时触发
        /// </summary>
        public event OnAddWebSocket OnAddWebSocket;
        /// <summary>
        /// 当服务删除WebSocket时触发
        /// </summary>
        public event OnRemoveWebSocket OnRemoveWebSocket;
        /// <summary>
        /// 身份验证
        /// </summary>
        public event OnAuthentication OnAuthentication;
        #endregion

        #region 构造函数
        /// <summary>
        /// 初始化一个WebSocket服务
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="subProtocol"></param>
        public WebSocketService(string ip, int port, string subProtocol)
        {
            Console.WriteLine($"创建WebSocket服务");
            Console.WriteLine($"当前操作系统【{Environment.OSVersion.VersionString}】");
            Ip = ip;
            Port = port;
            SubProtocol = subProtocol;
            cancellationToken = CancellationTokenSource.Token;
            if (!HttpListener.IsSupported)
                throw new Exception($"操作系统【{Environment.OSVersion.VersionString}】不支持 HTTP 协议侦听器");
            HttpListener = new HttpListener();
            PrintHttpListenerInfo(HttpListener);
            
            Console.WriteLine($"WebSocket服务创建成功");
        }
        #endregion

        #region 成员方法
        public void Start()
        {
            if (HttpListener.IsListening)
            {
                Console.WriteLine("HTTP 协议侦听器已启动");
                return;
            };

            Console.WriteLine("开始启动WebSocket服务");

            HttpListener.Prefixes.Add($"http://{Ip}:{Port}/");
            //HttpListener.Prefixes.Add($"https://{Ip}:{Port}/");

            Console.WriteLine("支持的资源标识符 (URI) 前缀：");
            foreach (var item in HttpListener.Prefixes)
            {
                Console.WriteLine(item);
            }

            if (OnWebSocketServiceBeginStart != null)
                OnWebSocketServiceBeginStart.Invoke(this, HttpListener);

            HttpListener.Start();

            ThreadPool.QueueUserWorkItem(new WaitCallback(p => CreateWebSocket(p as HttpListener)), HttpListener);
            if (OnWebSocketServiceStart != null)
            {
                OnWebSocketServiceStart.Invoke(this, HttpListener);
            }
            Console.WriteLine("服务已启动");
        }

        public void Stop()
        {
            if (!HttpListener.IsListening)
            {
                Console.WriteLine("HTTP 协议侦听器未启动");
                return;
            }
            Console.WriteLine("服务停止，停止接受传入的请求");
            HttpListener.Stop();
            if (OnWebSocketServiceStop != null)
                OnWebSocketServiceStop.Invoke(this, HttpListener);
        }

        public void Close()
        {
            Console.WriteLine("服务关闭，释放服务资源");
            Dispose();
            if (OnWebSocketServiceClose != null)
                OnWebSocketServiceClose.Invoke();
        }

        public void Dispose()
        {
            HttpListener.Stop();
            if (webSocketContexts != null)
            {
                foreach (var item in webSocketContexts)
                {
                    item.Dispose();
                }
            }
            webSocketContexts = null;
            if (CancellationTokenSource != null)
            {
                CancellationTokenSource.Cancel();
                CancellationTokenSource.Dispose();
            }
            if (HttpListener != null)
            {
                HttpListener.Close();
                HttpListener = null;
            }
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 监听端口 创建WebSocket
        /// </summary>
        /// <param name="httpListener"></param>
        private void CreateWebSocket(HttpListener httpListener)
        {
            if (!httpListener.IsListening)
                throw new Exception("HttpListener未启动");
            HttpListenerContext listenerContext = httpListener.GetContext();

            if (OnAuthentication != null)
            {
                foreach (OnAuthentication item in OnAuthentication.GetInvocationList())
                {
                    if (!item.Invoke(listenerContext))
                    {
                        CreateWebSocket(httpListener);
                        return;
                    }
                }
            }

            WebSocketContext webSocket = null;
            try
            {
                webSocket = new WebSocketContext(listenerContext, SubProtocol);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                CreateWebSocket(HttpListener);
                return;
            }

            Console.WriteLine($"成功创建WebSocket：{webSocket.ID}");

            int workerThreads = 0, completionPortThreads = 0;
            ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads);
            if (workerThreads <= ReservedThreadsCount + 1 || completionPortThreads <= ReservedThreadsCount + 1)
            {
                /**
                 * 可用线程小于5
                 * 通知客户端关闭连接
                 * */
                webSocket.CloseAsync(WebSocketCloseStatus.InternalServerError, "可用线程不足，无法连接").Wait();
            }
            else
            {
                if (OnReceiveMessage != null)
                    webSocket.OnReceiveMessage += OnReceiveMessage;
                webSocket.OnCloseWebSocket += WebSocket_OnCloseWebSocket;
                webSocketContexts.Add(webSocket);
                if (OnAddWebSocket != null)
                    OnAddWebSocket.Invoke(webSocket);
                ThreadPool.QueueUserWorkItem(new WaitCallback(p =>
                {
                    (p as WebSocketContext).ReceiveMessageAsync().Wait();
                }), webSocket);

            }

            CreateWebSocket(HttpListener);
        }

        private void WebSocket_OnCloseWebSocket(WebSocketContext context)
        {
            webSocketContexts.Remove(context);
            if (OnRemoveWebSocket != null)
                OnRemoveWebSocket.Invoke(context);
            if (context != null)
                context.Dispose();
        }

        /// <summary>
        /// 打印HttpListener的信息
        /// </summary>
        /// <param name="HttpListener"></param>
        private void PrintHttpListenerInfo(HttpListener HttpListener)
        {
            Console.WriteLine($"资源分区:{HttpListener.Realm}");
            Console.WriteLine($"允许请求在请求队列中停留的时间（以秒为单位）:{HttpListener.TimeoutManager.RequestQueue}");
            Console.WriteLine($"响应的最低发送速率（以每秒字节数为单位）:{HttpListener.TimeoutManager.MinSendBytesPerSecond}");
            Console.WriteLine($"允许空闲连接的时间（以秒为单位）:{HttpListener.TimeoutManager.IdleConnection.TotalSeconds}");
            Console.WriteLine($"允许 HttpListener 分析请求标头的时间（以秒为单位）:{HttpListener.TimeoutManager.HeaderWait.TotalSeconds}");
            Console.WriteLine($"允许请求实体正文到达的时间（以秒为单位）:{HttpListener.TimeoutManager.EntityBody.TotalSeconds}");
            Console.WriteLine($"允许 HttpListener 在保持连接时侦听完实体正文的时间（以秒为单位）:{HttpListener.TimeoutManager.DrainEntityBody.TotalSeconds}");
            Console.WriteLine($"使用 NTLM 时是否需要对使用同一传输控制协议 (TCP) 连接的其他请求进行身份验证:{HttpListener.UnsafeConnectionNtlmAuthentication}");
            Console.WriteLine($"应用程序是否接收 System.Net.HttpListener 向客户端发送响应时发生的异常:{HttpListener.IgnoreWriteExceptions}");
        }
        #endregion
    }

    public delegate void OnReceiveMessageHandler(WebSocketContext context, string message);
    public delegate void OnCloseWebSocket(WebSocketContext context);

    /// <summary>
    /// WebSocket上下文
    /// </summary>
    public class WebSocketContext : IDisposable
    {
        #region 成员属性
        /// <summary>
        /// id
        /// </summary>
        public Guid ID { get; private set; }
        /// <summary>
        /// 编码
        /// </summary>
        public Encoding Encoding { get; private set; }
        public HttpListenerWebSocketContext HttpListenerWebSocketContext { get; private set; }
        /// <summary>
        /// 接收缓冲区的大小（以字节为单位）。
        /// </summary>
        public int ReceiveBufferSize { get; set; } = 1024;
        #endregion

        #region 私有属性
        private CancellationTokenSource CancellationTokenSource = new CancellationTokenSource(); //可以更改CancellationToken的状态
        private CancellationToken cancellationToken;
        #endregion

        #region 事件
        /// <summary>
        /// 当接受到消息时触发
        /// </summary>
        public event OnReceiveMessageHandler OnReceiveMessage;
        public event OnCloseWebSocket OnCloseWebSocket;
        #endregion

        #region 构造函数
        /// <summary>
        /// 初始化WebSocket上下文
        /// </summary>
        /// <param name="listenerContext"></param>
        /// <param name="SubProtocol"></param>
        public WebSocketContext(HttpListenerContext listenerContext, string SubProtocol)
        {
            cancellationToken = CancellationTokenSource.Token;
            ID = listenerContext.Request.RequestTraceIdentifier;
            HttpListenerWebSocketContext = listenerContext.AcceptWebSocketAsync(SubProtocol).Result;
            Encoding = listenerContext.Request.ContentEncoding;
            var charset = listenerContext.Request.Headers["charset"];
            if (charset != null && charset.Length > 0)
            {
                try
                {
                    Encoding = Encoding.GetEncoding(charset);
                }
                catch (ArgumentException ex)
                {
                    CloseAsync(WebSocketCloseStatus.InvalidMessageType, ex.Message).Wait();
                    throw ex;
                }
            }
        }
        #endregion

        #region 成员方法
        /// <summary>
        /// 递归 接收消息
        /// </summary>
        /// <param name="httpListenerWebSocketContext"></param>
        /// <returns></returns>
        public async Task ReceiveMessageAsync()
        {
            System.Net.WebSockets.WebSocket webSocket = HttpListenerWebSocketContext.WebSocket;

            if (webSocket.State != WebSocketState.Open)
                throw new Exception("Http未握手成功，接受消息！");

            var byteBuffer = System.Net.WebSockets.WebSocket.CreateServerBuffer(ReceiveBufferSize);
            WebSocketReceiveResult receiveResult = null;
            try
            {
                receiveResult = await webSocket.ReceiveAsync(byteBuffer, cancellationToken);
            }
            catch (WebSocketException ex)
            {
                if (ex.InnerException is HttpListenerException)
                {
                    Console.WriteLine(ex);
                    await CloseAsync(WebSocketCloseStatus.ProtocolError, "客户端断开连接" + ex.Message);
                    return;
                }
                else
                {
                    Console.WriteLine(ex);
                    await CloseAsync(WebSocketCloseStatus.ProtocolError, "WebSocket 连接异常" + ex.Message);
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                await CloseAsync(WebSocketCloseStatus.ProtocolError, "客户端断开连接" + ex.Message);
                return;
            }
            if (receiveResult.CloseStatus.HasValue)
            {
                Console.WriteLine("接受到关闭消息！");
                await CloseAsync(receiveResult.CloseStatus.Value, receiveResult.CloseStatusDescription);
                return;
            }

            byte[] bytes = new byte[receiveResult.Count];
            Array.Copy(byteBuffer.Array, bytes, bytes.Length);

            string message = Encoding.GetString(bytes);
            Console.WriteLine($"{ID}接收到消息：{message}");

            if (OnReceiveMessage != null)
                OnReceiveMessage.Invoke(this, message);

            if (!cancellationToken.IsCancellationRequested)
                await ReceiveMessageAsync();
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendMessageAsync(string message)
        {
            System.Net.WebSockets.WebSocket webSocket = HttpListenerWebSocketContext.WebSocket;
            var bytes = Encoding.GetBytes(message);
            Console.WriteLine($"{ID}发送消息:{message}");
            await webSocket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Binary, true, cancellationToken);
        }
        /// <summary>
        /// 关闭WebSocket
        /// </summary>
        /// <param name="closeStatus"></param>
        /// <param name="statusDescription"></param>
        /// <returns></returns>
        public async Task CloseAsync(WebSocketCloseStatus closeStatus, string statusDescription)
        {
            if (HttpListenerWebSocketContext.WebSocket.State == WebSocketState.Open || HttpListenerWebSocketContext.WebSocket.State == WebSocketState.CloseReceived)
            {
                string message = statusDescription;
                message = message.Length > 61 ? message.Substring(0, 61) : message;
                Console.WriteLine($"{ID}关闭WebSocket");
                await HttpListenerWebSocketContext.WebSocket.CloseAsync(closeStatus, message, cancellationToken);
            }
            CancellationTokenSource.Cancel();
            if (OnCloseWebSocket != null)
                OnCloseWebSocket.Invoke(this);
        }
        /// <summary>
        /// 释放WebSocket的资源
        /// </summary>
        public void Dispose()
        {
            if (HttpListenerWebSocketContext.WebSocket.State == WebSocketState.Open)
            {
                CloseAsync(WebSocketCloseStatus.EndpointUnavailable, "服务器正在关闭").Wait();
            }
            CancellationTokenSource.Cancel();
            CancellationTokenSource.Dispose();
        }
        #endregion
    }
}
