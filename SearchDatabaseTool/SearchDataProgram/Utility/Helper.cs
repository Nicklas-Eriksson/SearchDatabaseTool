using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchDatabaseTool.SearchDataProgram.Utils
{
    internal class Helper
    {
        internal string Error(string e)
        {
            if (e == "")
                return "Error! Wrong input.";
            else
                return e;
        }

        internal bool IsNumb(int nr) 
        {
            return false;
        }

        internal void ExitProgram()
        {
            Environment.Exit(0);
        }
    }
}
