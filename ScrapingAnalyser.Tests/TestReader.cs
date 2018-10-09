using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScrapingAnalyser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
namespace ScrapingAnalyser.Tests
{
    [TestClass]
    public class TestReader
    {
        [TestMethod]
        public void TestReader_Fail_InvalidUrl()
        {
            var reader = new WebReader("conveyancing software", 100, "www.111");
            try
            {
                reader.Read();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Incorrect site URL", ((HttpResponseException)ex).Response.ReasonPhrase);
            }
        }
    }
}
