using DataAccess.Domain.Masters.VendorInvoiceTxn;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Domain.Masters.Vendor
{
    [Table("VENDOR_MST_TB")]
    public class VendorEntity : EntityBase
    {
        [Column("VENDOR_TYPE")]
        [StringLength(50)]
        public string? VendorType { get; set; }

        [Column("VENDOR_NAME")]
        [Required]
        [StringLength(255)]
        public string VendorName { get; set; }

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

        [Column("PAN_NO")]
        [StringLength(20)]
        public string? PAN { get; set; }

        [Column("GST_NO")]
        [StringLength(20)]
        public string? GST { get; set; }

        [Column("GST_TREATMENT")]
        [StringLength(100)]
        public string? GSTTreatment { get; set; }

        [Column("MSME_REGISTERED")]
        public bool? MSMERegistered { get; set; }

        [Column("MSME_TYPE")]
        [StringLength(50)]
        public string? MSMEType { get; set; }

        [Column("MSME_NO")]
        [StringLength(50)]
        public string? MSMENo { get; set; }

        [Column("CONTACT_PERSON_NAME")]
        [StringLength(255)]
        public string? ContactPersonName { get; set; }

        [Column("DESIGNATION")]
        [StringLength(100)]
        public string? Designation { get; set; }

        [Column("EMAIL_1")]
        [StringLength(255)]
        public string? Email1 { get; set; }

        [Column("EMAIL_2")]
        [StringLength(255)]
        public string? Email2 { get; set; }

        [Column("PHONE_MOBILE_NO")]
        [StringLength(50)]
        public string? PhoneMobileNo { get; set; }

        [Column("Country_Code")]
        [StringLength(5)]
        public string? CountryCode { get; set; }

        [Column("CURRENCY")]
        [StringLength(10)]
        public string? Currency { get; set; }

        [Column("CURRENCY_SYMBOL")]
        [StringLength(10)]
        public string? CurrencySymbol { get; set; }

        [Column("PAYMENT_TERMS")]
        [StringLength(255)]
        public string? PaymentTerms { get; set; }

        [Column("BANK_NAME")]
        [StringLength(255)]
        public string? BankName { get; set; }

        [Column("ACCOUNT_HOLDER_NAME")]
        [StringLength(255)]
        public string? AccountHolderName { get; set; }

        [Column("ACCOUNT_NUMBER")]
        [StringLength(50)]
        public string? AccountNumber { get; set; }

        [Column("CONFIRM_ACCOUNT_NUMBER")]
        [StringLength(50)]
        public string? ConfirmAccountNumber { get; set; }

        [Column("IFSC_CODE")]
        [StringLength(20)]
        public string? IFSCCode { get; set; }

        [Column("SWIFT_CODE")]
        [StringLength(20)]
        public string? SwiftCode { get; set; }

        [Column("BANK_ADDRESS_LINE_1")]
        [StringLength(255)]
        public string? BankAddressLine1 { get; set; }

        [Column("BANK_ADDRESS_LINE_2")]
        [StringLength(255)]
        public string? BankAddressLine2 { get; set; }

        [Column("BRANCH")]
        [StringLength(100)]
        public string? Branch { get; set; }

        [Column("BANK_CITY")]
        [StringLength(100)]
        public string? BankCity { get; set; }


        [Column("BANK_COUNTRY")]
        [StringLength(100)]
        public string? BankCountry { get; set; }

        [Column("BANK_STATE")]
        [StringLength(100)]
        public string? BankState { get; set; }

        [Column("BANK_PIN_CODE")]
        [StringLength(20)]
        public string? BankPinCode { get; set; }

        [Column("IBAN")]
        public string? iban { get; set; }

        [Column("SORT_CODE")]
        public string? SortCode { get; set; }

        [Column("ROUTING_NO")]
        public string? routingNo { get; set; }

        [Column("FC_TC_CHARGES")]
        public string? fCTCCharges { get; set; }

        [Column("COMPL_DOC_YEAR")]
        public string? complDocyear { get; set; }

        public ICollection<VendorInvoiceTxnEntity>? VendorInvoiceTxns { get; set; }

    }
}
