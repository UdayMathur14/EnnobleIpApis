namespace Models.ResponseModels.Masters.Customer
{
    public class CustomerReadResponseModel : BaseResponseModel
    {
        public string? CustomerType { get; set; }
        public string? CustomerCode { get; set; }
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
        public string? ContactPersonName { get; set; }
        public string? Designation { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        public string? Currency { get; set; }
        public string? PaymentTerms { get; set; }
    }
}
