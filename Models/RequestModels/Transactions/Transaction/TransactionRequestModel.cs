using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RequestModels.Masters.Transaction
{
    public class TransactionRequestModel
    {
        public string? TransactionType { get; set; }
        public string? TransactionCode { get; set; }
        public string? TransactionName { get; set; }

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
        public string? BankPinCode { get; set; }
    }
}
