using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDevTools.Plugin.UtilityTools.DownloadImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Test.MyDevTools.Plugin.UtilityTools
{
    [TestClass]
    public class TestDownloadHelper
    {
        [TestMethod]
        public void Download()
        {
            DownloadHelper downloadHelper = new DownloadHelper();
            String url = "http://b354.photo.store.qq.com/psb?/V13pHVVf2GwiZg/WNGARehOFNIa*ho9Rcypvrxce71LilpaVwQtIT4SdTE!/b/dGIBAAAAAAAA&bo=gAJxBAAAAAAFB9M!&rf=viewer_4";
            String savePath = "E:\\study\\QQ控件相册图片批量下载";
            String fileType = "jpg";
            downloadHelper.Download(url, savePath, fileType);
        }
    }
}
