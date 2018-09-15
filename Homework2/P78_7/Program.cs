using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P78_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[10] { 2, 65, 23, 87, 42, 3, 6, 96, 78, 21 };

            int max = aMax(a);
            Console.WriteLine("该数组中最大值为：" + max);

            int min = aMin(a);
            Console.WriteLine("该数组中最小值为：" + min);

            double aver = averageA(a);
            Console.WriteLine("该数组平均值为：" + aver);

            int sum = sumA(a);
            Console.WriteLine("该数组元素和为：" + sum);
        }

        static int aMax(int[] a)
        {
            int Max = 0;
            for(int i=0;i<10;i++)
            {
                if(a[i]>Max)
                {
                    Max = a[i];
                }
            }
            return Max;
        }

        static int aMin(int[] a)
        {
            int Min = a[0];
            for (int i = 0; i < 10; i++)
            {
                if (a[i] < Min)
                {
                    Min = a[i];
                }
            }
            return Min;
        }

        static double averageA(int[] a)
        {
            int sum = 0;
            int lenth = a.Length;
            for (int i=0;i<lenth;i++)
            {
                sum = sum + a[i];
            }
            double averageA = Convert.ToDouble(sum) / lenth;
            return averageA;
        }

        static int sumA(int[] a)
        {
            int sum = 0;
            int lenth = a.Length;
            for (int i = 0; i < lenth; i++)
            {
                sum = sum + a[i];
            }
            return sum;
        }
    }
}
