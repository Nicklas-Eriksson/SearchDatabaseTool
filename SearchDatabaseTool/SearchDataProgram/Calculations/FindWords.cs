using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SearchDatabaseTool.SearchDataProgram.Calculations
{
    class FindWords
    {
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

        // Spara resultatet av SÖKNINGEN i en icke-linjär eller abstrakt datastruktur.

        // Det skall gå att skriva ut samtliga resultat från er datastruktur i föregående punkt till konsollen.

        // Användaren skall ha möjlighet att sortera orden i dokumenten i bokstavsordning och skriva ut de första x orden till konsolen.

        // Ge användaren feedback på resultat av kommandon.

        // Tidskomplexiteten för minst 2 funktioner skall skrivas som kommentarer i koden.

        // Minst en funktion skall vara rekursiv i programmet.

        // Koden skall vara kommenterad.
    }
}
