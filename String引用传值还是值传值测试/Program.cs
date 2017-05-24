using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace String引用传值还是值传值测试
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = "123456";

            Console.WriteLine(test);
            SubIndex0(test);
            Console.WriteLine(test);

            Console.ReadKey();
        }

        public static string SubIndex0(string text)
        {
            text = text.Substring(1);
            return text;
        }
    }
}
