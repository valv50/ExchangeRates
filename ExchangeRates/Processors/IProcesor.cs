using ExchangeRates.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.Processors
{
    public interface IProcessor
    {
        void SetRates((string, List<(string, decimal, int)>) rates);

        decimal? GetAmount(string currencyFrom, string currencyTo, decimal amount);
    }
}
