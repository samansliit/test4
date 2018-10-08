using ScrapingAnalyser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapingAnalyser
{
    public class ScrapingReportJob : IScrapingReportJob
    {
        private readonly IScrapingDataAnalyzer _dataAnalyzer;
        private readonly IWebReader _webReader;

        public ScrapingReportJob(IScrapingDataAnalyzer dataAnalyzer,IWebReader webReader)
        {
            if(webReader == null)
            {
                throw new ArgumentNullException(nameof(webReader));
            }
            if(dataAnalyzer == null)
            {
                throw new ArgumentNullException(nameof(dataAnalyzer));
            }
            _webReader = webReader;
            _dataAnalyzer = dataAnalyzer;
            //_webReader = webReader ?? throw new ArgumentNullException(nameof(webReader));
            //_dataAnalyzer = dataAnalyzer ?? throw new ArgumentNullException(nameof(dataAnalyzer));
        }

        public void Execute()
        {
            var htmlStr = _webReader.Read();
            var results = _dataAnalyzer.AnalyseWebContent(htmlStr);
        }
    }
}
