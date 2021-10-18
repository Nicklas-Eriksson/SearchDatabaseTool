using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchDatabaseTool.SearchDataProgram.Calculations
{
    class FindWords
    {
        // Hämtar filerna från DB.cs

        /// <summary>
        /// Search for how many times your word is occuring in the documents.
        /// Returns a ranking of which documents containing the word the most.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public void WordOccurrence(string word)
        {
            if (word == null || word == "") return;



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
        public void ListContains(string word)
        {
            //testa om sökte ordet contains i listorna innan en loop sökning genomförs?
            //finns det inte meddelas det, eller så söks bara listorna där det finns.
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
