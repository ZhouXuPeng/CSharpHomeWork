using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program3
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i = 2; i <= 100; i++)
            {
                if (i % 2 == 0 && i != 2)
                {
                    continue;
                }
                else if (i % 3 == 0 && i != 3)
                {
                    continue;
                }
                else if (i % 5 == 0 && i != 5)
                {
                    continue;
                }
                else if (i % 7 == 0 && i != 7)
                {
                    continue;
                }
                else if (i % 11 == 0 && i != 11)
                {
                    continue;
                }
                else if (i % 13 == 0 && i != 13)
                {
                    continue;
                }
                else
                {
                    System.Console.Write(i + " ");
                }
            }
        }
    }
}
