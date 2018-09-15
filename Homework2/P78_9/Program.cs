using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace P78_9
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[99];
            for(int i=0;i<99;i++)
            {
                a[i] = i + 2;
            }
            ArrayList list = new ArrayList(a);
            for(int i=2;i<10;i++)
            {
                for(int j=2;j<=100;j++)
                {
                    if(j%i==0)
                    {
                        list.Remove(j);
                    }
                }
            }

            Console.Write("该范围内素数为：" + 2 + "  " + 3 + "  " + 5 + "  " + 7 + "  ");

            foreach(int b in list)
            {
                Console.Write(b + "  ");
            }

            Console.Write("\n");
        }  
    }
}
