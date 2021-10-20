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
    public static class Helper
    {
        /// <summary>
        /// Prompts user with an error.
        /// Default error = "Error! Wrong input."
        /// </summary>
        /// <param name="e">"" for default error or optional.</param>
        /// <returns></returns>
        internal static string Error(string e)
        {
            Thread.Sleep(1500);

            if (e == "") return "Error! Wrong input.";
            
            return e;
        }

        //Test this method
        public static bool IsNumb(int nr) 
        {
            return false;
        }

        /// <summary>
        /// For menu options.
        /// if input is not able to be parsed the method is called again.
        /// if number is lower than minInput or higher than maxOutput is called again.
        /// if input == q user wants to go back to previous menu.
        /// </summary>
        internal static int GetUserInput(int minInput, int maxOutput)
        {
            var input = Console.ReadLine().Trim().ToLower();
            var success = Int32.TryParse(input, out int number);
            if (success == false ||number < minInput || number > maxOutput)
            {
                if (input.StartsWith("q")) return 0; //user wants to go back
                Error("");
                GetUserInput(minInput, maxOutput);
            }
            return number;
        }
               
        /// <summary>
        /// Exits the application with exit code 0.
        /// </summary>
        internal static void ExitProgram()
        {
            Environment.Exit(0);
        }
    }
}
