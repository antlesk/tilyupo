using _7.Entities;
using _7.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace _7
{
    class Program
    {
        private static readonly ICrimeRepository CrimeRepository;
        private static readonly ICriminalRepository CriminalRepository;
        private static readonly ICriminalOrganizationRepository CriminalOrganizationRepository;

        static Program()
        {
            var context = new ApplicationDbContext();

            CrimeRepository = new CrimeRepository(context);
            CriminalRepository = new CriminalRepository(context);
            CriminalOrganizationRepository = new CriminalOrganizationRepository(context);
        }

        static void Main(string[] args)
        {
            var app = new BashApplication();

            app.AddCommand("crimes", (arguments) =>
            {
                if (arguments.Length == 0)
                {
                    PrintHelp();

                    return;
                }

                if (arguments[0] == "all")
                {
                    foreach (var crime in CrimeRepository.GetAll())
                    {
                        Console.WriteLine(crime.ToString());

                        if (crime != CrimeRepository.GetAll().Last())
                        {
                            Console.WriteLine();
                        }
                    }

                    return;
                }

                if (arguments[0] == "add")
                {
                    var crime = new Crime();

                    Console.Write("Place: ");
                    crime.Place = Console.ReadLine();

                    Console.Write("Effects: ");
                    crime.Effects = Console.ReadLine();

                    Console.Write("Comments: ");
                    crime.Comments = Console.ReadLine();

                    CrimeRepository.Add(crime);
                    CrimeRepository.Save();

                    return;
                }

                if (arguments.Length == 1)
                {
                    PrintHelp();

                    return;
                }

                if (arguments[0] == "remove")
                {
                    var crime = CrimeRepository.GetById(Convert.ToInt32(arguments[1]));
                    CrimeRepository.Delete(crime);

                    CrimeRepository.Save();

                    return;
                }

                if (arguments[0] == "id")
                {
                    Crime crime = CrimeRepository.GetAll().FirstOrDefault(c => c.CrimeId == Convert.ToInt32(arguments[1]));

                    Console.WriteLine(crime?.ToString() ?? "Не найдено");

                    return;
                }

                if (arguments[0] == "place")
                {
                    Crime crime = CrimeRepository.GetAll().FirstOrDefault(c => c.Place == arguments[1]);

                    Console.WriteLine(crime?.ToString() ?? "Не найдено");

                    return;
                }

                if (arguments[0] == "effects")
                {
                    Crime crime = CrimeRepository.GetAll().FirstOrDefault(c => c.Effects == arguments[1]);

                    Console.WriteLine(crime?.ToString() ?? "Не найдено");

                    return;
                }

                if (arguments[0] == "comments")
                {
                    Crime crime = CrimeRepository.GetAll().FirstOrDefault(c => c.Comments == arguments[1]);

                    Console.WriteLine(crime?.ToString() ?? "Не найдено");

                    return;
                }

                if (arguments[0] == "remove")
                {
                    CrimeRepository.Delete(CrimeRepository.GetAll().
                        FirstOrDefault(crime => crime.CrimeId == Convert.ToInt32(arguments[1])));

                    CrimeRepository.Save();

                    return;
                }

                PrintHelp();
            });

            app.AddCommand("criminals", (arguments) =>
            {
                void PrintCriminalInfo(Criminal criminal, string indent = "")
                {
                    if (criminal == null)
                    {
                        Console.WriteLine("Не найдено");
                    }

                    Console.WriteLine(criminal.ToString(indent));

                    Console.WriteLine("Преступления: ");
                    foreach (var crime in criminal.Crimes)
                    {
                        Console.WriteLine(crime.ToString(indent + "  "));

                        if (crime != criminal.Crimes.Last())
                        {
                            Console.WriteLine();
                        }
                    }
                }

                if (arguments.Length == 0)
                {
                    PrintHelp();

                    return;
                }

                if (arguments[0] == "all")
                {
                    foreach (var criminal in CriminalRepository.GetAll())
                    {
                        PrintCriminalInfo(criminal);

                        if (criminal != CriminalRepository.GetAll().Last())
                        {
                            Console.WriteLine();
                        }
                    }

                    return;
                }

                if (arguments[0] == "add")
                {
                    var criminal = new Criminal();

                    Console.Write("Грожданство: ");
                    criminal.Cirezenship = Console.ReadLine();

                    Console.Write("Типы преступлений: ");
                    criminal.CrimeTypes = Console.ReadLine();

                    Console.Write("ФИО: ");
                    criminal.FullName = Console.ReadLine();

                    Console.Write("Росто: ");
                    criminal.Height = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Цвет волос: ");
                    criminal.HeirColor = Console.ReadLine();

                    Console.Write("Языки: ");
                    criminal.Languages = Console.ReadLine();

                    Console.Write("Кличка: ");
                    criminal.Nickaname = Console.ReadLine();

                    Console.Write("Особые приметы: ");
                    criminal.SpecialSigns = Console.ReadLine();

                    CriminalRepository.Add(criminal);
                    CriminalRepository.Save();

                    return;
                }

                if (arguments.Length == 1)
                {
                    PrintHelp();

                    return;
                }

                if (arguments[0] == "remove")
                {
                    CriminalRepository.Delete(CriminalRepository.GetById(Convert.ToInt32(arguments[1])));
                    CriminalRepository.Save();

                    return;
                }

                if (arguments[0] == "id")
                {
                    var criminal = CriminalRepository.GetAll().FirstOrDefault(c => c.CriminalId == Convert.ToInt32(arguments[1]));

                    PrintCriminalInfo(criminal);

                    return;
                }

                if (arguments[0] == "crirezenship")
                {
                    var criminal = CriminalRepository.GetAll().FirstOrDefault(c => c.Cirezenship == arguments[1]);

                    PrintCriminalInfo(criminal);

                    return;
                }

                if (arguments[0] == "crimetypes")
                {
                    var criminal = CriminalRepository.GetAll().FirstOrDefault(c => c.CrimeTypes == arguments[1]);

                    PrintCriminalInfo(criminal);

                    return;
                }

                if (arguments[0] == "name")
                {
                    var criminal = CriminalRepository.GetAll().FirstOrDefault(c => c.FullName == arguments[1]);

                    PrintCriminalInfo(criminal);

                    return;
                }

                if (arguments[0] == "height")
                {
                    var criminal = CriminalRepository.GetAll().FirstOrDefault(c => c.Height == Convert.ToInt32(arguments[1]));

                    PrintCriminalInfo(criminal);

                    return;
                }

                if (arguments[0] == "color")
                {
                    var criminal = CriminalRepository.GetAll().FirstOrDefault(c => c.HeirColor == arguments[1]);

                    PrintCriminalInfo(criminal);

                    return;
                }

                if (arguments[0] == "langs")
                {
                    var criminal = CriminalRepository.GetAll().FirstOrDefault(c => c.Languages == arguments[1]);

                    PrintCriminalInfo(criminal);

                    return;
                }

                if (arguments[0] == "nick")
                {
                    var criminal = CriminalRepository.GetAll().FirstOrDefault(c => c.Nickaname == arguments[1]);

                    PrintCriminalInfo(criminal);

                    return;
                }

                if (arguments[0] == "signs")
                {
                    var criminal = CriminalRepository.GetAll().FirstOrDefault(c => c.SpecialSigns == arguments[1]);

                    PrintCriminalInfo(criminal);

                    return;
                }

                if (arguments.Length <= 3)
                {
                    PrintHelp();

                    return;
                }

                if ((arguments[1] == "crimes") && (arguments[2] == "add"))
                {
                    var criminal = CriminalRepository.GetById(Convert.ToInt32(arguments[0]));
                    if (criminal == null)
                    {
                        Console.WriteLine("Преступника с таким id не существует");

                        return;
                    }
                    var crime = CrimeRepository.GetById(Convert.ToInt32(arguments[3]));
                    if (crime == null)
                    {
                        Console.WriteLine("Преступления с таким id не существует");
                    }
                    else
                    {
                        criminal.Crimes.Add(crime);

                        CriminalRepository.Save();

                        return;
                    }
                }

                if ((arguments[1] == "crimes") && (arguments[2] == "remove"))
                {
                    var criminal = CriminalRepository.GetById(Convert.ToInt32(arguments[0]));
                    if (criminal == null)
                    {
                        Console.WriteLine("Преступника с таким id не существует");

                        return;
                    }
                    var crime = CrimeRepository.GetById(Convert.ToInt32(arguments[3]));
                    if (crime == null)
                    {
                        Console.WriteLine("Преступления с таким id не существует");
                    }
                    else
                    {
                        criminal.Crimes.Remove(crime);

                        CriminalRepository.Save();

                        return;
                    }
                }

                PrintHelp();
            });

            app.AddCommand("organizations", (arguments) =>
            {
                void PrintOrganizationInfo(CriminalOrganization organization, string indent = "")
                {
                    if (organization == null)
                    {
                        Console.WriteLine("Не найдено");
                    }

                    Console.WriteLine(organization.ToString(indent));

                    Console.WriteLine("Преступники: ");
                    foreach (var criminal in organization.Members)
                    {
                        Console.WriteLine(indent + "  " + criminal.FullName);

                        if (criminal != organization.Members.Last())
                        {
                            Console.WriteLine();
                        }
                    }
                }

                if (arguments.Length == 0)
                {
                    PrintHelp();

                    return;
                }

                if (arguments[0] == "all")
                {
                    foreach (var organization in CriminalOrganizationRepository.GetAll())
                    {
                        PrintOrganizationInfo(organization);

                        if (organization != CriminalOrganizationRepository.GetAll().Last())
                        {
                            Console.WriteLine();
                        }
                    }

                    return;
                }

                if (arguments[0] == "add")
                {
                    var organization = new CriminalOrganization();

                    Console.Write("Имя: ");
                    organization.Name = Console.ReadLine();

                    Console.Write("Область деятельности: ");
                    organization.Occupation = Console.ReadLine();

                    Console.Write("Уровень опасности: ");
                    organization.DangerLevel = Convert.ToInt32(Console.ReadLine());

                    CriminalOrganizationRepository.Add(organization);
                    CriminalOrganizationRepository.Save();

                    return;
                }

                if (arguments.Length == 1)
                {
                    PrintHelp();

                    return;
                }

                if (arguments[0] == "remove")
                {
                    var organization = CriminalOrganizationRepository.GetById(Convert.ToInt32(arguments[1]));

                    CriminalOrganizationRepository.Delete(organization);
                    CriminalOrganizationRepository.Save();

                    return;
                }

                if (arguments[0] == "id")
                {
                    var organization = CriminalOrganizationRepository.GetById(Convert.ToInt32(arguments[1]));

                    PrintOrganizationInfo(organization);

                    return;
                }

                if (arguments[0] == "name")
                {
                    var organization = CriminalOrganizationRepository.GetAll().First(org => org.Name == arguments[1]);

                    PrintOrganizationInfo(organization);

                    return;
                }

                if (arguments[0] == "level")
                {
                    var organization = CriminalOrganizationRepository.GetAll()
                        .First(org => org.DangerLevel == Convert.ToInt32(arguments[1]));

                    PrintOrganizationInfo(organization);

                    return;
                }

                if (arguments[0] == "occupation")
                {
                    var organization = CriminalOrganizationRepository.GetAll().First(org => org.Occupation == arguments[1]);

                    PrintOrganizationInfo(organization);

                    return;
                }

                if (arguments.Length == 3)
                {
                    PrintHelp();

                    return;
                }

                if ((arguments[1] == "criminals") && (arguments[2] == "add"))
                {
                    var organization = CriminalOrganizationRepository.GetById(Convert.ToInt32(arguments[0]));
                    if (organization == null)
                    {
                        Console.WriteLine("Организации с таким id не существует");
                    }
                    var criminal = CriminalRepository.GetById(Convert.ToInt32(arguments[3]));
                    if (criminal == null)
                    {
                        Console.WriteLine("Преступника с таким id не существует");

                        return;
                    }
                    else
                    {
                        organization.Members.Add(criminal);

                        CriminalOrganizationRepository.Update(organization);

                        CriminalOrganizationRepository.Save();

                        return;
                    }
                }
                
                if ((arguments[1] == "criminals") && (arguments[2] == "remove"))
                {
                    var organization = CriminalOrganizationRepository.GetById(Convert.ToInt32(arguments[0]));
                    if (organization == null)
                    {
                        Console.WriteLine("Организации с таким id не существует");
                    }
                    var criminal = CriminalRepository.GetById(Convert.ToInt32(arguments[3]));
                    if (criminal == null)
                    {
                        Console.WriteLine("Преступника с таким id не существует");

                        return;
                    }
                    else
                    {
                        organization.Members.Remove(criminal);

                        CriminalOrganizationRepository.Update(organization);

                        CriminalOrganizationRepository.Save();

                        return;
                    }
                }
            });

            app.Start();
        }

        static void PrintHelp()
        {
            Console.WriteLine("Неверные аргументы для команды");
        }
    }
}
