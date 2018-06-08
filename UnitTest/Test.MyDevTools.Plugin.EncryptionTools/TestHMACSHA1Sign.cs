using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDevTools.Plugin.EncryptionTools.Cryptos;

namespace UnitTest.Test.MyDevTools.Plugin.EncryptionTools
{
    [TestClass]
    public class TestHMACSHA1Sign
    {
        const String input = @"private static void EncryptData(String inName, String outName, byte[] desKey, byte[] desIV)
 {    
     //Create the file streams to handle the input and output files.
     FileStream fin = new FileStream(inName, FileMode.Open, FileAccess.Read);
     FileStream fout = new FileStream(outName, FileMode.OpenOrCreate, FileAccess.Write);
     fout.SetLength(0);
       
     //Create variables to help with read and write.
     byte[] bin = new byte[100]; //This is intermediate storage for the encryption.
     long rdlen = 0;              //This is the total number of bytes written.
     long totlen = fin.Length;    //This is the total length of the input file.
     int len;                     //This is the number of bytes to be written at a time.
 
     DES des = new HMACSHA1SignServiceProvider();          
     CryptoStream encStream = new CryptoStream(fout, des.CreateEncryptor(desKey, desIV), CryptoStreamMode.Write);
                
     Console.WriteLine(""Encrypting..."");
 
     //Read from the input file, then encrypt and write to the output file.
     while(rdlen<totlen)
     {
         len = fin.Read(bin, 0, 100);
         encStream.Write(bin, 0, len);
         rdlen = rdlen + len;
         Console.WriteLine(""{0} bytes processed"", rdlen);
     }

    encStream.Close();  
     fout.Close();
     fin.Close();                   
 }";

        [TestMethod]
        public void TestCreateKey()
        {
            var keyValue= HMACSHA1Sign.CreatedSignKey();
            Assert.IsNotNull(keyValue);
            Assert.IsTrue(keyValue.Length > 0);

            Console.WriteLine(keyValue);
        }

        [TestMethod]
        public void TestEncryptor()
        {
            var keyValue = HMACSHA1Sign.CreatedSignKey();
            string encryptorStr= HMACSHA1Sign.SignStr(input, keyValue);

            Assert.IsNotNull(encryptorStr);
            Assert.IsTrue(encryptorStr.Length > 0);
            Console.WriteLine(encryptorStr);
        }
        

        [TestMethod]
        public void TestDecryptor()
        {
            var keyValue = HMACSHA1Sign.CreatedSignKey();
            string signedStr = HMACSHA1Sign.SignStr(input, keyValue);

            String outStr = String.Empty;

            var b = HMACSHA1Sign.VerifyStr(signedStr, keyValue,out outStr);

            Assert.IsNotNull(signedStr);
            Assert.IsTrue(signedStr.Length > 0);
            Console.WriteLine(signedStr);

            Assert.IsTrue(b);
            Assert.IsNotNull(outStr);
            Console.WriteLine(outStr);
            Assert.IsTrue(outStr.Equals(input));
        }        
    }
}
