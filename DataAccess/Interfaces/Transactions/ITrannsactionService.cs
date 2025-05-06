using DataAccess.Domain.Masters.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces.Transactions
{
    public interface ITransactionRepository : IRepository<TransactionEntity>
    {
        Task<TransactionSearchResponseEntity> SearchTransactionAsync(TransactionSearchRequestEntity request);
        Task<TransactionEntity?> IsExistsAsync(string? code);
    }
}
