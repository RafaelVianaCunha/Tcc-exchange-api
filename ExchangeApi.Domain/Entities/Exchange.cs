using System;

namespace ExchangeApi.Domain.Entities 
{
    public class Exchange
    {
        public Guid Id { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public string Name { get; private set; }

        public DateTime? DeletedAt { get; private set; }

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
            Name = name;

            return this;
        }

        public Exchange Delete()
        {
            DeletedAt = DateTime.UtcNow;

            return this;
        }
    }
}