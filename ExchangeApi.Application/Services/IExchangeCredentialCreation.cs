using System.Threading.Tasks;
using ExchangeApi.Domain.Entities;

namespace ExchangeApi.Application.Services
{
    public interface IExchangeCredentialCreation 
    {
        Task<ExchangeCredential> Create(ExchangeModel exchangeModel);
    }
}