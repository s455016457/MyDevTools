using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyDevTools.Plugin.EncryptionTools.Cryptos
{
    public class CryptoTransform
    {
        const string strKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        static Random random = new Random();

        /// <summary>
        /// 创建秘钥，无向量
        /// </summary>
        /// <param name="Length">秘钥位数</param>
        /// <returns></returns>
        public static String CreateKey(int Length = 32)
        {
            char[] chars = new Char[Length];
            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = strKey[random.Next(strKey.Length)];
            }

            return new string(chars);
        }

        /// <summary>
        /// 算法转换，对转换流读取访问
        /// </summary>
        /// <param name="inputStream">输入流</param>
        /// <param name="transform">加密/解密算法</param>
        /// <param name="outStream">转换输出流</param>
        public static void TransformByRead(Stream inputStream, ICryptoTransform transform, ref Stream outStream)
        {
            //创建算法转换流 写入数据
            using (CryptoStream cryptoStream = new CryptoStream(inputStream, transform, CryptoStreamMode.Read))
            {
                Byte[] buffer = new Byte[1024];

                int bytesRead;

                //将转换率内容写入输出流
                do
                {
                    bytesRead = cryptoStream.Read(buffer, 0, buffer.Count());
                    outStream.Write(buffer, 0, bytesRead);
                }
                while (bytesRead > 0);
            }
        }

        /// <summary>
        /// 算法转换，对转换流写入访问
        /// </summary>
        /// <param name="inputStream">输入流</param>
        /// <param name="transform">加密/解密算法</param>
        /// <param name="outStream">转换输出流</param>
        public static void TransformByWrite(Stream inputStream, ICryptoTransform transform, ref Stream outStream)
        {
            using (CryptoStream cryptoStream = new CryptoStream(outStream, transform, CryptoStreamMode.Write))
            {
                Byte[] buffer = new Byte[1024];

                int bytesRead;
                //将明文写入转换流中
                do
                {
                    bytesRead = inputStream.Read(buffer, 0, buffer.Count());
                    cryptoStream.Write(buffer, 0, bytesRead);
                }
                while (bytesRead > 0);
            }
        }
    }
}
