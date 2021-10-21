using SearchDatabaseTool.SearchDataProgram.Database;
using SearchDatabaseTool.SearchDataProgram.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SearchDatabaseTool.SearchDataProgram.Calculations
{
    class FindWords
    {
        public static Dictionary<string, int> DocNameAndWordOccurance = new Dictionary<string, int>();
        public static List<string> WordsSearched = new List<string>();
        public static List<int> WordMatchCounter = new List<int>();
        private static int index = 1;

        //TEST ATT SKRIVA UT TIDIGARE SÖKNINGAR
        public static void PrintOutPriorSearches()
        {
            Console.WriteLine("Here are your prior searches:\n");


            foreach (var item in FileNameSearchWordAndCounter.myCollection)
            {
                Console.WriteLine($"Word: {item.Item2}\nTitle: {item.Item1}\nCount: {item.Item3}\n");
            }
        }

        // Hämtar filerna från DB.cs
        public void WordManager()
        {

        }

        /// <summary>
        /// Search for how many times your word is occuring in the documents.
        /// Returns a ranking of which documents containing the word the most.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public void WordOccurrence(string word, List<string> list)
        {
            if (string.IsNullOrEmpty(word)) return;
            int count = 0;
            //foreach (Match match in Regex.Matches(list, word))
            //{
            //    count++;
            //}
            //if (count > 0)
            //{
            //    //save number of occurences or return number

            //}
            //else
            //{
            //    //return 0
            //}


            // Räkna ordet i alla 3 filer.
            // Jämföra vilket doc som har mest förekomst av ordet. TEX:
            // Lista1 = 33st ord
            // Lista2 = 12st ord
            // Lista3 = 79st ord
            // Rangordna och returnera listorna plus hur många ord i varje

            // --Display sample--
            // 1. De tre bockarna bruse. Word match = 79
            // 2. Den magiska grottan. Word match = 33
            // 3. En saga om tre fiskar. Word match = 12
        }

        //TESTVERISON
        public static void TestPrintWord(string word)
        {
            WordsSearched.Add(word); //Addar sökordet i en lista
            DB.GetStream();

            //laddar in allList in i dictionaryn
            if(index == 1)
            {
                foreach (var list in DB.AllLists)
                {
                    DB.AllLists2.Add($"Textfil:{index}.txt", list);
                    index++;
                }
            }
           
            var sentencesContainingWord = new List<string>();

            //Loops through all the lists.
            foreach (var keyValueCombination in DB.AllLists2)
            {
                var count = 0;

                //Loops through all the rows in the list at AllList at index i.
                for (int row = 0; row < keyValueCombination.Value.Count; row++)
                {
                    if (keyValueCombination.Value[row].Contains(word))
                    {
                        var sentences = keyValueCombination.Value[row].ToString().Split('.').ToList();
                        foreach (var s in sentences)
                        {
                            if (s.Contains(word))
                            {
                                count++; // Vad händer om det står: pain pain pain i rad. Då räknas bara 1.
                                sentencesContainingWord.Add(s);
                            }
                        }
                    }
                }
                FileNameSearchWordAndCounter.FillTuple(keyValueCombination.Key, word, count);
            }

            //Bryt ut
            Console.WriteLine($"Your word: {FileNameSearchWordAndCounter.SearchWord} was found {FileNameSearchWordAndCounter.TotalWordCounter} times.");
            Console.WriteLine($"Your word was found in these sentences:\n");

            //Skriver ut alla meningar där ordet hittats + markera ordet med en annan färg
            for (int i = 1; i < sentencesContainingWord.Count; i++)
            {
                var splitSentence = sentencesContainingWord[i].Split(' ').ToList();
                Console.Write($"{i}: ");
                foreach (var w in splitSentence)
                {
                    if (!w.Contains(FileNameSearchWordAndCounter.SearchWord))
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

            Console.WriteLine("Press any key to go back!");
            Console.ReadLine();
            var d = new DisplayToUser();
            d.MainMenu();
        }


        public bool ListContains(string word, List<string> list)
        {
            //testa om sökte ordet contains i listorna innan en loop sökning genomförs?
            //finns det inte meddelas det, eller så söks bara listorna där det finns.

            // check if list contains word. if not it does not need to be fully checked.
            if (list.Contains(word))
            {
                return true;
            }
            return false;

        }
        public void SortList(List<string> list)
        {
            list.Sort();
        }

        public static void Method()
        {
            string text2 = (File.ReadAllText(@"D:\Upload\story.txt"));
            MatchCollection matchedAuthors = RegexMethod(Console.ReadLine().Trim().ToLower()).Matches(text2);
            Console.WriteLine(matchedAuthors.Count);
        }
        public static Regex RegexMethod(string search) => new Regex($@"\b{search}\b");

        // Spara resultatet av SÖKNINGEN i en icke-linjär eller abstrakt datastruktur.
        // Det skall gå att skriva ut samtliga resultat från er datastruktur i föregående punkt till konsollen.
        //välja vilken sökning du vill läsa mer om
        //skriv ut alla sökningar

        //Search: "alarming" was found a total of 99 times, 49 times from Text3000.txt, 40 times from Text1500.txt & 10 times from Text1000.txt.
        //Search: "book" was found a total of 99 times, 49 times from Text3000.txt, 40 times from Text1500.txt & 10 times from Text1000.txt.
        //Search: "frog" was found a total of 99 times, 49 times from Text3000.txt, 40 times from Text1500.txt & 10 times from Text1000.txt.


        // Användaren skall ha möjlighet att sortera orden i dokumenten i bokstavsordning och skriva ut de första x orden till konsolen.

        // Ge användaren feedback på resultat av kommandon.

        // Tidskomplexiteten för minst 2 funktioner skall skrivas som kommentarer i koden.

        // Minst en funktion skall vara rekursiv i programmet.

        // Koden skall vara kommenterad.
    }
}
