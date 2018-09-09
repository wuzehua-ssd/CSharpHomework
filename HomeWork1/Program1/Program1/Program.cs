using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("输入第一个数字：");
            string str1 = Console.ReadLine();
            double num1 = Int32.Parse(str1);

            Console.WriteLine("输入第二个数字：");
            string str2 = Console.ReadLine();
            double num2 = Int32.Parse(str2);

            double num = num1 * num2;
            Console.WriteLine(num);
        }
    }
}
