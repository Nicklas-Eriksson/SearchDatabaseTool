using SearchDatabaseTool.SearchDataProgram.Calculations;
using SearchDatabaseTool.SearchDataProgram.Database;
using SearchDatabaseTool.SearchDataProgram.UI;
using System;

namespace SearchDatabaseTool
{
    class Program
    {
        static void Main(string[] args)
        {
            DB.GetStream(); //fyller listorna
            FindWords.LoadLists(); //adderar namn på listor + listorna
            var Menu = new DisplayToUser();
            Menu.MainMenu();
            //Method();
            Console.ReadKey();
        }
    }
}
