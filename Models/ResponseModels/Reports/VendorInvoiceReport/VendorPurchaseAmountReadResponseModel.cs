using Models.ResponseModels.Masters.Vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Models.ResponseModels.Reports.VendorInvoiceReport
{
    public class VendorPurchaseAmountReadResponseModel : BaseResponseModel
    {
        public decimal? VendorId { get; set; }
        public string VendorName { get; set; } 
        public decimal? TotalAmount { get; set; }
        public string Status { get; set; }
        public string ApplicationNumber { get; set; }
        public string ClientInvNo { get; set; }
        public DateOnly InvoiceDate { get; set; }
        public VendorReadResponseModel? VendorDetails { get; set; }
    }
}
