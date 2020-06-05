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

        public IExchangeDelete ExchangeDelete { get; }

        public ExchangeController(IExchangeCreation exchangeCreation, IExchangeReader exchangeReader, IExchangeUpdate exchangeUpdate, IExchangeDelete exchangeDelete)
        {
            ExchangeCreation = exchangeCreation;
            ExchangeReader = exchangeReader;
            ExchangeUpdate = exchangeUpdate;
            ExchangeDelete = exchangeDelete;
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

        [HttpDelete]
        [Route("{exchangeId}")]
        public async Task<IActionResult> Delete(Guid exchangeId)
        {
            var exchange = await ExchangeReader.Get(exchangeId);

            if (exchange == null) 
            {
                return NotFound();
            }

            var exchangeDelete = await ExchangeDelete.Delete(exchange);

            return Ok(exchange);
        }


        [HttpGet]
        [Route("{exchangeId}")]
        public async Task<IActionResult> Get(Guid exchangeId)
        {
            var exchange = await ExchangeReader.Get(exchangeId);

            if (exchange == null) 
            {
                return NotFound();
            }
            return Ok(exchange);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var exchange = await ExchangeReader.Get();
            return Ok(exchange);
        }
    }
}