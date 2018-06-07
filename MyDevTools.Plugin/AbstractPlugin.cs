using MyDevTools.Plugin.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDevTools.Plugin
{
    /// <summary>
    /// 插件基类
    /// </summary>
    public abstract class AbstractPlugin : IPlugin
    {
        /// <summary>
        /// 组别
        /// </summary>
        public virtual string Group { get; protected set; }
        /// <summary>
        /// 标题
        /// </summary>
        public virtual string Title { get; protected set; }
        /// <summary>
        /// 副标题
        /// </summary>
        public virtual string SubTitle { get; protected set; }
        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Description { get; protected set; }
        /// <summary>
        /// 作者
        /// </summary>
        public virtual string Author { get; protected set; }
        /// <summary>
        /// 图标
        /// </summary>
        public virtual Icon Icon { get; protected set; }
        /// <summary>
        /// 可以配置
        /// </summary>
        public virtual bool CanConfig { get; protected set; }
        /// <summary>
        /// 可以重置
        /// </summary>
        public virtual bool CanReset { get; protected set; }
        /// <summary>
        /// 配置
        /// </summary>
        public abstract void Config();
        /// <summary>
        /// 重置
        /// </summary>
        public abstract void Reset();
        /// <summary>
        /// 开启
        /// </summary>
        public abstract void StartUp();
        /// <summary>
        /// 构造函数
        /// </summary>
        public AbstractPlugin()
        {
            object[] customAttributes= GetType().GetCustomAttributes(typeof(Attributes.PluginAttribute), false);

            if (customAttributes.Length <= 0) return;

            Attributes.PluginAttribute pluginAttribute = customAttributes[0] as Attributes.PluginAttribute;

            if (pluginAttribute == null) return;

            Group = pluginAttribute.Group??PluginGroup.Utility;
            Title = pluginAttribute.Title;
            SubTitle = pluginAttribute.SubTitle;
            Description = pluginAttribute.Description;
            Author = pluginAttribute.Author;
            Icon = pluginAttribute.Icon ?? Resources.DefaultIcon;
            CanConfig = pluginAttribute.CanConfig;
            CanReset = pluginAttribute.CanReset;
        }
    }
}
