using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Domain.Masters.Transaction
{
    public class TransactionSearchRequestEntity
    {
        public string? TransactionName { get; set; }
        public string? TransactionCode { get; set; }
        public string? TransactionType { get; set; }
        public string? Status { get; set; }
        public int Offset { get; set; }
        public int Count { get; set; }
    }
}
