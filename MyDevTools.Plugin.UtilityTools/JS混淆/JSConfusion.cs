using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyDevTools.Plugin.UtilityTools.JS混淆
{
    /// <summary>
    /// JavaScript 脚本混淆
    /// 核心思想 
    /// 1、将执行的JS转成ASCII编码
    /// 2、在页面上用 String. fromCharCode方法将ASCII编码转成字符串
    /// 3、用eval方法执行JS字符串
    /// </summary>
    public class JSConfusion
    {
        // fromCharCode 方法，将ASCII字符串转成字符串
        private const string fromCharCode = " \\u0053\\u0074\\u0072\\u0069\\u006e\\u0067. \\u0066\\u0072\\u006f\\u006d\\u0043\\u0068\\u0061\\u0072\\u0043\\u006f\\u0064\\u0065";
        // eval 方法，在浏览器执行JS字符串
        private const string eval = " \\u0065\\u0076\\u0061\\u006c";

        private const string str = "1234567890qwertyuiopasdfghjklzxcvbnm-_QWERTYUIOPASDFGHJKLZXCVBNM";

        private Random Random = new Random(0);

        StringBuilder template = new StringBuilder();
        string evalName, fromCharCodeName;

        public JSConfusion()
        {
            evalName = CreateRandomStr(10);
            fromCharCodeName = CreateRandomStr(10);
            while(fromCharCodeName.Equals(evalName,StringComparison.CurrentCultureIgnoreCase))
                fromCharCodeName = CreateRandomStr(10);

            initEvalMethod(evalName);
            initFromCharCodeMethod(fromCharCodeName);
        }

        /// <summary>
        /// 混淆脚本
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        public string Confusion(string script)
        {
            string strScript = BytesToIntStr(StringToAscii(script));
            var str = packagFromCharCodeMethod(strScript);
            str = packagEvalCodeMethod(str);
            template.Append(str);
            return template.ToString();
        }
        /// <summary>
        /// 范混淆
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        public string UnObfuscate(string script)
        {
            ///****GJM3Ub***//****Un6wzpMRA2gsBvI8iX***//****sz0tjIWceLGPJYWr***/var /****6HqRGtMxROF7OI9Zex***//****aTzHFDAVobT***//****oGtw5WU***/GSmrmZl/****tC5ZY707WVc0Y-tW1f***//****4oIBMgbivn4icJW7P***/=/****9UWHY-wwQuM-5uH-Rb***//****5v0GR-mYMp5zxr5t0ll***/ \u0065\u0076\u0061\u006c;/****GeX2vBM2***/var /****B_SajN***//****Nu9ZwLnDvdM3U8ec_***/iozExN2KM/****yD9WmR***/=/****7***//****IZRuuxeLcEafyMW1N***/ \u0053\u0074\u0072\u0069\u006e\u0067. \u0066\u0072\u006f\u006d\u0043\u0068\u0061\u0072\u0043\u006f\u0064\u0065;/****91mYgKaDbHn***//****qEmayFzXse***//****Trn***/GSmrmZl/****x7l8KmUR1-zM88o***//****Fuu1loHGbVeV***/(/****S6e***//****8O***//****HR***/iozExN2KM/****HKlXF***//****sSkRMQ6WM***/(99,111,110,115,111,108,101,46,108,111,103,40,49,50,51,41,59))
            Regex reg = new Regex(@"\((\d,*)+\)");
            var str = reg.Match(script).Value;
            str = str.Substring(1, str.Length - 2);
           return  Encoding.ASCII.GetString(IntStrToBytes(str));
        }

        private void initEvalMethod(string evalName)
        {
            template.Append(CreateRandomAnnotation());
            template.Append("var ");
            template.Append(CreateRandomAnnotation());
            template.Append(evalName);
            template.Append(CreateRandomAnnotation());
            template.Append("=");
            template.Append(CreateRandomAnnotation());
            template.Append(eval);
            template.Append(";");
        }

        private void initFromCharCodeMethod(string fromCharCodeName)
        {
            template.Append(CreateRandomAnnotation());
            template.Append("var ");
            template.Append(CreateRandomAnnotation());
            template.Append(fromCharCodeName);
            template.Append(CreateRandomAnnotation());
            template.Append("=");
            template.Append(CreateRandomAnnotation());
            template.Append(fromCharCode);
            template.Append(";");
        }

        private StringBuilder packagEvalCodeMethod(StringBuilder param)
        {
            StringBuilder temp = new StringBuilder();
            temp.Append(CreateRandomAnnotation());
            temp.Append(evalName);
            temp.Append(CreateRandomAnnotation());
            temp.Append($"({param})");
            return temp;
        }
        private StringBuilder packagEvalCodeMethod(string param)
        {
            StringBuilder temp = new StringBuilder();
            temp.Append(CreateRandomAnnotation());
            temp.Append(evalName);
            temp.Append(CreateRandomAnnotation());
            temp.Append($"({param})");
            return temp;
        }

        private StringBuilder packagFromCharCodeMethod(string param)
        {
            StringBuilder temp = new StringBuilder();
            temp.Append(CreateRandomAnnotation());
            temp.Append(fromCharCodeName);
            temp.Append(CreateRandomAnnotation());
            temp.Append($"({param})");
            return temp;
        }

        private StringBuilder packagFromCharCodeMethod(StringBuilder param)
        {
            StringBuilder temp = new StringBuilder();
            temp.Append(CreateRandomAnnotation());
            temp.Append(fromCharCodeName);
            temp.Append(CreateRandomAnnotation());
            temp.Append($"({param})");
            return temp;
        }

        /// <summary>
        /// 创建随机字符串
        /// </summary>
        /// <param name="maxLenght"></param>
        /// <returns></returns>
        private string CreateRandomStr(int maxLenght)
        {
            var length = Random.Next(maxLenght - 1) + 1;
            StringBuilder temp = new StringBuilder();
            while (temp.Length < length)
            {
                temp.Append(str[Random.Next(str.Length)]);
            }
            return temp.ToString();
        }

        /// <summary>
        /// 创建随机注释
        /// </summary>
        /// <returns></returns>
        private string CreateRandomAnnotation()
        {
            //return string.Empty;
            StringBuilder temp = new StringBuilder();
            int count = Random.Next(3);
            while (count-- >= 0)
            {
                temp.Append($"/****{CreateRandomStr(20)}***/");
            }
            return temp.ToString();
        }

        private byte[] StringToAscii(string str)
        {
            return Encoding.ASCII.GetBytes(str);
        }

        private string BytesToIntStr(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in bytes)
            {
                sb.Append($"{item},");
            }
            sb.Length = sb.Length - 1;
            return sb.ToString();
        }

        private byte[] IntStrToBytes(string str)
        {
            List<byte> bytes = new List<byte>();
            string[] strs = str.Split(',');
            foreach (var item in strs)
            {
                bytes.Add(byte.Parse(item));
            }

            return bytes.ToArray();
        }
    }
}
