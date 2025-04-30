using DataAccess.Domain.Masters.State;

namespace DataAccess.Interfaces.Masters
{
    public interface IStateRepository : IRepository<StateEntity>
    {
        Task<StateSearchResponseEntity> SearchStateAsync(StateSearchRequestEntity request);
    }
}
