using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SearchDatabaseTool.SearchDataProgram.Calculations;
using SearchDatabaseTool.SearchDataProgram.Utils;
using SearchDatabaseTool.SearchDataProgram.Database;

namespace SearchDatabaseTool.SearchDataProgram.UI
{
    internal class DisplayToUser
    {
        readonly Helper h = new Helper();
        readonly FindWords fw = new FindWords();
        //readonly DB db = new DB();

        /// <summary>
        /// Prompts user to choose a option.
        /// </summary>
        internal void MainMenu()
        {
            Console.Clear();
            bool loop = true;
            PrintMenuOptions();
            var input = h.GetUserInput(1, 4);
            if (input == 0) loop = true;
            do
            {
                OptionForMainMenu(input);
            }
            while (loop);
        }

        private void OptionForMainMenu(int option)
        {
            switch (option)
            {
                case 1:
                    SelectAWordToSearch();
                    break;
                case 2:
                    SelectAText();
                    break;
                case 3:
                    //DB.GetStream();
                    Console.WriteLine("Not implemented!");
                    break;
                case 4:
                    h.ExitProgram();
                    break;
            }
        }

        private void OptionForPrintTxtMenu(int option)
        {
            switch (option)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    DB.PrintChosenTxt(option);
                    break;
                case 5:
                    MainMenu();
                    break;
            }
        }

        private void SelectAText()
        {
            Console.Clear();

            DB.GetStream();

            Console.WriteLine("What txt you want to print out?\n");
            Console.WriteLine("==========================");
            Console.WriteLine("|| 1. 1000 words text.. ||");
            Console.WriteLine("|| 2. 1500 words text.. ||");
            Console.WriteLine("|| 3. 3000 words text.. ||");
            Console.WriteLine("|| 4. Biiig words text. ||");
            Console.WriteLine("|| 5. Back to menu..... ||");
            Console.WriteLine("==========================");

            bool loop = true;
            var input = h.GetUserInput(1, 5);
            if (input == 0) loop = true;
            do
            {
                OptionForPrintTxtMenu(input);
            }
            while (loop);
        }

        private void SelectAWordToSearch()
        {
            Console.Write("Word: ");
            var word = Console.ReadLine()?.Trim().Split(' ').First();


            FindWords.TestPrintWord(word);
            //fw.WordOccurrence(word);
        }

        /// <summary>
        /// Prints out the alternatives for te user.
        /// </summary>
        private void PrintMenuOptions()
        {
            Console.WriteLine("===============================");
            Console.WriteLine("|| 1. Search for a new word. ||");
            Console.WriteLine("|| 2. Print out a text...... ||");
            Console.WriteLine("|| 3. Previous results...... ||");
            Console.WriteLine("|| 4. Exit application...... ||");
            Console.WriteLine("===============================");
        }
    }
}
