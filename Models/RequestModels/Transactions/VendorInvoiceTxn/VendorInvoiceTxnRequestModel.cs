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
        public int? professionalFeeAmt { get; set; }        
        public int? govtOrOfficialFeeAmt { get; set; }      
        public int? otherChargesAmt { get; set; }           
        public int? discountAmt { get; set; }              
        public int? discountCreditNoteAmt { get; set; }
        public int? totalAmount { get; set; }  

        // Tab 3
        public DateTime? paymentDate { get; set; }          
        public int? bankID { get; set; }                    
        public string? oWRMNo1 { get; set; }                 
        public string? oWRMNo2 { get; set; }                
        public string? paymentCurrency { get; set; }              
        public int? paymentAmount { get; set; }             

        // Tab 4
        public string? customerPONo { get; set; }           
        public DateTime? pODate { get; set; }               
        public int? pOValueInclusiveTaxes { get; set; }       
        public string? saleCurrency { get; set; }   
        public List<SaleInvoiceDetailList>? salesInvoiceDetails { get; set; }
        public string? status { get; set; }                              
    }

    public class InvoiceFessDetailList
    {
        public string? feeType { get; set; }
        public string? subFeeValue { get; set; }
        public string? country { get; set; }
        public int? amount { get; set; }
        public string? remarks { get; set; }
        public string? language { get; set; }
    }

    public class SaleInvoiceDetailList
    {
        public string? type { get; set; }
        public string? invoiceNo { get; set; }
        public int? amount { get; set; }
        public int? estimateNo { get; set; }
        public string? remarks { get; set; }
        public string? postedInTally { get; set; }
    }


}
