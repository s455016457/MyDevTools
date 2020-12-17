using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetPrint.Entities
{
    /// <summary>
    /// 线条空间基类
    /// </summary>
    public abstract class BaseLineControl:BaseControl
    {
        /// <summary>
        /// 画笔
        /// </summary>
        public Pen Pen { get; set; }
    }
}
