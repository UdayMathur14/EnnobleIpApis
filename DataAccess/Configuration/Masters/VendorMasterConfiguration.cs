using DataAccess.Domain.Masters.Vendor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration.Masters
{
    public sealed class VendorMasterConfiguration : IEntityTypeConfiguration<VendorEntity>
    {
        public void Configure(EntityTypeBuilder<VendorEntity> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
        }
    }
}
