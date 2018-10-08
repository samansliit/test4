using ScrapingAnalyser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapingAnalyser.Writers
{
    public class ConsoleWriter : IOutputWriter
    {
        public void Write(string message)
        {
            Console.WriteLine("Current indexes are " + message);
        }
    }
}
