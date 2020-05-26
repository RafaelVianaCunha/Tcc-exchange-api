using System.Threading.Tasks;
using ExchangeApi.Domain.Entities;

namespace ExchangeApi.Application.Services
{
    public interface IExchangeCreation 
    {
        Task<Exchange> Create(ExchangeModel exchangeModel);
    }
}