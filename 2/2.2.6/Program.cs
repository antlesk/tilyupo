//Rextester.Program.Main is the entry point for your code. Don't change it.
//Compiler version 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5

using System;

namespace _2._2._6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            for (double i = 0.2; i <= 10; i += 0.2)
                Test(i);
        }

        private static void Test(double alpha, int n = 20)
        {
            alpha %= 2 * Math.PI;

            double res = 0;
            for (int i = 1; i <= n; i++)
            {
                double numerator = 1;
                for (int j = 1; j <= 2 * i - 1; j++)
                {
                    numerator *= alpha;
                }

                double denominator = 1;
                for (int j = 1; j <= 2 * i - 1; j++)
                {
                    denominator *= j;
                }

                res += Math.Pow(-1, i - 1) * numerator / denominator;
            }

            double source = Math.Sin(alpha);

            Console.WriteLine("{0} ~= {1}", source, res);

            Console.ReadKey();
        }
    }
}