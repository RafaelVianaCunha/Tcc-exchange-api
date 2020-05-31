using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using ExchangeApi.Domain.Repositories;
using ExchangeApi.Domain.Entities;

namespace ExchangeApi.Infrastructure
{
    public class ExchangeReader : IExchangeReader
    {
        public ExchangeDbContext ExchangeDbContext { get; }

        public Task<bool> Any(Guid exchangeId)
        {
            throw new NotImplementedException();
        }

        public Task<Exchange> Get(Guid exchangeId)
        {
            throw new NotImplementedException();
        }

        public Task<Exchange> Get(string exchangeName)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<Exchange>> Get()
        {
            throw new NotImplementedException();
        }
    }
}