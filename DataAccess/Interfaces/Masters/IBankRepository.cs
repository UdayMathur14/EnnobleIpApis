using DataAccess.Domain.Masters.Bank;
namespace DataAccess.Interfaces.Masters
{
    public interface IBankRepository : IRepository<BankEntity>
    {
        Task<BankSearchResponseEntity> SearchBankAsync(BankSearchRequestEntity request);
        Task<BankEntity?> IsExistsAsync(string? AccountNumber, string? AccountType);
        Task<BankEntity> GetByNameAsync(string transportName);
    }
}

