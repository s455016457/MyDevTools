using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogProvider.Extended
{
    public static class ExceptionExtend
    {
        /// <summary>
        /// 获取完整异常信息
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static String GetMessage(this Exception ex)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(ex.Message);
            ex = ex.InnerException;
            while (ex != null)
            {
                stringBuilder.AppendLine(ex.Message);
                ex = ex.InnerException;
            }

            return stringBuilder.ToString();
        }
    }
}
