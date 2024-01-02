using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrapper.Entities
{
    public class Wallet
    {
        public List<Dividend> dividends { get; set; }

        public Wallet()
        {

        }

        public void addDividend(Dividend dividend) => dividends.Add(dividend);
        
        public void removeDividend(Dividend dividend) => dividends.Remove(dividend); 
    }
}
