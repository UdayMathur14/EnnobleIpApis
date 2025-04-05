using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DataAccess.Domain.Masters.Country;

namespace DataAccess.Configuration.Master
{
    public sealed class CountryConfiguration : IEntityTypeConfiguration<CountryEntity>
    {
        public void Configure(EntityTypeBuilder<CountryEntity> builder)
        {
            builder.Property(e => e.Id)
                   .ValueGeneratedOnAdd();
        }
    }
}
