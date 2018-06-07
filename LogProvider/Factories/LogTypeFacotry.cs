using LogProvider.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogProvider.Factories
{
    /// <summary>
    /// 日志类别工程类
    /// </summary>
    public class LogTypeFacotry
    {
        /// <summary>
        /// 创建异常日志类型
        /// </summary>
        /// <returns></returns>
        public static LogType CreateExceptionLogType()
        {
            return new LogType() { Type = LogType.Exception };
        }

        /// <summary>
        /// 创建应用程序跟踪日志类型
        /// </summary>
        /// <returns></returns>
        public static LogType CreateApplicationTackLogType()
        {
            return new LogType() { Type = LogType.ApplicationTack };
        }
    }
}
