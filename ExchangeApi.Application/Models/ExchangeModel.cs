using System;

namespace ExchangeApi.Application 
{
    public class ExchangeModel
    {   
        public Guid UserId { get; set; }
        public string ApiKey { get; set; }  
        public string ApiSecret { get; set; }
        public string Name { get; set; }

    }
}