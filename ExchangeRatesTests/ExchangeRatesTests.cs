using System;
using System.Collections.Generic;
using ExchangeRates.Processors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExchangeRatesTests
{
    [TestClass]
    public class ExchangeRatesTests
    {
        private (string, List<(string, decimal, int)>) currenciesRates;

        public ExchangeRatesTests()
        {
            FillExchangeRates();
        }

        private void FillExchangeRates()
        {
            List<(string, decimal, int)> rates = new List<(string, decimal, int)>();
            rates.Add(("EUR", 743.97M, 100));
            rates.Add(("USD", 663.11M, 100));
            rates.Add(("GBP", 852.85M, 100));
            rates.Add(("SEK", 76.10M, 100));
            rates.Add(("NOK", 78.40M, 100));
            rates.Add(("CHF", 683.58M, 100));
            rates.Add(("JPY", 5.9740M, 100));

            currenciesRates = ("DKK", rates);
        }

        [TestMethod]
        public void GetAmountTest()
        {
            IProcessor exchangeProcessor = new ExchangeProcessor();
            
            exchangeProcessor.SetRates(currenciesRates);

            List<(string currencyFrom, string currencyTo, decimal amountFrom, decimal amountTo)> testData 
                = new List<(string currencyFrom, string currencyTo, decimal amountFrom, decimal amountTo)>();

            testData.Add(("EUR", "USD", 100M, 112.19M));
            testData.Add(("GBP", "NOK", 100M, 1087.82M));
            testData.Add(("CHF", "SEK", 100M, 898.27M));

            foreach ((string currencyFrom, string currencyTo, decimal amountFrom, decimal amountTo) 
                in testData)
            {
                Assert.AreEqual(exchangeProcessor.GetAmount(currencyFrom, currencyTo, amountFrom)
                    , amountTo);
            }
        }
    }
}
