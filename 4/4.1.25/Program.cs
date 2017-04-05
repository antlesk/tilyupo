using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your text (double enter to exit");

            string line;
            List<string> lines = new List<string>();
            while ((line = Console.ReadLine()) != "")
            {
                lines.Add(line);
            }

            string longestLine = "";
            string longestWord = "";
            foreach (string oneLine in lines)
            {
                if (oneLine.Length > longestLine.Length)
                {
                    longestLine = oneLine;
                }

                string[] words = oneLine.Split(new[] { ' ', ',', '.', '!', '?' }, 
                    StringSplitOptions.RemoveEmptyEntries);
                

                foreach (var word in words)
                {
                    if (word.Length > longestWord.Length)
                    {
                        longestWord = word;
                    }
                }
            }

            Console.WriteLine($"Longest line {longestLine}");
            Console.WriteLine($"Longest word {longestWord}");

            Console.ReadKey();
        }
    }
}
