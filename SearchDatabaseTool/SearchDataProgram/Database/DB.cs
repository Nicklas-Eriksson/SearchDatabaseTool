using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace SearchDatabaseTool.SearchDataProgram.Database
{
    public static class DB
    {
        public static List<List<string>> AllLists = new List<List<string>>();

        public static List<string> List1000 = new List<string>();
        public static List<string> List1500 = new List<string>();
        public static List<string> List3000 = new List<string>();
        public static List<string> ListBig = new List<string>();

        internal static void GetStream()
        {
            if(AllLists.Count <= 0) FillLists();
        }

        private static void FillLists()
        {
            var folder = "ShortStories/";
            var File1000 = $@"{folder}1000Words.txt";
            var File1500 = $@"{folder}1500Words.txt";
            var File3000 = $@"{folder}3000Words.txt";
            var FileBig = $@"{folder}BigWords.txt";

            var folderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);
            folderPath = folderPath.Remove(folderPath.Length - 5);

            var path1000 = Path.Combine(folderPath, File1000);
            var path1500 = Path.Combine(folderPath, File1500);
            var path3000 = Path.Combine(folderPath, File3000);
            var pathBig = Path.Combine(folderPath, FileBig);

            var pathList = new List<string>() { path1000, path1500, path3000, pathBig };

            AllLists.Add(List1000);
            AllLists.Add(List1500);
            AllLists.Add(List3000);
            AllLists.Add(ListBig);

            for (int i = 0; i < AllLists.Count; i++)
            {
                using (StreamReader sr = new StreamReader(pathList[i]))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        AllLists[i].Add(line);
                    }
                }
            }          
        }

        //Fel class!!!
        internal static void TestPrintWord(string word)
        {
            GetStream();
            var count = 0;
            var x = new List<string>();

            for (int i = 0; i < AllLists.Count; i++)
            {
                for (int row = 0; row < AllLists[i].Count; row++)
                {
                    if (AllLists[i][row].Contains(word))
                    {
                        count++;
                        x.Add(AllLists[i][row].ToString());
                    }
                }
            }
           

            Console.WriteLine($"Your word: {word} was found {count} times.");
            Console.WriteLine("Here are the sentences they were found in:");
            foreach (var row in x)
            {
                Console.WriteLine($"Sentence: {row}\n");
            }
            Console.ReadLine();
        }


        internal static void PrintChosenTxt(int option)
        {
            foreach (var line in AllLists[option-1])
            {
                Console.WriteLine(line);
            }

            //To stop loop
            Console.ReadLine();
        }
    }
}
