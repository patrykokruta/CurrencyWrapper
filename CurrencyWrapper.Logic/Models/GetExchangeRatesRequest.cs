using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyWrapper.Logic.Models
{
    public class GetExchangeRatesRequest
    {
        public Dictionary<string, string> currencyCodes { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }
}
