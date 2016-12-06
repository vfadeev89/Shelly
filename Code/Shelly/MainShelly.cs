using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Shelly
{
    class MainShelly
    {
        private readonly Dictionary<string, string> _aliases = new Dictionary<string, string>
        {
            { "ls", @".\Commands\ListDirectories.exe" },
            { "cl", @".\Commands\Clear.exe" },
            { "calc", @"calc.exe" },
            { "note", @"notepad.exe" }
        };

        public MainShelly()
        {
            
        }

        public void Run()
        {
            string input = null;

            do
            {
                Console.Write("* ");
                input = Console.ReadLine();

                if (input == String.Empty)
                    continue;

                Execute(input);
            }
            while (input != "exit");
        }

        private int Execute(string command)
        {
            if (_aliases.Keys.Contains(command))
            {
                var process = new Process();
                process.StartInfo = new ProcessStartInfo(_aliases[command])
                {
                    UseShellExecute = false
                };
                process.Start();
                process.WaitForExit();

                return 0;
            }

            Console.WriteLine($"command {command} not found");
            return 1;
        }
    }
}
