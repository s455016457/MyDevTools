using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MyDevTools.Plugin.EncryptionTools.Cryptos
{
    public class RSACrypto
    {
        const String OidName = "SHA1";
        public static RSACryptoServiceProvider rsaServiec;

        /// <summary>
        /// 产生一个秘钥
        /// </summary>
        /// <returns></returns>
        public static Key CreateKey()
        {
            rsaServiec = new RSACryptoServiceProvider();
            return new Key
            {
                PublicKey = rsaServiec.ToXmlString(false),
                PrivateKey = rsaServiec.ToXmlString(true)
            };
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="content">待密文本</param>
        /// <param name="key">秘钥</param>
        /// <param name="fOAEP">
        /// 如果为 true，则使用 OAEP 填充（仅在运行 Microsoft Windows XP 或更高版本的计算机上可用）执行直接的 System.Security.Cryptography.RSA加密；
        /// 否则，如果为 false，则使用 PKCS#1 1.5 版填充。
        /// </param>
        /// <returns></returns>
        public static string Encrypt(string content, string key, bool fOAEP)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(content);
            rsaServiec.FromXmlString(key);
            int keySize = rsaServiec.KeySize / 8;
            int maxLength = keySize - 42;
            int dataLength = bytes.Length;
            int iterations = dataLength / maxLength;
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i <= iterations; i++)
            {
                byte[] tempBytes = new byte[(dataLength - maxLength * i > maxLength) ? maxLength : dataLength - maxLength * i];
                Buffer.BlockCopy(bytes, maxLength * i, tempBytes, 0, tempBytes.Length);
                byte[] encryptedBytes = rsaServiec.Encrypt(tempBytes, false);
                Array.Reverse(encryptedBytes);
                stringBuilder.Append(Convert.ToBase64String(encryptedBytes));
            }
            return stringBuilder.ToString();
        }

        public static byte[] Encryptor(byte[] toEncrypt, String key)
        {
            List<byte> arrayList = new List<byte>();
            rsaServiec.FromXmlString(key);
            int keySize = rsaServiec.KeySize / 8;
            int maxLength = keySize - 42;
            int dataLength = toEncrypt.Length;
            int iterations = dataLength / maxLength;

            for (int i = 0; i <= iterations; i++)
            {
                byte[] tempBytes = new byte[(dataLength - maxLength * i > maxLength) ? maxLength : dataLength - maxLength * i];
                Buffer.BlockCopy(toEncrypt, maxLength * i, tempBytes, 0, tempBytes.Length);
                byte[] encryptedBytes = rsaServiec.Encrypt(tempBytes, false);
                //Array.Reverse(encryptedBytes);
                arrayList.AddRange(encryptedBytes);
            }

            return arrayList.ToArray();
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="content">待解密文本</param>
        /// <param name="key">秘钥</param>
        /// <param name="fOAEP">
        /// 如果为 true，则使用 OAEP 填充（仅在运行 Microsoft Windows XP 或更高版本的计算机上可用）执行直接的 System.Security.Cryptography.RSA加密；
        /// 否则，如果为 false，则使用 PKCS#1 1.5 版填充。
        /// </param>
        /// <returns></returns>
        public static string Decrypt(string content, string key, bool fOAEP)
        {
            rsaServiec.FromXmlString(key);

            int base64BlockSize = ((rsaServiec.KeySize / 8) % 3 != 0) ? (((rsaServiec.KeySize / 8) / 3) * 4) + 4 : ((rsaServiec.KeySize / 8) / 3) * 4;
            int iterations = content.Length / base64BlockSize;
            ArrayList arrayList = new ArrayList();
            for (int i = 0; i < iterations; i++)
            {
                byte[] encryptedBytes = Convert.FromBase64String(content.Substring(base64BlockSize * i, base64BlockSize));
                Array.Reverse(encryptedBytes);
                arrayList.AddRange(rsaServiec.Decrypt(encryptedBytes, false));
            }
            return Encoding.UTF8.GetString(arrayList.ToArray(typeof(Byte)) as byte[]);
        }

        public static byte[] Decryptor(byte[] encrypted, String key)
        {
            rsaServiec.FromXmlString(key);
            string content = Convert.ToBase64String(encrypted);

            int base64BlockSize = ((rsaServiec.KeySize / 8) % 3 != 0) ? (((rsaServiec.KeySize / 8) / 3) * 4) + 4 : ((rsaServiec.KeySize / 8) / 3) * 4;
            int iterations = content.Length / base64BlockSize;
            List<byte> list = new List<byte>();
            for (int i = 0; i < iterations; i++)
            {
                byte[] encryptedBytes = Convert.FromBase64String(content.Substring(base64BlockSize * i, base64BlockSize));
                list.AddRange(rsaServiec.Decrypt(encryptedBytes, false));
            }
            return list.ToArray();
        }

        /// <summary>
        /// Hash签名 私钥签名
        /// </summary>
        /// <param name="key"></param>
        /// <param name="encrypted"></param>
        /// <returns></returns>
        public static byte[] HashAndSign(String key,byte[] encrypted)
        {
            rsaServiec.FromXmlString(key);
            SHA1Managed hash = new SHA1Managed();
            byte[] hashedData;            

            hashedData = hash.ComputeHash(encrypted);

            return rsaServiec.SignHash(hashedData, CryptoConfig.MapNameToOID(OidName));
        }

        /// <summary>
        ///  Hash签名 私钥签名
        /// </summary>
        /// <param name="content">待签名文本</param>
        /// <param name="key">私钥</param>
        /// <returns></returns>
        public static String HashAndSign(String content, String key)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(content);
            var signBytes = HashAndSign(key, bytes);
            return Convert.ToBase64String(signBytes);
        }

        /// <summary>
        /// 验证签名  公钥验证签名
        /// </summary>
        /// <param name="key">公钥</param>
        /// <param name="content">数据</param>
        /// <param name="signa">签名</param>
        /// <returns></returns>
        public static bool VerifyHash(String key, byte[] content, byte[] signa)
        {
            rsaServiec.FromXmlString(key);
            SHA1Managed hash = new SHA1Managed();
            byte[] hashedData;
            
            bool dataOK = rsaServiec.VerifyData(content, CryptoConfig.MapNameToOID(OidName), signa);
            hashedData = hash.ComputeHash(content);
            return rsaServiec.VerifyHash(hashedData, CryptoConfig.MapNameToOID(OidName), signa);
        }

        /// <summary>
        /// 验证签名  公钥验证签名
        /// </summary>
        /// <param name="key">公钥</param>
        /// <param name="content">数据</param>
        /// <param name="signa">签名</param>
        /// <returns></returns>
        /// <returns></returns>
        public static bool VerifyHash(String key, String content, String signa)
        {
            byte[] signature= Encoding.UTF8.GetBytes(content);
            byte[] signedData =  Convert.FromBase64String(signa);
            return VerifyHash(key, signature, signedData);
        }
    }

    public class Key
    {
        /// <summary>
        /// 私钥
        /// </summary>
        public string PrivateKey { get; set; }

        /// <summary>
        /// 公钥
        /// </summary>
        public string PublicKey { get; set; }
    }
}
