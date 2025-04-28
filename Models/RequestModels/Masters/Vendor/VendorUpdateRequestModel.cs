namespace Models.RequestModels.Masters.Vendor
{
    public class VendorUpdateRequestModel
    {
        public string? ActionBy { get; set; }

        public string? VendorType { get; set; }
        public string? VendorCode { get; set; }
        public string? VendorName { get; set; }

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

        public string? PAN { get; set; }
        public string? GST { get; set; }
        public string? GSTTreatment { get; set; }

        public bool? MSMERegistered { get; set; }
        public string? MSMEType { get; set; }
        public string? MSMENo { get; set; }

        public string? ContactPersonName { get; set; }
        public string? Designation { get; set; }
        public string? Email1 { get; set; }
        public string? Email2 { get; set; }
        public string? PhoneMobileNo { get; set; }

        public string? Currency { get; set; }
        public string? PaymentTerms { get; set; }

        public string? BankName { get; set; }
        public string? AccountHolderName { get; set; }
        public string? AccountNumber { get; set; }
        public string? ConfirmAccountNumber { get; set; }
        public string? IFSCCode { get; set; }
        public string? SwiftCode { get; set; }
        public string? BankAddressLine1 { get; set; }
        public string? BankAddressLine2 { get; set; }
        public string? Branch { get; set; }
        public string? BankCity { get; set; }
        public string? BankState { get; set; }
        public string? BankPinCode { get; set; }
        public string? iban { get; set; }
        public string? SortCode { get; set; }
        public string? routingNo { get; set; }
        public string? bankCountry { get; set; }
        public string? fctcCharge { get; set; }
        public string? completionYear { get; set; }
        public string? Status { get; set; }
    }
}
