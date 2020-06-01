using System;
using Microsoft.EntityFrameworkCore;
using ExchangeApi.Domain.Repositories;
using ExchangeApi.Domain.Entities;

namespace ExchangeApi.Infrastructure
{
    public class ExchangeDbContext : DbContext
    {
        public DbSet<Exchange> Exchanges { get; }

        protected ExchangeDbContext()
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ExchangeConfiguration());
        }
    }
}
