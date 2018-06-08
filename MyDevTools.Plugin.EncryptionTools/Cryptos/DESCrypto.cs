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
    /// DES加密(秘钥加密)
    /// </summary>
    public class DESCrypto
    {
        /// <summary>
        /// 创建秘钥
        /// </summary>
        /// <returns></returns>
        public static KeyValuePair<String, String> CreatedKey()
        {
            using (DESCryptoServiceProvider dESCrypto = new DESCryptoServiceProvider())
            {
                return new KeyValuePair<string, string>(Convert.ToBase64String(dESCrypto.Key), Convert.ToBase64String(dESCrypto.IV));
            }
        }        

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="input">明文</param>
        /// <param name="Key">秘钥 Base64字符串</param>
        /// <param name="Iv">偏移量 Base64字符串</param>
        /// <returns>密文</returns>
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
        /// <returns>密文</returns>
        public static String Encryptor(String input, byte[] Key, byte[] Iv)
        {
            if (input == null || input.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (Iv == null || Iv.Length <= 0)
                throw new ArgumentNullException("IV");

            using (DESCryptoServiceProvider dESCrypto = new DESCryptoServiceProvider())
            {
                var descEncrypto = dESCrypto.CreateEncryptor(Key, Iv);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, descEncrypto, CryptoStreamMode.Write))
                    {
                        var bytes = Encoding.UTF8.GetBytes(input);
                        cryptoStream.Write(bytes, 0, bytes.Length);
                    }
                    return Convert.ToBase64String(memoryStream.ToArray());
                }
            }
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="input">明文</param>
        /// <param name="Key">秘钥 Base64字符串</param>
        /// <param name="Iv">偏移量 Base64字符串</param>
        /// <returns>密文</returns>
        public static async Task<string> EncryptorAsync(String input, String Key, String Iv)
        {
            return await EncryptorAsync(input, Convert.FromBase64String(Key), Convert.FromBase64String(Iv));
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="input">明文</param>
        /// <param name="Key">秘钥</param>
        /// <param name="Iv">偏移量</param>
        /// <returns>密文</returns>
        public static async Task<string> EncryptorAsync(String input, byte[] Key, byte[] Iv)
        {
            if (input == null || input.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (Iv == null || Iv.Length <= 0)
                throw new ArgumentNullException("IV");

            using (DESCryptoServiceProvider dESCrypto = new DESCryptoServiceProvider())
            {
                var descEncrypto = dESCrypto.CreateEncryptor(Key, Iv);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, descEncrypto, CryptoStreamMode.Write))
                    {
                        var bytes = Encoding.UTF8.GetBytes(input);
                        await cryptoStream.WriteAsync(bytes, 0, bytes.Length);
                    }
                    return Convert.ToBase64String(memoryStream.ToArray());
                }
            }
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="input">密文</param>
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
        /// <param name="input">密文</param>
        /// <param name="Key">秘钥</param>
        /// <param name="Iv">偏移量</param>
        /// <returns>明文</returns>
        public static String Decryptor(String input, byte[] Key, byte[] Iv)
        {
            if (input == null || input.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (Iv == null || Iv.Length <= 0)
                throw new ArgumentNullException("IV");

            using (DESCryptoServiceProvider dESCrypto = new DESCryptoServiceProvider())
            {
                var desDecryptor = dESCrypto.CreateDecryptor(Key, Iv);
                using (MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(input)))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, desDecryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cryptoStream, Encoding.UTF8))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
        } 
        /// <summary>
          /// 解密
          /// </summary>
          /// <param name="input">密文</param>
          /// <param name="Key">秘钥 Base64字符串</param>
          /// <param name="Iv">偏移量 Base64字符串</param>
          /// <returns>明文</returns>
        public static async Task<string> DecryptorAsync(String input, String Key, String Iv)
        {
            return await DecryptorAsync(input, Convert.FromBase64String(Key), Convert.FromBase64String(Iv));
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="input">密文</param>
        /// <param name="Key">秘钥</param>
        /// <param name="Iv">偏移量</param>
        /// <returns>明文</returns>
        public static async Task<string> DecryptorAsync(String input, byte[] Key, byte[] Iv)
        {
            if (input == null || input.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (Iv == null || Iv.Length <= 0)
                throw new ArgumentNullException("IV");

            using (DESCryptoServiceProvider dESCrypto = new DESCryptoServiceProvider())
            {
                var descDecrypto = dESCrypto.CreateDecryptor(Key, Iv);
                using (MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(input)))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, descDecrypto, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cryptoStream, Encoding.UTF8))
                        {
                            return await reader.ReadToEndAsync();
                        }
                    }
                }
            }
        }
    }
}
