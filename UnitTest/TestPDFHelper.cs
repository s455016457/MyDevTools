using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass]
    public class TestPDFHelper
    {
        [TestMethod]
        public void TestMethod1()
        {
            PdfHelper.MyPdfHelper.MergePDFAndSave("E:\\WORK\\客户资料\\服务协议\\签回服务协议扫描\\123.pdf"
                , "E:\\WORK\\客户资料\\服务协议\\签回服务协议扫描\\2020科华服务协议.pdf"
                , "E:\\WORK\\客户资料\\服务协议\\签回服务协议扫描\\2020美斯特服务协议.pdf"
                , "E:\\WORK\\客户资料\\服务协议\\签回服务协议扫描\\2020翔光服务协议.pdf");

        }
    }
}
