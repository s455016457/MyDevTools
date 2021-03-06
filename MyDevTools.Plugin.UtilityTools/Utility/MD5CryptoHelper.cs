﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace MyDevTools.Plugin.UtilityTools.Utility
{
    public class MD5CryptoHelper
    {
        public static byte[] Encrypto(byte[] input)
        {
            return new MD5CryptoServiceProvider().ComputeHash(input);
        }

        public static String Encrypto(String input,String separator="")
        {
            return Encrypto(Encoding.UTF8.GetBytes(input)).ToBitString(separator);
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
