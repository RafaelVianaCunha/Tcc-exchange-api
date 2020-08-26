using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using ExchangeApi.Domain.Repositories;
using ExchangeApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ExchangeApi.Infrastructure
{
    public class ExchangeCredentialReader : IExchangeCredentialReader
    {
        public ExchangeDbContext ExchangeDbContext { get; }

        public ExchangeCredentialReader(ExchangeDbContext exchangeDbContext)
        {
            ExchangeDbContext = exchangeDbContext;
        }

        public Task<bool> Any(Guid exchangeId)
        {
            return ExchangeDbContext.ExchangeCredential.AnyAsync(x => x.Id == exchangeId && x.DeletedAt == null);
        }

        public Task<ExchangeCredential> Get(Guid exchangeId)
        {
            return ExchangeDbContext.ExchangeCredential.SingleOrDefaultAsync(x => x.Id == exchangeId && x.DeletedAt == null);
        }

        public async Task<IReadOnlyCollection<ExchangeCredential>> Get()
        {
           return await ExchangeDbContext.ExchangeCredential.Where(x => x.DeletedAt == null).ToListAsync();
        }

        public Task<ExchangeCredential> GetByUserID(Guid userID)
        {
            return ExchangeDbContext.ExchangeCredential.SingleOrDefaultAsync(x => x.UserId == userID && x.DeletedAt == null);
        }
    }
}