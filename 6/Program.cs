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
            var list = new CustomList<int> { 1, -2, 3, -4, 5 };
            var tree = new SearchTree();

            foreach (var number in list)
            {
                tree.Insert(number);
            }

            DeleteAllNegative(tree);

            foreach (var number in tree)
            {
                Console.WriteLine(number);
            }

            Console.ReadKey();
        }

        static void DeleteAllNegative(SearchTree tree)
        {
            var negativeNumbers = new List<int>();
            foreach (var item in tree)
            {
                if (item < 0)
                {
                    negativeNumbers.Add(item);
                }
            }

            negativeNumbers.ForEach(item => tree.Remove(item));
        }
    }
}
