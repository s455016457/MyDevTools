using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDevTools.Plugin.EncryptionTools.Extends
{
    public static class IntExtend
    {
        /// <summary>
        /// int值转为byte
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte ToByte(this int value)
        {
            //int v = 0xFE; //申明一个16进制数字 值为255
            if (value < byte.MinValue || value > byte.MaxValue)
            {
                throw new Exception(String.Format("byte的有效值范围为【{0}，{1}】", byte.MinValue, byte.MaxValue));
            }
            return (byte)value;
        }
    }
}
