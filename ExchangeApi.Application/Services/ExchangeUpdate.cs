using System;
using System.Threading.Tasks;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Domain.Repositories;

namespace ExchangeApi.Application.Services
{
    public class ExchangeUpdate : IExchangeUpdate
    {
        IExchangeWriter ExchangeWrite { get; }

        public ExchangeUpdate(IExchangeWriter exchangeWrite)
        {
            ExchangeWrite = exchangeWrite;
        }

        public async Task<Exchange> Update(Exchange exchange, ExchangeModel exchangeModel)
        {
            exchange.UserId = exchangeModel.UserId;
            exchange.ApiSecret = exchangeModel.ApiSecret;
            exchange.ApiSecret = exchangeModel.ApiSecret;

            return await ExchangeWrite.Update(exchange);
        }
    }
}