using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExchangeApi.Domain.Entities;

namespace ExchangeApi.Domain.Repositories 
{
    public interface IExchangeReader
    {
        Task<Exchange> Get(Guid exchangeId);

        Task<IReadOnlyCollection<Exchange>> Get();

        Task<bool> Any(Guid exchangeId);
    }
}