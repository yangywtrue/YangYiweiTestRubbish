using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace lockTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("1", "1");
            dic.Add("1", "1");
            Object lockObj = new object();
            object lockObj1 = lockObj;
            object lockObj2 = lockObj;

            TaskFactory f = new TaskFactory();
            f.StartNew(() =>
            {
                lock (lockObj1)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        Console.WriteLine("LockObj1:" + i);
                        Thread.Sleep(100);
                    }
                }
            });

            f.StartNew(() =>
            {
                lock (lockObj2)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        Console.WriteLine("LockObj2:" + i);
                        Thread.Sleep(100);
                    }
                }
            });

            Console.ReadKey();
        }


    }
}
