using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDevTools.Plugin.UtilityTools.Utility
{
    public static class ByteExtend
    {
        /// <summary>
        /// 将byte[]转成bit字符串
        /// </summary>
        /// <param name="value"></param>
        /// <param name="separator">分隔符</param>
        /// <returns></returns>
        public static String ToBitString(this byte[] value,String separator="-")
        {
            String str = BitConverter.ToString(value);

            if (!separator.Equals("-"))
                str = str.Replace("-", separator);

            return str;
        }
    }
}
