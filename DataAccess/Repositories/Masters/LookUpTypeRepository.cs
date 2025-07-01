using DataAccess.Domain.Masters.LookUpType;
using DataAccess.Interfaces.Masters;
using Microsoft.EntityFrameworkCore;
using Utilities.Constants;

namespace DataAccess.Repositories.Masters
{
    internal class LookUpTypeRepository(ApplicationDbContext _context) : ILookUpTypeRepository
    {
        public async Task<int> AddAsync(LookUpTypeEntity entity)
        {
            _context.LookUpTypeEntity.Add(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<LookUpTypeEntity?> FindAsync(int id)
        {
            return await _context.LookUpTypeEntity.FindAsync(id);
        }

        public async Task<LookUpTypeEntity?> IsExistsAsync(string? type)
        {
            return await _context.LookUpTypeEntity.Where(x => x.Type == type).SingleOrDefaultAsync();
        }

        public async Task<LookUpTypeSearchResponseEntity> SearchLookUpAsync(LookUpTypeSearchRequestEntity request)
        {
            var response = new LookUpTypeSearchResponseEntity();

            var query = _context.LookUpTypeEntity.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Type))
            {
                query = query.Where(t => t.Type!.ToLower().Contains(request.Type.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(request.Status))
            {
                query = query.Where(t => t.Status!.ToLower().Contains(request.Status.ToLower()));
            }

            var Status = await query
                        .Select(a => a.Status)
                        .Distinct()
                        .ToListAsync();

            var Type = await query
                        .Select(a => a.Type)
                        .Distinct()
                        .ToListAsync();

            if (request.Count == 0)
            {
                response.LookUpTypes = await query.ToListAsync();
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
                response.LookUpTypes = await query.Skip(request.Offset).Take(request.Count).ToListAsync();
                response.Paging.TotalPages = (int)Math.Ceiling((double)response.Paging.Total / request.Count);
                response.Paging.CurrentPage = (request.Offset / request.Count) + 1;
                response.Paging.Results = response.LookUpTypes.Count();
                response.Paging.NextOffset = response.Paging.Total < request.Offset + request.Count ?
                    null :
                    (request.Offset + request.Count).ToString();

                response.Paging.NextPage = response.Paging.NextOffset != null ? $"?offset={(response.Paging.CurrentPage * request.Count)}&count={request.Count}" : null;
                response.Paging.PrevPage = response.Paging.CurrentPage > 1 ? $"?offset={(request.Offset - request.Count)}&count={request.Count}" : null;

            }
            response.Filters = new Dictionary<string, List<string>>
            {
                { "LookUpType", Type },
                { "Status", Status }
            };
            return response;
        }
         
        public async Task<LookUpTypeEntity> UpdateAsync(LookUpTypeEntity lookUpTypeEntity)
        {
            _context.LookUpTypeEntity.Update(lookUpTypeEntity);
            await _context.SaveChangesAsync();

            return lookUpTypeEntity;
        }
    }
}
