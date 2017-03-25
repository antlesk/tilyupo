using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2._1._24
{
    class Program
    {
        static void Main(string[] args)
        {
            var project = new AMPProgect();
            
            Console.Write("Connection count: ");
            project.ConnectionCount = Convert.ToInt32(Console.ReadLine());

            Console.Write("Floors count: ");
            project.FloorsCount = Convert.ToInt32(Console.ReadLine());

            Console.Write("Wall width: ");
            project.WallWidth = Convert.ToInt32(Console.ReadLine());

            Console.Write("Floor height: ");
            project.FloorHeight = Convert.ToInt32(Console.ReadLine());

            Console.Write("Distanse count: ");
            project.Distanse = Convert.ToInt32(Console.ReadLine());

            string query;
            while ((query = Console.ReadLine()) != "exit")
            {
                switch (query)
                {
                    case "planning cost":
                        Console.WriteLine(project.CalcPlanningCost());
                        break;
                    case "cable length":
                        Console.WriteLine(project.CalcTotalLength());
                        break;
                    case "equipment cost":
                        Console.WriteLine(project.CalcEquipmentCost());
                        break;
                    case "total cost":
                        Console.WriteLine(project.CalcTotalCost());
                        break;
                    case "info":
                        Console.WriteLine(project.Info);
                        break;
                }
            }

            Console.WriteLine("Good buy!");

            Task.Delay(2000).Wait();
        }
    }
}
