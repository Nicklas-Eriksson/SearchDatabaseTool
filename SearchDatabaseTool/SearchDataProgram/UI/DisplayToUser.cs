using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SearchDatabaseTool.SearchDataProgram.Calculations;
using SearchDatabaseTool.SearchDataProgram.Utils;

namespace SearchDatabaseTool.SearchDataProgram.UI
{
    internal class DisplayToUser
    {
        readonly Helper h = new Helper();
        readonly FindWords fw = new FindWords();

        /// <summary>
        /// Prompts user to choose a option.
        /// </summary>
        internal void MainMenu()
        {
            PrintMenuOptions();
            ChosenOption(h.GetUserInput(1,3));
        }

        private void ChosenOption(int option)
        {
            switch (option)
            {
                case 1:
                    SelectAWordToSearch();
                    break;
                case 2:
                    Console.WriteLine("Not implemented!");
                    break;
                case 3:
                    h.ExitProgram();
                    break;
            }
        }

        private void SelectAWordToSearch()
        {
            var word = Console.ReadLine()?.Trim().Split(' ').First();

            Console.WriteLine($"You searched for {word}");
            Thread.Sleep(1300);

            fw.WordOccurrence(word);
        }


        /// <summary>
        /// Prints out the alternatives for te user.
        /// </summary>
        private void PrintMenuOptions()
        {
            Console.WriteLine("===============================");
            Console.WriteLine("|| 1. Search for a new word. ||");
            Console.WriteLine("|| 2. Previous results...... ||");
            Console.WriteLine("|| 3. Exit application...... ||");
            Console.WriteLine("===============================");
        }
    }
}
