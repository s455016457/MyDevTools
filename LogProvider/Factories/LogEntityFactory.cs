using LogProvider.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogProvider.Extended;

namespace LogProvider.Factories
{
    /// <summary>
    /// 日志实体工厂
    /// </summary>
    public class LogEntityFactory
    {
        /// <summary>
        /// 创建异常实体
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static LogEntity Create(Exception ex)
        {
            StringBuilder logTrackInfo = new StringBuilder();
            logTrackInfo.AppendLine(ex.Source);
            logTrackInfo.AppendLine(ex.HelpLink);
            logTrackInfo.AppendLine(ex.StackTrace);
            logTrackInfo.AppendLine(ex.TargetSite == null ? String.Empty : ex.TargetSite.ToString());

            return Create(logTrackInfo.ToString(), 
                ex.GetMessage(),
                LogTypeFacotry.CreateExceptionLogType(), 
                LogLevelFactory.CreateGravenessLogLevel());
        }

        /// <summary>
        /// 创建日志实体
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="logType">日志类别</param>
        /// <param name="logLevel">日志级别</param>
        /// <returns></returns>
        public static LogEntity Create(String message, LogType logType, LogLevel logLevel)
        {
            return Create(String.Empty, message, logType, logLevel);
        }

        /// <summary>
        /// 创建日志实体
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="logLevel">日志级别</param>
        /// <returns></returns>
        public static LogEntity Create(String message, LogLevel logLevel)
        {
            return Create(message, LogTypeFacotry.CreateApplicationTackLogType(), logLevel);
        }

        /// <summary>
        /// 创建异常日志实体
        /// </summary>
        /// <param name="ex">异常信息</param>
        /// <param name="logLevel">日志级别</param>
        /// <returns></returns>
        public static LogEntity Create(Exception ex, LogLevel logLevel)
        {
            return Create(ex.HelpLink, ex.Message, LogTypeFacotry.CreateExceptionLogType(), logLevel);
        }

        /// <summary>
        /// 创建异常日志实体
        /// </summary>
        /// <param name="ex">异常信息</param>
        /// <param name="logLevel">日志级别</param>
        /// <returns></returns>
        public static LogEntity Create(Exception ex, String logLevel)
        {
            return Create(ex, new LogLevel { Level = logLevel });
        }


        /// <summary>
        /// 创建日志实体
        /// </summary>
        /// <param name="logTrackInfo">日志跟踪信息</param>
        /// <param name="message">日志信息</param>
        /// <param name="logType">日志类别</param>
        /// <param name="logLevel">日志级别</param>
        /// <returns></returns>
        public static LogEntity Create(String logTrackInfo, String message, LogType logType, LogLevel logLevel)
        {
            return new LogEntity
            {
                Type = logType,
                Levl = logLevel,
                Content = new LogContent { LogTrackInfo = logTrackInfo, Message = message }
            };
        }
        public static LogEntity Create(String logTrackInfo, String message, String logType, String logLevel)
        {
            return new LogEntity
            {
                Type = new LogType { Type = logType },
                Levl = new LogLevel { Level = logLevel },
                Content = new LogContent { LogTrackInfo = logTrackInfo, Message = message }
            };
        }
    }
}
