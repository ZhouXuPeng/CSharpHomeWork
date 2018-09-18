using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            String s = " ";
            int n;
            int[] Prime = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
            System.Console.Write("请输入一个要分解的整数:");
            s = Console.ReadLine();
            n = Int32.Parse(s);

            //判断是不是质数
            //bool flag = true;
            //int n2;
            //n2 = n;
            //while (flag) {
            //    for (int i = 0; i < 10; i++)
            //    {
            //        if (n2 % Prime[i] == 0)
            //        {
            //            n2 = n2 / Prime[i];
            //            flag = false;
            //        }
            //    }
            //}




            //for(int i = 0; i < 10; i++)
            //{
            //    if(n % Prime[i] == 0)
            //    {
            //        n = n / Prime[i];
            //        System.Console.Write(Prime[i] + " *");
            //        continue;
            //    }
            //}

            if (n == 2)
            {
                System.Console.WriteLine("2");
            }

            else if (n < 2)
            {
                System.Console.WriteLine("输入有误");
            }

            else { 
                int i = 2;
                while (n > 0)
                {

                    if (n % i == 0)
                    {
                        System.Console.Write(i + " * ");
                        n /= i;
                    }
                    else i++;
                }
            }
        }
    }
}
