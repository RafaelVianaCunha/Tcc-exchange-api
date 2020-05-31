using ExchangeApi.Domain.Repositories;
using ExchangeApi.Domain.Entities;

namespace Exchange.Infrastructure 
{
    public class ExchangeReader : IExchangeReader
    {
        public ExchangeDbContext DbContext { get; }
        
        public ExchangeReader(ExchangeDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public Task<Exchange> Get(Guid exchangeId)
        {
            return DbContext.Exchanges.FirstOrDefault();
        }

        public Task<Exchange> Get(string exchangeName)
        {
          return DbContext.Exchanges.FirstOrDefault(x -> x.exchangeName = exchangeName);

        }

        public Task<IReadOnlyCollection<Exchange>> Get()
        {

        }

        public Task<bool> Any(Guid exchangeId) 
        {

        }
        
    }
}