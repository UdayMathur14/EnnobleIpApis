using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DataAccess.Domain.Masters.Bank;


namespace DataAccess.Configuration.Master
{
    public sealed class BankConfiguration : IEntityTypeConfiguration<BankEntity>
    {
        public void Configure(EntityTypeBuilder<BankEntity> builder)
        {
            builder.Property(e => e.Id)
                   .ValueGeneratedOnAdd();          

         
        }
    }
}
