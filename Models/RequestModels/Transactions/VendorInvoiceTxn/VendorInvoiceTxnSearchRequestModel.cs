using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RequestModels.Masters.VendorInvoiceTxn
{
    public class VendorInvoiceTxnSearchRequestModel
    {
        public int? VendorID { get; set; }
        public string? ClientInvoiceNo { get; set; }
        public string? OurInvoiceNo { get; set; }
        public DateTime? InvoiceDateFrom { get; set; }
        public DateTime? InvoiceDateTo { get; set; }
        public string? Status { get; set; }
    }
}
