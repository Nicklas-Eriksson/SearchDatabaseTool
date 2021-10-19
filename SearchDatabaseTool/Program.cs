using SearchDatabaseTool.SearchDataProgram.UI;
using System;

namespace SearchDatabaseTool
{
    class Program
    {
        static void Main(string[] args)
        {
            var Menu = new DisplayToUser();
            Menu.MainMenu();
            //Method();
            Console.ReadKey();
        }
    }
}
