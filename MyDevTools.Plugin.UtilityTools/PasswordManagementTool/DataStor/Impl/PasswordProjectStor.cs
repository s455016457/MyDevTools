using LogProvider;
using LogProvider.Interfaces;
using MyDevTools.Plugin.UtilityTools.PasswordManagementTool.Entity;
using MyDevTools.Plugin.UtilityTools.Utility;
using System;
using System.Text;

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
        private ISign Sign;
        private IFileReadWriteHelper FileReadWrite;
        private ISerializationHelper<PaswordProjectDataStor> SerializationHelper;

        public PasswordProjectStor(ISerializationHelper<PaswordProjectDataStor> serializationHelper
            , ICryptor cryptor
            , ISign sign
            , IFileReadWriteHelper fileReadWrite)
        {
            SerializationHelper = serializationHelper;
            Cryptor = cryptor;
            Sign = sign;
            FileReadWrite = fileReadWrite;
        }

        public void SaveChanges(PaswordProjectDataStor dataStor,String sign)
        {
            /**
             * 序列化数据
             * 对数据加密
             * 对数据签名
             * 将数据保存进文件
             * */
            if (dataStor == null) return;
            String message = SerializationHelper.Serialization(dataStor);
            if (message == null || message.Length <= 0) return;
            var bytes = Cryptor.Encryptor(Encoding.UTF8.GetBytes(message));

            String key = sign.Length > 64
                        ? sign.Substring(0, 64)
                        : sign.PadRight(64, '0');

            bytes = Sign.Sign(bytes, Encoding.UTF8.GetBytes(key));

            FileReadWrite.Write(Convert.ToBase64String(bytes));
        }

        public PaswordProjectDataStor GetPaswordProjectDataStor(String sign)
        {
            /**
             * 从文件中获取数据
             * 验证签名
             * 对数据解密
             * 对数据反序列化
             * */
            String message = FileReadWrite.Read();
            if (message == null || message.Length <= 0) return null;

            String key = sign.Length > 64
                        ? sign.Substring(0, 64)
                        : sign.PadRight(64,'0');
            byte[] outBytes;

            if (!Sign.Verify(Convert.FromBase64String(message), Encoding.UTF8.GetBytes(key), out outBytes))
            {
                throw new Exception("密码数据文件被篡改！");
            }

            var bytes = Cryptor.Decryptor(outBytes);

            message = Encoding.UTF8.GetString(bytes);
            return SerializationHelper.Deserialization(message);
        }
    }
}
