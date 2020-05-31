using System;

namespace ExchangeApi.Domain.ValueObjects
{
    public class ExchangeCredential
    {
        public Guid ExchangeId { get; private set; }

        public Guid UserId { get; private set; }

        public string ApiKey { get; private set; }

        public int MyProperty { get; set; }
    }
}