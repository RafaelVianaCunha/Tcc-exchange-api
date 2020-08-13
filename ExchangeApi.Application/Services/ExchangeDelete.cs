using System;
using System.Threading.Tasks;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Domain.Repositories;

namespace ExchangeApi.Application.Services
{
    public class ExchangeDelete : IExchangeDelete
    {
        IExchangeWriter ExchangeWrite { get; }

        public ExchangeDelete(IExchangeWriter exchangeWrite)
        {
            ExchangeWrite = exchangeWrite;
        }

        public async Task<ExchangeCredential> Delete(ExchangeCredential exchange)
        {
            return await ExchangeWrite.Delete(exchange);
        }
    }
}