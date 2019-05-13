using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExchangeRates.Providers;

namespace ExchangeRatesTests
{
    /// <summary>
    /// Summary description for ExchangeRateProviderTests
    /// </summary>
    [TestClass]
    public class ExchangeRateProviderTests
    {
        [TestMethod]
        public void TestGetData()
        {
            IProvider exchangeRateProvider = 
                new ExchangeRateProvider();

            try
            {
                (string, List<(string, decimal, int)>) rates
                    = exchangeRateProvider.GetRates();

                Assert.IsNotNull(rates);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
