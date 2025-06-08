using DataAccess.Domain.Masters.VendorInvoiceTxn;
using DataAccess.Interfaces.VendorInvoiceTxn;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.VendorInvoiceTxns
{
    internal class VendorInvoiceTxnRepository(ApplicationDbContext _context) : IVendorInvoiceTxnRepository
    {
        public async Task<int> AddAsync(VendorInvoiceTxnEntity entity)
        {
            if (entity.FeeDetails != null && entity.FeeDetails.Any())
            {
                foreach (var fee in entity.FeeDetails)
                {
                    fee.VendorInvoiceTxnEntity = entity; 
                }
            }
            _context.VendorInvoiceTxnEntity.Add(entity);

            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<VendorInvoiceTxnEntity?> FindAsync(int id)
        {
            //return await _context.VendorInvoiceTxnEntity.FindAsync(id);

            return await
                _context.VendorInvoiceTxnEntity
                .Include(x => x.FeeDetails)
                .Include(x => x.VendorEntity)
                .Include(x=>x.CustomerEntity)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<VendorInvoiceTxnEntity?> IsExistsAsync(string? code)
        {
            //return await _context.VendorInvoiceTxnEntity.Where(c=>c.VendorInvoiceTxnCode==code).SingleOrDefaultAsync();
            return null;
        }

        public async Task<VendorInvoiceTxnSearchResponseEntity> SearchVendorInvoiceTxnAsync(VendorInvoiceTxnSearchRequestEntity request)
        {
            var response = new VendorInvoiceTxnSearchResponseEntity();

            var query = _context.VendorInvoiceTxnEntity.AsQueryable();

            //var VendorInvoiceTxnName = await _context.VendorInvoiceTxnEntity
            //           .Select(a => a.VendorInvoiceTxnName)
            //           .Distinct()
            //           .ToListAsync();

            //var VendorInvoiceTxnCode = await _context.VendorInvoiceTxnEntity
            //           .Select(a => a.VendorInvoiceTxnCode)
            //           .Distinct()
            //           .ToListAsync();

            //var VendorInvoiceTxnType = await _context.VendorInvoiceTxnEntity
            //           .Select(a => a.VendorInvoiceTxnType)
            //           .Distinct()
            //           .ToListAsync();


            var Status = await _context.VendorInvoiceTxnEntity
                       .Select(a => a.Status)
                       .Distinct()
                       .ToListAsync();

            if (!string.IsNullOrWhiteSpace(request.Status))
            {
                query = query.Where(t => t.Status!.ToLower().Contains(request.Status.ToLower()));
            }
            //if (!string.IsNullOrWhiteSpace(request.VendorInvoiceTxnName))
            //{
            //    query = query.Where(t => t.VendorInvoiceTxnName!.ToLower().Contains(request.VendorInvoiceTxnName.ToLower()));
            //}
            //if (!string.IsNullOrWhiteSpace(request.VendorInvoiceTxnCode))
            //{
            //    query = query.Where(t => t.VendorInvoiceTxnCode!.ToLower().Contains(request.VendorInvoiceTxnCode.ToLower()));
            //}
            //if (!string.IsNullOrWhiteSpace(request.VendorInvoiceTxnType))
            //{
            //    query = query.Where(t => t.VendorInvoiceTxnType!.ToLower().Contains(request.VendorInvoiceTxnType.ToLower()));
            //}

            if (request.Count == 0)
            {
                response.VendorInvoiceTxn = await query.ToListAsync();
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
                response.VendorInvoiceTxn = await query.Skip(request.Offset).Take(request.Count).ToListAsync();
                response.Paging.TotalPages = (int)Math.Ceiling((double)response.Paging.Total / request.Count);
                response.Paging.CurrentPage = (request.Offset / request.Count) + 1;
                response.Paging.Results = response.VendorInvoiceTxn.Count();
                response.Paging.NextOffset = response.Paging.Total < request.Offset + request.Count ?
                    null :
                    (request.Offset + request.Count).ToString();

                response.Paging.NextPage = response.Paging.NextOffset != null ? $"?offset={(response.Paging.CurrentPage * request.Count)}&count={request.Count}" : null;
                response.Paging.PrevPage = response.Paging.CurrentPage > 1 ? $"?offset={(request.Offset - request.Count)}&count={request.Count}" : null;

            }
            response.Filters = new Dictionary<string, List<string>>
            {
                //{ "VendorInvoiceTxnName", VendorInvoiceTxnName  },
                //{ "VendorInvoiceTxnCode", VendorInvoiceTxnCode  },
                //{ "VendorInvoiceTxnType",VendorInvoiceTxnType},
                { "Status", Status }
            };

            return response;
        }

        public async Task<VendorInvoiceTxnEntity> UpdateAsync(VendorInvoiceTxnEntity VendorInvoiceTxnEntity)
        {
            _context.VendorInvoiceTxnEntity.Update(VendorInvoiceTxnEntity);
            await _context.SaveChangesAsync();

            return VendorInvoiceTxnEntity;
        }
    }
}
