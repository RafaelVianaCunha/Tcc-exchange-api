using System;

namespace ExchangeApi.Domain.Entities 
{
    public class Exchange
    {
        public Guid Id { get; }

        public DateTime CreatedAt { get; }

        public string Name { get; }

        public DateTime? DeletedAt { get; }

        public Exchange(string name)
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            Name = name;
        }

        private Exchange(
            Guid id, 
            DateTime createdAt, 
            string name)
        {
            Id = id;
            CreatedAt = createdAt;
            Name = name;
        }

        private Exchange(
            Guid id, 
            DateTime createdAt, 
            string name,
            DateTime deletedAt)
        {
            Id = id;
            CreatedAt = createdAt;
            Name = name;
            DeletedAt = deletedAt;
        }

        public Exchange WithName(string name)
        {
            return new Exchange(
                Id,
                CreatedAt,
                name
            );
        }

        public Exchange Delete()
        {
            return new Exchange(
                Id,
                CreatedAt,
                Name,
                DateTime.UtcNow
            );
        }
    }
}