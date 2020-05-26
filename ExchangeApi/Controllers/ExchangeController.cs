using System.Threading.Tasks;
using ExchangeApi.Application;
using ExchangeApi.Application.Services;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Controllers
{
    public class ExchangeController : Controller
    {
        public IExchangeCreation ExchangeCreation { get; }

        public ExchangeController(IExchangeCreation exchangeCreation)
        {
            ExchangeCreation = exchangeCreation;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ExchangeModel exchangeModel)
        {
            var exchange = await ExchangeCreation.Create(exchangeModel);

            return Created(string.Empty, exchange);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ExchangeModel exchangeModel)
        {
            var 
        }
    }
}