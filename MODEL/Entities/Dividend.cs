using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Dividend
    {
        public string CompanyName { get; set; }
        public string Name { get; set; }
        public string Segment { get; set; }
        public string CNPJ { get; set; }
        public decimal AverageDailytrading { get; set; }
        public decimal LastYield { get; set; }
        public decimal DividendYield { get; set; }
        public decimal RentabilityPerMonth { get; set; }

        public Dividend(string companyName, string name, string segment, string cnpj, double averageDailytrading, double lastYield, double dividendYield, double rentabilityPerMonth)
        {
            CompanyName =
            Name =
            Segment =
            CNPJ = string.Empty;
            AverageDailytrading =
            LastYield =
            DividendYield =
            RentabilityPerMonth = 0m;
        }
    }
 
}
