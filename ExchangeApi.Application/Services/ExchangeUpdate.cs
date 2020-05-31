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
            var exchangeWithNewName = exchange.WithName(exchangeModel.Name);

            return await ExchangeWrite.Update(exchangeWithNewName);
        }
    }
}