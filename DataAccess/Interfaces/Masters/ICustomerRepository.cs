using DataAccess.Domain.Masters.Customer;

namespace DataAccess.Interfaces.Masters
{
    public interface ICustomerRepository : IRepository<CustomerEntity>
    {
        Task<CustomerSearchResponseEntity> SearchCustomerAsync(CustomerSearchRequestEntity request);
        Task<CustomerEntity?> IsExistsAsync(string? code, string? name);
        Task<CustomerEntity> GetByCustomerAsync(string customerCode);
    }
}
