using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyDevTools.Plugin.UtilityTools.Utility.Impl
{
    /// <summary>
    /// 哈希签名
    /// </summary>
    public class HMACSHA1Sign : ISign
    {
        /// <summary>
        /// 创建签名秘钥
        /// </summary>
        /// <param name="lenght">签名秘钥字节长度</param>
        /// <returns>签名Key Base64字符串</returns>
        public String CreatedSignKey(int lenght = 64)
        {
            return CryptoTransform.CreateKey(lenght);
        }

        /// <summary>
        /// 对字符串签名
        /// </summary>
        /// <param name="input">待签名字符串</param>
        /// <param name="sign">签名Key Base64字符串</param>
        /// <returns>已签名的字符</returns>
        public string Sign(String input, String sign)
        {
            return Sign(input, Convert.FromBase64String(sign));
        }

        /// <summary>
        /// 对字符串签名
        /// </summary>
        /// <param name="input">待签名字符串</param>
        /// <param name="sign">签名字符</param>
        /// <returns>已签名的字符</returns>
        public string Sign(String input, byte[] sign)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(Sign(Encoding.UTF8.GetBytes(input), sign));
        }

        /// <summary>
        /// 对字符串签名
        /// </summary>
        /// <param name="bytes">待签名字符串</param>
        /// <param name="sign">签名字符</param>
        /// <returns>已签名的字符</returns>
        public byte[] Sign(byte[] bytes, byte[] sign)
        {
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
                        /**
                         * 可以将签名拆分写入内容流指定位置
                         * 在验证时，从流的指定位置获取并拼接出签名和内容
                         * */

                        //将哈希值写入输出内存流
                        outStream.Write(hashValue, 0, hashValue.Length);

                        //将字符写入输出输出内存流
                        int bytesRead;
                        //每次写入1K
                        byte[] buffer = new byte[1024];
                        do
                        {
                            bytesRead = inputStream.Read(buffer, 0,
                                inputStream.Length - inputStream.Position > buffer.Count()
                                ? buffer.Count()
                                : (int)(inputStream.Length - inputStream.Position));
                            outStream.Write(buffer, 0, bytesRead);
                        } while (bytesRead > 0);

                        return outStream.ToArray();
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
        public bool Verify(String input, String sign, out String outStr)
        {
            return Verify(input, Convert.FromBase64String(sign), out outStr);
        }

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="input">已签名的字符</param>
        /// <param name="sign">签名Key</param>
        /// <param name="outStr">去掉签名后的字符</param>
        /// <returns>验证成功返回True，验证失败返回False</returns>
        public bool Verify(String input, byte[] sign, out String outStr)
        {
            return Verify(Convert.FromBase64String(input), sign, out outStr);
        }

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="input">已签名的字符</param>
        /// <param name="sign">签名Key</param>
        /// <param name="outStr">去掉签名后的字符</param>
        /// <returns>验证成功返回True，验证失败返回False</returns>
        public bool Verify(byte[] bytes, byte[] sign, out String outStr)
        {
            outStr = String.Empty;
            //使用知道的签名秘钥创建 HMACSHA1 的实例
            using (HMACSHA1 hmac = new HMACSHA1(sign))
            {
                //创建一个数组来保存从输入字符中读取的键控散列值。
                byte[] storedHash = new byte[hmac.HashSize / 8];
                //将字节写入内存流
                using (MemoryStream inputStream = new MemoryStream(bytes))
                {
                    /**
                     * 可以从流指定位置获取签名
                     * */
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

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="input">已签名的字符</param>
        /// <param name="sign">签名Key</param>
        /// <param name="outByte">去掉签名后的字符</param>
        /// <returns>验证成功返回True，验证失败返回False</returns>
        public bool Verify(String input, byte[] sign, out byte[] outByte)
        {
            return Verify(Convert.FromBase64String(input), sign, out outByte);
        }

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="input">已签名的字符</param>
        /// <param name="sign">签名Key</param>
        /// <param name="outByte">去掉签名后的字符</param>
        /// <returns>验证成功返回True，验证失败返回False</returns>
        public bool Verify(byte[] bytes, byte[] sign, out byte[] outByte)
        {
            outByte = new byte[0];
            //使用知道的签名秘钥创建 HMACSHA1 的实例
            using (HMACSHA1 hmac = new HMACSHA1(sign))
            {
                //创建一个数组来保存从输入字符中读取的键控散列值。
                byte[] storedHash = new byte[hmac.HashSize / 8];
                //将字节写入内存流
                using (MemoryStream inputStream = new MemoryStream(bytes))
                {
                    /**
                     * 可以从流指定位置获取签名
                     * */
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

                    outByte = new byte[inputStream.Length - storedHash.Length];
                    inputStream.Read(outByte, 0, outByte.Length);
                }
            }

            return true;
        }
    }
}
