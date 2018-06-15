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
            return Convert.ToBase64String(Encryptor(Encoding.UTF8.GetBytes(content), key,true));
        }

        public static byte[] Encryptor(byte[] toEncrypt, String key, bool Reverse = false)
        {
            List<byte> arrayList = new List<byte>();
            rsaServiec.FromXmlString(key);

            //加密快大小
            int encryptorBlockSize = rsaServiec.KeySize / 8 - 42;

            int count = (int)Math.Ceiling((decimal)toEncrypt.Length / encryptorBlockSize);
            for (int i = 0; i < count; i++)
            {
                byte[] tempBytes = new byte[encryptorBlockSize];
                if (toEncrypt.Length - i * encryptorBlockSize < encryptorBlockSize)
                {
                    tempBytes = new byte[toEncrypt.Length - i * encryptorBlockSize];
                }
                Array.Copy(toEncrypt, i * encryptorBlockSize, tempBytes, 0, tempBytes.Length);

                arrayList.AddRange(rsaServiec.Encrypt(tempBytes, false));
            }
            if (!Reverse) return arrayList.ToArray();

            //根据解密快大小反转字节数组
            List<byte> reverseArrayList = new List<byte>();
            //解密快大小
            int decryptorBlockSize = rsaServiec.KeySize / 8;
            var encryptedBytes = arrayList.ToArray();

            count = (int)Math.Ceiling((decimal)encryptedBytes.Length / decryptorBlockSize);
            for (int i = 0; i < count; i++)
            {
                byte[] tempBytes = new byte[decryptorBlockSize];
                if (encryptedBytes.Length - i * decryptorBlockSize < decryptorBlockSize)
                {
                    tempBytes = new byte[encryptedBytes.Length - i * decryptorBlockSize];
                }
                Array.Copy(encryptedBytes, i * decryptorBlockSize, tempBytes, 0, tempBytes.Length);
                Array.Reverse(tempBytes);
                reverseArrayList.AddRange(tempBytes);
            }

            return reverseArrayList.ToArray();
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
            return Encoding.UTF8.GetString(Decryptor(Convert.FromBase64String(content), key,true));
        }

        public static byte[] Decryptor(byte[] encrypted, String key,bool Reverse=false)
        {
            List<byte> list = new List<byte>();
            rsaServiec.FromXmlString(key);

            //解密快大小
            int decryptorBlockSize = rsaServiec.KeySize / 8;
            int count = (int)Math.Ceiling((decimal)encrypted.Length / decryptorBlockSize);
            for (int i = 0; i < count; i++)
            {
                byte[] tempBytes = new byte[decryptorBlockSize];
                if (encrypted.Length - i * decryptorBlockSize < decryptorBlockSize)
                {
                    tempBytes = new byte[encrypted.Length - i * decryptorBlockSize];
                }
                Array.Copy(encrypted, i * decryptorBlockSize, tempBytes, 0, tempBytes.Length);
                if (Reverse)
                    Array.Reverse(tempBytes);
                list.AddRange(rsaServiec.Decrypt(tempBytes, false));
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
