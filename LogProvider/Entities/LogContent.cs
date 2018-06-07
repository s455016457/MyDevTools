using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogProvider.Entities
{
    /// <summary>
    /// 日志内容
    /// </summary>
    public class LogContent
    {
        /// <summary>
        /// 跟踪信息，记录次Log的当前程序位置
        /// </summary>
        public String LogTrackInfo { get; set; }

        /// <summary>
        /// Log文本信息
        /// </summary>
        public String Message { get; set; }
    }
}
