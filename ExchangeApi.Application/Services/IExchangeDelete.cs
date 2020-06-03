using System;
using System.Threading.Tasks;
using ExchangeApi.Domain.Entities;

namespace ExchangeApi.Application.Services
{
    public interface IExchangeDelete
    {
        Task<Exchange> Delete(Exchange exchange);
    }
}