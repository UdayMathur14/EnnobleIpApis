using DataAccess.Domain.Masters.VendorInvoiceTxn;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration.Masters
{
    public sealed class VendorInvoiceTxnMasterConfiguration : IEntityTypeConfiguration<VendorInvoiceTxnEntity>
    {
        public void Configure(EntityTypeBuilder<VendorInvoiceTxnEntity> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.HasOne(b => b.VendorEntity)  
            .WithMany(a => a.VendorInvoiceTxns)     
            .HasForeignKey(b => b.VendorID);

            builder.HasOne(b => b.CustomerEntity)
           .WithMany(a => a.CustomerInvoiceTxns)
           .HasForeignKey(b => b.CustomerID);

            builder.HasMany(e => e.FeeDetails)
               .WithOne()  // no navigation back from Fee to Invoice
               .HasForeignKey(f => f.VendorInvoiceTxnID)
               .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
