using DataAccess.Domain.Masters.Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration.Masters
{
    public sealed class TransactionMasterConfiguration : IEntityTypeConfiguration<TransactionEntity>
    {
        public void Configure(EntityTypeBuilder<TransactionEntity> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
        }
    }
}
