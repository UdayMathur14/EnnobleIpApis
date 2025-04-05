using DataAccess.Domain.Masters.LookUpType;

namespace DataAccess.Interfaces.Masters
{
    public interface ILookUpTypeRepository : IRepository<LookUpTypeEntity>
    {
        Task<LookUpTypeSearchResponseEntity> SearchLookUpAsync(LookUpTypeSearchRequestEntity request);
        Task<LookUpTypeEntity?> IsExistsAsync(string? type);
    }
}
