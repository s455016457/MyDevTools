using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogProvider.Entities
{
    /// <summary>
    /// 日志实体
    /// </summary>
    public class LogEntity
    {
        /// <summary>
        /// 日志类型
        /// </summary>
        public LogType Type { get; set; }
        /// <summary>
        /// 日志等级
        /// </summary>
        public LogLevel Levl { get; set; }
        /// <summary>
        /// 日志内容
        /// </summary>
        public LogContent Content { get; set; }
    }
}
