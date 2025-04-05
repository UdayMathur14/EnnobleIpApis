﻿using AutoMapper;
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
                //customerEntity.CustomerContactNo = requestModel.CustomerContactNo;
                //customerEntity.CustomerEmailId = requestModel.CustomerEmailId;
                customerEntity.Status = requestModel.Status;

                var customerResponse = await customerRepository.UpdateAsync(customerEntity);

                CustomerReadResponseModel customerSearchResponse = mapper.Map<CustomerReadResponseModel>(customerResponse);
                wrapper.Response = customerSearchResponse;
            }
            return wrapper;
        }
    }
}
