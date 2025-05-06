using DataAccess.Domain.Masters.Transaction;
using DataAccess.Interfaces.Transactions;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Transactions
{
    internal class TransactionRepository(ApplicationDbContext _context) : ITransactionRepository
    {
        public async Task<int> AddAsync(TransactionEntity entity)
        {
            _context.TransactionEntity.Add(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<TransactionEntity?> FindAsync(int id)
        {
            return await _context.TransactionEntity.FindAsync(id);
        }

        public async Task<TransactionEntity?> IsExistsAsync(string? code)
        {
            //return await _context.TransactionEntity.Where(c=>c.TransactionCode==code).SingleOrDefaultAsync();
            return null;
        }

        public async Task<TransactionSearchResponseEntity> SearchTransactionAsync(TransactionSearchRequestEntity request)
        {
            var response = new TransactionSearchResponseEntity();

            var query = _context.TransactionEntity.AsQueryable();

            var TransactionName = await _context.TransactionEntity
                       .Select(a => a.TransactionName)
                       .Distinct()
                       .ToListAsync();

            var TransactionCode = await _context.TransactionEntity
                       .Select(a => a.TransactionCode)
                       .Distinct()
                       .ToListAsync();

            var TransactionType = await _context.TransactionEntity
                       .Select(a => a.TransactionType)
                       .Distinct()
                       .ToListAsync();


            var Status = await _context.TransactionEntity
                       .Select(a => a.Status)
                       .Distinct()
                       .ToListAsync();

            if (!string.IsNullOrWhiteSpace(request.Status))
            {
                query = query.Where(t => t.Status!.ToLower().Contains(request.Status.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(request.TransactionName))
            {
                query = query.Where(t => t.TransactionName!.ToLower().Contains(request.TransactionName.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(request.TransactionCode))
            {
                query = query.Where(t => t.TransactionCode!.ToLower().Contains(request.TransactionCode.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(request.TransactionType))
            {
                query = query.Where(t => t.TransactionType!.ToLower().Contains(request.TransactionType.ToLower()));
            }

            if (request.Count == 0)
            {
                response.Transactions = await query.ToListAsync();
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
                response.Transactions = await query.Skip(request.Offset).Take(request.Count).ToListAsync();
                response.Paging.TotalPages = (int)Math.Ceiling((double)response.Paging.Total / request.Count);
                response.Paging.CurrentPage = (request.Offset / request.Count) + 1;
                response.Paging.Results = response.Transactions.Count();
                response.Paging.NextOffset = response.Paging.Total < request.Offset + request.Count ?
                    null :
                    (request.Offset + request.Count).ToString();

                response.Paging.NextPage = response.Paging.NextOffset != null ? $"?offset={(response.Paging.CurrentPage * request.Count)}&count={request.Count}" : null;
                response.Paging.PrevPage = response.Paging.CurrentPage > 1 ? $"?offset={(request.Offset - request.Count)}&count={request.Count}" : null;

            }
            response.Filters = new Dictionary<string, List<string>>
            {
                { "TransactionName", TransactionName  },
                { "TransactionCode", TransactionCode  },
                { "TransactionType",TransactionType},
                { "Status", Status }
            };

            return response;
        }

        public async Task<TransactionEntity> UpdateAsync(TransactionEntity TransactionEntity)
        {
            _context.TransactionEntity.Update(TransactionEntity);
            await _context.SaveChangesAsync();

            return TransactionEntity;
        }
    }
}
