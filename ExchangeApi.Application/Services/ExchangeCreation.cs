using System.Threading.Tasks;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Domain.Repositories;

namespace ExchangeApi.Application.Services 
{
    public class ExchangeCreation : IExchangeCreation
    {
        public IExchangeWriter ExchangeWriter { get; }

        public ExchangeCreation(IExchangeWriter exchangeWriter)
        {
            ExchangeWriter = exchangeWriter;
        }

        public Task<Exchange> Create(ExchangeModel exchangeModel)
        {
            var exchange = new Exchange(exchangeModel.UserId, exchangeModel.ApiKey, exchangeModel.ApiSecret, exchangeModel.Name);

            return ExchangeWriter.Create(exchange);
        }
    }
}