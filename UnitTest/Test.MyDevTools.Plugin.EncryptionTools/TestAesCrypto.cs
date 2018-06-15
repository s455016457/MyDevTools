using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MyDevTools.Plugin.EncryptionTools.Cryptos;
using MyDevTools.Plugin.EncryptionTools.Extends;
using System.Text;

namespace UnitTest.Test.MyDevTools.Plugin.EncryptionTools
{
    [TestClass]
    public class TestAesCrypto
    {
        const String body = @"Test AesManaged 提供高级加密标准（AES）对称算法的管理实现。
AES算法本质上是具有固定块大小和迭代次数的Rijndael对称算法。
该类的功能与RijndaelManaged类相同，但将块限制为128位，并且不允许反馈模式。";
        String Key, Iv;
        public TestAesCrypto() {
            var keyValue = AesCrypto.CreateKeyAndIv();
            Key = keyValue.Key;
            Iv = keyValue.Value;
        }

        [TestMethod]
        public void TestCreateKeyAndIv()
        {
            var keyValue = AesCrypto.CreateKeyAndIv();
            Assert.IsNotNull(keyValue);
            Assert.IsTrue(keyValue.Key.Length > 0);
            Assert.IsTrue(keyValue.Value.Length > 0);
            Console.WriteLine("Key:{0}", keyValue.Key);
            Console.WriteLine("IV:{0}", keyValue.Value);
        }

        [TestMethod]
        public void TestCreateKey()
        {
            var key = AesCrypto.CreateKey();
            Assert.IsNotNull(key);
            Assert.IsTrue(key.Length > 0);
            Console.WriteLine("Key:{0}", key);
        }

        [TestMethod]
        public void TestEncryptNoIv()
        {
            var key = AesCrypto.CreateKey();
            String encryptBody = AesCrypto.Encrypt(body, Encoding.UTF8.GetBytes(key));
            Assert.IsTrue(encryptBody.Length > 0);
            Console.WriteLine(encryptBody);
        }

        [TestMethod]
        public void TestDecryptNoIv()
        {
            var key = AesCrypto.CreateKey();
            String encryptBody = AesCrypto.Encrypt(body, Encoding.UTF8.GetBytes(key));
            Console.WriteLine("密文：{0}", encryptBody);

            String decryptBody = AesCrypto.Decrypt(encryptBody, Encoding.UTF8.GetBytes(key));

            Assert.IsNotNull(decryptBody);
            Assert.IsTrue(decryptBody.Length > 0);
            Console.WriteLine("明文：{0}", decryptBody);
            Assert.IsTrue(decryptBody.Equals(body));
        }

        [TestMethod]
        public void TestEncrypt()
        {
            String encryptBody = AesCrypto.Encrypt(body, Key, Iv);
            Assert.IsTrue(encryptBody.Length > 0);
            Console.WriteLine(encryptBody);
        }

        [TestMethod]
        public void TestDecrypt()
        {
            String encryptBody = AesCrypto.Encrypt(body, Key, Iv);
            String decryptBody = AesCrypto.Decrypt(encryptBody, Key, Iv);

            Assert.IsNotNull(decryptBody);
            Assert.IsTrue(decryptBody.Length > 0);
            Console.WriteLine("密文：{0}", encryptBody);
            Console.WriteLine("明文：{0}", decryptBody);
            Assert.IsTrue(decryptBody.Equals(body));
        }

        [TestMethod]
        public void TestBitConverter()
        {
            Console.WriteLine("base64String Key:{0}",Key);
            var bytes = Convert.FromBase64String(Key);

            String bitKey = BitConverter.ToString(bytes);
            Console.WriteLine("BitString Key:{0}", bitKey);

            String[] strs= bitKey.Split('-');
            var newBytes = new byte[strs.Length];
            for (int i = 0; i < strs.Length; i++)
            {
                newBytes[i] = Byte.Parse(Convert.ToInt32(strs[i], 16).ToString());
                if (!bytes[i].Equals(newBytes[i]))
                {
                    Console.WriteLine("bytes[i]:{0} newBytes[i]：{1} ", bytes[i], newBytes[i]);
                }
            }

            String newKey = Convert.ToBase64String(newBytes);
            Console.WriteLine("base64String Key:{0}", newKey);
            Assert.IsTrue(Key.Equals(newKey));
        }
        [TestMethod]
        public void TestBitConverter2()
        {
            Console.WriteLine("base64String Key:{0}",Key);
            var bytes = Convert.FromBase64String(Key);

            String bitKey = bytes.ToBitString("");
            Console.WriteLine("BitString Key:{0}", bitKey);
            var newBytes = bitKey.ToByteArrayByBitString();
            String newKey = Convert.ToBase64String(newBytes);
            Console.WriteLine("base64String Key:{0}", newKey);
            Assert.IsTrue(Key.Equals(newKey));

            bitKey = bytes.ToBitString("-");
            Console.WriteLine("BitString Key:{0}", bitKey);
            newBytes = bitKey.ToByteArrayByBitString('-');
            newKey = Convert.ToBase64String(newBytes);
            Console.WriteLine("base64String Key:{0}", newKey);
            Assert.IsTrue(Key.Equals(newKey));
        }
    }
}
