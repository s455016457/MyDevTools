using MyDevTools.Plugin.Interfaces;
using MyDevTools.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDevTools.Repositories.Impl
{
    public class MenuItemRepository : IMenuItemRepository
    {
        IList<MenuItemEntity> list = new List<MenuItemEntity>();

        public IList<string> GetGroupName()
        {
            return GetPlugins().Select(p=>p.Group).Distinct().ToList();
        }

        public IList<IPlugin> GetPlugins()
        {
            return PluginManager.PluginManager.Plugins.OrderBy(p=>p.Title).ToList();
        }
    }
}
