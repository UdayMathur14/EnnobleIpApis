using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RequestModels.Masters.Transaction
{
    public class TransactionSearchRequestModel
    {
        public string? TransactionName { get; set; }  
        public string? TransactionCode { get; set; }
        public string? TransactionType { get; set; }
        public string? Status { get; set; }
    }
}
