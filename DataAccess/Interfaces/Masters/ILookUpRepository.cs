using DataAccess.Domain.Masters.LookUp;

namespace DataAccess.Interfaces.Masters
{
    public interface ILookUpRepository : IRepository<LookUpEntity>
    {
        Task<LookUpSearchResponseEntity> SearchLookUpAsync(LookUpSearchRequestEntity request);   
        Task<LookUpEntity?> IsExistsAsync(string? code, string? value, int? typeId);
        Task<List<LookUpEntity>> SearchByTypeAsync(string type);
        Task<LookUpEntity> FindAsync(Func<LookUpEntity, bool> predicate);
        Task<LookUpEntity?> GetLookUpByTypeIdAndCodeAsync(int typeId, string taxCode);
        Task<List<LookUpEntity>> FindByTypeListAsync(string? type);
    }
}
