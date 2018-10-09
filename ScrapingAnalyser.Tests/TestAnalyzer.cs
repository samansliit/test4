using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScrapingAnalyser;

namespace ScrapingAnalyser.Tests
{
    /// <summary>
    /// Summary description for TestAnalyzer
    /// </summary>
    [TestClass]
    public class TestAnalyzer
    {
        ScrapingDataAnalyzer scrapingDataAnalyzer;

       [TestInitialize]
        public void SetupTestData()
        {
           
        }


        [TestMethod]
        public void TestContentword_matches()
        {
            scrapingDataAnalyzer = new ScrapingDataAnalyzer("https://www.test.com.au");
            scrapingDataAnalyzer.AnalyseWebContent(@"<h3 class=""r""><a href= ""/ url ? q = https ://www.test.com.au/&amp;sa=U&amp;ved=0ahUKEwi4ybGdjfbdAhUBPH0KHYZoDkIQwW4IxQQwZg&amp;usg=AOvVaw3O0Ztr4Ng6Pd9PLPzoozLW""></a>");
        }
    }
}
