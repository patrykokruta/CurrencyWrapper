using CurrencyWrapper.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWrapper.Logic
{
    public interface IExchangeRatesService
    {
        bool IsRequestObjectValid(GetExchangeRatesRequest requestObj);
    }
}
