using DataAccess.Domain.Masters.VendorInvoiceReport;

namespace BusinessLogic.Rules.Masters.VendorInvoiceReport.Search
{
    public partial class VendorInvoiceReportSearchRules : RuleBase<VendorInvoiceReportSearchRules>
    {
        public VendorInvoiceReportSearchRules(VendorInvoiceReportSearchRequestEntity VendorInvoiceReportSearchRequestEntity, string? offset, string? count)
        {
            this.VendorInvoiceReportSearchRequestEntity = VendorInvoiceReportSearchRequestEntity;
            this.Offset = offset;
            this.Count = count;
        }

        private VendorInvoiceReportSearchRequestEntity VendorInvoiceReportSearchRequestEntity { get; }
        private string? Offset { get; set; }
        private string? Count { get; set; }
    }
}
