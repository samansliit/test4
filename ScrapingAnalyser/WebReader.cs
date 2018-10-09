using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ScrapingAnalyser.Interfaces
{
    public class WebReader : IWebReader
    {
        private const string GOOGLE_SEARCH_URL = "http://www.google.com.au/search?num={0}&q={1}";
        private string _searchTerm;
        private int _numOfResults;
        private string _siteUrl;

        public WebReader(string searchTerm, int numOfResults, string siteUrl)
        {
            _searchTerm = searchTerm;
            _numOfResults = numOfResults;
            _siteUrl = siteUrl;
        }

        public string Read()
        {
            string htmlString = string.Empty;
            string search = string.Format(_siteUrl, _numOfResults, HttpUtility.UrlEncode(_searchTerm));

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(search);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.ASCII))
                    {
                        htmlString = reader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {

                var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "Incorrect site URL"
                };
                throw new HttpResponseException(response);
            }
          
            return htmlString;
        }
    }
}
