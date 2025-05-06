using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Domain.Masters.Transaction
{
    public class TransactionRequestEntity
    {
        public decimal Id { get; set; }

        public string? Status { get; set; }
    }
}
