using CurrencyWrapper.Common.ECB;
using CurrencyWrapper.Common.EcbClient.Models;
using CurrencyWrapper.Common.UnitOfWork;
using CurrencyWrapper.Data;
using CurrencyWrapper.Logic.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyWrapper.Logic
{
    public class ExchangeRatesService
    {
        private readonly IUnitOfWork<CurrencyContext> _unitOfWork;
        private readonly IEcbClient _ecbClient;

        public ExchangeRatesService(IUnitOfWork<CurrencyContext> unitOfWork, IEcbClient ecbClient)
        {
            _unitOfWork = unitOfWork;
            _ecbClient = ecbClient;
        }

        public bool IsRequestObjectValid(GetExchangeRatesRequest request)
        {
            return IsCurrencyCodeSetValid(request.currencyCodes) &&
                   IsDateValid(request.startDate) &&
                   IsDateValid(request.endDate);
        }

        public async Task<List<GetExchangeRatesResult>> GetExchangeRates(GetExchangeRatesRequest request)
        {
            var exchangeRates = new List<GetExchangeRatesResult>();
            foreach (var pair in request.currencyCodes.GroupBy(x => x.Value))
            {
                string sourceCurrency = string.Join("+", pair.Select(x => x.Key));
                string targetCurrency = pair.Key;
                DateTime startDate = Convert.ToDateTime(request.startDate);
                DateTime endDate = Convert.ToDateTime(request.endDate);

                //checkInCache

                var response = await _ecbClient.GetExchangeRates(sourceCurrency, targetCurrency, startDate, endDate);
                exchangeRates.AddRange(response.GetResults());
            }
            return exchangeRates;
        }

        private bool IsDateValid(string date)
        {
            bool parsedSuccessfully = DateTime.TryParse(date, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate);
            bool isFutureDate = parsedDate.Date > DateTime.Now.Date;
            return parsedSuccessfully && !isFutureDate;
        }
        private bool IsCurrencyCodeSetValid(Dictionary<string, string> currencyCodes)
        {
            foreach (var pair in currencyCodes)
            {
                if (string.IsNullOrEmpty(pair.Key) || string.IsNullOrEmpty(pair.Value))
                    return false;
                if (pair.Key.Length != 3 || pair.Value.Length != 3)
                    return false;
            }
            return true;
        }

    }
}
