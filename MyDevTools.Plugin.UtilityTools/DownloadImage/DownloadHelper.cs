using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;

namespace MyDevTools.Plugin.UtilityTools.DownloadImage
{
    public class DownloadHelper
    {
        HttpClient httpClient;
        public DownloadHelper() {
            httpClient = new HttpClient();
        }
        public void Download(String Url, String SavePath, String fileType)
        {
            httpClient = new HttpClient();

            var bytes = httpClient.GetByteArrayAsync(Url).Result;
            Stream stream = httpClient.GetStreamAsync(Url).Result;
            String fileName = String.Format("{0}.{1}", Guid.NewGuid().ToString("N"), fileType);
            using (FileStream file = File.Create(Path.Combine(SavePath, fileName)))
            {
                file.Write(bytes, 0, bytes.Length);
                //byte[] buffer = new byte[102400];
                //int length = 0;
                //while ((length = stream.Read(buffer, 0, buffer.Length)) > 0)
                //{
                //    file.Write(buffer, 0, length);
                //}
            }
        }
    }
}
