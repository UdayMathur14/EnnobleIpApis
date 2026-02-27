using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RequestModels.Reports.VendorInvoiceReport
{
    public class VendorPurchaseRequestModel
    {
        public string? Status { get; set; }
        public string? Vendor { get; set; }
        public string? Country { get; set; }
        public DateTime? fromdate { get; set; }
        public DateTime? todate { get; set; }
    }
}
