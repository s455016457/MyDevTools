using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using PdfSharp;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace PdfHelper
{
    public static class MyPdfHelper
    {
        public static void MergePDFAndSave(string saveFilePath,params string[] filePaths)
        {
            var doc = MergePDF(filePaths);
            doc.Save(saveFilePath);
        }

        public static void MergePDFAndSave(string saveFilePath, params FileInfo[] fileInfos)
        {
            var doc = MergePDF(fileInfos);
            doc.Save(saveFilePath);
        }

        public static PdfDocument MergePDF(params string[] filePaths)
        {
            var fileInfos = new List<FileInfo>();
            foreach(var filePath in filePaths)
            {
                if (!File.Exists(filePath))
                    throw new Exception($"文件【{filePath}】不存在！");
                fileInfos.Add(new FileInfo(filePath));
            }

            return MergePDF(fileInfos.ToArray());
        }

        public static PdfDocument MergePDF(params FileInfo[] fileInfos)
        {
            PdfDocument document = new PdfDocument();
            foreach(var fileInfo in fileInfos)
            {
                var pages = GetPages(fileInfo);
                foreach(var page in pages)
                {
                    document.AddPage(page);
                }
            }
            return document;
        }
        /// <summary>
        /// Pdf删除指定页并保存
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="saveFileFullName">保存文件全称</param>
        /// <param name="index">指定页，从1开始</param>
        /// <returns></returns>
        public static void RemovePageAndSave(string filePath,string saveFileFullName, params int[] index)
        {
            var doc = RemovePage(filePath, index);
            doc.Save(saveFileFullName);
        }
        /// <summary>
        /// Pdf删除指定页并保存
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <param name="saveFileFullName">保存文件全称</param>
        /// <param name="index">指定页，从1开始</param>
        /// <returns></returns>
        public static void RemovePageAndSave(FileInfo fileInfo, string saveFileFullName, params int[] index)
        {
            var doc = RemovePage(fileInfo, index);
            doc.Save(saveFileFullName);
        }
        /// <summary>
        /// Pdf删除指定页
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="index">指定页，从1开始</param>
        /// <returns></returns>
        public static PdfDocument RemovePage(string filePath, params int[] index)
        {
            if (!File.Exists(filePath))
                throw new Exception($"文件【{filePath}】不存在！");

            return RemovePage(new FileInfo(filePath), index);
        }

        /// <summary>
        /// Pdf删除指定页
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <param name="index">指定页，从1开始</param>
        /// <returns></returns>
        public static PdfDocument RemovePage(FileInfo fileInfo,params int[] index)
        {
            if (index.Min() < 1)
            {
                throw new Exception("被删除的页不能小于1！");
            }
            PdfDocument document = new PdfDocument();
            int i =0;
            foreach(var page in GetPages(fileInfo))
            {
                i++;
                if (Array.Exists(index,p=>p.Equals(i))) continue;
                document.AddPage(page);
            }
            return document;
        }

        public static IEnumerable<PdfPage> GetPages(FileInfo fileInfo)
        {
            PdfDocument inputDoc = PdfReader.Open(fileInfo.FullName, PdfDocumentOpenMode.Import);
            return inputDoc.Pages;
        }

        public static int GetPagesCount(FileInfo fileInfo)
        {
            PdfDocument inputDoc = PdfReader.Open(fileInfo.FullName, PdfDocumentOpenMode.Import);
            return inputDoc.PageCount;
        }
    }
}
