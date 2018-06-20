using MyDevTools.Plugin.Utility;
using MyDevTools.Plugin.UtilityTools.PasswordManagementTool.DataStor;
using MyDevTools.Plugin.UtilityTools.PasswordManagementTool.DataStor.Impl;
using MyDevTools.Plugin.UtilityTools.PasswordManagementTool.Entity;
using MyDevTools.Plugin.UtilityTools.PasswordManagementTool.Repository;
using MyDevTools.Plugin.UtilityTools.PasswordManagementTool.Repository.Impl;
using MyDevTools.Plugin.UtilityTools.Utility;
using MyDevTools.Plugin.UtilityTools.Utility.Impl;
using System;
using System.Collections.Generic;
using System.IO;

namespace MyDevTools.Plugin.UtilityTools.PasswordManagementTool
{
    public class Factory
    {
        private static String privateKeyDirectoryPath = Path.Combine(ApplicationCofig.AppDataDirectoryPath, "PasswordManagementTool"),
               dataDirectoryPath = Path.Combine(ApplicationCofig.AppDataDirectoryPath, "PasswordManagementTool");
        const String privateKeyFileName = "Private.key", dataFileName = "PasswordManagement.data";

        /// <summary>
        /// 创建密码项目资源库
        /// </summary>
        /// <returns></returns>
        public static IPassworkProjectRepository CreatePassworkProjectRepository(String password)
        {
            return new PasswordProjectRepository(CreatePasswordProjectStor(), password);
        }

        /// <summary>
        /// 创建文件读写帮助类
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static IFileReadWriteHelper CreateFileReadWriteHelper(String directoryPath, String fileName) {
            return new FileReadWriteHelper(directoryPath, fileName);
        }

        public static IFileReadWriteHelper CreateDataStorFileReadWriteHelper()
        {
            return CreateFileReadWriteHelper(privateKeyDirectoryPath, dataFileName);
        }

        /// <summary>
        /// 创建序列化帮助类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static ISerializationHelper<T> CreateSerializationHelper<T>()
        {
            return new JsonSerializationHelper<T>();
        }
    
        /// <summary>
        /// 创建加密类
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static ICryptor CreateCryptor()
        {
            return new AESCryptor(CreateSerializationHelper<KeyValuePair<String, String>>()
                , CreateFileReadWriteHelper(privateKeyDirectoryPath, privateKeyFileName));
        }

        public static ISign CreateSign()
        {
            return new HMACSHA1Sign();
        }

        /// <summary>
        /// 创建密码项目仓储
        /// </summary>
        /// <returns></returns>
        public static IPasswordProjectStor CreatePasswordProjectStor()
        {
            return new PasswordProjectStor(CreateSerializationHelper<PaswordProjectDataStor>()
                , CreateCryptor()
                , CreateSign()
                , CreateDataStorFileReadWriteHelper());
        }
    }
}
