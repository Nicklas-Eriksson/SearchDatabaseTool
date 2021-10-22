using System;
using System.Collections.Generic;

namespace SearchDatabaseTool.SearchDataProgram.Database
{
    public class FileNameSearchWordAndCounter
    {
        /// <summary>
        /// Title, SearchWord, Counter.
        /// </summary>
        public static List<(string, string, int)> MyCollection = new List<(string, string, int)>();
        public static List<string> SearchWords = new List<string> ();

        public static string TextTitle { get; internal set; }
        public static string SearchWord { get; internal set; }
        public static int TotalWordCounter { get; internal set; }

        public static void FillTuple(string textTitle, string searchWord, int wordCounter)
        {
            TextTitle = textTitle;
            SearchWord = searchWord;
            TotalWordCounter += wordCounter;
            FileNameSearchWordAndCounter.MyCollection.Add((textTitle, searchWord, wordCounter));
        }

    }
}
