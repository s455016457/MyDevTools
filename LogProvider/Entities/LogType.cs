using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogProvider.Entities
{
    /// <summary>
    /// 日志类型
    /// </summary>
    public class LogType
    {
        /// <summary>
        /// 异常
        /// </summary>
        public const String Exception = "Error";
        /// <summary>
        /// 跟踪
        /// </summary>
        public const String ApplicationTack = "Tack";

        public String Type { get; internal set; }
    }
}
