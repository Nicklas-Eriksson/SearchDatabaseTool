using SearchDatabaseTool.SearchDataProgram.Calculations;
using SearchDatabaseTool.SearchDataProgram.Database;
using SearchDatabaseTool.SearchDataProgram.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SearchDatabaseTool.SearchDataProgram.UI
{
    internal class DisplayToUser
    {
        /// <summary>
        /// Prompts user to choose a option.
        /// </summary>
        internal void MainMenu()
        {
            bool loop = false;
            do
            {
                Console.Clear();
                PrintMenuOptions();
                var input = Helper.GetUserInput(1, 4);
                if (input == 0) loop = false;
                Console.Write("Option: ");
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
                    PrintPreviousResults();
                    OptionForPrintPreviousResults();
                    break;
                case 4:
                    Helper.ExitProgram();
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
            var input = Helper.GetUserInput(1, 5);
            if (input == 0) loop = true;
            do
            {
                OptionForPrintTxtMenu(input);
            }
            while (loop);
        }

        private void SelectAWordToSearch()
        {
            Console.Write("\nWord: ");
            var word = Console.ReadLine()?.Trim().Split(' ').First();


            FindWords.CallerMethod(word);
            //fw.WordOccurrence(word);
        }

        /// <summary>
        /// Prints out the alternatives for the user.
        /// Options 4
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

        /// <summary>
        /// Prints out the previous results for the user.
        /// Options 4
        /// </summary>
        private void PrintPreviousResults()
        {
            Console.Clear();
            Console.WriteLine("=====================================================");
            Console.WriteLine("|| 1. Print out all results from previous search. ||");
            Console.WriteLine("|| 2. Print out a specific search result......... ||");
            Console.WriteLine("|| 3. Back to main menu.......................... ||");
            Console.WriteLine("|| 4. Exit application........................... ||");
            Console.WriteLine("=====================================================");
        }

        private void OptionForPrintPreviousResults()
        {
            //Swap
            Console.Write("Option: ");
            switch (Helper.GetUserInput(1, 4))
            {
                case 1:
                    FindWords.PrintOutPriorSearches(FileNameSearchWordAndCounter.myCollection, 0);
                    break;
                case 2:
                    Console.WriteLine("Not Implemented");
                    Thread.Sleep(1300);
                    MainMenu();
                    break;
                case 3:
                    MainMenu();
                    break;
                case 4:
                    Helper.ExitProgram();
                    break;
            }
        }

        private void PrintASpecificSearchResult(List<string> searchResultCollection)
        {
            Console.WriteLine("Press [Q] to go back to previous menu");

            var index = 0;
            foreach (var r in searchResultCollection)
            {
                Console.WriteLine($"|| {index}. {r}");
            }
            Console.WriteLine("\nChoose your result to inspect further");
            Console.Write("Option: ");
            var result = Helper.GetUserInput(1, searchResultCollection.Count);
            if (result == 0)
                PrintPreviousResults();
            //else ChosenResult(result);
        }

        private void ChosenResult(int r, Dictionary<int, string> collection)
        {
            //Console.WriteLine($"Search: {word} was found a total of {totalTimes} times.");
            //for (int i = 0; i < collection.Count; i++)
            //{
            //    Console.WriteLine($"{collection.nr} times from {collection.doc}.txt.");
            //}
        }
    }
}
