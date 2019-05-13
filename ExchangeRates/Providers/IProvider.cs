using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.Providers
{
    public interface IProvider
    {
        (string, List<(string, decimal, int)>) GetRates();
    }
}
