using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWrapper.Common.EcbClient.Models
{
    public class GetExchangeRatesResult
    {
        public DateTime Date { get; set; }
        public string SourceCurrency { get; set; }
        public string TargetCurrency { get; set; }
        public double Rate { get; set; }
    }
}
