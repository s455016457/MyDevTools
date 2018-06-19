using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyDevTools.Plugin.UtilityTools.Utility
{
    /// <summary>
    /// Ase加密(秘钥加密)
    /// </summary>
    public class AesCryptoHelper
    {
        static Random random = new Random();
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
        /// 创建秘钥，无向量
        /// </summary>
        /// <returns></returns>
        public static String CreateKey()
        {
            return CryptoTransform.CreateKey();
        }

        /// <summary>
        ///  加密，无向量
        /// </summary>
        /// <param name="input">明文</param>
        /// <param name="key">秘钥，UTF8格式</param>
        /// <returns>密文</returns>
        public static String Encrypt(String input, String key)
        {
            return Encrypt(input, Encoding.UTF8.GetBytes(key));
        }

        /// <summary>
        /// 加密，无向量
        /// </summary>
        /// <param name="input">明文</param>
        /// <param name="key">秘钥</param>
        /// <returns>密文</returns>
        public static String Encrypt(String input, byte[] key)
        {
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (input == null || input.Length <= 0)
                return String.Empty;

            //创建AES管理工具
            using (AesManaged myAes = new AesManaged()
            {
                Key = key,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.ISO10126,
            })
            {
                //创建加密算法
                var encrypt = myAes.CreateEncryptor();

                //创建内存流，并将明文写入内存流
                using (MemoryStream inputStream = new MemoryStream(Encoding.UTF8.GetBytes(input)))
                {
                    //创建输出流，用于接收转换后的数据流
                    Stream outStream = new MemoryStream();
                    try
                    {
                        CryptoTransform.TransformByRead(inputStream, encrypt, ref outStream);

                        return Convert.ToBase64String((outStream as MemoryStream).ToArray());
                    }
                    finally
                    {
                        if (outStream != null)
                        {
                            outStream.Close();
                        }
                    }
                }
            }
        }

        /// <summary>
        ///  解密，无向量
        /// </summary>
        /// <param name="input">密文</param>
        /// <param name="key">秘钥，UTF8格式</param>
        /// <returns>明文</returns>
        public static String Decrypt(String input, String key)
        {
            return Decrypt(input, Encoding.UTF8.GetBytes(key));
        }

        /// <summary>
        /// 解密 无向量
        /// </summary>
        /// <param name="input">密文</param>
        /// <param name="key">秘钥，UTF8格式</param>
        /// <returns>明文</returns>
        public static String Decrypt(String input, byte[] key)
        {
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (input == null || input.Length <= 0)
                return String.Empty;
            
            using (AesManaged myAes = new AesManaged()
            {
                Key=key,
                Mode=CipherMode.ECB,
                Padding=PaddingMode.ISO10126,
            })
            {

                //创建解密算法
                var decrypt = myAes.CreateDecryptor();

                //创建内存流，将密文直接写入内存流
                using (MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(input)))
                {
                    //创建输出流，用于接收转换后的数据流
                    Stream outStream = new MemoryStream();
                    try
                    {
                        //根据解密算法，将密文解密为明文，并写入输出流
                        CryptoTransform.TransformByRead(memoryStream, decrypt, ref outStream);

                        return Encoding.UTF8.GetString((outStream as MemoryStream).ToArray());
                    }
                    finally
                    {
                        if (outStream != null)
                        {
                            outStream.Close();
                        }
                    }
                }
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
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("IV");
            if (input == null || input.Length <= 0)
                return string.Empty;

            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(input), key, iv));
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="bytes">代加密字符串</param>
        /// <param name="key">秘钥</param>
        /// <param name="iv">初始化向量</param>
        /// <returns></returns>
        public static byte[] Encrypt(byte[] bytes, byte[] key, byte[] iv)
        {
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("IV");
            if (bytes == null || bytes.Length <= 0)
                return new byte[0];

            using (AesManaged myAes = new AesManaged())
            {
                //创建加密算法
                var encrypt = myAes.CreateEncryptor(key, iv);
                using (MemoryStream inputStream = new MemoryStream(bytes))
                {
                    Stream outStream = new MemoryStream();
                    try
                    {
                        CryptoTransform.TransformByRead(inputStream, encrypt, ref outStream);

                        return (outStream as MemoryStream).ToArray();
                    }
                    finally
                    {
                        if (outStream != null)
                        {
                            outStream.Close();
                        }
                    }
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
            return Encoding.UTF8.GetString(Decrypt(Convert.FromBase64String(input), key, iv));
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="bytes">密文字符串</param>
        /// <param name="key">秘钥</param>
        /// <param name="iv">初始化向量</param>
        /// <returns></returns>
        public static byte[] Decrypt(byte[] bytes, byte[] key, byte[] iv)
        {
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("IV");
            if (bytes == null || bytes.Length <= 0)
                return  new byte[0];

            using (AesManaged myAes = new AesManaged())
            {
                //创建解密算法
                var decrypt = myAes.CreateDecryptor(key, iv);

                //创建内存流，将密文直接写入内存流
                using (MemoryStream memoryStream = new MemoryStream(bytes))
                {
                    //创建解密算法数据流，将内存流写入
                    Stream outStream = new MemoryStream();
                    try
                    {
                        CryptoTransform.TransformByRead(memoryStream, decrypt, ref outStream);

                        return (outStream as MemoryStream).ToArray();
                    }
                    finally
                    {
                        if (outStream != null)
                        {
                            outStream.Close();
                        }
                    }
                }
            }
        }
    }
}
