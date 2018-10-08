using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ScrapingAnalyser.Interfaces
{
    public class WebReader : IWebReader
    {
        private const string GOOGLE_SEARCH_URL = "http://www.google.com.au/search?num={0}&q={1}";
        private string _searchTerm;
        private int _numOfResults;

        public WebReader(string searchTerm, int numOfResults)
        {
            _searchTerm = searchTerm;
            _numOfResults = numOfResults;
        }

        public string Read()
        {
            string htmlString = string.Empty;
            string search = string.Format(GOOGLE_SEARCH_URL, _numOfResults, HttpUtility.UrlEncode(_searchTerm));
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(search);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.ASCII))
                {
                    htmlString = reader.ReadToEnd();
                }
            }
            return htmlString;
        }
    }
}
