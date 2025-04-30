using DataAccess.Domain.Masters.State;
using DataAccess.Interfaces.Masters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Masters
{
    internal class StateRepository(ApplicationDbContext _context) : IStateRepository
    {
        public Task<int> AddAsync(StateEntity entity)
        {
            throw new NotImplementedException();
        }


        public async Task<StateEntity?> FindAsync(int id)
        {
            return await _context.StateEntity
                              .FirstOrDefaultAsync(t => t.Id == id);
        }


        public async Task<StateSearchResponseEntity> SearchStateAsync(StateSearchRequestEntity request)
        {
            var response = new StateSearchResponseEntity();
            var query = _context.StateEntity
                                    .OrderBy(t => t.Status == "Inactive")
                                    .ThenByDescending(t => t.LastUpdateDate)
                                    .AsQueryable();

          

            var StateName = await _context.StateEntity
                            .Select(a => a.StateName)
                            .Distinct()
                            .ToListAsync();

            var Status = await _context.StateEntity
                            .Select(a => a.Status)
                            .Distinct()
                            .ToListAsync();

        
            if (!string.IsNullOrWhiteSpace(request.StateName))
            {
                var nameFilter = request.StateName.ToLower();
                query = query.Where(t => t.StateName != null && t.StateName.ToLower().Contains(nameFilter));
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
                response.States = await query.ToListAsync();
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
                response.States = await query.Skip(request.Offset).Take(request.Count).ToListAsync();
                response.Paging.TotalPages = (int)Math.Ceiling((double)response.Paging.Total / request.Count);
                response.Paging.CurrentPage = (request.Offset / request.Count) + 1;
                response.Paging.Results = response.States.Count();
                response.Paging.NextOffset = response.Paging.Total < request.Offset + request.Count ?
                    null :
                    (request.Offset + request.Count).ToString();

                response.Paging.NextPage = response.Paging.NextOffset != null ? $"?offset={(response.Paging.CurrentPage * request.Count)}&count={request.Count}" : null;
                response.Paging.PrevPage = response.Paging.CurrentPage > 1 ? $"?offset={(request.Offset - request.Count)}&count={request.Count}" : null;

            }

            response.Filters = new Dictionary<string, List<string>>
            {
                { "StateName", StateName },
                { "Status", Status }
            };

            return response;
        }


        public async Task<StateEntity> UpdateAsync(StateEntity countryEntity)
        {
            _context.StateEntity.Update(countryEntity);
            await _context.SaveChangesAsync();
            return countryEntity;
        }
    }
}
