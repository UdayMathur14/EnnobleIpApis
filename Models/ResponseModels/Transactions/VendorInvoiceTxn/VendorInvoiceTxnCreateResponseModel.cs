using Models.ResponseModels.BaseResponseSetup;

namespace Models.ResponseModels.Transaction.VendorInvoiceTxn
{
    public class VendorInvoiceTxnCreateResponseModel: ResponseMessage
    {
        public int Id { get; set; }

        public VendorInvoiceTxnCreateResponseModel() { }

        public VendorInvoiceTxnCreateResponseModel(int id)
        {
            Id = id;
        }
    }
}
