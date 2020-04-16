using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDevTools.Plugin.UtilityTools.EncoderConver
{
    /// <summary>
    /// 繁体简体互转
    /// </summary>
   public  class TraditionalToSimplified
    {

        /// <summary>
        /// 繁体转简体
        /// </summary>
        /// <param name="strbig5"></param>
        /// <returns></returns>
        public string Big5ConvGb2312(string strbig5)
        {
            return Strings.StrConv(strbig5, VbStrConv.SimplifiedChinese);
        }
        /// <summary>
        /// 简体转繁体
        /// </summary>
        /// <param name="strGb2312"></param>
        /// <returns></returns>
        public string Gb2312ConvBig5(string strGb2312)
        {
            return Strings.StrConv(strGb2312, VbStrConv.TraditionalChinese);
        }
    }
}
