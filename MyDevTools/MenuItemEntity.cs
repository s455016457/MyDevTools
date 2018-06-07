using MyDevTools.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDevTools
{
    /// <summary>
    /// 菜单实体
    /// </summary>
    public class MenuItemEntity
    {
        /// <summary>
        /// 组
        /// </summary>
        public String Group { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public String Title { get; set; }
        /// <summary>
        /// 副标题
        /// </summary>
        public String SubTitle { get; set; }
        /// <summary>
        /// 详情
        /// </summary>
        public String Description { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public String Author { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public Icon Icon { get; set; } = Resources.icon;
    }
}
