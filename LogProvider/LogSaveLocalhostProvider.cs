using LogProvider.Abstract;
using LogProvider.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogProvider
{
    /// <summary>
    /// 日志本地存储
    /// </summary>
    public class LogSaveLocalhostProvider : LogSaveBaseProvider
    {
        LogHelper log = LogHelper.Create();
        public override bool DoSaveLog(LogEntity logEntity)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("日志类型："+logEntity.Type.Type);
            stringBuilder.AppendLine("日志等级：" + logEntity.Levl.Level);
            stringBuilder.AppendLine("日志信息："+logEntity.Content.Message);
            stringBuilder.AppendLine("跟踪信息：" + logEntity.Content.LogTrackInfo);

            if (logEntity.Type.Type.Equals(LogType.Exception))
                log.WriteErrorLog(stringBuilder.ToString());
            else
                log.WriteLog(stringBuilder.ToString());

            return true;
        }
    }
}
