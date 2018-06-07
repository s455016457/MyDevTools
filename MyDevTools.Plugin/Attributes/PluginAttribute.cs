using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDevTools.Plugin.Attributes
{
    /// <summary>
    /// 插件属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class PluginAttribute : Attribute
    {
        /// <summary>
        /// 插件组别
        /// </summary>
        public string Group
        {
            get;
            set;
        }
        /// <summary>
        /// 插件可配置
        /// </summary>
        public bool CanConfig
        {
            get;
            set;
        }
        /// <summary>
        /// 插件可重置
        /// </summary>
        public bool CanReset
        {
            get;
            set;
        }
        /// <summary>
        /// 插件标题
        /// </summary>
        public string Title
        {
            get;
            set;
        }
        /// <summary>
        /// 插件副标题
        /// </summary>
        public string SubTitle
        {
            get;
            set;
        }
        /// <summary>
        /// 插件作者
        /// </summary>
        public string Author
        {
            get;
            set;
        }
        /// <summary>
        /// 插件描述
        /// </summary>
        public string Description
        {
            get;
            set;
        }
        /// <summary>
        /// 插件图标
        /// </summary>
        public Icon Icon
        {
            get;
            set;
        }
        /// <summary>
        /// 初始化插件属性
        /// </summary>
        public PluginAttribute()
        {
            CanConfig = false;
            CanReset = false;
            Title = string.Empty;
            SubTitle = String.Empty;
            Author = string.Empty;
            Description = string.Empty;
            Icon = Resources.DefaultIcon;
            Group = PluginGroup.Utility;
        }
    }
}
