using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDevTools.Plugin.UtilityTools.Maths;

namespace UnitTest.Test.MyDevTools.Plugin.UtilityTools
{
    [TestClass]
    public class TestMathHelper
    {
        [TestMethod]
        public void TesGetGCD()
        {
            int x=104, y=40, z = 0;
            z=MathHelper.GetGCD(x, y);
            Console.WriteLine($"【{x}】【{y}】的最大公约数是：【{z}】");

            x = 88;
            y = 33;
            z = 0;
            z = MathHelper.GetGCD(x, y);
            Console.WriteLine($"【{x}】【{y}】的最大公约数是：【{z}】");


            x = 83;
            y = 32;
            z = 0;
            z = MathHelper.GetGCD(x, y);
            Console.WriteLine($"【{x}】【{y}】的最大公约数是：【{z}】");

            x = 88;
            y = -33;
            z = 0;
            z = MathHelper.GetGCD2(x, y);
            Console.WriteLine($"【{x}】【{y}】的最大公约数是：【{z}】");

            x = 31596596;
            y = 26547544;
            z = 0;
            z = MathHelper.GetGCD2(x, y);
            Console.WriteLine($"【{x}】【{y}】的最大公约数是：【{z}】");

            int i = 1000000;
            var temp = i;
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            while (i-- > 0)
            {
                x = 31596596;
                y = 26547544;
                z = 0;
                z = MathHelper.GetGCD2(x, y);
            }
            stopwatch.Stop();
            Console.WriteLine($"执行【{temp}】次，耗时【{stopwatch.Elapsed.Milliseconds}】毫秒！");
        }
        [TestMethod]
        public void TesGetGCDLong()
        {
            long x = 104, y = 40, z = 0;
            z = MathHelper.GetGCD(x, y);
            Console.WriteLine($"【{x}】【{y}】的最大公约数是：【{z}】");

            x = 88;
            y = 33;
            z = 0;
            z = MathHelper.GetGCD(x, y);
            Console.WriteLine($"【{x}】【{y}】的最大公约数是：【{z}】");


            x = 83;
            y = 32;
            z = 0;
            z = MathHelper.GetGCD(x, y);
            Console.WriteLine($"【{x}】【{y}】的最大公约数是：【{z}】");

            x = 88;
            y = -33;
            z = 0;
            z = MathHelper.GetGCD2(x, y);
            Console.WriteLine($"【{x}】【{y}】的最大公约数是：【{z}】");

            x = 31596596;
            y = 26547544;
            z = 0;
            z = MathHelper.GetGCD2(x, y);
            Console.WriteLine($"【{x}】【{y}】的最大公约数是：【{z}】");
            {
                x = 75430199424;
                y = 14307527990520;
                z = 0;
                z = MathHelper.GetGCD2(x, y);
                Console.WriteLine($"【{x}】【{y}】的最大公约数是：【{z}】");

                int i = 1000000;
                var temp = i;
                System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
                stopwatch.Start();
                while (i-- > 0)
                {
                    x = 75430199424;
                    y = 14307527990520;
                    z = 0;
                    z = MathHelper.GetGCD2(x, y);
                }
                stopwatch.Stop();
                Console.WriteLine($"执行【{temp}】次，耗时【{stopwatch.Elapsed.Milliseconds}】毫秒！");

                stopwatch.Reset();
                stopwatch.Start();
                i = temp;
                while (i-- > 0)
                {
                    x = 75430199424;
                    y = 14307527990520;
                    z = 0;
                    z = MathHelper.GetGCD(x, y);
                }
                stopwatch.Stop();
                Console.WriteLine($"执行【{temp}】次，耗时【{stopwatch.Elapsed.Milliseconds}】毫秒！");
            }
            {
                x = 8676462979039442346;
                y = 2823870847698223284;
                z = 0;
                z = MathHelper.GetGCD2(x, y);
                Console.WriteLine($"【{x}】【{y}】的最大公约数是：【{z}】");
                int i = 1000000;
                var temp = i;
                System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
                stopwatch.Start();
                while (i-- > 0)
                {
                    x = 8676462979039442346;
                    y = 2823870847698223284;
                    z = 0;
                    z = MathHelper.GetGCD2(x, y);
                }
                stopwatch.Stop();
                Console.WriteLine($"执行【{temp}】次，耗时【{stopwatch.Elapsed.Milliseconds}】毫秒！");

                stopwatch.Reset();
                stopwatch.Start();
                i = temp;
                while (i-- > 0)
                {
                    x = 8676462979039442346;
                    y = 2823870847698223284;
                    z = 0;
                    z = MathHelper.GetGCD(x, y);
                }
                stopwatch.Stop();
                Console.WriteLine($"执行【{temp}】次，耗时【{stopwatch.Elapsed.Milliseconds}】毫秒！");
            }
            {
                x = 2022162432;
                y = 2095439872;
                z = 0;
                z = MathHelper.GetGCD2(x, y);
                Console.WriteLine($"【{x}】【{y}】的最大公约数是：【{z}】");
                int i = 1000000;
                var temp = i;
                System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
                stopwatch.Start();
                while (i-- > 0)
                {
                    x = 2022162432;
                    y = 2095439872;
                    z = 0;
                    z = MathHelper.GetGCD2(x, y);
                }
                stopwatch.Stop();
                Console.WriteLine($"执行【{temp}】次，耗时【{stopwatch.Elapsed.Milliseconds}】毫秒！");

                stopwatch.Reset();
                stopwatch.Start();
                i = temp;
                while (i-- > 0)
                {
                    x = 2022162432;
                    y = 2095439872;
                    z = 0;
                    z = MathHelper.GetGCD(x, y);
                }
                stopwatch.Stop();
                Console.WriteLine($"执行【{temp}】次，耗时【{stopwatch.Elapsed.Milliseconds}】毫秒！");
            }
        }
    }
}
