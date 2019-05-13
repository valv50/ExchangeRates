using ExchangeRates.Processors;
using ExchangeRates.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.ConsoleProcessor
{
    public class ConsoleProcessor
    {
        public static string ProcessLine(string line)
        {
            string returnValue = null;
            LineValue(line,
                out string currencyFrom, out string currencyTo, out decimal? amount);

            if (currencyFrom != null && currencyTo != null && amount != null)
            {
                IProvider exchangeRatesProvider = new ExchangeRateProvider();
                IProcessor exchangeProcessor = new ExchangeProcessor();

                exchangeProcessor.SetRates(exchangeRatesProvider.GetRates());
                returnValue = exchangeProcessor.GetAmount(currencyFrom, currencyTo, amount ?? 0M)?.ToString();
            }

            if (returnValue == null)
            {
                returnValue = "Usage: Exchange <currency pair> <amount to exchange>";
            }

            return returnValue;
        }

        private static void LineValue(string line, 
            out string currencyFrom, out string currencyTo, out decimal? amount)
        {
            currencyFrom = currencyTo = null;
            amount = null;

            string[] lineValues = line.Split(new string[] { "/", " " }, 0);

            if (lineValues.Length >= 3)
            {
                currencyFrom = lineValues[0];
                currencyTo = lineValues[1];
                amount = Convert.ToDecimal(lineValues[2]);
            }
        }
    }
}
