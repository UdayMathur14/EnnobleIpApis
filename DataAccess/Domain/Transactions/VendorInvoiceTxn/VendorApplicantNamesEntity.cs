using DataAccess.Domain.Masters.VendorInvoiceTxn;
using Models.ResponseModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Domain.Transactions.VendorInvoiceTxn
{
    [Table("VENDOR_APPLICANT_NAME")]
    public class VendorApplicantNamesEntity 
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("VendorInvoiceTxnEntity")]
        public int VendorInvoiceTxnID { get; set; }
        public string? ApplicantName { get; set; }
        public VendorInvoiceTxnEntity? VendorApplicationEntity { get; set; }
    }

}
