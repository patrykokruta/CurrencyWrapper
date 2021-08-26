using CurrencyWrapper.Common.ECB;
using CurrencyWrapper.Common.EcbClient.Models;
using CurrencyWrapper.Common.Logger;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CurrencyWrapper.Common.EcbClient
{
    public class EcbClient : IEcbClient
    {
        private readonly HttpClient _httpClient;
        private readonly XmlSerializer _serializer;
        private readonly ILoggerService _loggerService;
        private const string _schema = "yyyy-MM-dd";

        public EcbClient(HttpClient httpClient, XmlSerializer serializer, ILoggerService loggerService)
        {
            _httpClient = httpClient;
            _serializer = serializer;
            _loggerService = loggerService;
        }

        public async Task<GetExchangeRatesResponse> GetExchangeRates(string sourceCurrency, string targetCurrency,
            DateTime stardPeriod, DateTime endPeriod)
        {
            string uri = $"EXR/D.{sourceCurrency}.{targetCurrency}.SP00.A" +
                $"?startPeriod={stardPeriod.ToString(_schema)}&endPeriod={endPeriod.ToString(_schema)}&detail=dataonly";
            try
            {
                using (var result = await _httpClient.GetAsync(uri))
                {
                    result.EnsureSuccessStatusCode();

                    using (var responseStream = await result.Content.ReadAsStreamAsync())
                    {
                        using (var streamReader = new StreamReader(responseStream))
                        using (var xmlTextReader = new XmlTextReader(streamReader))
                        {
                            var deserialized = _serializer.Deserialize(xmlTextReader) as GetExchangeRatesXmlResponse;
                            return new GetExchangeRatesResponse(deserialized);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _loggerService.Log($"[{nameof(EcbClient)}] {ex.Message}", LogLevel.Error);
                return new GetExchangeRatesResponse(null);
            }

        }
    }
}
