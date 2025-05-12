using DataAccess.Domain.Masters.VendorInvoiceTxn;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Domain.Masters.Customer
{

    [Table("CUSTOMER_MST_TB")]
    public class CustomerEntity : EntityBase
    {
        [Required]
        [Column("CUSTOMER_TYPE")]
        [StringLength(50)]
        public string CustomerType { get; set; }

        [Required]
        [Column("CUSTOMER_CODE")]
        [StringLength(50)]
        public string CustomerCode { get; set; }

        [Required]
        [Column("CUSTOMER_NAME")]
        [StringLength(255)]
        public string CustomerName { get; set; }

        [Column("BILLING_ADDRESS_LINE_1")]
        [StringLength(255)]
        public string? BillingAddressLine1 { get; set; }

        [Column("BILLING_ADDRESS_LINE_2")]
        [StringLength(255)]
        public string? BillingAddressLine2 { get; set; }

        [Column("BILLING_CITY")]
        [StringLength(100)]
        public string? BillingCity { get; set; }

        [Column("BILLING_STATE")]
        [StringLength(100)]
        public string? BillingState { get; set; }

        [Column("BILLING_COUNTRY")]
        [StringLength(100)]
        public string? BillingCountry { get; set; }

        [Column("BILLING_PIN_CODE")]
        [StringLength(20)]
        public string? BillingPinCode { get; set; }

        [Column("SHIPPING_ADDRESS_LINE_1")]
        [StringLength(255)]
        public string? ShippingAddressLine1 { get; set; }

        [Column("SHIPPING_ADDRESS_LINE_2")]
        [StringLength(255)]
        public string? ShippingAddressLine2 { get; set; }

        [Column("SHIPPING_CITY")]
        [StringLength(100)]
        public string? ShippingCity { get; set; }

        [Column("SHIPPING_STATE")]
        [StringLength(100)]
        public string? ShippingState { get; set; }

        [Column("SHIPPING_COUNTRY")]
        [StringLength(100)]
        public string? ShippingCountry { get; set; }

        [Column("SHIPPING_PIN_CODE")]
        [StringLength(20)]
        public string? ShippingPinCode { get; set; }

        [Column("CONTACT_PERSON_NAME")]
        [StringLength(255)]
        public string? ContactPersonName { get; set; }

        [Column("DESIGNATION")]
        [StringLength(100)]
        public string? Designation { get; set; }

        [Column("EMAIL")]
        [StringLength(255)]
        public string? Email { get; set; }

        [Column("MOBILE_NO")]
        [StringLength(20)]
        public string? MobileNumber { get; set; }

        [Column("CURRENCY")]
        [StringLength(50)]
        public string? Currency { get; set; }

        [Column("PAYMENT_TERMS")]
        [StringLength(255)]
        public string? PaymentTerms { get; set; }

        public ICollection<VendorInvoiceTxnEntity> CustomerInvoiceTxns { get; set; } = new List<VendorInvoiceTxnEntity>();
    }

}
