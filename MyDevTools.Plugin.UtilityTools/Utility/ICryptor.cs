using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDevTools.Plugin.UtilityTools.Utility
{
    /// <summary>
    /// 加密接口
    /// </summary>
    public interface ICryptor
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        byte[] Encryptor(byte[] bytes);

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="encrypted"></param>
        /// <returns></returns>
        byte[] Decryptor(byte[] bytes);
    }
}
