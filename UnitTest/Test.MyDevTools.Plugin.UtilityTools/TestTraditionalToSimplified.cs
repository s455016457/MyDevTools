using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDevTools.Plugin.UtilityTools.EncoderConver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Test.MyDevTools.Plugin.UtilityTools
{
    [TestClass]
    public class TestTraditionalToSimplified
    {
        [TestMethod]
        public void TestBig5ConvGb2312()
        {
            var tranfer = new TraditionalToSimplified();
            var str = tranfer.Big5ConvGb2312("中國");
            Console.WriteLine(str);
            Assert.AreEqual(str, "中国");
        }
        [TestMethod]
        public void TestGb2312ConvBig5()
        {
            var tranfer = new TraditionalToSimplified();
            var str = tranfer.Gb2312ConvBig5("中国");
            Console.WriteLine(str);
            Assert.AreEqual(str, "中國");
        }
    }
}
