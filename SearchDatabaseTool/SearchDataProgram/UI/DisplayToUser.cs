using SearchDatabaseTool.SearchDataProgram.Calculations;
using SearchDatabaseTool.SearchDataProgram.Database;
using SearchDatabaseTool.SearchDataProgram.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

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
                OptionForMainMenu(input);
            } while (loop);
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
            FindWords.CallerMethod(Console.ReadLine()?.Trim().Split(' ').First());
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
            Console.Write("Option: ");
            switch (Helper.GetUserInput(1, 4))
            {
                case 1:
                    PrintOutPriorSearches(FileNameSearchWordAndCounter.MyCollection, 0);
                    break;
                case 2:
                    PrintASpecificSearchResult(FileNameSearchWordAndCounter.SearchWords);
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

            var index = 1;
            foreach (var r in searchResultCollection)
            {
                Console.WriteLine($"|| {index++}. {r}");
            }
            Console.WriteLine("\nChoose your result to inspect further");
            Console.Write("Option: ");
            var result = Helper.GetUserInput(1, searchResultCollection.Count);
            if (result == 0)
                MainMenu();
            else
            {
                ChosenResult(searchResultCollection[result - 1]);
            }
            Helper.PressAnyKeyToContinue();
        }

        private void ChosenResult(string chosenOption)
        {
            //Console.WriteLine($"Search: {word} was found a total of {totalTimes} times.");
            //for (int i = 0; i < collection.Count; i++) Console.WriteLine($"{collection.nr} times from {collection.doc}.txt.");
        }

        public static void PrintWord(List<string> sentencesContainingWord)
        {
            var nr = FileNameSearchWordAndCounter.TotalWordCounter;
            var searchWord = FileNameSearchWordAndCounter.SearchWord;
            var word = searchWord[0].ToString().ToUpper() + (searchWord.Substring(1));

            Console.WriteLine($"\nYour word: {word} was found {nr} times.");
            if (nr != 0) Console.WriteLine($"{word} was found in these sentences:\n");

            for (int i = 0; i < sentencesContainingWord.Count; i++)
            {
                var splitSentence = sentencesContainingWord[i].Split(' ').ToList();
                Console.Write($"{i + 1}: ");
                foreach (var w in splitSentence)
                {
                    if (!w.ToLower().Equals(FileNameSearchWordAndCounter.SearchWord)) Console.Write($"{w} ");
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write($"{w}");
                        Console.ResetColor();
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
            }

            FileNameSearchWordAndCounter.TotalWordCounter = 0;
            Helper.PressAnyKeyToContinue();
            new DisplayToUser().MainMenu();
        }

        /// <summary>
        /// List = FileNameSearchWordAndCounter.MyCollection >> List<titles.txts, searchWord, counter>
        /// </summary>
        /// <param name="allLists"></param>
        /// <param name="i"></param>
        internal static void PrintOutPriorSearches(List<(List<Dictionary<string, string>>, string, int)> allLists, int i)
        {
            //Varje lista ska inehålla varsitt sökord
            //gå igenom lista 1. word He. 3 listor 86 count. 35, 9 ,24, 0
            //gå igenom lista 2. word = Help. 5 count. 1, 0, 4, 0
            //printa ut det

            //Så lista 1 ska inehålla 
            // 1 lista med 3 dictionarys. dict key = heList1.txt //(word+title)
            // 1 sökord (he)
            // 1 count (total count) 86
            if (allLists.Count > i)
            {
                //searchword+title ex: helloTextFile1.txt
                var keyItteration = allLists[i].Item1[i].Keys.First();
                var word = allLists[i].Item2; //ok

                // vill bara loopa igenom listorna som hör till första sökordet. inte alla 8 listor om man söker på 2 ord
                int index = 0;
                int totalWords = 0;
                var listOfDictOfTitles = allLists[i].Item1; //ok
                Console.WriteLine($"\n{i + 1}: ");
                Console.WriteLine($"Word: {word}");
                Console.WriteLine($"{word} was found in these titles:\n");


                if (keyItteration.Contains(word))
                {
                    foreach (var keyValuePair in listOfDictOfTitles)
                    {
                        foreach (var v in keyValuePair.Values)
                        {
                            Console.WriteLine($"Title:{v}");
                            Console.WriteLine($"Count: {allLists[index].Item3}\n");
                            totalWords += allLists[index].Item3;
                            index++;
                        }
                    }
                    Console.WriteLine($"Total count: {totalWords}");

                }

                PrintOutPriorSearches(allLists, i + index);
            }
        }
    }
}
