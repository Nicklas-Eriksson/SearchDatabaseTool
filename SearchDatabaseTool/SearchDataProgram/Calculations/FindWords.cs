using SearchDatabaseTool.SearchDataProgram.Database;
using SearchDatabaseTool.SearchDataProgram.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SearchDatabaseTool.SearchDataProgram.Calculations
{
    public class FindWords
    {
        public static Dictionary<string, int> DocNameAndWordOccurance = new Dictionary<string, int>();
        public static List<int> WordMatchCounter = new List<int>();
        private static int index = 1;

        //TEST ATT SKRIVA UT TIDIGARE SÖKNINGAR
        public static void PrintOutPriorSearches(List<(string, string, int)> allLists, int i)
        {
            if (allLists.Count > i)
            {
                Console.WriteLine("Here are your prior searches:\n");
                Console.WriteLine($"Word: {allLists.FirstOrDefault().Item2}\nTitle: {allLists.FirstOrDefault().Item1}\nCount: {allLists.FirstOrDefault().Item3}\n");
                PrintOutPriorSearches(allLists, i + 1);
            }
        }

        public static void CallerMethod(string word)
        {
            FileNameSearchWordAndCounter.SearchWords.Add(word); //Addar sökordet i en lista

            //Behövs för tester.
            DB.GetStream(); //fyller listorna
            LoadLists(); //adderar namn på listor + listorna
            HolderMethodForSearching();

            //börja loopa igenom och identifiera rader med sökordet
            //ta ut de meningar där ordet nämns
            //loopa igenom meningar där ordet nämnts för att få exakt antal
            //där kan vi behöva en samlingsmetod. som får tillbaka namn på filen, sökordet från ena och antalet från andra. 
            //problematiken blir. att vi måste matcha vilken lista som hade vilket resultat. det kan ju dock få bli rekursivt. 
            //var sentencesContainingWord = LoopThroughListRows();
            //TestPrintWord(sentencesContainingWord); //Avaktivera vid tester

        }

        public static void HolderMethodForSearching()
        {
            foreach (var keyValueCombination in DB.AllLists2)
            {
                //Metodanrop
                //som returnerar lista med raderna som innehåller ordet
                //metod som tar emot lista med raderna och räknar antalet förekomster
                //detta görs tills alla listorna i AllLists2 är körda.

                //möjlig struktur ....
                //var sentences = LoopThroughListRows();
                //var count = FindWords(sentences);
                //FileNameSearchWordAndCounter.FillTuple(keyValueCombination.Key, WordsSearched.Last();, count);
                var sentenses = LoopThroughListRowsTESTMETOD(keyValueCombination.Value);
                var count = CheckSentencesForMultipleWords(sentenses);
                FileNameSearchWordAndCounter.FillTuple(keyValueCombination.Key, FileNameSearchWordAndCounter.SearchWords.Last(), count);
                TestPrintWord(sentenses);
            }

        }
        public static void LoadLists()
        {
            //laddar in allList in i dictionaryn
            if (index == 1)
            {
                foreach (var list in DB.AllLists)
                {
                    DB.AllLists2.Add($"Textfil:{index}.txt", list);
                    index++;
                }
            }
        }
             
        private static List<string> LoopThroughListRowsTESTMETOD(List<string> list)
        {
            var sentencesContainingWord = new List<string>();
            var word = FileNameSearchWordAndCounter.SearchWords.Last();

            //Loops through all the rows in the list at AllList at index i.
            foreach (var row in list)
            {
                if (row.ToLower().Contains(word))
                {
                    var sentences = row.Split('.').ToList();
                    foreach (var s in sentences)
                    {
                        if (s.ToLower().Contains(word))
                        {
                            var words = s.ToLower().Split(' ');
                            var sentenseMatchExact = new List<bool>();
                            foreach (var w in words)
                            {
                                if (w.Equals(word))
                                {
                                    sentenseMatchExact.Add(true);
                                }
                                else
                                {
                                    sentenseMatchExact.Add(false);
                                }
                            }
                            if (sentenseMatchExact.Contains(true))
                            {
                                sentencesContainingWord.Add(s);
                            }
                        }
                    }
                }
            }

            return sentencesContainingWord;
        }

        private static int CheckSentencesForMultipleWords(List<string> list) //Sökning på specifika ord metod
        {
            int counter = 0;
            var word = FileNameSearchWordAndCounter.SearchWords.Last();
            for (int i = 0; i < list.Count; i++)
            {
                var words = list[i].Split(' ');
                for (int j = 0; j < words.Length; j++)
                {
                    if (words[j].ToLower().Equals(word))
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }
        
        //TESTVERISON
        public static void TestPrintWord(List<string> sentencesContainingWord)
        {
            var nr = FileNameSearchWordAndCounter.TotalWordCounter;
            var searchWord = FileNameSearchWordAndCounter.SearchWord;
            var word = searchWord.ToString().ToUpper() + (searchWord.Substring(1));

            Console.WriteLine($"\nYour word: {word} was found {nr} times.");
            if (nr != 0)
            {
                Console.WriteLine($"{word} was found in these sentences:\n");
            }

            //Skriver ut alla meningar där ordet hittats + markera ordet med en annan färg
            for (int i = 0; i < sentencesContainingWord.Count; i++)
            {
                var splitSentence = sentencesContainingWord[i].Split(' ').ToList();
                Console.Write($"{i + 1}: ");
                foreach (var w in splitSentence)
                {
                    if (!w.ToLower().Equals(FileNameSearchWordAndCounter.SearchWord))
                    {
                        Console.Write($"{w} ");
                    }
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

            Console.WriteLine("\nPress any key to go back!");
            Console.ReadLine();
            new DisplayToUser().MainMenu();
        }
    }
}
