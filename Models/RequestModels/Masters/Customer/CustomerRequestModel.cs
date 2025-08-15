using Models.RequestModels;

namespace DataAccess.Domain.Masters.Customer
{
    public class CustomerRequestModel : BaseRequestModel
    {
        public string? CustomerType { get; set; }
        public string? CustomerName { get; set; }

        public string? BillingAddressLine1 { get; set; }
        public string? BillingAddressLine2 { get; set; }
        public string? BillingCity { get; set; }
        public string? BillingState { get; set; }
        public string? BillingCountry { get; set; }
        public string? BillingPinCode { get; set; }

        public string? ShippingAddressLine1 { get; set; }
        public string? ShippingAddressLine2 { get; set; }
        public string? ShippingCity { get; set; }
        public string? ShippingState { get; set; }
        public string? ShippingCountry { get; set; }
        public string? ShippingPinCode { get; set; }

        public string? Pan { get; set; }
        public string? Gst { get; set; }
        public string? GstTreatment { get; set; }
        public bool? MsmeRegistered { get; set; }
        public string? MsmeType { get; set; }
        public string? MsmeNo { get; set; }
        public string? ContactPersonName { get; set; }
        public string? Designation { get; set; }
        public string? Email1 { get; set; }
        public string? Email2 { get; set; }
        public string? PhoneMobileNo { get; set; }
        public string? CountryCode { get; set; }

        public string? Currency { get; set; }
        public string? CurrencySymbol { get; set; }
        public string? PaymentTerms { get; set; }
        public string? Status { get; set; }
    }

}

