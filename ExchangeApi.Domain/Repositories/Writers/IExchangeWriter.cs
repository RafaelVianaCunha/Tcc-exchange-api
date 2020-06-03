using System.Threading.Tasks;
using ExchangeApi.Domain.Entities;

namespace ExchangeApi.Domain.Repositories
{
    public interface IExchangeWriter
    {
        Task<Exchange> Create(Exchange exchange);

        Task<Exchange> Update(Exchange exchange);

        Task<Exchange> Delete(Exchange exchange);
    }
}