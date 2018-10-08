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
using ScrapingAnalyser.Writers;

namespace ConsoleApp1
{
    class Program
    {

      
        static void Main(string[] args)
        {

            UnityContainer iocContainer = new UnityContainer();
            Configure(iocContainer);

            var reportJob = iocContainer.Resolve<IScrapingReportJob>();
            reportJob.Execute();
            Console.ReadLine();
        }

        private static void Configure(UnityContainer iocContainer)
        {
            iocContainer.RegisterType<IWebReader, WebReader>(new InjectionConstructor("conveyancing software", 100));
            iocContainer.RegisterType<IScrapingDataAnalyzer, ScrapingDataAnalyzer>(new InjectionConstructor("https://www.smokeball.com.au"));
            iocContainer.RegisterType<IOutputWriter, ConsoleWriter>();
            iocContainer.RegisterType<IScrapingReportJob, ScrapingReportJob>();
        }
    }
}
