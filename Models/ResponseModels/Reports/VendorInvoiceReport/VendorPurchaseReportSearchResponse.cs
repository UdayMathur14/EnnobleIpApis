using Models.ResponseModels.BaseResponseSetup;
using Models.ResponseModels.VendorInvoiceReport.VendorInvoiceReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ResponseModels.Reports.VendorInvoiceReport
{
    public class VendorPurchaseReportSearchResponse : SearchResponseBase<VendorPurchaseAmountReadResponseModel>
    {
        public List<VendorPurchaseAmountReadResponseModel> VendorPurchaseReports => base.Results;
    }
}
