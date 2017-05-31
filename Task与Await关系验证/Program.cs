using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task与Await关系验证
{
    class Program
    {
        static void Main(string[] args)
        {
            //Form1 form = new Form1();
            //form.ShowDialog();

            //Console.WriteLine("主线程测试开始..");
            //AsyncMethod();
            //Thread.Sleep(1000);
            //Console.WriteLine("主线程测试结束..");
            //Console.ReadLine();

            Test();
            Console.WriteLine("ssssssssssssssssss");
            Console.ReadKey();
        }

        static async void Test()
        {
            Console.WriteLine("主线程测试开始..");
            await AsyncMethod();
            Thread.Sleep(1000);
            Console.WriteLine("主线程测试结束..");
            Console.ReadLine();
        }


        static async Task AsyncMethod()
        {
            Console.WriteLine("开始异步代码");
            var result = await MyMethod();
            Console.WriteLine("异步代码执行完毕");
        }

        static async Task<int> MyMethod()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("异步执行" + i.ToString() + "..");
                await Task.Delay(1000); //模拟耗时操作
            }
            return 0;
        }
    }
}
