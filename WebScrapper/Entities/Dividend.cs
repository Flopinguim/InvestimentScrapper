using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrapper.Entities
{
    public class Dividend
    {
        public string CompanyName { get; set; }
        public string Name { get; set; }
        public string Segment { get; set; }
        public string CNPJ { get; set; }
        public double AverageDailytrading { get; set; }
        public double LastYield { get; set; }
        public double DividendYield { get; set; }
        public double RentabilityPerMonth { get; set; }

        public Dividend(string companyName, string name, string segment, string cnpj, double averageDailytrading, double lastYield, double dividendYield, double rentabilityPerMonth)
        {
            CompanyName =
            Name =
            Segment =
            CNPJ = string.Empty;
            AverageDailytrading =
            LastYield =
            DividendYield =
            RentabilityPerMonth = 0d;
        }
    }
 
}
