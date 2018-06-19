using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDevTools.Plugin.UtilityTools.Utility
{
    public interface ISign
    {
        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="bytes">待签名字节</param>
        /// <param name="sign">签名</param>
        /// <returns></returns>
        byte[] Sign(byte[] bytes, byte[] sign);

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="sign"></param>
        /// <param name="outByte"></param>
        /// <returns></returns>
        bool Verify(byte[] bytes, byte[] sign, out byte[] outByte);
    }
}
