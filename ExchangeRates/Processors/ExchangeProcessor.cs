using ExchangeRates.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.Processors
{
    public class ExchangeProcessor : IProcessor
    {
        private (string mainCurrencyCode, List<(string currencyCode, decimal rate, int amount)> currencyRates) rates;

        public int RoundDigits { get; set; } = 2;

        public void SetRates((string, List<(string, decimal, int)>) rates)
        {
            this.rates = rates;
        }
        
        public decimal? GetAmount(string currencyFrom, string currencyTo, decimal amount)
        {            
            decimal? currencyAmount = null;
            currencyAmount = amount * CalculateRate(currencyFrom, currencyTo);

            currencyAmount = currencyAmount == null 
                ? currencyAmount
                : Math.Round((decimal)currencyAmount, RoundDigits);

            return currencyAmount;
        }

        private decimal? CalculateRate(string currencyFrom, string currencyTo)
        {
            decimal? rate = null;

            List<(string currencyCode, decimal rate, int amount)> currencyRates
                = GetAllRates();

            GetRate(currencyFrom, out decimal? rateFrom, out int? amountFrom);
            GetRate(currencyTo, out decimal? rateTo, out int? amountTo);

            if (rateFrom.GetValueOrDefault() != 0
                && rateTo.GetValueOrDefault() != 0
                && amountFrom.GetValueOrDefault() != 0
                && amountTo.GetValueOrDefault() != 0)
            {
                rate = (rateFrom * amountFrom) / (rateTo * amountTo);
            }

            return rate;
        }

        private void GetRate(string currencyCode, out decimal? rate, out int? amount)
        {
            rate = null;
            amount = null;

            List<(string currencyCode, decimal rate, int amount)> currencyRates = GetAllRates();

            (rate, amount) =
                currencyRates
                .Where(w => w.currencyCode == currencyCode)
                .Select(s => (s.rate, s.amount))
                .FirstOrDefault();
        }

        private List<(string currencyCode, decimal rate, int amount)> 
            GetAllRates()
        {
            string mainCurrencyCode;

            List<(string currencyCode, decimal rate, int amount)> currencyRates
                = new List<(string currencyCode, decimal rate, int amount)>();

            mainCurrencyCode = rates.mainCurrencyCode;

            currencyRates = rates.currencyRates;
            currencyRates.Add((mainCurrencyCode, 1, 1));

            return currencyRates;
        }
    }
}
