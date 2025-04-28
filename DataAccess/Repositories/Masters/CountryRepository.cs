using DataAccess.Domain.Masters.Country;
using DataAccess.Interfaces.Masters;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Masters
{
    
    internal class CountryRepository(ApplicationDbContext _context) : ICountryRepository
    {
     
        public  Task<int> AddAsync(CountryEntity entity)
        {
            throw new NotImplementedException();
        }

  
        public async Task<CountryEntity?> FindAsync(int id)
        {
            return await _context.CountryEntity
                              .FirstOrDefaultAsync(t => t.Id == id);
        }

       
        public async Task<CountrySearchResponseEntity> SearchCountryAsync(CountrySearchRequestEntity request)
        {
            var response = new CountrySearchResponseEntity();
            var query = _context.CountryEntity
                                    .OrderBy(t => t.Status == "Inactive")
                                    .ThenByDescending(t => t.LastUpdateDate)
                                    .AsQueryable();

            var CountryCode = await _context.CountryEntity
                            .Select(a => a.CountryCode)
                            .Distinct()
                            .ToListAsync();

            var CountryName = await _context.CountryEntity
                            .Select(a => a.CountryName)
                            .Distinct()
                            .ToListAsync();

            var Status = await _context.CountryEntity
                            .Select(a => a.Status)
                            .Distinct()
                            .ToListAsync();

            if (!string.IsNullOrWhiteSpace(request.CountryCode))
            {
                var codeFilter = request.CountryCode.ToLower();
                query = query.Where(t => t.CountryCode != null && t.CountryCode.ToLower().Contains(codeFilter));
            }
            if (!string.IsNullOrWhiteSpace(request.CountryName))
            {
                var nameFilter = request.CountryName.ToLower();
                query = query.Where(t => t.CountryName != null && t.CountryName.ToLower().Contains(nameFilter));
            }
            //if (!string.IsNullOrWhiteSpace(request.GlSubCategory))
            //{
            //    var nameFilter = request.GlSubCategory.ToLower();
            //    query = query.Where(t => t.GlSubCategory != null && t.GlSubCategory.Code!.ToLower().Contains(nameFilter));
            //}
            if (!string.IsNullOrEmpty(request.Status))
            {
                query = query.Where(t => t.Status != null && t.Status!.ToLower().Contains(request.Status.ToLower()));
            }

            if (request.Count == 0)
            {
                response.Countrys = await query.ToListAsync();
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
                response.Countrys = await query.Skip(request.Offset).Take(request.Count).ToListAsync();
                response.Paging.TotalPages = (int)Math.Ceiling((double)response.Paging.Total / request.Count);
                response.Paging.CurrentPage = (request.Offset / request.Count) + 1;
                response.Paging.Results = response.Countrys.Count();
                response.Paging.NextOffset = response.Paging.Total < request.Offset + request.Count ?
                    null :
                    (request.Offset + request.Count).ToString();

                response.Paging.NextPage = response.Paging.NextOffset != null ? $"?offset={(response.Paging.CurrentPage * request.Count)}&count={request.Count}" : null;
                response.Paging.PrevPage = response.Paging.CurrentPage > 1 ? $"?offset={(request.Offset - request.Count)}&count={request.Count}" : null;

            }

            response.Filters = new Dictionary<string, List<string>>
            {
                { "CountryCode", CountryCode },
                { "CountryName", CountryName },
                { "Status", Status }
            };

            return response;
        }

       
        public async Task<CountryEntity> UpdateAsync(CountryEntity countryEntity)
        {
            _context.CountryEntity.Update(countryEntity);
            await _context.SaveChangesAsync();
            return countryEntity;
        }

        public async Task<CountryEntity> FindByTxnTypeCodeAsync(string txnTypeCode)
        {
            return await _context.CountryEntity
            .Where(m => m.CountryCode! == txnTypeCode)
            .FirstOrDefaultAsync();
        }
    }
}
