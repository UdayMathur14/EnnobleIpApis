using DataAccess.Domain.Masters.LookUp;
using DataAccess.Interfaces.Masters;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Masters
{
    internal class LookUpRepository(ApplicationDbContext _context) : ILookUpRepository
    {

        public async Task<int> AddAsync(LookUpEntity entity)
        {
            _context.LookUpEntity.Add(entity); 
            await _context.SaveChangesAsync();

            return entity.Id;  // The database will generate the ID automatically
        }


        public async Task<LookUpEntity?> FindAsync(int id)
        {
            return await _context.LookUpEntity.Include(x => x.LookUpType).SingleOrDefaultAsync(x => x.Id == id);
        }

     
        public async Task<LookUpEntity?> IsExistsAsync(string? code, string? value, int? typeId)
        {
            return await _context.LookUpEntity.Where(x => x.Code == code && x.Value == value && x.TypeId == typeId).SingleOrDefaultAsync();
        }

        public async Task<LookUpSearchResponseEntity> SearchLookUpAsync(LookUpSearchRequestEntity request)
        {
            var response = new LookUpSearchResponseEntity();

            var query = _context.LookUpEntity.Include(x => x.LookUpType)
                        .OrderBy(t => t.Status == "Inactive")
                        .ThenByDescending(t => t.LastUpdateDate)
                        .AsQueryable();

            var LookUpType = await query
                        .Where(t => t.LookUpType != null)
                        .Select(a => a.LookUpType!.Type)
                        .Distinct()
                        .ToListAsync();

            var Code = await query
                        .Select(a => a.Code)
                        .Distinct()
                        .ToListAsync();

            var Value = await query
                       .Select(a => a.Value)
                       .Distinct()
                       .ToListAsync();

            var Status = await query
                        .Select(a => a.Status)
                        .Distinct()
                        .ToListAsync();

            if (!string.IsNullOrWhiteSpace(request.LookupType))
            {
                query = query.Where(t => t.LookUpType!.Type!.ToLower().Contains(request.LookupType.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(request.Code))
            {
                query = query.Where(t => t.Code!.ToLower().Contains(request.Code.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(request.Status))
            {
                query = query.Where(t => t.Status!.ToLower().Contains(request.Status.ToLower()));
            }

            if (request.Count == 0)
            {
                response.LookUps = await query.ToListAsync();
                // If Count is 0, we should return an empty result set and set paging values appropriately
                response.Paging.TotalPages = 0;
                response.Paging.CurrentPage = 0;
                response.Paging.Results = 0;
                response.Paging.NextOffset = null;
                response.Paging.NextPage = null;
                response.Paging.PrevPage = null;
            }
            else
            {
                response.Paging.Total = query.AsNoTracking().Count();
                response.LookUps = await query.Skip(request.Offset).Take(request.Count).ToListAsync();
                response.Paging.TotalPages = (int)Math.Ceiling((double)response.Paging.Total / request.Count);
                response.Paging.CurrentPage = (request.Offset / request.Count) + 1;
                response.Paging.Results = response.LookUps.Count();
                response.Paging.NextOffset = response.Paging.Total < request.Offset + request.Count ?
                    null :
                    (request.Offset + request.Count).ToString();

                response.Paging.NextPage = response.Paging.NextOffset != null ? $"?offset={(response.Paging.CurrentPage * request.Count)}&count={request.Count}" : null;
                response.Paging.PrevPage = response.Paging.CurrentPage > 1 ? $"?offset={(request.Offset - request.Count)}&count={request.Count}" : null;

            }

            response.Filters = new Dictionary<string, List<string>>
            {
                { "LookUpType", LookUpType },
                { "Code", Code },
                { "Value", Value },
                { "Status", Status }
            };

            return response;
        }

    
        public async Task<LookUpEntity> UpdateAsync(LookUpEntity lookUpEntity)
        {
            _context.LookUpEntity.Update(lookUpEntity);
            await _context.SaveChangesAsync();
            return lookUpEntity;
        }

      
        public async Task<List<LookUpEntity>> SearchByTypeAsync(string type)
        {
            return await _context.LookUpEntity
                .Include(l => l.LookUpType)
                .Where(l => l.LookUpType != null && l.LookUpType.Type != null && l.LookUpType.Type.ToLower() == type.ToLower())
                .ToListAsync();
        }

    
        private async Task<int> GetNextIdAsync()
        {
            int lastId = await _context.LookUpEntity
                                          .MaxAsync(e => e.Id);
            int newId = lastId + 1;

            return newId;
        }

        public async Task<LookUpEntity> FindAsync(Func<LookUpEntity, bool> predicate)
        {
            return await Task.FromResult(_context.LookUpEntity.FirstOrDefault(predicate));
        }

        public async Task<LookUpEntity?> GetLookUpByTypeIdAndCodeAsync(int typeId, string taxCode)
        {
            return await _context.LookUpEntity
                .FirstOrDefaultAsync(l => l.TypeId == typeId && l.Code == taxCode);
        }

        public async Task<List<LookUpEntity>> FindByTypeListAsync(string? type)
        {
            var query = await _context.LookUpEntity
                    .Include(x => x.LookUpType)
                    .AsNoTracking()
                    .Where(x => x.LookUpType.Type == type)
                    .ToListAsync();

            return query;
        }
    }
}
