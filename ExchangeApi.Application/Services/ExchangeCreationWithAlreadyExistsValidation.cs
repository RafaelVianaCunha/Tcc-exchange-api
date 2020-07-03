using System;
using System.Threading.Tasks;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Domain.Repositories;

namespace ExchangeApi.Application.Services 
{
    public class ExchangeCreationWithAlreadyExists : IExchangeCreation
    {
        public IExchangeReader ExchangeReader { get; }

        public IExchangeCreation ExchangeCreation { get; }

        public ExchangeCreationWithAlreadyExists(IExchangeCreation exchangeCreation, IExchangeReader exchangeReader)
        {
            ExchangeCreation = exchangeCreation;
            ExchangeReader = exchangeReader;
        }

        public async Task<Exchange> Create(ExchangeModel exchangeModel)
        {
            return await ExchangeCreation.Create(exchangeModel);
        }
    }
}