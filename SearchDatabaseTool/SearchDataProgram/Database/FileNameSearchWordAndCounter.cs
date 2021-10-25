using System.Collections.Generic;

namespace SearchDatabaseTool.SearchDataProgram.Database
{
    public class FileNameSearchWordAndCounter
    {
        /// <summary>
        /// Title, SearchWord, Counter.
        /// </summary>
        public static List<(List<string>, string, int)> MyCollection = new List<(List<string>, string, int)>();
        public static List<string> SearchWords = new List<string> ();

        public static string SearchWord { get; internal set; }
        public static int TotalWordCounter { get; internal set; }

        /// <summary>
        /// Title > Search Word > Word Counter.
        /// </summary>
        /// <param name="textTitle"></param>
        /// <param name="searchWord"></param>
        /// <param name="wordCounter"></param>
        public static void FillTuple(List<string> textTitle, string searchWord, int wordCounter)
        {
            SearchWord = searchWord;
            TotalWordCounter += wordCounter;
            FileNameSearchWordAndCounter.MyCollection.Add((textTitle, searchWord, wordCounter));
        }
    }
}
