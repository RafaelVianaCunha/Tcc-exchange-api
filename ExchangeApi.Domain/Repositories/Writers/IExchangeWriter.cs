using System.Threading.Tasks;
using ExchangeApi.Domain.Entities;

namespace ExchangeApi.Domain.Repositories
{
    public interface IExchangeWriter
    {
        Task<ExchangeCredential> Create(ExchangeCredential exchange);

        Task<ExchangeCredential> Update(ExchangeCredential exchange);

        Task<ExchangeCredential> Delete(ExchangeCredential exchange);
    }
}