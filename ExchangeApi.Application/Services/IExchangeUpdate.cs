using System;
using System.Threading.Tasks;
using ExchangeApi.Domain.Entities;

namespace ExchangeApi.Application.Services
{
    public interface IExchangeUpdate
    {
        Task<Exchange> Update(Guid exchangeId, ExchangeModel exchangeModel);
    }
}