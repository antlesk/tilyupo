using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_2_26
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new SearchTree();
            var set = new HashSet<int>();

            var rand = new Random();

            for (int i = 0; i < 100000; i++)
            {
                //string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                //    .ToArray();

                //string type = input[0];

                //if (type == "e")
                //{
                //    break;
                //}

                //int x = Convert.ToInt32(input[1]);

                if (i % 10 == 0)
                {
                    Console.WriteLine(i);
                }

                int x = rand.Next(5);

                string type;
                switch (rand.Next(3))
                {
                    case 0:
                        type = "+";
                        break;
                    case 1:
                        type = "-";
                        break;
                    case 2:
                        type = "f";
                        break;
                    default:
                        type = "err";
                        break;
                }

                if (type == "+")
                {
                    tree.Insert(x);
                    set.Add(x);
                }

                if (type == "-")
                {
                    tree.Pop(x);
                    set.Remove(x);
                }

                Console.WriteLine($"{type} {x}");
                Console.Write("  ");
                foreach (int item in tree)
                {
                    Console.Write(item.ToString() + " ");
                }
                Console.WriteLine();


                if (type == "f")
                {
                    if (tree.Find(x) != set.Contains(x))
                    {
                        Console.WriteLine("error!");

                        Console.ReadKey();
                        break;
                    }
                }
            }
        }
    }
}
