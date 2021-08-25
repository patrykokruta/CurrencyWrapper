using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWrapper.Data.Entities
{
    public class Currency
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public ICollection<CurrencyExchange> Exchanges { get; set; }
    }
}
