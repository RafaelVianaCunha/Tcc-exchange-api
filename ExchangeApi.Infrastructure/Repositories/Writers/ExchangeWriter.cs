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
        
        public async Task<Exchange> Create(Exchange exchange)
        {
            await ExchangeDbContext.Exchanges.AddAsync(exchange);
            await ExchangeDbContext.SaveChangesAsync();

            return exchange;
        }

        public async Task<Exchange> Update(Exchange exchange)
        {
            ExchangeDbContext.Exchanges.Attach(exchange);
            ExchangeDbContext.Entry(exchange).State = EntityState.Modified;

            await ExchangeDbContext.SaveChangesAsync();

            return exchange;
        }

        
        public async Task<Exchange> Delete(Exchange exchange)
        {
            return await Update(exchange.Delete());
        }
    }
}