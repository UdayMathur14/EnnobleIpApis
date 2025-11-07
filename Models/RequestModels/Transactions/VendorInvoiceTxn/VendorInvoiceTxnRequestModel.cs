namespace Models.RequestModels.Masters.VendorInvoiceTxn
{
    public class VendorInvoiceTxnRequestModel
    {
        // Tab 1
        public int? vendorID { get; set; }                  
        public DateTime? invoiceDate { get; set; }          
        public string? FY { get; set; }                     
        public string? clientInvoiceNo { get; set; }        
        public DateTime? dueDateAsPerInvoice { get; set; }  
        public int? creditDaysAsPerContract { get; set; }   
        public int? customerID { get; set; }                
        public string? description { get; set; }            
        public string? title { get; set; }                  
        public string? applicationNumber { get; set; }      
        public DateTime? filingDate { get; set; }          
        public string? clientRefNo { get; set; }            
        public string? ourRefNo { get; set; }               
        public string? officialFilingReceiptSupporting { get; set; } 
        public DateTime? workDeliveryDateOrMonth { get; set; }          
        public string? purchaseCurrency { get; set; }

        // Tab2
        public List<InvoiceFessDetailList>? invoiceFeeDetails { get; set; }
        public decimal? professionalFeeAmt { get; set; }        
        public decimal? govtOrOfficialFeeAmt { get; set; }      
        public decimal? otherChargesAmt { get; set; }           
        public decimal? discountAmt { get; set; }              
        public decimal? discountCreditNoteAmt { get; set; }
        public decimal? totalAmount { get; set; }

        // Tab 4
        public string? customerPONo { get; set; }           
        public DateTime? pODate { get; set; }               
        public decimal? pOValueInclusiveTaxes { get; set; }       
        public string? saleCurrency { get; set; }   
        public List<SaleInvoiceDetailList>? salesInvoiceDetails { get; set; }
        public List<PaymentInvoiceDetailList>? paymentFeeDetails { get; set; }
        public List<VendorApplicantNameList>? VendorApplicantNames { get; set; }
        public string? status { get; set; }                              
        public string? postedInTally { get; set; }                              
        public string? patentNo { get; set; }                              
        public string? creditNoteNo { get; set; }                              
        public DateTime? creditNoteDate { get; set; }                              
        public string? creditNoteRefNo { get; set; }                              
    }

    public class InvoiceFessDetailList
    {
        public int id { get; set; }
        public string? feeType { get; set; }
        public string? subFeeValue { get; set; }
        public string? country { get; set; }
        public decimal? amount { get; set; }
        public string? remarks { get; set; }
        public string? language { get; set; }
    }

    public class SaleInvoiceDetailList
    {
        public int id { get; set; }
        public string? type { get; set; }
        public string? invoiceNo { get; set; }
        public decimal? amount { get; set; }
        public string? estimateNo { get; set; }
        public DateTime? saleinvoiceDate { get; set; }
        public string? remarks { get; set; }
        public string? postedInTally { get; set; }
    }

    public class PaymentInvoiceDetailList
    {
        public int id { get; set; }
        public DateTime? paymentDate { get; set; }
        public int? bankID { get; set; }
        public string? oWRMNo1 { get; set; }
        public decimal? rate { get; set; }
        public decimal? quantity { get; set; }
        public decimal? bankcharges { get; set; }
        public decimal? totalAmountInr { get; set; }
        public string? paymentCurrency { get; set; }
        public decimal? paymentAmount { get; set; }
    }
    public class VendorApplicantNameList
    {
        public int id { get; set; }
        public string? applicantName { get; set; }
    }
}
