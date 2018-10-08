using ScrapingAnalyser.Interfaces;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ScrapingAnalyser
{
    public class ScrapingDataAnalyzer : IScrapingDataAnalyzer
    {
        private const string HREF_REG_EX = @"<h3 class=""r""><a href=""/.*?\?q=(.*?)"">(.*?)</a>";
        private string _contentKeyWord;

        public ScrapingDataAnalyzer(string contentKeyWord)
        {
            _contentKeyWord = contentKeyWord;
        }
        public List<int> AnalyseWebContent(string htmlContent)
        {
            List<int> indexes = new List<int>();
            MatchCollection matches = Regex.Matches(htmlContent, HREF_REG_EX);
            for (int i = 0; i < matches.Count; i++)
            {
                string match = matches[i].Groups[1].Value;
                if (match.Contains(_contentKeyWord))
                    indexes.Add(i + 1);
            }
            return indexes;
        }
    }
}
