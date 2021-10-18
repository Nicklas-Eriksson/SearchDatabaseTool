using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SearchDatabaseTool.SearchDataProgram.Database;

namespace SearchDatabaseTool
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = Console.ReadLine()?.Trim().Split(' ').First();
           
            Console.WriteLine($"You searched for {word}");
            
            Console.WriteLine(word);

                Console.ReadLine();
        }
    }
}
