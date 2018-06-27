using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MyDevTools.Plugin.EncryptionTools.Extends;

namespace MyDevTools.Plugin.EncryptionTools.Cryptos
{
    public class MD5Crypto
    {
        public static byte[] Encryptor(byte[] input)
        {
            return new MD5CryptoServiceProvider().ComputeHash(input);
        }

        public static String Encryptor(String input,String separator="")
        {
            return Encryptor(Encoding.UTF8.GetBytes(input)).ToBitString(separator);
        }

        public static byte[] Hash(byte[] input)
        {
            return new HMACSHA1().ComputeHash(input);
        }

        public static String Hash(String input, String separator = "")
        {
            return Hash(Encoding.UTF8.GetBytes(input)).ToBitString(separator);
        }
    }
}
