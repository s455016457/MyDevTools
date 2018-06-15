using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDevTools.Plugin.EncryptionTools.Extends
{
    public static class StringExtend
    {
        /// <summary>
        /// 将Bit字符串转为Byte数字
        /// 含分隔符
        /// <remark>
        /// Bit字符串格式为 16进制-16进制-16进制
        /// byte[ ] arrayOne = { 0, 1, 2, 4, 8, 16, 32, 64,128, 255 }
        /// 转换后 00-01-02-04-08-10-20-40-80-FF
        /// byte minValue=0,maxValue=255
        /// 16进制两位数的取值范围[0，255]
        /// </remark>
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static byte[] ToByteArrayByBitString(this String Value,char separator='-')
        {
            String[] strs = Value.Split(separator);
            var bytes = new byte[strs.Length];
            for (int i = 0; i < strs.Length; i++)
            {
                try
                {
                    bytes[i] = strs[i].ToIntX().ToByte();
                }
                catch (Exception ex)
                {
                    throw new Exception(
                        String.Format("Bit字符串格式不正确，错误字符：{0},错误原因：{1}"
                            , strs[i]
                            ,ex.Message)
                        , ex.InnerException);
                }
            }
            return bytes;
        }

        /// <summary>
        /// 将Bit字符串转为Byte数字
        /// 无分隔符
        /// <remark>
        public static byte[] ToByteArrayByBitString(this String Value)
        {
            if (Value.Length % 2 > 0)
            {
                throw new Exception("Bit字符串格式不正确");
            }

            byte[] bytes = new byte[Value.Length / 2];

            for (int i = 0; i < Value.Length / 2; i++)
            {
                String str = Value.Substring(i * 2, 2);
                try
                {
                    bytes[i] = str.ToIntX().ToByte();
                }
                catch (Exception ex)
                {
                    throw new Exception(
                        String.Format("Bit字符串格式不正确，错误字符：{0},错误原因：{1}"
                            , str
                            , ex.Message)
                        , ex.InnerException);
                }
            }

            return bytes;
        }

        /// <summary>
        /// 将16进制字符串转成int
        /// int v = 0xFE; 申明一个16进制数字 值为255
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static int ToIntX(this String Value)
        {
            return Convert.ToInt32(Value, 16);
        }
    }
}
