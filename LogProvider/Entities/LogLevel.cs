using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogProvider.Entities
{
    /// <summary>
    /// 日志级别
    /// </summary>
    public class LogLevel
    {
        /// <summary>
        /// 警告
        /// </summary>
        public const String Warning = "Warning";

        /// <summary>
        /// 严重、需立即处理
        /// </summary>
        public const String Graveness = "Graveness";

        /// <summary>
        /// 日志级别
        /// </summary>
        public String Level { get; internal set; }
    }
}
