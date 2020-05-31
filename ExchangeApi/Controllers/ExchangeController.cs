using System;
using System.Threading.Tasks;
using ExchangeApi.Application;
using ExchangeApi.Application.Services;
using ExchangeApi.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Controllers
{
    [Route("/api/exchanges")]
    public class ExchangeController : Controller
    {
        public IExchangeCreation ExchangeCreation { get; }

        public IExchangeReader ExchangeReader { get; }

        public IExchangeUpdate ExchangeUpdate { get; }

        public ExchangeController(IExchangeCreation exchangeCreation, IExchangeReader exchangeReader, IExchangeUpdate exchangeUpdate)
        {
            ExchangeCreation = exchangeCreation;
            ExchangeReader = exchangeReader;
            ExchangeUpdate = exchangeUpdate;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create([FromBody] ExchangeModel exchangeModel)
        {
            var exchange = await ExchangeCreation.Create(exchangeModel);

            return Created(string.Empty, exchange);
        }

        [HttpPut]
        [Route("{exchangeId}")]
        public async Task<IActionResult> Update(Guid exchangeId, [FromBody] ExchangeModel exchangeModel)
        {
            var exchange = await ExchangeReader.Get(exchangeId);

            if (exchange == null) 
            {
                return NotFound();
            }

            var exchangeUpdated = await ExchangeUpdate.Update(exchange, exchangeModel);

            return Ok(exchange);
        }
    }
}