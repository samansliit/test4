using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Unity;
using ScrapingAnalyser.Interfaces;
using Unity.Injection;
using ScrapingAnalyser;

namespace ConsoleApp1
{
    class Program
    {

      
        static void Main(string[] args)
        {

            UnityContainer iocContainer = new UnityContainer();

            iocContainer.RegisterType<IWebReader, WebReader>(new InjectionConstructor("conveyancing software",100));
            iocContainer.RegisterType<IScrapingDataAnalyzer, ScrapingDataAnalyzer>(new InjectionConstructor("https://www.smokeball.com.au"));
            iocContainer.RegisterType<IScrapingReportJob, ScrapingReportJob>();
            var reportJob = iocContainer.Resolve<IScrapingReportJob>();
            reportJob.Execute();
            //////////////////////////////////////////////////
            ///
            Uri url = new Uri("https://www.smokeball.com.au");
            List<int> positions = GetPosition(url, "conveyancing software");
            foreach (var item in positions)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
  
        public static List<int> GetPosition(Uri url, string searchTerm)
        {
          
            string raw = "http://www.google.com.au/search?num={0}&q={1}";
            int numOfResults = 100;
            string search = string.Format(raw, numOfResults, HttpUtility.UrlEncode(searchTerm));
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(search);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.ASCII))
                {
                    string html = reader.ReadToEnd();
                    return FindPosition(html, url);
                }
            }
        }

        private static List<int> FindPosition(string html, Uri url)
        {
            string lookup = @"<h3 class=""r""><a href=""/.*?\?q=(.*?)"">(.*?)</a>";
            List<int> indexes = new List<int>();
            MatchCollection matches = Regex.Matches(html, lookup);
            for (int i = 0; i < matches.Count; i++)
            {
                string match = matches[i].Groups[1].Value;
                if (match.Contains(url.Host))
                    indexes.Add( i + 1);
            }
            indexes.Add(0);
            return indexes;
        }
    }
}
