using System;
using System.Threading.Tasks;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Domain.Repositories;

namespace ExchangeApi.Application.Services 
{
    public class ExchangeCreationWithAlreadyExists : IExchangeCredentialCreation
    {
        public IExchangeCredentialReader ExchangeReader { get; }

        public IExchangeCredentialCreation ExchangeCredentialCreation { get; }

        public ExchangeCreationWithAlreadyExists(IExchangeCredentialCreation exchangeCredentialCreation, IExchangeCredentialReader exchangeReader)
        {
            ExchangeCredentialCreation = exchangeCredentialCreation;
            ExchangeReader = exchangeReader;
        }

        public async Task<ExchangeCredential> Create(ExchangeModel exchangeModel)
        {
            return await ExchangeCredentialCreation.Create(exchangeModel);
        }
    }
}