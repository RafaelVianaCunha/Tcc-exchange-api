using System;
using System.Threading.Tasks;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Domain.Repositories;

namespace ExchangeApi.Application.Services 
{
    public class ExchangeCreationWithAlreadyExists 
    {
        public IExchangeReader ExchangeReader { get; }

        public IExchangeCreation ExchangeCreation { get; }

        public ExchangeCreationWithAlreadyExists(IExchangeReader exchangeReader)
        {
            ExchangeReader = exchangeReader;
        }

        public async Task<Exchange> Create(ExchangeModel exchangeModel)
        {
            var exchange = ExchangeReader.Get(exchangeModel.Name);

            if (exchange != null)
                throw new Exception();

            return await ExchangeCreation.Create(exchangeModel);
        }
    }
}