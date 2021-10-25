using System.Collections.Generic;

namespace SearchDatabaseTool.SearchDataProgram.Database
{
    public class FileNameSearchWordAndCounter
    {
        // Titel + lista med rader

        /// <summary>
        /// Lista med tuples som är fynd>>> Dict key = word+titel, titel     titel och count
        /// 
        /// Title, SearchWord, Counter.
        /// </summary>
        public static List<(List<Dictionary<string, string>>, string, int)> MyCollection
            = new List<(List<Dictionary<string, string>>, string, int)>();

        public static List<string> SearchWords = new List<string>();
        //dict > key string = searchWord+title to get unique ID, value = title

        private static List<Dictionary<string, string>> TitlesContainingWord = new List<Dictionary<string, string>>();

        public static string SearchWord { get; internal set; }
        public static int TotalWordCounter { get; internal set; }

        /// <summary>
        /// Title > Search Word > Word Counter.
        /// </summary>
        /// <param name="textTitle"></param>
        /// <param name="searchWord"></param>
        /// <param name="wordCounter"></param>
        public static void FillTuple(string textTitle, string searchWord, int wordCounter)
        {
            SearchWord = searchWord;
            TotalWordCounter += wordCounter;
            TitlesContainingWord.Add(new Dictionary<string, string>() { { searchWord+textTitle, textTitle } }); //kanske
            FileNameSearchWordAndCounter.MyCollection.Add((TitlesContainingWord, searchWord, wordCounter));
        }
    }
}
