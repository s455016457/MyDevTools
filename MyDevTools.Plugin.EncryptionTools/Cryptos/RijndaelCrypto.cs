using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyDevTools.Plugin.EncryptionTools.Cryptos
{
    public class RijndaelCrypto
    {
        public static KeyValuePair<String, String> CreateKey()
        {
            using (RijndaelManaged rijndae = new RijndaelManaged())
            {
                return new KeyValuePair<string, string>(Convert.ToBase64String(rijndae.Key), Convert.ToBase64String(rijndae.IV));
            }
        }

        public static String CreateKeyNoIv()
        {
            return CryptoTransform.CreateKey(32);
        }

        public static String Encryptor(String input, String key, String iv=null)
        {
            return Encryptor(input, 
                Convert.FromBase64String(key), 
                iv != null && iv.Length > 0 ? Convert.FromBase64String(iv) : null);
        }

        public static String Decryptor(String input, String key, String iv = null)
        {
            return Decryptor(input,
                Convert.FromBase64String(key),
                iv != null && iv.Length > 0 ? Convert.FromBase64String(iv) : null);
        }

        public static String Encryptor(String input, byte[] key, byte[] iv)
        {
            using (MemoryStream inputStream = new MemoryStream(Encoding.UTF8.GetBytes(input)))
            {
                Stream outStream = new MemoryStream();
                try
                {
                    Encryptor(inputStream, key, iv, ref outStream);
                    return Convert.ToBase64String((outStream as MemoryStream).ToArray());
                }
                finally
                {
                    if (outStream != null)
                        outStream.Close();
                }
            }
        }

        public static String Decryptor(String input, byte[] key, byte[] iv)
        {
            using (MemoryStream inputStream = new MemoryStream(Convert.FromBase64String(input)))
            {
                Stream outStream = new MemoryStream();
                try
                {
                    Decryptor(inputStream, key, iv, ref outStream);
                    return Encoding.UTF8.GetString((outStream as MemoryStream).ToArray());
                }
                finally
                {
                    if (outStream != null)
                        outStream.Close();
                }
            }
        }

        public static void Encryptor(Stream inputStream, byte[] key, byte[] iv, ref Stream outStream)
        {
            using (RijndaelManaged managed = CreateRijndaelManaged(key, iv))
            {
                var encryptory = managed.CreateEncryptor();
                CryptoTransform.TransformByRead(inputStream, encryptory, ref outStream);
            }
        }

        public static void Decryptor(Stream inputStream, byte[] key, byte[] iv, ref Stream outStream)
        {
            using (RijndaelManaged managed = CreateRijndaelManaged(key, iv))
            {
                var encryptory = managed.CreateDecryptor();
                CryptoTransform.TransformByRead(inputStream, encryptory, ref outStream);
            }
        }

        private static RijndaelManaged CreateRijndaelManaged(byte[] key, byte[] iv)
        {
            RijndaelManaged rijndaelManaged = new RijndaelManaged()
            {
                Key = key,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.ISO10126,
            };
            if (iv != null && iv.Length > 0)
            {
                rijndaelManaged.IV = iv;
                rijndaelManaged.Mode = CipherMode.CBC;
            }

            return rijndaelManaged;
        }
    }
}
