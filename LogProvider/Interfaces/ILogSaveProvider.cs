using LogProvider.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogProvider.Interfaces
{
    /// <summary>
    /// 日志存储提供程序接口，仅供内部使用
    /// </summary>
    public interface ILogSaveProvider
    {
        /// <summary>
        /// 保存Log
        /// </summary>
        /// <param name="logEntity"></param>
        /// <returns>bool</returns>
        Task<bool> SaveLog(LogEntity logEntity);
    }
}
