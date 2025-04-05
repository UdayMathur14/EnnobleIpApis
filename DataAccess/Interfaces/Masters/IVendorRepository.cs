using DataAccess.Domain.Masters.Vendor;

namespace DataAccess.Interfaces.Masters
{
    public interface IVendorRepository : IRepository<VendorEntity>
    {
        Task<VendorSearchResponseEntity> SearchLookUpAsync(VendorSearchRequestEntity request);
        Task<VendorEntity?> IsExistsAsync(string? type);
    }
}
