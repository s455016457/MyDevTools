using System;
using System.IO;
using System.Runtime.InteropServices;

namespace MyDevTools.Plugin.UtilityTools.Utility
{
    /// <summary>
    /// 相机
    /// </summary>
    public class CamWorker
    {
        #region 成员属性
        /// <summary>
        /// 要显示的宽度
        /// </summary>
        public int Width { get; private set; }
        /// <summary>
        /// 要显示的高度
        /// </summary>
        public int Height { get; private set; }
        /// <summary>
        /// 左边距离
        /// </summary>
        public int Left { get; private set; }
        /// <summary>
        /// 顶部距离
        /// </summary>
        public int Top { get; private set; }

        /// <summary>
        /// 相机已打开
        /// </summary>
        public bool IsOpen { get; private set; } = false;
        #endregion

        #region 私有属性
        private IntPtr hWndC;
        private IntPtr mControlPtr;

        private const int WM_USER = 0x400;
        private const int WS_CHILD = 0x40000000;
        private const int WS_VISIBLE = 0x10000000;
        private const int WM_CAP_START = WM_USER;
        private const int WM_CAP_STOP = WM_CAP_START + 68;
        private const int WM_CAP_DRIVER_CONNECT = WM_CAP_START + 10;
        private const int WM_CAP_DRIVER_DISCONNECT = WM_CAP_START + 11;
        private const int WM_CAP_SAVEDIB = WM_CAP_START + 25;
        private const int WM_CAP_GRAB_FRAME = WM_CAP_START + 60;
        private const int WM_CAP_SEQUENCE = WM_CAP_START + 62;
        private const int WM_CAP_FILE_SET_CAPTURE_FILEA = WM_CAP_START + 20;
        private const int WM_CAP_SEQUENCE_NOFILE = WM_CAP_START + 63;
        private const int WM_CAP_SET_OVERLAY = WM_CAP_START + 51;
        private const int WM_CAP_SET_PREVIEW = WM_CAP_START + 50;
        private const int WM_CAP_SET_CALLBACK_VIDEOSTREAM = WM_CAP_START + 6;
        private const int WM_CAP_SET_CALLBACK_ERROR = WM_CAP_START + 2;
        private const int WM_CAP_SET_CALLBACK_STATUSA = WM_CAP_START + 3;
        private const int WM_CAP_SET_CALLBACK_FRAME = WM_CAP_START + 5;
        private const int WM_CAP_SET_SCALE = WM_CAP_START + 53;
        private const int WM_CAP_SET_PREVIEWRATE = WM_CAP_START + 52;
        #endregion

        #region 构造函数
        /// <summary>
        /// 初始化相机
        /// </summary>
        /// <param name= "handle "> 控件的句柄 </param>
        /// <param name= "left "> 开始显示的左边距 </param>
        /// <param name= "top "> 开始显示的上边距 </param>
        /// <param name= "width "> 要显示的宽度 </param>
        /// <param name= "height "> 要显示的长度 </param>
        public CamWorker(IntPtr handle, int left, int top, int width, int height)
        {
            mControlPtr = handle;
            Width = width;
            Height = height;
            Left = left;
            Top = top;
        }
        #endregion

        #region 成员方法
        /// <summary>
        /// 打开相机
        /// </summary>
        public void Open()
        {
            if (IsOpen)
                return;

            IsOpen = true;
            byte[] lpszName = new byte[100];

            hWndC = capCreateCaptureWindowA(lpszName, WS_CHILD | WS_VISIBLE, Left, Top, Width, Height, mControlPtr, 0);

            if (hWndC.ToInt32() != 0)
            {
                SendMessage(hWndC, WM_CAP_SET_CALLBACK_VIDEOSTREAM, 0, 0);
                SendMessage(hWndC, WM_CAP_SET_CALLBACK_ERROR, 0, 0);
                SendMessage(hWndC, WM_CAP_SET_CALLBACK_STATUSA, 0, 0);
                SendMessage(hWndC, WM_CAP_DRIVER_CONNECT, 0, 0);
                SendMessage(hWndC, WM_CAP_SET_SCALE, 1, 0);
                SendMessage(hWndC, WM_CAP_SET_PREVIEWRATE, 66, 0);
                SendMessage(hWndC, WM_CAP_SET_OVERLAY, 1, 0);
                SendMessage(hWndC, WM_CAP_SET_PREVIEW, 1, 0);
                //Global.log.Write( “SendMessage “);
            }
            return;

        }


        /// <summary>
        /// 关闭相机
        /// </summary>
        public void Close()
        {
            SendMessage(hWndC, WM_CAP_DRIVER_DISCONNECT, 0, 0);
            IsOpen = false;
        }

        /// <summary>
        /// 拍照
        /// </summary>
        /// <param name= “path “> 照片要存的地址 </param>
        /// <returns>照片地址</returns>
        public string TakePhotos(string path)
        {
            if (!Directory.Exists(path))
                throw new Exception($"文件夹路径【{path}】不存在！");

            string bmpPath = Path.Combine(path, Guid.NewGuid() + ".bmp");

            IntPtr hBmp = Marshal.StringToHGlobalAnsi(bmpPath);
            SendMessage(hWndC, WM_CAP_SAVEDIB, 0, hBmp.ToInt32());
            return bmpPath;
        }

        #endregion

        #region 非托管动态链接库静态入口
        /// <summary>
        /// cap创建窗口捕获
        /// </summary>
        /// <param name="lpszWindowName">lpsz窗口名称</param>
        /// <param name="dwStyle">dw类别</param>
        /// <param name="x">x轴</param>
        /// <param name="y">y轴</param>
        /// <param name="nWidth">宽度</param>
        /// <param name="nHeight">高度</param>
        /// <param name="hWndParent">窗口父指针</param>
        /// <param name="nID">ID</param>
        /// <returns></returns>
        [DllImport("avicap32.dll ")]        
        private static extern IntPtr capCreateCaptureWindowA(byte[] lpszWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, int nID);

        /// <summary>
        /// cap获取视频格式
        /// </summary>
        /// <param name="hWnd">指针</param>
        /// <param name="psVideoFormat">视频格式</param>
        /// <param name="wSize">窗口大小</param>
        /// <returns></returns>
        [DllImport("avicap32.dll ")]
        private static extern int capGetVideoFormat(IntPtr hWnd, IntPtr psVideoFormat, int wSize);

        /// <summary>
        /// 发送消息 
        /// 这里特别注意，因为WinAPI中的long为32位，而C#中的long为64位，所以需要将lParam该为int
        /// </summary>
        /// <param name="hWnd">指针</param>
        /// <param name="wMsg">消息</param>
        /// <param name="wParam">参数</param>
        /// <param name="lParam">参数</param>
        /// <returns></returns>
        [DllImport("User32.dll ")]
        private static extern bool SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion
    }
}
