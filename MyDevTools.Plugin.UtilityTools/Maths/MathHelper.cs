using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDevTools.Plugin.UtilityTools.Maths
{
    public static class MathHelper
    {
        /// <summary>
        /// 获取两个正整数的最大公约数
        /// </summary>
        /// <param name="x">整数1</param>
        /// <param name="y">整数2</param>
        /// <returns></returns>
        public static int GetGCD(int x, int y)
        {
            //int temp = 0;
            //while ((temp = x % y) != 0)
            //{
            //    x = y;
            //    y = temp;
            //}
            //return y;

            // 简化上面代码
            return y == 0 ? x : GetGCD(y, x % y);

        }

        /// <summary>
        /// 获取两个整数的最大公约数
        /// </summary>
        /// <param name="x">整数1</param>
        /// <param name="y">整数2</param>
        /// <returns></returns>
        public static int GetGCD2(int x,int y)
        {
            if (x == 0 || y == 0)
                throw new Exception("x,y必须为非零整数！");
            return GetGCD(Math.Abs(x), Math.Abs(y));
        }

        /// <summary>
        /// 获取两个大正整数的最大公约数
        /// </summary>
        /// <param name="x">大整数1</param>
        /// <param name="y">大整数2</param>
        /// <returns></returns>
        public static long GetGCD(long x,long y)
        {
            return y == 0 ? x : GetGCD(y, x % y);
        }

        /// <summary>
        /// 获取两个大整数的最大公约数
        /// </summary>
        /// <param name="x">大整数1</param>
        /// <param name="y">大整数2</param>
        /// <returns></returns>
        public static long GetGCD2(long x, long y)
        {
            if (x == 0 || y == 0)
                throw new Exception("x,y必须为非零整数！");
            x = Math.Abs(x);
            y = Math.Abs(y);
            int xLeftSize = 0, yLeftSize = 0;
            // 将大数变成小数
            while (!IsOdd(x) /*&& xLeftSize < 8*/)
            {
                x = x >> 1;
                xLeftSize++;
            }
            while (!IsOdd(y) /*&& yLeftSize < 8*/)
            {
                y = y >> 1;
                yLeftSize++;
            }

            return GetGCD(x, y) << (xLeftSize > yLeftSize ? yLeftSize : xLeftSize);
        }

        /// <summary>
        /// 判断一个数组为奇数
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool IsOdd(long x) {
            /***
             * 与运算 任何一个数字与1与运算不为0则为奇数
             * 例如：
             * 3与1与运算
             * 11&01 结果为1
             * 
             * 5与1 与运算
             * 101&001 结果为1
             * 
             * 6与1 与运算
             * 110&001 结果为0
             * 
             * * */
            return Convert.ToBoolean(x & 1);
        }
    }
}

