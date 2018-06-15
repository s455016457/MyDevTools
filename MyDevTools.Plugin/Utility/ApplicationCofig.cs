using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyDevTools.Plugin.Utility
{
    /// <summary>
    /// 应用程序配置
    /// </summary>
    public class ApplicationCofig
    {
        /// <summary>
        /// 应用程序数据文件夹目录
        /// </summary>
        public static readonly String AppDataDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AppData");
        /// <summary>
        /// 应用程序配置文件夹目录
        /// </summary>
        public static readonly String ConfigDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config");
        /// <summary>
        /// 应用程序日志文件夹目录
        /// </summary>
        public static readonly String LogDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
        /// <summary>
        /// 应用程序插件文件夹目录
        /// </summary>
        public static readonly String PluginsDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");
    }
}
