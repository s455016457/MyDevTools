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
        protected ICryptor Cryptor;
        protected ISign Sign;
        protected IFileReadWriteHelper FileReadWrite;
        protected ISerializationHelper<PaswordProjectDataStor> SerializationHelper;
        protected PaswordProjectDataStor dataStor;

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

        public void SaveChanges()
        {
            /**
             * 序列化数据
             * 对数据加密
             * 将密文写入文件
             * */
            if (dataStor == null) return;
            String message = SerializationHelper.Serialization(dataStor);
            var bytes = Encryptor(Encoding.UTF8.GetBytes(message));
            FileReadWrite.Write(Convert.ToBase64String(bytes));
        }

        public PaswordProjectDataStor GetPaswordProjectDataStor(String password)
        {
            if (dataStor != null) return dataStor;
            dataStor = new PaswordProjectDataStor();
            dataStor.UpdatePassword(password);
            /**
             * 从文件中获取数据
             * 对数据解密
             * 对数据反序列化
             * */
            String message = FileReadWrite.Read();

            if (message == null || message.Length <= 0) return dataStor;

            var bytes = Decryptor(Convert.FromBase64String(message));

            message = Encoding.UTF8.GetString(bytes);
            dataStor = SerializationHelper.Deserialization(message);

            if (dataStor == null) dataStor = new PaswordProjectDataStor();

            return dataStor;
        }

        protected virtual byte[] Encryptor(byte[] bytes)
        {
            /**
            * 对数据加密
            * 用密码加密数据
            * 对数据签名
            * */
            bytes = Cryptor.Encryptor(bytes);
            bytes = AesCryptoHelper.Encrypt(bytes, GetKeyBytesByPasword(), null);
            bytes = Sign.Sign(bytes, GetSignBytes());
            return bytes;
        }
        protected virtual byte[] Decryptor(byte[] bytes)
        {
            /**
            * 验证签名
            * 用密码解密数据
            * 对数据码解
            * */

            if (!Sign.Verify(bytes, GetSignBytes(), out bytes))
            {
                throw new Exception("密文被篡改！");
            }

            try
            {
                bytes = AesCryptoHelper.Decrypt(bytes, GetKeyBytesByPasword(), null);
            }
            catch (Exception ex)
            {
                throw new Exception("密码不正确！", ex.InnerException);
            }
            bytes= Cryptor.Decryptor(bytes);
            return bytes;
        }

        protected virtual String GetKeyByPasword()
        {
            return dataStor.Password.Length > 32 ? dataStor.Password.Substring(0, 32) : dataStor.Password.PadRight(32, 'A');
        }

        protected virtual byte[] GetKeyBytesByPasword()
        {
            var key = GetKeyByPasword();
            return Encoding.UTF8.GetBytes(key);
        }

        protected virtual String GetSign()
        {
            return Forms.MainForm.Sign.Length > 64
                        ? Forms.MainForm.Sign.Substring(0, 64)
                        : Forms.MainForm.Sign.PadRight(64, 'A');
        }

        protected virtual byte[] GetSignBytes()
        {
            var sign = GetSign();
            return Encoding.UTF8.GetBytes(sign);
        }
    }
}
