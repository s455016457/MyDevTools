using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyDevTools.Plugin.UtilityTools.Utility.Impl
{
    public class FileReadWriteHelper : IFileReadWriteHelper
    {
        /// <summary>
        /// 文件路径
        /// </summary>
        public String FilePath { get; private set; }
        /// <summary>
        /// 文件夹路径
        /// </summary>
        public String DirectoryPath { get; private set; }
        /// <summary>
        /// 文件名
        /// </summary>
        public String FileName { get; private set; }
        public FileReadWriteHelper(String directoryPath,String fileName)
        {
            this.DirectoryPath = directoryPath;
            this.FileName = fileName;
            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }

            FilePath = Path.Combine(directoryPath,fileName);
            if (!File.Exists(FilePath))
            {
                FileStream stream = null;
                try
                {
                    stream = File.Create(FilePath);
                }
                finally
                {
                    if (stream != null) stream.Close();
                }
            }
        }

        public string Read()
        {
            using (FileStream stream = File.OpenRead(FilePath))
            {
                if (!stream.CanRead)
                {
                    throw new Exception(String.Format("文件【{0}】不可读取！", FilePath));
                }                

                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        /// <summary>
        /// 完全覆盖
        /// </summary>
        /// <param name="message"></param>
        public void Write(string message)
        {
            using (FileStream stream = File.OpenWrite(FilePath))
            {
                if (!stream.CanWrite)
                {
                    throw new Exception(String.Format("文件【{0}】不可写入！", FilePath));
                }
                stream.SetLength(0);
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(message);
                }
            }
        }

        public bool HasContent()
        {
            if (!File.Exists(FilePath)) return false;
            using (FileStream stream = File.OpenWrite(FilePath))
            {
                return stream.Length > 0;
            }
        }
    }
}
