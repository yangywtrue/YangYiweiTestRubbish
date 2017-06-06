using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task类研究
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;

            token.Register(() =>
            {
                Console.WriteLine("Token 的Register方法被触发!");
            });

            Task task = new Task(() =>
            {
                for (int i = 0; i < int.MaxValue; i++)
                {
                    Console.WriteLine("Task 中循环：" + i);
                    token.WaitHandle.WaitOne(1000);

                    token.ThrowIfCancellationRequested();
                }
            }, token);

            task.Start();

            //try
            //{
            //    Task.WaitAll(task);
            //}
            //catch (AggregateException ex)
            //{
            //    Console.WriteLine(ex.InnerException.Message);
            //}
            
            Console.ReadKey();

            source.Cancel();

            Console.ReadKey();

            task.Start();

            Console.ReadKey();
        }
    }
}
