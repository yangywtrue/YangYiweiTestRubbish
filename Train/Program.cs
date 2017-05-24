using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Longest("loop", "lessdangerousthancoding"));
            Console.ReadKey();
        }

        public static string Longest(string s1, string s2)
        {
            string str = s1+s2;
            StringBuilder sb = new StringBuilder();
            sb.Append(str.Distinct().OrderBy(c => c).ToArray());
            return sb.ToString();
        }
    }
}
