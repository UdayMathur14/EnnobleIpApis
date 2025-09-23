using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RequestModels.Transactions.VendorInvoiceTxn
{
    public class VendorInvoicePaymentSearchRequest
    {
        public int? VendorId { get; set; }      
        public string? VendorName { get; set; }
    }
}
