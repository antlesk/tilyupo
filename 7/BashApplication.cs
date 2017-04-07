using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7
{
    class BashApplication
    {
        public delegate void CommandListener(string[] arguments);
        private Dictionary<string, CommandListener> _commands;

        public BashApplication()
        {
            _commands = new Dictionary<string, CommandListener>();
        }

        public void AddCommand(string name, CommandListener listener)
        {
            if (_commands.ContainsKey(name))
            {
                throw new ArgumentException("Имя для команды уже занято");
            }

            _commands.Add(name, listener);
        }

        public void RemoveCommand(string name)
        {
            if (!_commands.ContainsKey(name))
            {
                throw new ArgumentException("Такоей команды не существует");
            }

            _commands.Remove(name);
        }

        public void Start()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("$ ");
                Console.ForegroundColor = ConsoleColor.Green;
                var line = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Gray;

                string[] arguments = line.Split(' ');

                if (arguments[0] == "exit")
                {
                    break;
                }

                if (!_commands.ContainsKey(arguments[0]))
                {
                    Console.WriteLine($"Ошибка! Не найдено команды \"{arguments[0]}\"");
                }
                else
                {
                    try
                    {
                        _commands[arguments[0]](arguments.Skip(1).ToArray());
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Ошибка: {ex.Message}");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
            }
        }

        public Task StartAsync()
        {
            var task = new Task(Start);
            task.Start();

            return task;
        }
    }
}
