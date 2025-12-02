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
    }
}
