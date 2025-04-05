using DataAccess.Domain;

namespace DataAccess.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : EntityBase
    {
        Task<TEntity?> FindAsync(int id);
        Task<int> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
