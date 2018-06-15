using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogProvider;
using LogProvider.Interfaces;
using LogProvider.Factories;
using MyDevTools.Plugin;
using MyDevTools.Plugin.Interfaces;
using MyDevTools.Plugin.Attributes;
using System.IO;
using System.Reflection;
using MyDevTools.Plugin.Utility;

namespace MyDevTools.PluginManager
{
    /// <summary>
    /// 插件管理
    /// </summary>
    public static class PluginManager
    {
        private static ILogSaveProvider log = new LogSaveLocalhostProvider();
        private static string[] _pluginExtensions = new String[] { ".exe", ".dll" };
        /// <summary>
        /// 插件文件夹
        /// </summary>
        public static string PluginsFolder { get; private set; } = ApplicationCofig.PluginsDirectoryPath;

        /// <summary>
        /// 插件集合
        /// </summary>
       public static List<IPlugin> Plugins { get; private set; }
        /// <summary>
        /// 重新加载插件
        /// </summary>
        public static void ReLoadPlugins()
        {
            LoadPlugins();
        }

        static PluginManager()
        {
            CheckPluginFolder();
            LoadPlugins();
        }

        /// <summary>
        /// 检查插件文件夹
        /// </summary>
        private static void CheckPluginFolder()
        {
            if (!Directory.Exists(PluginsFolder))
            {
                Directory.CreateDirectory(PluginsFolder);
            }
        }

        /// <summary>
        /// 加载插件
        /// </summary>
        private static void LoadPlugins()
        {
            Plugins = new List<IPlugin>();
            List<String> files = GetFiles(PluginsFolder);

            foreach (String filePath in files)
            {
                string fileName = Path.GetFileName(filePath);
                string fileExtension = Path.GetExtension(filePath);

                if (fileName.Equals("MyDevTools.Plugin.dll", StringComparison.InvariantCultureIgnoreCase) 
                    || !_pluginExtensions.Contains(fileExtension)) continue;

                try
                {
                    Assembly pluginAssembly = Assembly.LoadFrom(filePath);
                    Type[] exprotedTypes = pluginAssembly.GetExportedTypes();

                    foreach (Type type in exprotedTypes)
                    {
                        if (!TypeIsIPlugin(type)) continue;

                        Plugins.Add((IPlugin)Activator.CreateInstance(type));
                    }
                }
                catch (Exception ex)
                {
                    var entity = LogEntityFactory.Create(String.Format("加载插件 {0} 时出现错误:{1}", fileName, ex.ToString()),
                        LogTypeFacotry.CreateExceptionLogType(),
                        LogLevelFactory.CreateWarningLogLevel());
                    log.SaveLog(entity);
                }
            }            
        }

        /// <summary>
        /// 获取文件夹中所有文件
        /// </summary>
        /// <param name="folderPath">文件夹路径</param>
        /// <returns></returns>
        private static List<String> GetFiles(String folderPath)
        {
            List<String> files = new List<string>();
            string[] directories = Directory.GetDirectories(folderPath);
            for (int i = 0; i < directories.Length; i++)
            {
                string pluginFolder = directories[i];
                files.AddRange(Directory.GetFiles(pluginFolder));
            }
            return files;
        }

        /// <summary>
        /// 类型是插件
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static Boolean TypeIsIPlugin(Type type)
        {
            return !type.IsAbstract
                && typeof(IPlugin).IsAssignableFrom(type)
                && type.GetConstructor(Enumerable.Empty<Type>().ToArray<Type>()) != null;
        }
    }
}
