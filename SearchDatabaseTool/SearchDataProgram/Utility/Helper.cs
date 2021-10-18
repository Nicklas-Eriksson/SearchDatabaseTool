using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SearchDatabaseTool.SearchDataProgram.Utils
{
    /// <summary>
    /// Utility classes to help with programming.
    /// </summary>
    public class Helper
    {
        /// <summary>
        /// Prompts user with an error.
        /// Default error = "Error! Wrong input."
        /// </summary>
        /// <param name="e">"" for default error or optional.</param>
        /// <returns></returns>
        internal string Error(string e)
        {
            Thread.Sleep(1500);

            if (e == "") return "Error! Wrong input.";
            
            return e;
        }

        //Test this method
        public bool IsNumb(int nr) 
        {
            return false;
        }
       
        /// <summary>
        /// For menu options.
        /// if input is not able to be parsed 0 is returned.
        /// if number is lower than minInput or higher than maxOutput 0 is returned.
        /// </summary>
        internal int GetUserInput(int minInput, int maxOutput)
        {
            var success = Int32.TryParse(Console.ReadLine().Trim().ToLower(), out int number);
            if (success == false ||number < minInput || number > maxOutput)
            {
                Error("");
                GetUserInput(minInput, maxOutput);
            }
            return number;
        }

        /// <summary>
        /// Exits the application with exit code 0.
        /// </summary>
        internal void ExitProgram()
        {
            Environment.Exit(0);
        }
    }
}
