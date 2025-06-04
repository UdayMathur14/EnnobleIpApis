using DataAccess.Configuration.Master;
using DataAccess.Configuration.Masters;
using DataAccess.Domain.Masters.Bank;
using DataAccess.Domain.Masters.Country;
using DataAccess.Domain.Masters.Customer;
using DataAccess.Domain.Masters.LookUp;
using DataAccess.Domain.Masters.LookUpType;
using DataAccess.Domain.Masters.State;
using DataAccess.Domain.Masters.VendorInvoiceTxn;
using DataAccess.Domain.Masters.Vendor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DataAccess.Domain.Transactions.VendorInvoiceTxn;

namespace DataAccess
{
    public class ApplicationDbContext : DbContext
    {
       
        protected readonly IConfiguration Configuration;
        public ApplicationDbContext(IConfiguration configuration, DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Configuration = configuration;
        }
        //masters 
        public virtual DbSet<LookUpTypeEntity> LookUpTypeEntity { get; set; }
        public virtual DbSet<LookUpEntity> LookUpEntity { get; set; }
        public virtual DbSet<CustomerEntity> CustomerEntity { get; set; }
        public virtual DbSet<VendorEntity> VendorEntity { get; set; }
        public virtual DbSet<BankEntity> BankEntity { get; set; }
        public virtual DbSet<CountryEntity> CountryEntity { get; set; }
        public virtual DbSet<StateEntity> StateEntity { get; set; }

        public virtual DbSet<VendorInvoiceFeesEntity> FeesEntity { get; set; }

        //transactions
        public virtual DbSet<VendorInvoiceTxnEntity> VendorInvoiceTxnEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LookUpConfiguration());
            modelBuilder.ApplyConfiguration(new LookUpTypeConfiguration());

            modelBuilder.ApplyConfiguration(new VendorInvoiceTxnMasterConfiguration());
        }
    }
}
