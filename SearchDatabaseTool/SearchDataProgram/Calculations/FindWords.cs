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
        private static List<string> AllSentences = new List<string>();

        internal static void CallerMethod(string word)
        {
            FileNameSearchWordAndCounter.SearchWords.Add(word); //Addar sökordet i en lista
            DB.GetStream(); //fyller listorna
            LoadLists(); //adderar namn på listor + listorna
            HolderMethodForSearching();
        }

        public static void HolderMethodForSearching()
        {
            AllSentences.Clear();
            //DB.AllList2 = Dictionary with key = title, value = list of 
            List<string> sentences = new List<string>();
            foreach (var keyValueCombination in DB.AllLists2)
            {
                //Picks out the sentences from all the txt files containing the sentences.
                sentences = LoopThroughListRows(keyValueCombination.Value);
                var count = CheckSentencesForMultipleWords(sentences);
                if (count > 0)
                {
                    FileNameSearchWordAndCounter.FillTuple(
                        keyValueCombination.Key,
                        FileNameSearchWordAndCounter.SearchWords.Last(),
                        count
                        );
                    for (int i = 0; i < sentences.Count; i++)
                    {
                        AllSentences.Add(sentences[i]);
                    }
                }
            }
            DisplayToUser.PrintWord(AllSentences);
        }

        /// <summary>
        /// Loads up the list with all the txt docs once.
        /// </summary>
        public static void LoadLists()
        {
            if (index == 1)
                foreach (var list in DB.AllLists)
                {
                    DB.AllLists2.Add($"Textfil:{index}.txt", list);
                    index++;
                }
        }

        private static List<string> LoopThroughListRows(List<string> list)
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
                            var sentenceMatchExact = new List<bool>();
                            foreach (var w in words)
                            {
                                if (w.Equals(word)) sentenceMatchExact.Add(true);
                                else sentenceMatchExact.Add(false);
                            }

                            if (sentenceMatchExact.Contains(true)) sentencesContainingWord.Add(s);
                        }
                    }
                }
            }
            return sentencesContainingWord;
        }

        private static int CheckSentencesForMultipleWords(List<string> list)
        {
            int counter = 0;
            for (int i = 0; i < list.Count; i++)
            {
                var words = list[i].Split(' ');
                for (int j = 0; j < words.Length; j++)
                    if (words[j].ToLower().Equals(FileNameSearchWordAndCounter.SearchWords.Last())) counter++;
            }
            return counter;
        }

        //private static int CheckSentencesForMultipleWords(List<string> list, int counter, int i)
        //{

        //    if (i >= list.Count) return counter;

        //    var words = list[i].Split(' ');
        //    for (int j = 0; j < words.Length; j++)
        //        if (words[j].ToLower().Equals(FileNameSearchWordAndCounter.SearchWords.Last())) counter++;

        //    CheckSentencesForMultipleWords(list, counter, i+1);

        //    return counter;
        //}
    }
}
