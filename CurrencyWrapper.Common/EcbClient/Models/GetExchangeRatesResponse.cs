using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace CurrencyWrapper.Common.EcbClient.Models
{
    public class GetExchangeRatesResponse
    {
        private readonly GetExchangeRatesXmlResponse _getExchangeRatesXmlResponse;
        private const string CURRENCY = "CURRENCY";
        private const string CURRENCY_DENOM = "CURRENCY_DENOM";

        public GetExchangeRatesResponse(GetExchangeRatesXmlResponse getExchangeRatesXmlResponse)
        {
            _getExchangeRatesXmlResponse = getExchangeRatesXmlResponse;
        }
        public List<GetExchangeRatesResult> GetResults()
        {
            var series = _getExchangeRatesXmlResponse?.DataSet?.Series?.ToList() ?? new List<Series>();
            var results = new List<GetExchangeRatesResult>();
            series.ForEach(x =>
            {
                var sourceCurrency = x.SeriesKey.Value.FirstOrDefault(y => y.Id == CURRENCY).Value;
                var targetCurrency = x.SeriesKey.Value.FirstOrDefault(y => y.Id == CURRENCY_DENOM).Value;
                x.Obs.ForEach(y =>
                {
                    results.Add(new GetExchangeRatesResult
                    {
                        SourceCurrency = sourceCurrency,
                        TargetCurrency = targetCurrency,
                        Date = Convert.ToDateTime(y.ObsDimension.Value, CultureInfo.InvariantCulture),
                        Rate = Convert.ToDouble(y.ObsValue.Value, CultureInfo.InvariantCulture)
                    });
                });
            });
            return results;
        }
    }
}
