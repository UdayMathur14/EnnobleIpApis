using DataAccess.Domain.Masters.Bank;
using DataAccess.Interfaces.Masters;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Repositories.Masters
{
    public class BankRepository(ApplicationDbContext _context) : IBankRepository
    {
        public async Task<int> AddAsync(BankEntity entity)
        {
            _context.BankEntity.Add(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        
        public async Task<BankEntity?> FindAsync(int id)
        {
            return await _context.BankEntity
                .SingleOrDefaultAsync(x => x.Id == id);
        }

      
        public async Task<BankEntity?> IsExistsAsync(string? AccountNumber, string? AccountType)
        {
            return await _context.BankEntity                       
                        .Where(x => x.AccountNumber == AccountNumber).SingleOrDefaultAsync();
        }
        
        public async Task<BankSearchResponseEntity> SearchBankAsync(BankSearchRequestEntity request)
        {
            var response = new BankSearchResponseEntity();

            var query = _context.BankEntity                     
                        //.Where(tm => tm.Status == "Active"))
                        //.OrderBy(t => t.Status == "Inactive")
                        //.ThenByDescending(t => t.LastUpdateDate)
                        .AsQueryable();


            var BankCode = await _context.BankEntity
                        .Select(a => a.BankCode)
                        .Distinct()
                        .ToListAsync();

            var BankName = await _context.BankEntity
                            .Select(a => a.BankName)
                            .Distinct()
                            .ToListAsync();
            var BankType = await _context.BankEntity
                           .Select(a => a.AccountType)
                           .Distinct()
                           .ToListAsync();

            var Status = await _context.BankEntity
                        .Select(a => a.Status)
                        .Distinct()
                        .ToListAsync();

        

            if (!string.IsNullOrWhiteSpace(request.BankCode))
            {
                query = query.Where(t => t.BankCode!.ToLower().Contains(request.BankCode.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(request.BankName))
            {
                query = query.Where(t => t.BankName!.ToLower().Contains(request.BankName.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(request.AccountType))
            {
                query = query.Where(t => t.AccountType!.ToLower().Contains(request.AccountType.ToLower()));
            }

            if (!string.IsNullOrEmpty(request.Status))
            {
                query = query.Where(t => t.Status != null && t.Status!.ToLower().Contains(request.Status.ToLower()));
            }

            if (request.Count == 0)
            {
                response.Banks = await query.ToListAsync();
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
                response.Banks = await query.Skip(request.Offset).Take(request.Count).ToListAsync();
                response.Paging.TotalPages = (int)Math.Ceiling((double)response.Paging.Total / request.Count);
                response.Paging.CurrentPage = (request.Offset / request.Count) + 1;
                response.Paging.Results = response.Banks.Count();
                response.Paging.NextOffset = response.Paging.Total < request.Offset + request.Count ?
                    null :
                    (request.Offset + request.Count).ToString();

                response.Paging.NextPage = response.Paging.NextOffset != null ? $"?offset={(response.Paging.CurrentPage * request.Count)}&count={request.Count}" : null;
                response.Paging.PrevPage = response.Paging.CurrentPage > 1 ? $"?offset={(request.Offset - request.Count)}&count={request.Count}" : null;

            }

            response.Filters = new Dictionary<string, List<string>>
            {
                { "BankCode", BankCode },
                { "BankName", BankName },
                 { "BankType",BankType  },
                { "Status", Status },
            };

            return response;
        }
        
        public async Task<BankEntity> UpdateAsync(BankEntity entity)
        {
            _context.BankEntity.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<BankEntity> GetByNameAsync(string transportName)
        {
            return await _context.BankEntity.FirstOrDefaultAsync(t => t.BankName == transportName);
        }
    }
}
