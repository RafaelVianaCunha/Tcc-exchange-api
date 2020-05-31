using ExchangeApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExchangeApi.Infrastructure
{
    public class ExchangeConfiguration : IEntityTypeConfiguration<Exchange>
    {
        public void Configure(EntityTypeBuilder<Exchange> builder)
        {
            builder.ToTable("Exchanges");
            
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.Name);
            builder.Property(x => x.DeletedAt);
        }
    }
}