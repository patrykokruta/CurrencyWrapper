using CurrencyWrapper.Common.EcbClient.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyWrapper.Common.ECB
{
    public interface IEcbClient
    {
        Task<GetExchangeRatesResponse> GetExchangeRates(string sourceCurrency, string targetCurrency,
            DateTime stardPeriod, DateTime endPeriod);
    }
}
