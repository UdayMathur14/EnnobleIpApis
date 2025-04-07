using AutoMapper;
using BusinessLogic.Interfaces.Masters;
using BusinessLogic.Rules.Enums;
using BusinessLogic.Rules.Master.Customer;
using DataAccess.Domain.Masters.Customer;
using DataAccess.Interfaces.Masters;
using Models.RequestModels.Masters.Customer;
using Models.ResponseModels.Masters.Customer;
using Utilities;
using Utilities.Constants;
using Utilities.Extensions;
using Utilities.Implementation;

namespace BusinessLogic.Services.Masters
{
    internal class CustomerService(ICustomerRepository customerRepository, IMapper mapper) : ICustomerService
    {
        public async Task<IResponseWrapper<CustomerCreateResponseModel>> CreateCustomerAsync(CustomerRequestModel requestModel)
        {
            var wrapper = new ResponseWrapper<CustomerCreateResponseModel>();

            CustomerEntity? CustomerEntity = await customerRepository.IsExistsAsync(requestModel.CustomerCode, requestModel.CustomerName);

            if (CustomerEntity != null)
            {
                wrapper.Messages.Add(Messages.AlreadyExists.ToDetailModel(requestModel.CustomerCode.ToString()));
            }
            else
            {
                CustomerEntity entity = mapper.Map<CustomerEntity>(requestModel);


                entity.Status = Status.Active.ToString();

                int id = await customerRepository.AddAsync(entity);

                wrapper.Response = new CustomerCreateResponseModel()
                {
                    Id = id
                };
            }
            return wrapper;
        }

        public async Task<IResponseWrapper<CustomerReadResponseModel>> GetCustomerAsync(int customerId)
        {
            var wrapper = new ResponseWrapper<CustomerReadResponseModel>();
            CustomerEntity? customerEntity = await customerRepository.FindAsync(customerId);

            if (customerEntity == null)
            {
                wrapper.Messages.Add(Messages.EntityNotFound.ToDetailModel($"CustomerId: {customerId}"));
                return wrapper;
            }

            CustomerReadResponseModel response = mapper.Map<CustomerReadResponseModel>(customerEntity);
            wrapper.Response = response;

            return wrapper;
        }

       
        public async Task<IResponseWrapper<CustomerSearchResponse>> SearchCustomerAsync(CustomerSearchRequestModel requestModel, string? offset, string count)
        {
            var wrapper = new ResponseWrapper<CustomerSearchResponse>();

            CustomerSearchRequestEntity? request = mapper.Map<CustomerSearchRequestEntity>(requestModel);
            var rules = new CustomerSearchRules(request, offset, count);
            rules.RunRules();
            foreach (var result in rules.Results)
            {
                if (result.ResultCode == RuleResultType.Fail && result.Exception != null)
                {
                    wrapper.Messages.Add(Messages.GetErrorDetail(
                        result.Exception.Code,
                        result.Exception.Message,
                        result.Exception.Element,
                        result.Exception.Category)
                        .ToDetailModel(result.Exception.ElementValue));
                }
            }

            if (rules.Result == RuleResultType.Fail)
            {
                return wrapper;
            }

            CustomerSearchResponseEntity entityResponse = await customerRepository.SearchCustomerAsync(request);
            CustomerSearchResponse customerReadResponse = mapper.Map<CustomerSearchResponse>(entityResponse);

            wrapper.Response = customerReadResponse;

            return wrapper;
        }

        public async Task<IResponseWrapper<CustomerReadResponseModel>> UpdateCustomerAsync(CustomerRequestModel requestModel, int customerId)
        {
            var wrapper = new ResponseWrapper<CustomerReadResponseModel>();

            CustomerEntity? customerEntity = await customerRepository.FindAsync(customerId);

            if (customerEntity == null)
            {
                wrapper.Messages.Add(Messages.EntityNotFound.ToDetailModel($"CustomerId: {customerId}"));
                return wrapper;
            }
            else
            {
                customerEntity.CustomerType = requestModel.CustomerType;
                customerEntity.CustomerCode = requestModel.CustomerCode;
                customerEntity.CustomerName = requestModel.CustomerName;

                customerEntity.BillingAddressLine1 = requestModel.BillingAddressLine1;
                customerEntity.BillingAddressLine2 = requestModel.BillingAddressLine2;
                customerEntity.BillingCity = requestModel.BillingCity;
                customerEntity.BillingState = requestModel.BillingState;
                customerEntity.BillingCountry = requestModel.BillingCountry;
                customerEntity.BillingPinCode = requestModel.BillingPinCode;

                customerEntity.ShippingAddressLine1 = requestModel.ShippingAddressLine1;
                customerEntity.ShippingAddressLine2 = requestModel.ShippingAddressLine2;
                customerEntity.ShippingCity = requestModel.ShippingCity;
                customerEntity.ShippingState = requestModel.ShippingState;
                customerEntity.ShippingCountry = requestModel.ShippingCountry;
                customerEntity.ShippingPinCode = requestModel.ShippingPinCode;

                customerEntity.ContactPersonName = requestModel.ContactPersonName;
                customerEntity.Designation = requestModel.Designation;
                customerEntity.Email = requestModel.Email;
                customerEntity.MobileNumber = requestModel.MobileNumber;

                customerEntity.Currency = requestModel.Currency;
                customerEntity.PaymentTerms = requestModel.PaymentTerms;

                customerEntity.Status = requestModel.Status;
                customerEntity.LastUpdatedBy = requestModel.ActionBy; // from BaseRequestModel


                var customerResponse = await customerRepository.UpdateAsync(customerEntity);

                CustomerReadResponseModel customerSearchResponse = mapper.Map<CustomerReadResponseModel>(customerResponse);
                wrapper.Response = customerSearchResponse;
            }
            return wrapper;
        }
    }
}
