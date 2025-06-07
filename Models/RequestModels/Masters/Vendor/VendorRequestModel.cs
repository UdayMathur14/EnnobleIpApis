namespace Models.RequestModels.Masters.Vendor
{
    public class VendorRequestModel
    {
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
        public string? PaymentTerms { get; set; }

        public string? BankName { get; set; }
        public string? AccountHolderName { get; set; }
        public string? AccountNumber { get; set; }
        public string? ConfirmAccountNumber { get; set; }
        public string? IfscCode { get; set; }
        public string? SwiftCode { get; set; }
        public string? BankAddressLine1 { get; set; }
        public string? BankAddressLine2 { get; set; }
        public string? Branch { get; set; }
        public string? BankCity { get; set; }
        public string? BankState { get; set; }
        public string? BankCountry { get; set; }
        public string? BankPinCode { get; set; }

        public string? iban { get; set; }
        public string? SortCode { get; set; }
        public string? routingNo { get; set; }
        public string? fCTCCharges { get; set; }
        public string? complDocyear { get; set; }
        public string? Status { get; set; }


    }
}
