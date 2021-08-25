using CurrencyWrapper.Common.Logger;
using CurrencyWrapper.Common.UnitOfWork;
using CurrencyWrapper.Common.UnitOfWork.Repository;
using CurrencyWrapper.Data;
using CurrencyWrapper.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyWrapper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRatesController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IUnitOfWork<CurrencyContext> _unitOfWork;

        public ExchangeRatesController(ILoggerService loggerService, IUnitOfWork<CurrencyContext> unitOfWork)
        {
            _loggerService = loggerService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetExchangeRates([FromQuery] string query)
        {
            var from = DateTime.Now.AddDays(-20).Date;
            //_repository.GetAll().Where(x => x.Date >= from && x.Date <= DateTime.Now.Date).Select(x => x.Exchanges.Where(y => y.CurrencyKind.;
            return Ok();
        }
    }
}
