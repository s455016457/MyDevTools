using LogProvider.Entities;
using LogProvider.Interfaces;
using System.Threading.Tasks;

namespace LogProvider.Abstract
{
    /// <summary>
    /// 提供程序基类，实现部分保存功能的抽象类
    /// </summary>
    public abstract class LogSaveBaseProvider : ILogSaveProvider
    {
        /// <summary>
        /// 保存日志
        /// </summary>
        /// <param name="logEntity"></param>
        /// <returns></returns>
        public async Task<bool> SaveLog(LogEntity logEntity)
        {
            if (!ValidatorLogEntity(logEntity)) return false;

            if (!IsSaveLogWithConfiguration(logEntity)) return false;

            FormatLogConten(logEntity);

            return await Task.Factory.StartNew(() => DoSaveLog(logEntity));
        }

        /// <summary>
        /// 保存日志
        /// </summary>
        /// <param name="logEntity"></param>
        /// <returns></returns>
        public abstract bool DoSaveLog(LogEntity logEntity);

        /// <summary>
        /// 判断此Log是否是配置文件中配置需要保存的类型
        /// </summary>
        /// <param name="logEntity"></param>
        /// <returns></returns>
        public virtual bool IsSaveLogWithConfiguration(LogEntity logEntity)
        {
            // 读取配置文件，判断日志是否是可保存类型
            return true;
        }

        /// <summary>
        /// 验证日志实体是否有效
        /// </summary>
        /// <param name="logEntity"></param>
        /// <returns></returns>
        public virtual bool ValidatorLogEntity(LogEntity logEntity)
        {
            /*
            Boolean b = true;
            b &= logEntity != null;
            b &= logEntity.Type != null;
            b &= logEntity.Content != null;
            b &= logEntity.Levl != null;
            return b;
            */
            return logEntity != null
                && logEntity.Type != null
                && logEntity.Content != null
                && logEntity.Levl != null;
        }

        /// <summary>
        /// 格式化Log实体中的信息内容
        /// </summary>
        /// <param name="logEntity"></param>
        /// <returns></returns>
        public virtual void FormatLogConten(LogEntity logEntity)
        {
            //对日志进行格式化
        }
    }
}
