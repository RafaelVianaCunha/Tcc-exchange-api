using System;
using System.Threading.Tasks;
using ExchangeApi.Application;
using ExchangeApi.Application.Services;
using ExchangeApi.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Controllers
{
    [Route("/api/exchanges/")]
    public class ExchangeController : Controller
    {
        public IExchangeCredentialCreation ExchangeCredentialCreation { get; }

        public IExchangeCredentialReader ExchangeCredentialReader { get; }

        public IExchangeDelete ExchangeDelete { get; }

        public ExchangeController(IExchangeCredentialCreation exchangeCredentialCreation, IExchangeCredentialReader exchangeCredentialReader, IExchangeDelete exchangeDelete)
        {
            ExchangeCredentialCreation = exchangeCredentialCreation;
            ExchangeCredentialReader = exchangeCredentialReader;
            ExchangeDelete = exchangeDelete;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create([FromBody] ExchangeModel exchangeModel)
        {
            var exchange = await ExchangeCredentialCreation.Create(exchangeModel);

            return Created(string.Empty, exchange);
        }

        [HttpDelete]
        [Route("{exchangeId}")]
        public async Task<IActionResult> Delete(Guid exchangeId)
        {
            var exchangeCredential = await ExchangeCredentialReader.Get(exchangeId);

            if (exchangeCredential == null) 
            {
                return NotFound();
            }

            var exchangeDelete = await ExchangeDelete.Delete(exchangeCredential);

            return Ok(exchangeCredential);
        }


        [HttpGet]
        [Route("{exchangeId}")]
        public async Task<IActionResult> Get(Guid exchangeId)
        {
            var exchangeCredential = await ExchangeCredentialReader.Get(exchangeId);

            if (exchangeCredential == null) 
            {
                return NotFound();
            }
            return Ok(exchangeCredential);
        }

        [HttpGet]
        [Route("users/{userId}/credentials")]
        public async Task<IActionResult> GetByUserId(Guid userId)
        {
            var exchangeCredential = await ExchangeCredentialReader.GetByUserID(userId);

            if (exchangeCredential == null) 
            {
                return NotFound();
            }
            return Ok(exchangeCredential);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var exchange = await ExchangeCredentialReader.Get();
            return Ok(exchange);
        }
    }
}