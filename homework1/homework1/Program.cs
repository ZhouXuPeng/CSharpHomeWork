using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            String c = " ";
            int num_1, num_2, product;
            System.Console.Write("两个数做乘法，请输入第一个数字: ");
            c = Console.ReadLine();
            num_1 = Int32.Parse(c);
            System.Console.Write("请输入第二个数字: ");
            c = Console.ReadLine();
            num_2 = Int32.Parse(c);
            product = num_1 * num_2;
            Console.WriteLine("乘积为: " + product);
        }
    }
}
