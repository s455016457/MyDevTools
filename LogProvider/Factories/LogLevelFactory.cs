using LogProvider.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogProvider.Factories
{
    public class LogLevelFactory
    {
        /// <summary>
        /// 警告
        /// </summary>
        /// <returns></returns>
        public static LogLevel CreateWarningLogLevel()
        {
            return new LogLevel { Level = LogLevel.Warning };
        }
        /// <summary>
        /// 严重、需立即处理
        /// </summary>
        /// <returns></returns>
        public static LogLevel CreateGravenessLogLevel()
        {
            return new LogLevel { Level = LogLevel.Graveness };
        }
    }
}
