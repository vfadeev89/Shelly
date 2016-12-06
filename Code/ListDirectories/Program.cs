using System;
using System.IO;

namespace ListDirectories
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = Directory.GetFiles(Directory.GetCurrentDirectory());
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
        }
    }
}
