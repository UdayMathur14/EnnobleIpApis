using Models.ResponseModels.BaseResponseSetup;

namespace Models.ResponseModels.Masters.Customer
{
    public class CustomerSearchResponse : SearchResponseBase<CustomerReadResponseModel>
    {
        public List<CustomerReadResponseModel> Customers => base.Results;
    }
}
