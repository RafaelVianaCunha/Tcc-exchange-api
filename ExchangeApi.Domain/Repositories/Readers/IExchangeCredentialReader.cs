using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExchangeApi.Domain.Entities;

namespace ExchangeApi.Domain.Repositories 
{
    public interface IExchangeCredentialReader
    {
        Task<ExchangeCredential> Get(Guid exchangeId);

        Task<ExchangeCredential> GetByUserID(Guid userID);

        Task<IReadOnlyCollection<ExchangeCredential>> Get();

        Task<bool> Any(Guid exchangeId);
    }
}