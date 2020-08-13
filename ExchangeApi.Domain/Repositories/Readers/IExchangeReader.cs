using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExchangeApi.Domain.Entities;

namespace ExchangeApi.Domain.Repositories 
{
    public interface IExchangeReader
    {
        Task<ExchangeCredential> Get(Guid exchangeId);

        Task<IReadOnlyCollection<ExchangeCredential>> Get();

        Task<bool> Any(Guid exchangeId);
    }
}