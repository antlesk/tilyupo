using System;
using System.Linq;

namespace _5_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter two numbers (one line)");
            string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).
                ToArray();
            
            var a = new CustomBigUInt(input[0]);
            var b = new CustomBigUInt(input[1]);

            Console.WriteLine($"LCM = {a * b / GCD(a, b)}");

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
