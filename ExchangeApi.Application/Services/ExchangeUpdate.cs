using System;
using System.Threading.Tasks;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Domain.Repositories;

namespace ExchangeApi.Application.Services
{
    public class ExchangeUpdate : IExchangeUpdate
    {
        IExchangeWriter ExchangeWrite { get; }

        IExchangeReader ExchangeReader { get; }

        public ExchangeUpdate(IExchangeWriter exchangeWrite, IExchangeReader exchangeReader)
        {
            ExchangeWrite = exchangeWrite;
            ExchangeReader = exchangeReader;
        }

        public async Task<Exchange> Update(Guid exchangeId, ExchangeModel exchangeModel)
        {
            var exchange = await ExchangeReader.Get(exchangeId);

            var exchangeWithNewName = exchange.WithName(exchangeModel.Name);

            return await ExchangeWrite.Update(exchangeWithNewName);
        }
    }
}