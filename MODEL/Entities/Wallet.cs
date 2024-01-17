using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Model.Entities
{
    public class Wallet
    {
        public List<Dividend> Dividends { get; set; }

        public Wallet()
        {

        }

        public void addDividend(Dividend dividend) => Dividends.Add(dividend);
        
        public void removeDividend(Dividend dividend) => Dividends.Remove(dividend); 
    }
}
