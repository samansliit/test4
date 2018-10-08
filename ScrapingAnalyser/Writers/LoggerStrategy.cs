using ScrapingAnalyser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapingAnalyser.Writers
{
    public class LoggerStrategy
    {
        IOutputWriter writer;
        public LoggerStrategy(IOutputWriter writer)
        {
            this.writer = writer;
            //
        }

        public void Log(string message)
        {
            writer.Write(message);
        }
    }
}
