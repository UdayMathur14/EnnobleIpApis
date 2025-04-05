using System.ComponentModel.DataAnnotations;

namespace DataAccess.Domain.Masters.Customer
{
    public class CustomerSearchRequestEntity
    {
        public string CustomerType { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerCode { get; set; }

        [Required]
        [StringLength(255)]
        public string CustomerName { get; set; }

        [StringLength(255)]
        public string? BillingAddressLine1 { get; set; }

        [StringLength(255)]
        public string? BillingAddressLine2 { get; set; }

        [StringLength(100)]
        public string? BillingCity { get; set; }

        [StringLength(100)]
        public string? BillingState { get; set; }

        [StringLength(100)]
        public string? BillingCountry { get; set; }

        [StringLength(20)]
        public string? BillingPinCode { get; set; }

        [StringLength(255)]
        public string? ShippingAddressLine1 { get; set; }

        [StringLength(255)]
        public string? ShippingAddressLine2 { get; set; }

        [StringLength(100)]
        public string? ShippingCity { get; set; }

        [StringLength(100)]
        public string? ShippingState { get; set; }

        [StringLength(100)]
        public string? ShippingCountry { get; set; }

        [StringLength(20)]
        public string? ShippingPinCode { get; set; }

        [StringLength(255)]
        public string? ContactPersonName { get; set; }

        [StringLength(100)]
        public string? Designation { get; set; }

        [StringLength(255)]
        public string? Email { get; set; }

        [StringLength(20)]
        public string? MobileNumber { get; set; }

        [StringLength(50)]
        public string? Currency { get; set; }

        [StringLength(255)]
        public string? PaymentTerms { get; set; }

        public bool? BlockCustomer { get; set; }
        public string? Status { get; set; }
        public int Offset { get; set; }
        public int Count { get; set; }
    }
}
