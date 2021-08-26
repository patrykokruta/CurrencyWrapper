using CurrencyWrapper.Common.ECB;
using CurrencyWrapper.Common.Logger;
using CurrencyWrapper.Common.UnitOfWork;
using CurrencyWrapper.Data;
using CurrencyWrapper.Logic;
using CurrencyWrapper.Logic.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CurrencyWrapper.API.Controllers
{
    [Route("api/[exchangeRates]")]
    [ApiController]
    public class ExchangeRatesController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IUnitOfWork<CurrencyContext> _unitOfWork;
        private readonly IExchangeRatesService _exchangeRatesService;
        private readonly IEcbClient _esbClient;

        public ExchangeRatesController(ILoggerService loggerService,
            IUnitOfWork<CurrencyContext> unitOfWork,
            IExchangeRatesService exchangeRatesService)
        {
            _loggerService = loggerService;
            _unitOfWork = unitOfWork;
            _exchangeRatesService = exchangeRatesService;
        }

        [HttpGet]
        public IActionResult GetExchangeRates([FromBody] GetExchangeRatesRequest request)
        {
            if (!_exchangeRatesService.IsRequestObjectValid(request))
                return NotFound();

            var from = DateTime.Now.AddDays(-20).Date;
            //_repository.GetAll().Where(x => x.Date >= from && x.Date <= DateTime.Now.Date).Select(x => x.Exchanges.Where(y => y.CurrencyKind.;
            return Ok();
        }
    }
}
