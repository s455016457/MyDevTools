using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDevTools.Plugin.Utility;
using MyDevTools.Plugin.UtilityTools.PasswordManagementTool;
using MyDevTools.Plugin.UtilityTools.Utility;
using MyDevTools.Plugin.UtilityTools.Utility.Impl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTest.Test.MyDevTools.Plugin.UtilityTools
{
    [TestClass]
    public class TestAESCryptor
    {
        String privateKeyDirectoryPath = Path.Combine(ApplicationCofig.AppDataDirectoryPath, "PasswordManagementTool");
        const String fileName = "private.key";
        const String input = @"密钥加密算法使用单个密钥来加密和解密数据。 必须确保密钥不被未经授权的代理访问，因为具有此密钥的任意方均可使用此密钥解密你的数据或者加密自己的数据，而声称此数据来自于你。

密钥加密也称为对称加密，因为加密和解密所用的密码相同。 密钥加密算法非常迅速（相比于公钥算法），也非常适合在大型数据流上执行加密转换。 非对称加密算法（例如 RSA）从数学上来说在可加密的数据量方面存在限制。 对称加密算法通常没有这些问题。

一种名为分组加密的密钥算法用于一次加密一个数据块。 分组加密（例如数据加密标准 (DES)、TripleDES 和高级加密标准 (AES)）可将 n 字节的输入块通过加密转换为由加密字节构成的输出块。 如果想要加密或解密字节序列，则必须逐块执行。 由于 n 很小（DES 和 TripleDES 为 8 字节；AES 为 16 字节 [默认值]、24 字节或 32 字节），所以对于大于 n 的数据值，必须一次加密一个数据块。 小于 n 的数据值则必须扩展为 n 才能进行处理。

分组加密的一种简单形式被称为电子密码本 (ECB) 模式。 ECB 模式被视为不安全，因为它不使用初始化向量来初始化第一个纯文本块。 对于给定的密钥 k，不使用初始化向量的简单分组加密会将相同的纯文本输入块加密为相同的已加密文本的输出块。 因此，如果输入的纯文本流中存在重复的块，则输出密码文本流中也会有重复的块。 这些重复的输出块会警告未经授权的用户使用了可能被采用的算法访问不可靠的加密以及可能的攻击模式。 因此，ECB 密码模式非常易于分析，最终导致密钥易于被发现。

基类库中提供的分组加密类使用称为加密块链接 (CBC) 的默认链接模式，但可随意更改此默认设置。

通过使用初始化向量 (IV) 加密第一个纯文本块，CBC 密码克服了与 ECB 密码关联的问题。 每个后续纯文本块在加密之前，都将与之前的密码文本块进行位异或 (XOR) 运算。 因此，每个密码文本块均依赖于之前所有的块。 使用此系统时，可能已为未经授权的用户所知的常见消息头不可用来对密钥进行反向工程处理。

一种泄露以 CBC 密码加密的数据的方式是对每个可能的密钥执行详尽搜索。 具体取决于用来执行加密的密钥大小，这种搜索即使是使用最快的计算机也非常耗时，因此不可行。 密钥大小更大，解密更难。 虽然从理论上来说，加密并未使攻击者检索加密数据变得不可能，但它确实增加了执行此操作的成本。 如果花费三个月的时间执行详尽搜索来检索仅在几天之内有意义的数据，则详尽搜索方法不切实际。";

        String AppPath = AppDomain.CurrentDomain.BaseDirectory;

        [TestMethod]
        public void TestEncryptorDecryptor()
        {
            //FileReadWriteHelper fileReadWriteHelper = new FileReadWriteHelper(privateKeyDirectoryPath, fileName);
            //AESCryptor aESCryptor = new AESCryptor(new JsonSerializationHelper<KeyValuePair<String, String>>(),fileReadWriteHelper);

            ICryptor aESCryptor = Factory.CreateCryptor();

            String encrypted = Convert.ToBase64String(aESCryptor.Encryptor(Encoding.UTF8.GetBytes(input)));
            Assert.IsNotNull(encrypted);
            Console.WriteLine(encrypted);

            String outPut = Encoding.UTF8.GetString(aESCryptor.Decryptor(Convert.FromBase64String(encrypted)));

            Assert.IsNotNull(outPut);
            Console.WriteLine(outPut);
            Console.WriteLine(outPut.Length - input.Length);
            Assert.IsTrue(outPut.Length > 0);
            Assert.IsTrue(outPut.Length == input.Length);
        }
    }
}
