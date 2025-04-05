using DataAccess.Domain.Masters.Customer;
using DataAccess.Interfaces;
using DataAccess.Interfaces.Masters;
using Microsoft.EntityFrameworkCore;
using Utilities;

namespace DataAccess.Repositories.Masters
{
    internal class CustomerRepository(ApplicationDbContext _context) : ICustomerRepository
    {
      
        public async Task<CustomerEntity?> FindAsync(int id)
        {
            return await
               _context.CustomerEntity
               .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<CustomerEntity?> IsExistsAsync(string? code, string? name)
        {
            return await _context.CustomerEntity.Where(x => x.CustomerCode == code && x.CustomerName == name ).SingleOrDefaultAsync();
        }

        public async Task<CustomerSearchResponseEntity> SearchCustomerAsync(CustomerSearchRequestEntity request)
        {
            var response = new CustomerSearchResponseEntity();
            var query = _context.CustomerEntity
                        .OrderBy(t => t.Status == "Inactive")
                        .ThenByDescending(t => t.LastUpdateDate)
                        .AsQueryable();

            var CustomerCode = await _context.CustomerEntity
                            .Select(a => a.CustomerCode)
                            .Distinct()
                            .ToListAsync();

            var CustomerName = await _context.CustomerEntity
                            .Select(a => a.CustomerName)
                            .Distinct()
                            .ToListAsync();

            var Status = await _context.CustomerEntity
                        .Select(a => a.Status)
                        .Distinct()
                        .ToListAsync();

            if (!string.IsNullOrWhiteSpace(request.CustomerCode))
            {
                query = query.Where(t => t.CustomerCode!.ToLower().Contains(request.CustomerCode.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(request.CustomerName))
            {
                query = query.Where(t => t.CustomerName!.ToLower().Contains(request.CustomerName.ToLower()));
            }

            if (!string.IsNullOrEmpty(request.Status))
            {
                query = query.Where(t => t.Status != null && t.Status!.ToLower().Contains(request.Status.ToLower()));
            }

            if (request.Count == 0)
            {
                response.Customers = await query.ToListAsync();
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
                response.Customers = await query.Skip(request.Offset).Take(request.Count).ToListAsync();
                response.Paging.TotalPages = (int)Math.Ceiling((double)response.Paging.Total / request.Count);
                response.Paging.CurrentPage = (request.Offset / request.Count) + 1;
                response.Paging.Results = response.Customers.Count();
                response.Paging.NextOffset = response.Paging.Total < request.Offset + request.Count ?
                    null :
                    (request.Offset + request.Count).ToString();

                response.Paging.NextPage = response.Paging.NextOffset != null ? $"?offset={(response.Paging.CurrentPage * request.Count)}&count={request.Count}" : null;
                response.Paging.PrevPage = response.Paging.CurrentPage > 1 ? $"?offset={(request.Offset - request.Count)}&count={request.Count}" : null;

            }
            response.Filters = new Dictionary<string, List<string>>
            {
                { "CustomerCode", CustomerCode },
                { "Status", Status },
            };

            return response;
        }

   
        public async Task<CustomerEntity> UpdateAsync(CustomerEntity customerEntity)
        {
            _context.CustomerEntity.Update(customerEntity);
            await _context.SaveChangesAsync();

            return customerEntity;
        }

        public async Task<CustomerEntity> GetByCustomerAsync(string customerCode) => await _context.CustomerEntity
                .Where(d => d.Status != Status.Inactive.ToString())
                .FirstOrDefaultAsync(f => f.CustomerCode == customerCode);

        public Task<int> AddAsync(CustomerEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
