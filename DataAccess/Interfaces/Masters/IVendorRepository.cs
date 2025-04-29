using DataAccess.Domain.Masters.Vendor;

namespace DataAccess.Interfaces.Masters
{
    public interface IVendorRepository : IRepository<VendorEntity>
    {
        Task<VendorSearchResponseEntity> SearchVendorAsync(VendorSearchRequestEntity request);
        Task<VendorEntity?> IsExistsAsync(string? code);
    }
}
