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
    /// 哈希签名
    /// </summary>
    public class HMACSHA1Sign
    {
        /// <summary>
        /// 创建签名秘钥
        /// </summary>
        /// <param name="lenght">签名秘钥字节长度</param>
        /// <returns>签名Key Base64字符串</returns>
        public static String CreatedSignKey(int lenght = 64)
        {
            byte[] bytes = new Byte[lenght];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(bytes);
                return Convert.ToBase64String(bytes);
            }
        }

        /// <summary>
        /// 对字符串签名
        /// </summary>
        /// <param name="input">待签名字符串</param>
        /// <param name="sign">签名Key Base64字符串</param>
        /// <returns>已签名的字符</returns>
        public static string SignStr(String input, String sign)
        {
            return SignStr(input, Convert.FromBase64String(sign));
        }

        /// <summary>
        /// 对字符串签名
        /// </summary>
        /// <param name="input">待签名字符串</param>
        /// <param name="sign">签名字符</param>
        /// <returns>已签名的字符</returns>
        public static string SignStr(String input, byte[] sign)
        {
            var bytes = Encoding.UTF8.GetBytes(input);

            //使用知道的签名秘钥创建 HMACSHA1 的实例
            using (HMACSHA1 hmac = new HMACSHA1(sign))
            {
                //将待签名字节写入内存流
                using (MemoryStream inputStream = new MemoryStream(bytes))
                {
                    //计算内存流的哈希值
                    var hashValue = hmac.ComputeHash(inputStream);
                    //将流的偏移量设置为0
                    inputStream.Position = 0;

                    //创建输出内存流
                    using (MemoryStream outStream = new MemoryStream())
                    {
                        //将哈希值写入输出内存流
                        outStream.Write(hashValue, 0, hashValue.Length);

                        //将字符写入输出输出内存流
                        int bytesRead;
                        //每次写入1K
                        byte[] buffer = new byte[1024];
                        do
                        {
                            bytesRead = inputStream.Read(buffer, 0, 
                                inputStream.Length > buffer.Count() ? buffer.Count() : (int)inputStream.Length);
                            outStream.Write(buffer, 0, bytesRead);
                        } while (bytesRead > 0);

                        return (Convert.ToBase64String(outStream.ToArray()));
                    }
                }
            }
        }
        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="input">已签名的字符</param>
        /// <param name="sign">签名Key Base64字符串</param>
        /// <param name="outStr">去掉签名后的字符</param>
        /// <returns>验证成功返回True，验证失败返回False</returns>
        public static bool VerifyStr(String input, String sign, out String outStr)
        {
            return VerifyStr(input, Convert.FromBase64String(sign), out outStr);
        }

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="input">已签名的字符</param>
        /// <param name="sign">签名Key</param>
        /// <param name="outStr">去掉签名后的字符</param>
        /// <returns>验证成功返回True，验证失败返回False</returns>
        public static bool VerifyStr(String input, byte[] sign, out String outStr)
        {
            outStr = String.Empty;
            var bytes = Convert.FromBase64String(input);
            //使用知道的签名秘钥创建 HMACSHA1 的实例
            using (HMACSHA1 hmac = new HMACSHA1(sign))
            {
                //创建一个数组来保存从输入字符中读取的键控散列值。
                byte[] storedHash = new byte[hmac.HashSize / 8];
                //将字节写入内存流
                using (MemoryStream inputStream = new MemoryStream(bytes))
                {
                    //将哈希值保存进字节数组
                    inputStream.Read(storedHash, 0, storedHash.Length);

                    //计算正文的哈希值
                    byte[] hashValue = hmac.ComputeHash(inputStream);

                    for (int i = 0; i < storedHash.Length; i++)
                    {
                        if (storedHash[i] != hashValue[i])
                            return false;
                    }

                    //设置输入流的偏移量在签名之后
                    inputStream.Position = storedHash.Length;
                    using (StreamReader reader = new StreamReader(inputStream))
                    {
                        outStr = reader.ReadToEnd();
                    }
                }
            }

            return true;
        }
    }
}
