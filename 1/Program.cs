using System;
using System.Numerics;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n;
            while (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Вы ввели недопустимое значение!");
            }

            BigInteger res = new BigInteger(0);
            for (int i = 1; i <= n; i++)
            {
                BigInteger curr = new BigInteger(1);
                for (int j = 1; j <= i; j++)
                {
                    curr *= Factorial.Get(i + j) / Factorial.Get(i);
                }
                res += curr;
            }
            Console.WriteLine("Результат: " + res.ToString());
        }
    }
}
