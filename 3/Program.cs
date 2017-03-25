using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    class Program
    {
        class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        static void Main(string[] args)
        {
            int n;
            
            while (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Wrong input!");
            }

            byte[,,] cub = new byte[n, n, n];

            Point[] vec = new Point[n];
            for (int i = 0; i < n; i++)
            {
                vec[i] = new Point { X = n - 1 - i, Y = i };
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    cub[i, vec[j].X % n, vec[j].Y % n] = 1;

                    vec[j].X++;
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        Console.Write(cub[i, j, k].ToString() + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
