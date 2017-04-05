using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter two numbers");
            string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).
                ToArray();

            var a = new CustomBigUInt(input[0]);
            var b = new CustomBigUInt(input[1]);

            Console.WriteLine($"GCD = {a * b / GCD(a, b)}");

            Console.ReadKey();
        }

        static CustomBigUInt GCD(CustomBigUInt a, CustomBigUInt b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }
            }

            return a + b;
        }
    }
}
