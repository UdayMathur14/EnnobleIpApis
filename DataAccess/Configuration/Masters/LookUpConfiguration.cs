using DataAccess.Domain.Masters.LookUp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration.Master
{
    public sealed class LookUpConfiguration : IEntityTypeConfiguration<LookUpEntity>
    {
        public void Configure(EntityTypeBuilder<LookUpEntity> builder)
        {
            builder.Property(e => e.Id)
                   .ValueGeneratedOnAdd();

            builder.HasOne(b => b.LookUpType)  // LookUpEntity has ONE LookUpType
          .WithMany(a => a.LookUp)    // LookUpTypeEntity has MANY LookUpEntities
          .HasForeignKey(b => b.TypeId); // Foreign key is TypeId (Maps to TYPE_ID)
        }
    }

}
