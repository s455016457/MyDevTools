using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace MyDevTools.Plugin.EncryptionTools.Cryptos
{
    public class RC2Crypto
    {
        /// <summary>
        /// 创建秘钥
        /// </summary>
        /// <returns></returns>
        public static KeyValuePair<String, String> CreateKey()
        {
            //创建RC2算法服务提供类
            using (RC2CryptoServiceProvider rC2Crypto = new RC2CryptoServiceProvider())
            {
                return new KeyValuePair<string, string>(Convert.ToBase64String(rC2Crypto.Key), Convert.ToBase64String(rC2Crypto.IV));
            }
        }

        /// <summary>
        /// 创建秘钥
        /// </summary>
        /// <returns></returns>
        public static String CreateKeyNoIv()
        {
            return CryptoTransform.CreateKey(16);
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="input">明文</param>
        /// <param name="Key">秘钥 Base64字符串</param>
        /// <returns>密文 Base64字符串</returns>
        public static String Encryptor(String input, String key)
        {
            return Encryptor(input, Convert.FromBase64String(key), null);
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="input">明文</param>
        /// <param name="Key">秘钥 Base64字符串</param>
        /// <param name="Iv">偏移量 Base64字符串</param>
        /// <returns>密文 Base64字符串</returns>
        public static String Encryptor(String input, String Key, String Iv)
        {
            return Encryptor(input, Convert.FromBase64String(Key), Convert.FromBase64String(Iv));
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="input">明文</param>
        /// <param name="Key">秘钥</param>
        /// <param name="Iv">偏移量</param>
        /// <returns>密文 Base64字符串</returns>
        public static String Encryptor(String input, byte[] Key, byte[] Iv)
        {
            using (MemoryStream inputStream = new MemoryStream(Encoding.UTF8.GetBytes(input)))
            {
                Stream outStream = new MemoryStream();
                try
                {
                    Encryptor(inputStream, Key, Iv, ref outStream);
                    return Convert.ToBase64String((outStream as MemoryStream).ToArray());
                }
                finally
                {
                    if (outStream != null) outStream.Close();
                }
            }
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="input">密文 Base64字符串</param>
        /// <param name="Key">秘钥 Base64字符串</param>
        /// <returns>明文</returns>
        public static String Decryptor(String input, String Key)
        {
            return Decryptor(input, Convert.FromBase64String(Key),null);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="input">密文 Base64字符串</param>
        /// <param name="Key">秘钥 Base64字符串</param>
        /// <param name="Iv">偏移量 Base64字符串</param>
        /// <returns>明文</returns>
        public static String Decryptor(String input, String Key, String Iv)
        {
            return Decryptor(input, Convert.FromBase64String(Key), Convert.FromBase64String(Iv));
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="input">密文 Base64字符串</param>
        /// <param name="Key">秘钥</param>
        /// <param name="Iv">偏移量</param>
        /// <returns>明文</returns>
        public static String Decryptor(String input, byte[] Key, byte[] Iv)
        {
            using (MemoryStream inputStream = new MemoryStream(Convert.FromBase64String(input)))
            {
                Stream outStream = new MemoryStream();
                try
                {
                    Decryptor(inputStream, Key, Iv, ref outStream);
                    return Encoding.UTF8.GetString((outStream as MemoryStream).ToArray());
                }
                finally
                {
                    if (outStream != null) outStream.Close();
                }
            }
        }


        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="inputStream">明文输入流</param>
        /// <param name="key">秘钥</param>
        /// <param name="iv">偏移量</param>
        /// <param name="outStream">输出流</param>
        public static void Encryptor(Stream inputStream, byte[] key, byte[] iv, ref Stream outStream)
        {
            using (RC2CryptoServiceProvider rC2Crypto = CreateRC2CriptoService(key, iv))
            {
                var encryptor = rC2Crypto.CreateEncryptor();
                CryptoTransform.TransformByWrite(inputStream, encryptor, ref outStream);
            }
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="inputStream">密文输入流</param>
        /// <param name="key">秘钥</param>
        /// <param name="iv">偏移量</param>
        /// <param name="outStream">明文输出流</param>
        public static void Decryptor(Stream inputStream, byte[] key, byte[] iv, ref Stream outStream)
        {
            using (RC2CryptoServiceProvider rC2Crypto = CreateRC2CriptoService(key, iv))
            {
                var encryptor = rC2Crypto.CreateDecryptor();
                CryptoTransform.TransformByWrite(inputStream, encryptor, ref outStream);
            }
        }

        /// <summary>
        /// 创建RC2加密服务
        /// </summary>
        /// <param name="key">秘钥</param>
        /// <param name="iv">偏移量</param>
        /// <returns></returns>
        private static RC2CryptoServiceProvider CreateRC2CriptoService(byte[] key, byte[] iv)
        {
            RC2CryptoServiceProvider rC2Crypto = new RC2CryptoServiceProvider()
            {
                Key = key,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.ISO10126,
            };
            if (iv != null && iv.Length > 0)
            {
                rC2Crypto.IV = iv;
                rC2Crypto.Mode = CipherMode.CBC;
            }
            return rC2Crypto;
        }
    }
}
