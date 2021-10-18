using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SearchDatabaseTool.SearchDataProgram.UI;

namespace SearchDatabaseTool
{
    class Program
    {
        static void Main(string[] args)
        {
            var Menu = new DisplayToUser();
            Menu.MainMenu();
            Console.ReadLine();
        }
    }
}
