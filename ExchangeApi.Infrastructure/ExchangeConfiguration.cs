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
            builder.Property(x => x.UserId);
            builder.Property(x => x.ApiKey);
            builder.Property(x => x.ApiSecret);
            builder.Property(x => x.DeletedAt);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}