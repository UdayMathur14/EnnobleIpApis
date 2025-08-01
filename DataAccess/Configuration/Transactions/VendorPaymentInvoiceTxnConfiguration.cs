using DataAccess.Domain.Masters.VendorInvoiceTxn;
using DataAccess.Domain.Transactions.VendorInvoiceTxn;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace DataAccess.Configuration.Masters
{
    public sealed class VendorPaymentInvoiceTxnConfiguration : IEntityTypeConfiguration<VendorPaymentInvoiceEntity>
    {
        public void Configure(EntityTypeBuilder<VendorPaymentInvoiceEntity> builder)
        {
            //builder.HasOne(b => b.bankEntity)
            //.WithMany(a => a.VendorPayments)
            //.HasForeignKey(b => b.bankID);
        }
    }
}
