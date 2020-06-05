using System;
using Microsoft.EntityFrameworkCore;
using ExchangeApi.Domain.Repositories;
using ExchangeApi.Domain.Entities;

namespace ExchangeApi.Infrastructure
{
    public class ExchangeDbContext : DbContext , IDisposable
    {
        public DbSet<Exchange> Exchanges { get; set; }

        protected ExchangeDbContext()
        {
        }

        public ExchangeDbContext(DbContextOptions options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ExchangeConfiguration());
        }
    }
}
