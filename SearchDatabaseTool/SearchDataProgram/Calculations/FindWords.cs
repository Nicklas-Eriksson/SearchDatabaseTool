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

        public static void CallerMethod(string word)
        {
            WordsSearched.Add(word); //Addar sökordet i en lista

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
                var sentenses = LoopThroughListRowsTESTMETOD(keyValueCombination);
                var count = FindWordsFromSearchTESTMETOD(sentenses);
                FileNameSearchWordAndCounter.FillTuple(keyValueCombination.Key, WordsSearched.Last(), count);
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

        private static List<string> LoopThroughListRows()
        {
            var sentencesContainingWord = new List<string>();
            var splitRow = new List<string>();
            var word = WordsSearched.Last();
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
                        //foreach (var s in sentences)
                        //{
                        //    if (s.Contains(word))
                        //    {
                        //        //count++; // Vad händer om det står: pain pain pain i rad. Då räknas bara 1.
                        //        sentencesContainingWord.Add(s);
                        //    }
                        //}
                        //bättre exakt count. ska fixas till.
                        for (int i = 0; i < sentences.Count; i++)
                        {
                            if (sentences[i].Contains(word))
                            {
                                sentencesContainingWord.Add(sentences[i]);
                                splitRow = sentences[i].Split(' ').ToList();
                                for (int j = 0; j < splitRow.Count; j++)
                                {
                                    if (splitRow[j].Equals(word))
                                    {
                                        count++;
                                    }
                                }
                            }
                        }
                    }
                }
                FileNameSearchWordAndCounter.FillTuple(keyValueCombination.Key, word, count);
            }
            return sentencesContainingWord;
        }
        private static List<string> LoopThroughListRowsTESTMETOD(KeyValuePair<string, List<string>> list)
        {
            var sentencesContainingWord = new List<string>();
            var word = WordsSearched.Last();
            //Loops through all the lists.

            //Loops through all the rows in the list at AllList at index i.
            foreach (var row in list.Value)
            {
                    if (row.Contains(word))
                    {
                        var sentences = row.Split('.').ToString();
                        sentencesContainingWord.Add(sentences);
                    }
            }

            //for (int row = 0; row < list.Values.Count; row++)
            //{
            //    if (list.Values[row].Contains(word))
            //    {
            //        var sentences = list.Value[row].Split('.').ToString();
            //        sentencesContainingWord.Add(sentences);
            //    }
            //}

            return sentencesContainingWord;
        }
        public static int FindWordsFromSearchTESTMETOD(List<string> list) //Sökning på specifika ord metod
        {
            int counter = 0;
            var word = WordsSearched.Last();
            var splitRow = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Contains(word))
                {
                    splitRow = list[i].Split(' ').ToList();
                    for (int j = 0; j < splitRow.Count; j++)
                    {
                        if (splitRow[j].Equals(word))
                        {
                            counter++;
                        }
                    }
                }
            }
            return counter;
        }

        //public static int FindWordsFromSearch(List<string> list, string search) //Sökning på specifika ord metod
        //{
        //    //kanske ska ta in huvudlistan istället och en metod får loopa in alla i denna. se om det blir mer exakt resultat och mindre dubbelräkning/nollställning
        //    int counter = 0;
        //    var splitRow = new List<string>();
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        if (list[i].Contains(search))
        //        {
        //            splitRow = list[i].Split(' ').ToList();
        //            for (int j = 0; j < splitRow.Count; j++)
        //            {
        //                if (splitRow[j].Equals(search))
        //                {
        //                    counter++;
        //                }
        //            }
        //        }
        //    }
        //    return counter;
        //}

        //TESTVERISON
        public static void TestPrintWord(List<string> sentencesContainingWord)
        {
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


        //public bool ListContains(string word, List<string> list)
        //{
        //    //testa om sökte ordet contains i listorna innan en loop sökning genomförs?
        //    //finns det inte meddelas det, eller så söks bara listorna där det finns.

        //    // check if list contains word. if not it does not need to be fully checked.
        //    if (list.Contains(word))
        //    {
        //        return true;
        //    }
        //    return false;

        //}
        //public void SortList(List<string> list)
        //{
        //    list.Sort();
        //}

        //public static void Method()
        //{
        //    string text2 = (File.ReadAllText(@"D:\Upload\story.txt"));
        //    MatchCollection matchedAuthors = RegexMethod(Console.ReadLine().Trim().ToLower()).Matches(text2);
        //    Console.WriteLine(matchedAuthors.Count);
        //}
        //public static Regex RegexMethod(string search) => new Regex($@"\b{search}\b");

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
