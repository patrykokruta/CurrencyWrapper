using CurrencyWrapper.Common;
using CurrencyWrapper.Common.EcbClient;
using CurrencyWrapper.Common.EcbClient.Models;
using CurrencyWrapper.Common.Logger;
using CurrencyWrapper.Logic;
using CurrencyWrapper.Logic.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new System.Net.Http.HttpClient()
            {
                BaseAddress = new Uri("http://sdw-wsrest.ecb.europa.eu/service/data/")
            };
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/vnd.sdmx.genericdata+xml");

            var t = new ExchangeRatesService(
                null,
                new EcbClient(client, new System.Xml.Serialization.XmlSerializer(typeof(GetExchangeRatesXmlResponse)), new LoggerService()));

            var request = new GetExchangeRatesRequest()
            {
                currencyCodes = new System.Collections.Generic.Dictionary<string, string>(new List<KeyValuePair<string, string>>()
                {
                    KeyValuePair.Create("USD", "EUR"),
                    KeyValuePair.Create("JPY", "EUR"),
                    KeyValuePair.Create("EUR", "JPY")
                }),
                startDate = "2011-06-26",
                endDate = "2011-06-30"
            };

            var results = await t.GetExchangeRates(request);
        }
    }
}
