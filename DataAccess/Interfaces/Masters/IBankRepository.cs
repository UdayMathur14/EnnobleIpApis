using DataAccess.Domain.Masters.Bank;
namespace DataAccess.Interfaces.Masters
{
    public interface IBankRepository : IRepository<BankEntity>
    {
        Task<BankSearchResponseEntity> SearchBankAsync(BankSearchRequestEntity request);
        Task<BankEntity?> IsExistsAsync(string? bankCode, string? value, int? typeId);
        Task<BankEntity> GetByNameAsync(string transportName);
    }
}

