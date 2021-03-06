using SearchDatabaseTool.SearchDataProgram.Calculations;
using SearchDatabaseTool.SearchDataProgram.Database;
using SearchDatabaseTool.SearchDataProgram.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace SearchDatabaseTool.SearchDataProgram.UI
{
    internal class DisplayToUser
    {
        /// <summary>
        /// Prompts user to choose a option.
        /// </summary>
        internal void MainMenu()
        {
            bool loop = true;
            do
            {
                Console.Clear();
                PrintMenuOptions();
                var input = Helper.GetUserInput(1, 4);
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
            switch (Helper.GetUserInput(1, 4))
            {
                case 1:
                    PrintOutPriorSearches(FileNameSearchWordAndCounter.MyCollection, 0);
                    Helper.PressAnyKeyToContinue();
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
            var result = Helper.GetUserInput(1, searchResultCollection.Count);
            if (result == 0)
            {
                MainMenu();
            }
            else
            {
                var list = FindWords.FetchSpecificSearchResults(searchResultCollection[result - 1]);
                PrintSpecificResults(list, searchResultCollection[result - 1]);
            }
            //ChosenResult(searchResultCollection[result - 1]);
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
            var searchWord = FileNameSearchWordAndCounter.SearchWords.Last();
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
            if (allLists.Count > i)
            {
                var word = allLists[i].Item2;

                int index = 0;
                int totalWords = 0;
                var dictsOfTitles = allLists[i].Item1;
                var titlesContainingWord = new List<KeyValuePair<string, string>>();
                foreach (var keyValuePairs in dictsOfTitles)
                {
                    foreach (var kVP in keyValuePairs)
                    {
                        if (kVP.Key.Equals(word + kVP.Value))
                        {
                            titlesContainingWord.Add(kVP);
                        }
                    }
                }
                Console.WriteLine("=====================================================");
                Console.WriteLine($"\nWord: {word}");
                Console.WriteLine($"{word} was found in these titles:\n");

                PrintOutWordCounterForEachTitle(allLists, i, word, ref index, ref totalWords, titlesContainingWord);

                PrintOutPriorSearches(allLists, i + index);
            }
        }

        private static void PrintOutWordCounterForEachTitle(List<(List<Dictionary<string, string>>, string, int)> allLists, int i, string word, ref int index, ref int totalWords, List<KeyValuePair<string, string>> titlesContainingWord)
        {
            var x = i;
            foreach (var keyValuePair in titlesContainingWord)
            {
                Console.WriteLine($"Title:{keyValuePair.Value}");
                Console.WriteLine($"Count: {allLists[x].Item3}\n");
                totalWords += allLists[x].Item3;
                x++;
                index++;
            }

            Console.WriteLine($"Total count: {totalWords}");
        }
        private static void PrintSpecificResults(List<string> list, string word)
        {
            Console.WriteLine($"\nWord: {word}");
            Console.WriteLine($"Previous results containing {word}\n");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i+1}. {list[i]}");
            }
        }
    }
}
