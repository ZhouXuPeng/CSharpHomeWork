using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 2, 4, 1, 5, 3, 6 };

            ////获取数组长度
            //int length = 0;
            //while (arr[length] != NULL)
            //{
            //    length++;
            //}

            //求最大值最小值
            int min = arr[0], max = arr[0];
            for(int i = 0; i < 6; i++)
            {
                if(min > arr[i])
                {
                    min = arr[i];
                }
                else if(max<arr[i])
                {
                    max = arr[i];
                }
            }

            //所有元素的和
            int sum = 0;
            for (int i = 0; i < 6; i++)
            {
                sum = arr[i] + sum;
            }
            //平均值
            int average;
            average = sum / 6;

            //输出数据
            System.Console.WriteLine("最大值最小值分别为:" + max + ", " + min);
            System.Console.WriteLine("平均值为:" + average);
            System.Console.WriteLine("元素之和为:" + sum);
        }
    }
}
