using DataAccess.Domain.Masters.Vendor;
using DataAccess.Interfaces.Masters;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Masters
{
    internal class VendorRepository(ApplicationDbContext _context) : IVendorRepository
    {
        public async Task<int> AddAsync(VendorEntity entity)
        {
            _context.VendorEntity.Add(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }
        public async Task<VendorEntity?> FindAsync(int id)
        {
            return await _context.VendorEntity.FindAsync(id);
        }

        public async Task<VendorEntity?> IsExistsAsync(string? vendorName)
        {
            return await _context.VendorEntity.Where(c => c.VendorName == vendorName).SingleOrDefaultAsync();
            //return null;
        }

        public async Task<VendorSearchResponseEntity> SearchVendorAsync(VendorSearchRequestEntity request)
        {
            var response = new VendorSearchResponseEntity();

            var query = _context.VendorEntity.AsQueryable();

            var VendorName = await _context.VendorEntity
                       .Select(a => a.VendorName)
                       .Distinct()
                       .ToListAsync();

            var VendorCode = await query
                       .Select(a => a.VendorCode)
                       .Distinct()
                       .ToListAsync();

            var VendorType = await query
                       .Select(a => a.VendorType)
                       .Distinct()
                       .ToListAsync();


            var Status = await query
                       .Select(a => a.Status)
                       .Distinct()
                       .ToListAsync();

            if (!string.IsNullOrWhiteSpace(request.Status))
            {
                query = query.Where(t => t.Status!.ToLower().Contains(request.Status.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(request.VendorName))
            {
                query = query.Where(t => t.VendorName!.ToLower().Contains(request.VendorName.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(request.VendorCode))
            {
                query = query.Where(t => t.VendorCode!.ToLower().Contains(request.VendorCode.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(request.VendorType))
            {
                query = query.Where(t => t.VendorType!.ToLower().Contains(request.VendorType.ToLower()));
            }

            if (request.Count == 0)
            {
                response.Vendors = await query.ToListAsync();
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
                response.Vendors = await query.Skip(request.Offset).Take(request.Count).ToListAsync();
                response.Paging.TotalPages = (int)Math.Ceiling((double)response.Paging.Total / request.Count);
                response.Paging.CurrentPage = (request.Offset / request.Count) + 1;
                response.Paging.Results = response.Vendors.Count();
                response.Paging.NextOffset = response.Paging.Total < request.Offset + request.Count ?
                    null :
                    (request.Offset + request.Count).ToString();

                response.Paging.NextPage = response.Paging.NextOffset != null ? $"?offset={(response.Paging.CurrentPage * request.Count)}&count={request.Count}" : null;
                response.Paging.PrevPage = response.Paging.CurrentPage > 1 ? $"?offset={(request.Offset - request.Count)}&count={request.Count}" : null;

            }
            response.Filters = new Dictionary<string, List<string>>
            {
                { "VendorName", VendorName  },
                { "VendorCode", VendorCode  },
                { "VendorType",VendorType},
                { "Status", Status }
            };

            return response;
        }

        public async Task<VendorEntity> UpdateAsync(VendorEntity VendorEntity)
        {
            _context.VendorEntity.Update(VendorEntity);
            await _context.SaveChangesAsync();

            return VendorEntity;
        }
    }
}
