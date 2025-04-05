using DataAccess.Domain.Masters.LookUpType;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration.Master
{
    public sealed class LookUpTypeConfiguration : IEntityTypeConfiguration<LookUpTypeEntity>
    {
        public void Configure(EntityTypeBuilder<LookUpTypeEntity> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.CreationDate)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(e => e.LastUpdateDate)
                    .HasDefaultValueSql("GETDATE()");



        }
    }
}
