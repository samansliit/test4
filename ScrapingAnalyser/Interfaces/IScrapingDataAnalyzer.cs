﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapingAnalyser.Interfaces
{
    public interface IScrapingDataAnalyzer
    {
        List<int> AnalyseWebContent(string htmlContent);
    }
}
