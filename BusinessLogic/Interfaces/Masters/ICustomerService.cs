using DataAccess.Domain.Masters.Customer;
using Models.RequestModels.Masters.Customer;
using Models.ResponseModels.Masters.Customer;
using Utilities;

namespace BusinessLogic.Interfaces.Masters
{
    public interface ICustomerService
    {
        Task<IResponseWrapper<CustomerCreateResponseModel>> CreateCustomerAsync(CustomerRequestModel customer);
        Task<IResponseWrapper<CustomerReadResponseModel>> GetCustomerAsync(int customerId);
        Task<IResponseWrapper<CustomerSearchResponse>> SearchCustomerAsync(CustomerSearchRequestModel requestModel, string? offset, string count);
        Task<IResponseWrapper<CustomerReadResponseModel>> UpdateCustomerAsync(CustomerRequestModel requestModel, int customerId);
    }
}
