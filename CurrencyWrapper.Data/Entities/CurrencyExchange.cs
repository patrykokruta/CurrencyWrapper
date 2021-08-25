using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWrapper.Data.Entities
{
    public class CurrencyExchange
    {
        public int Id { get; set; }
        public virtual Currency SourceCurrency { get; set; }
        public virtual Currency TargetCurrency { get; set; }
        public decimal Rate { get; set; }
        public DateTime? Date { get; set; }
    }
}
