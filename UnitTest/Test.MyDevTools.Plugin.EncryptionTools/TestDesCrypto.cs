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
    public class TestDesCrypto
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
 
     DES des = new DESCryptoServiceProvider();          
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
            var keyValue= DESCrypto.CreatedKey();
            Assert.IsNotNull(keyValue);
            Assert.IsTrue(keyValue.Key.Length > 0);
            Assert.IsTrue(keyValue.Value.Length > 0);

            Console.WriteLine(keyValue.Key);
            Console.WriteLine(keyValue.Value);
        }

        [TestMethod]
        public void TestEncryptor()
        {
            var keyValue = DESCrypto.CreatedKey();
            string encryptorStr= DESCrypto.Encryptor(input, keyValue.Key, keyValue.Value);

            Assert.IsNotNull(encryptorStr);
            Assert.IsTrue(encryptorStr.Length > 0);
            Console.WriteLine(encryptorStr);
        }

        [TestMethod]
        public void TestEncryptorAsync()
        {
            var keyValue = DESCrypto.CreatedKey();
            string encryptorStr= DESCrypto.EncryptorAsync(input, keyValue.Key, keyValue.Value).Result;

            Assert.IsNotNull(encryptorStr);
            Assert.IsTrue(encryptorStr.Length > 0);
            Console.WriteLine(encryptorStr);
        }

        [TestMethod]
        public void TestDecryptor()
        {
            var keyValue = DESCrypto.CreatedKey();
            string encryptorStr = DESCrypto.Encryptor(input, keyValue.Key, keyValue.Value);
            String decryptorStr = DESCrypto.Decryptor(encryptorStr, keyValue.Key, keyValue.Value);

            Assert.IsNotNull(encryptorStr);
            Assert.IsTrue(encryptorStr.Length > 0);
            Console.WriteLine(encryptorStr);

            Assert.IsNotNull(decryptorStr);
            Assert.IsTrue(decryptorStr.Length > 0);
            Console.WriteLine(decryptorStr);
            Assert.IsTrue(decryptorStr.Equals(input));
        }

        [TestMethod]
        public void TestDecryptorAsync()
        {
            var keyValue = DESCrypto.CreatedKey();
            string encryptorStr = DESCrypto.EncryptorAsync(input, keyValue.Key, keyValue.Value).Result;
            String decryptorStr = DESCrypto.DecryptorAsync(encryptorStr, keyValue.Key, keyValue.Value).Result;

            Assert.IsNotNull(encryptorStr);
            Assert.IsTrue(encryptorStr.Length > 0);
            Console.WriteLine(encryptorStr);

            Assert.IsNotNull(decryptorStr);
            Assert.IsTrue(decryptorStr.Length > 0);
            Console.WriteLine(decryptorStr);
            Assert.IsTrue(decryptorStr.Equals(input));
        }
    }
}
