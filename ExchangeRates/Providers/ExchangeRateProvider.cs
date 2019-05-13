using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.Providers
{
    public class ExchangeRateProvider : IProvider
    {
        public (string, List<(string, decimal, int)>) GetRates()
        {
            List<(string, decimal, int)> rates = new List<(string, decimal, int)>();
            rates.Add(("EUR", 743.97M, 100));
            rates.Add(("USD", 663.11M, 100));
            rates.Add(("GBP", 852.85M, 100));
            rates.Add(("SEK", 76.10M, 100));
            rates.Add(("NOK", 78.40M, 100));
            rates.Add(("CHF", 683.58M, 100));
            rates.Add(("JPY", 5.9740M, 100));
            return ("DKK", rates);
        }
    }
}
