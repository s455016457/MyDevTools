using System;
using System.Collections.Generic;
using LogProvider.Interfaces;
using LogProvider;
using LogProvider.Factories;

namespace MyDevTools.Plugin.UtilityTools.Utility.Impl
{
    public class AESCryptor : ICryptor
    {
        private static ILogSaveProvider log = new LogSaveLocalhostProvider();

        IFileReadWriteHelper FileReadWrite;
        ISerializationHelper<KeyValuePair<String, String>> SerializationHelper;
        private KeyValuePair<String,String> Key;

        /// <summary>
        /// 秘钥加密秘钥，用于加密用户秘钥
        /// </summary>
        const String keyEncryptorKey = "FAGVM6OPE0UU7L7SMN5I1JDTSHE3L5WO";

        public AESCryptor(ISerializationHelper<KeyValuePair<String, String>> serializationHelper, IFileReadWriteHelper fileReadWrite)
        {
            SerializationHelper = serializationHelper;
            FileReadWrite = fileReadWrite;
            initKey();
        }

        private void initKey()
        {
            try
            {
                /**
                 * 获取秘钥
                 * 没有秘钥则产生一对秘钥，并用非明文方式保存秘钥
                 * */
                String strKey = FileReadWrite.Read();
                if (String.IsNullOrEmpty(strKey))
                {
                    Key = AesCryptoHelper.CreateKeyAndIv();
                    strKey = SerializationHelper.Serialization(Key);
                    strKey = AesCryptoHelper.Encrypt(strKey, keyEncryptorKey);
                    FileReadWrite.Write(strKey);
                }
                else
                {
                    strKey = AesCryptoHelper.Decrypt(strKey, keyEncryptorKey);
                    Key = SerializationHelper.Deserialization(strKey);
                }
            }
            catch (Exception ex)
            {
                var entity = LogEntityFactory.Create(String.Format("秘钥初始化失败:{0}", ex.ToString()),
                      LogTypeFacotry.CreateExceptionLogType(),
                      LogLevelFactory.CreateGravenessLogLevel());
                log.SaveLog(entity);
                throw new Exception("秘钥初始化失败，秘钥文件被破坏！");
            }
        }

        public string Decryptor(string encrypted)
        {
            return AesCryptoHelper.Decrypt(encrypted, Key.Key, Key.Value);
        }

        public string Encryptor(string message)
        {
            return AesCryptoHelper.Encrypt(message, Key.Key, Key.Value);
        }        
    }
}
