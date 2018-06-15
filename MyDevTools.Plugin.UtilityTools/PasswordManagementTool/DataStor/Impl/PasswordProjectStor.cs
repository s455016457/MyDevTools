using LogProvider;
using LogProvider.Factories;
using LogProvider.Interfaces;
using MyDevTools.Plugin.UtilityTools.PasswordManagementTool.Entity;
using MyDevTools.Plugin.UtilityTools.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDevTools.Plugin.UtilityTools.PasswordManagementTool.DataStor.Impl
{
    public class PasswordProjectStor: IPasswordProjectStor
    {
        private static ILogSaveProvider log = new LogSaveLocalhostProvider();
        /**
         * 加密方式的实现
         * public PasswordProjectStor(加密方式的实现,数据保存方式的实现){}
         * */
        private ICryptor Cryptor;
        private IFileReadWriteHelper FileReadWrite;
        private ISerializationHelper<List<PassworkProject>> SerializationHelper;

        public PasswordProjectStor(ISerializationHelper<List<PassworkProject>> serializationHelper,ICryptor cryptor, IFileReadWriteHelper fileReadWrite)
        {
            SerializationHelper = serializationHelper;
            Cryptor = cryptor;
            FileReadWrite = fileReadWrite;
        }

        public void SaveChanges(List<PassworkProject> PassworkProjects)
        {
            /**
             * 序列化数据
             * 对数据加密
             * 将数据保存进文件
             * */
            if (PassworkProjects == null) return;
            String message = SerializationHelper.Serialization(PassworkProjects);
            if (message == null || message.Length <= 0) return;
            message = Cryptor.Encryptor(message);
            FileReadWrite.Write(message);
        }

        public List<PassworkProject> GetPassworkProjects()
        {
            /**
             * 从文件中获取数据
             * 对数据解密
             * 对数据反序列化
             * */
            String message = FileReadWrite.Read();
            if (message == null || message.Length <= 0) return null;
            //var entity = LogEntityFactory.Create(String.Format("获取数据{0}", message),
            //            LogTypeFacotry.CreateApplicationTackLogType(),
            //            LogLevelFactory.CreateWarningLogLevel());
            //log.SaveLog(entity);
            message = Cryptor.Decryptor(message);
            if (message == null || message.Length <= 0) return null;
            //entity = LogEntityFactory.Create(String.Format("解密数据{0}", message),
            //            LogTypeFacotry.CreateApplicationTackLogType(),
            //            LogLevelFactory.CreateWarningLogLevel());
            //log.SaveLog(entity);
            return SerializationHelper.Deserialization(message);
        }
    }
}
