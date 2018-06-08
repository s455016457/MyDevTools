using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyDevTools.Plugin.EncryptionTools.Cryptos
{
    /// <summary>
    /// Ase加密(秘钥加密)
    /// </summary>
    public class AesCrypto
    {
        /// <summary>
        /// 创建加密秘钥和初始化向量
        /// </summary>
        /// <returns>KeyValuePair Key为秘钥，Value为初始化向量 </returns>
        public static KeyValuePair<String,String> CreateKeyAndIv()
        {
            using (AesManaged myAes = new AesManaged())
            {
                var key = myAes.Key;
                var iv = myAes.IV;

                return new KeyValuePair<string, string>(Convert.ToBase64String(key),Convert.ToBase64String(iv));
            }
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="input">代加密字符串</param>
        /// <param name="key">秘钥</param>
        /// <param name="iv">初始化向量</param>
        /// <returns></returns>
        public static String Encrypt(String input, String key, String iv)
        {
            return Encrypt(input, Convert.FromBase64String(key), Convert.FromBase64String(iv));
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="input">代加密字符串</param>
        /// <param name="key">秘钥</param>
        /// <param name="iv">初始化向量</param>
        /// <returns></returns>
        public static String Encrypt(String input, byte[] key, byte[] iv)
        {
            if (input == null || input.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("IV");

            using (AesManaged myAes = new AesManaged())
            {
                //创建加密算法
                var encrypt = myAes.CreateEncryptor(key, iv);

                //创建内存流，用于接收加密数据流
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    //创建加密算法数据流，将加密数据写入内存流
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encrypt, CryptoStreamMode.Write))
                    {
                        var types = Encoding.UTF8.GetBytes(input);
                        cryptoStream.Write(types, 0, types.Length);
                    }

                    return Convert.ToBase64String(memoryStream.ToArray());
                }
            }
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="input">密文字符串</param>
        /// <param name="key">秘钥</param>
        /// <param name="iv">初始化向量</param>
        /// <returns></returns>
        public static String Decrypt(String input, String key, String iv)
        {
            return Decrypt(input, Convert.FromBase64String(key), Convert.FromBase64String(iv));
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="input">密文字符串</param>
        /// <param name="key">秘钥</param>
        /// <param name="iv">初始化向量</param>
        /// <returns></returns>
        public static String Decrypt(String input, byte[] key, byte[] iv)
        {
            if (input == null || input.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("IV");

            using (AesManaged myAes = new AesManaged())
            {
                //创建解密算法
                var decrypt = myAes.CreateDecryptor(key, iv);

                var types = Convert.FromBase64String(input);
                //创建内存流，将密文直接写入内存流
                using (MemoryStream memoryStream = new MemoryStream(types))
                {
                    //创建解密算法数据流，将内存流写入
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decrypt, CryptoStreamMode.Read))
                    {
                        //创建读取流
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            //读取流中所有字符
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
