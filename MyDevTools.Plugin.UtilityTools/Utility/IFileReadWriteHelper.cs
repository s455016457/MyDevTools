using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDevTools.Plugin.UtilityTools.Utility
{
    public interface IFileReadWriteHelper
    {
        /// <summary>
        /// 读
        /// </summary>
        /// <returns></returns>
        String Read();
        /// <summary>
        /// 写
        /// </summary>
        /// <param name="message"></param>
        void Write(String message);

        Boolean HasContent();
    }
}
