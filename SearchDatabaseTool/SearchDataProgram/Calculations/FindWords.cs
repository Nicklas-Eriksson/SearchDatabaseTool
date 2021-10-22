using SearchDatabaseTool.SearchDataProgram.Database;
using SearchDatabaseTool.SearchDataProgram.UI;
using System.Collections.Generic;
using System.Linq;

namespace SearchDatabaseTool.SearchDataProgram.Calculations
{
    public class FindWords
    {
        public static Dictionary<string, int> DocNameAndWordOccurance = new Dictionary<string, int>();
        public static List<int> WordMatchCounter = new List<int>();
        private static int index = 1;
                
        internal static void CallerMethod(string word)
        {
            FileNameSearchWordAndCounter.SearchWords.Add(word); //Addar sökordet i en lista

            DB.GetStream(); //fyller listorna
            LoadLists(); //adderar namn på listor + listorna
            HolderMethodForSearching();
        }

        public static void HolderMethodForSearching()
        {
            foreach (var keyValueCombination in DB.AllLists2)
            {
                var sentenses = LoopThroughListRowsTESTMETOD(keyValueCombination.Value);
                var count = CheckSentencesForMultipleWords(sentenses);
                FileNameSearchWordAndCounter.FillTuple(keyValueCombination.Key, FileNameSearchWordAndCounter.SearchWords.Last(), count);
                DisplayToUser.PrintWord(sentenses);
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
                                if (w.Equals(word)) sentenseMatchExact.Add(true);
                                else sentenseMatchExact.Add(false);
                            }

                            if (sentenseMatchExact.Contains(true)) sentencesContainingWord.Add(s);
                        }
                    }
                }
            }

            return sentencesContainingWord;
        }

        private static int CheckSentencesForMultipleWords(List<string> list)
        {
            int counter = 0;
            var word = FileNameSearchWordAndCounter.SearchWords.Last();
            for (int i = 0; i < list.Count; i++)
            {
                var words = list[i].Split(' ');
                for (int j = 0; j < words.Length; j++)
                {
                    if (words[j].ToLower().Equals(word)) counter++;
                }
            }
            return counter;
        }
    }
}
