using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace SearchDatabaseTool.SearchDataProgram.Database
{
    public static class DB
    {
        internal static void MyStream()
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

            Console.WriteLine(folderPath);
            Console.WriteLine(path1000);

            var lista1k = new List<string>();

            using (StreamReader sr = new StreamReader(path1000))
            {
                string line;

                while((line = sr.ReadLine()) != null)
                {
                    lista1k.Add(line);
                }
            }


            var count = 0;
            var x = new List<string>();


            for (int i = 0; i < lista1k.Count; i++)
            {
                if (lista1k[i].Contains("He"))
                {
                    count++;
                    x.Add(lista1k[i].ToString());
                }
            }

            Console.WriteLine(count);

            foreach (var item in x)
            {
                Console.WriteLine(item);
            }
        }
       

        // Ladda in filerna i passande struktur (Lista eller liknande).
    }
}
