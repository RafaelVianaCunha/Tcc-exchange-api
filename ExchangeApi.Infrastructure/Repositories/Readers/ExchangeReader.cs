using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using ExchangeApi.Domain.Repositories;
using ExchangeApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ExchangeApi.Infrastructure
{
    public class ExchangeReader : IExchangeReader
    {
        public ExchangeDbContext ExchangeDbContext { get; }

        public ExchangeReader(ExchangeDbContext exchangeDbContext)
        {
            ExchangeDbContext = exchangeDbContext;
        }

        public Task<bool> Any(Guid exchangeId)
        {
            return ExchangeDbContext.Exchanges.AnyAsync(x => x.Id == exchangeId);
        }

        public Task<Exchange> Get(Guid exchangeId)
        {
            return ExchangeDbContext.Exchanges.SingleOrDefaultAsync(x => x.Id == exchangeId);
        }

        public Task<Exchange> Get(string exchangeName)
        {
            return ExchangeDbContext.Exchanges.SingleOrDefaultAsync(x => x.Name == exchangeName);
        }

        public async Task<IReadOnlyCollection<Exchange>> Get()
        {
           return await ExchangeDbContext.Exchanges.Where(x => x.DeletedAt != null).ToListAsync();
        }
    }
}