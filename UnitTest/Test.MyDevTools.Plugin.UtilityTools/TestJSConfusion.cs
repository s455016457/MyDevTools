using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDevTools.Plugin.UtilityTools.JS混淆;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Test.MyDevTools.Plugin.UtilityTools
{
    [TestClass]
    public class TestJSConfusion
    {
        [TestMethod]
        public void Confusion()
        {
            JSConfusion jSConfusion = new JSConfusion();
            var str = jSConfusion.Confusion("console.log(123);");

            Console.WriteLine(str);
        }

        [TestMethod]
        public void Unobfuscate()
        {
            JSConfusion jSConfusion = new JSConfusion();
            var str = jSConfusion.Confusion("console.log(123);");

            str = jSConfusion.UnObfuscate(str);
            Console.WriteLine(str);
        }
    }
}
