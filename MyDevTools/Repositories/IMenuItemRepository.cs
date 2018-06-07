using MyDevTools.Plugin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDevTools.Repositories
{
    public interface IMenuItemRepository
    {

        /// <summary>
        /// 获取插件列表
        /// </summary>
        /// <returns></returns>
        IList<IPlugin> GetPlugins();

        /// <summary>
        /// 获取插件组
        /// </summary>
        /// <returns></returns>
        IList<String> GetGroupName();
    }
}
