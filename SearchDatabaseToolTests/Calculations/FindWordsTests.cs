using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchDatabaseTool.SearchDataProgram.Calculations;
using SearchDatabaseTool.SearchDataProgram.Database;

namespace SearchDatabaseToolTests.Calculations
{
    [TestClass()]
    public class FindWordsTests
    {
        [TestMethod()]
        public void CallerMethodTest()
        {
            //DB.GetStream();
            //FindWords.LoadLists();
            string word = "cat";
            FindWords.CallerMethod(word);
            var res = FileNameSearchWordAndCounter.TotalWordCounter;
            Assert.AreEqual(512, res);
        }
    }
}

