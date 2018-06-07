using System;
using System.Drawing;

namespace MyDevTools.Plugin.Interfaces
{
    /// <summary>
    /// 插件接口 内部使用
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// 组
        /// </summary>
        String Group { get; }
        /// <summary>
        /// 标题
        /// </summary>
        String Title { get; }
        /// <summary>
        /// 副标题
        /// </summary>
        String SubTitle { get; }
        /// <summary>
        /// 详情
        /// </summary>
        String Description { get; }
        /// <summary>
        /// 作者
        /// </summary>
        String Author { get; }
        /// <summary>
        /// 图标
        /// </summary>
        Icon Icon { get; }
        /// <summary>
        /// 可以配置
        /// </summary>
        bool CanConfig{get;}
        /// <summary>
        /// 可以重置
        /// </summary>
        bool CanReset{get;}

        /// <summary>
        /// 开启
        /// </summary>
        void StartUp();
        /// <summary>
        /// 重置
        /// </summary>
        void Reset();
        /// <summary>
        /// 配置
        /// </summary>
        void Config();
    }
}
