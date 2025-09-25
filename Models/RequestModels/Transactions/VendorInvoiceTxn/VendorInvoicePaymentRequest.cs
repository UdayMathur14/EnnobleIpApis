using Models.RequestModels.Masters.VendorInvoiceTxn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RequestModels.Transactions.VendorInvoiceTxn
{
    public class VendorInvoicePaymentRequest
    {
        public List<int>? VendorInvoiceIds { get; set; }  
        public List<PaymentInvoiceDetailList>? PaymentDetails { get; set; }
    }
   
}
