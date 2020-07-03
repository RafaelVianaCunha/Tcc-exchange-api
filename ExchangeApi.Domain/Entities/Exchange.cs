using System;

namespace ExchangeApi.Domain.Entities 
{
    public class Exchange
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; set ; }
        public String ApiKey { get; set; }  
        public String ApiSecret { get; set; }
        public String Name { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }

        public Exchange(Guid userId , String apiKey, String apiSecret, String name)
        {
            Id = Guid.NewGuid();
            UserId = Guid.NewGuid();
            ApiKey = apiKey;
            ApiSecret = apiSecret;
            Name = name;
            CreatedAt = DateTime.UtcNow;
        }
        private Exchange(
            Guid id,
            Guid userId, 
            String apiKey,  
            String apiSecret,
            String name,
            DateTime createdAt)
        {
            Id = id;
            UserId = userId;
            ApiKey = apiKey;
            ApiSecret = apiSecret;
            CreatedAt = createdAt;
            Name = name;
        }

        private Exchange(
            Guid id, 
            DateTime createdAt, 
            DateTime deletedAt)
        {
            Id = id;
            CreatedAt = createdAt;
            DeletedAt = deletedAt;
        }

        public Exchange Delete()
        {
            DeletedAt = DateTime.UtcNow;
            return this;
        }
    }
}