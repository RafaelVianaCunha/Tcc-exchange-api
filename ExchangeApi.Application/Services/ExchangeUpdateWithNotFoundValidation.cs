using System;
using System.Threading.Tasks;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Domain.Repositories;

namespace ExchangeApi.Application.Services
{
    public class ExchangeUpdateWithNotFoundValidation : IExchangeUpdate
    {   
        public IExchangeUpdate ExchangeUpdate { get; }

        public IExchangeReader ExchangeReader { get; }

        public ExchangeUpdateWithNotFoundValidation(IExchangeUpdate exchangeUpdate, IExchangeReader exchangeReader)
        {
            ExchangeUpdate = exchangeUpdate;
            ExchangeReader = exchangeReader;
        }

        public async Task<Exchange> Update(Guid exchangeId, ExchangeModel exchangeModel)
        {
            var exchangeExist = await ExchangeReader.Any(exchangeId); 

            if (exchangeExist == false)
            {
                throw new Exception();
            }

            return await ExchangeUpdate.Update(exchangeId, exchangeModel);
        }
    }
}