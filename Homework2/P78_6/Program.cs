using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P78_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请在此处输入一个大于1的正整数：");
            int i = Convert.ToInt32(Console.ReadLine());

            int j = isPrime(i);
            switch(j)
            {
                case 0:
                    Console.WriteLine("该数字不是素数。");
                    Console.WriteLine("该数字的素数因子如下：");
                    askChildPrime(i);
                    break;
                case 1:
                    Console.WriteLine("该数字为素数。");
                    Console.WriteLine("该数字素数因子为：" + i);
                    break;
                case 2:
                    Console.WriteLine("输入数字不符合条件。");
                    break;
            }
        }

        static int isPrime(int i)
        {
            if (i <= 1)
            {
                return 2;
            }
            if(i==2)
            {
                return 1;
            }
            for(int j=2;j<i;j++)
            {
                if(i%j==0)
                {         
                    return 0;
                }
            }           
            return 1;
        }
        static void askChildPrime(int i)
        {
            for (int j = i; j > 1; --j) 
            {
                if(i%j==0&&isPrime(j)==1)
                {
                    i = i / j;
                    Console.Write(j+"  ");
                    ++j;
                }
            }
        }
    }
}
