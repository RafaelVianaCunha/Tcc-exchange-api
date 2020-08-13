using System.Threading.Tasks;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExchangeApi.Infrastructure.Repositories.Writers
{
    public class ExchangeWriter : IExchangeWriter
    {
        public ExchangeWriter(ExchangeDbContext exchangeDbContext) 
        {
            this.ExchangeDbContext = exchangeDbContext;
               
        }
        public ExchangeDbContext ExchangeDbContext { get; }
        
        public async Task<ExchangeCredential> Create(ExchangeCredential exchange)
        {
            await ExchangeDbContext.Exchanges.AddAsync(exchange);
            await ExchangeDbContext.SaveChangesAsync();

            return exchange;
        }

        public async Task<ExchangeCredential> Update(ExchangeCredential exchange)
        {
            ExchangeDbContext.Exchanges.Attach(exchange);
            ExchangeDbContext.Entry(exchange).State = EntityState.Modified;

            await ExchangeDbContext.SaveChangesAsync();

            return exchange;
        }

        
        public async Task<ExchangeCredential> Delete(ExchangeCredential exchange)
        {
            return await Update(exchange.Delete());
        }
    }
}