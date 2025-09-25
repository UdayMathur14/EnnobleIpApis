using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RequestModels.Transactions.VendorInvoiceTxn
{
    public class VendorInvoicePaymentSearchRequest
    {   
        public string? VendorName { get; set; }
        public string? Status { get; set; }
        public int Offset { get; set; }
        public int Count { get; set; }
    }
}
