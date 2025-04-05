using AutoMapper;
using BusinessLogic.Interfaces.Masters;
using BusinessLogic.Rules.Enums;
using BusinessLogic.Rules.Master.Bank.Search;
using DataAccess.Domain.Masters.Bank;
using DataAccess.Interfaces.Masters;
using Models.RequestModels.Masters.Bank;
using Models.ResponseModels.Masters.Bank;
using Utilities;
using Utilities.Constants;
using Utilities.Extensions;
using Utilities.Implementation;

namespace BusinessLogic.Services.Masters
{
    public class BankService(IBankRepository bankRepository, IMapper mapper) : IBankService
    {

        public async Task<IResponseWrapper<BankReadResponseModel>> GetBankAsync(int bankId)
        {
            var wrapper = new ResponseWrapper<BankReadResponseModel>();

            BankEntity? bankEntity = await bankRepository.FindAsync(bankId);

            if (bankEntity == null)
            {

                bankEntity = await bankRepository.FindAsync(bankId);
                if (bankEntity == null)
                {
                    wrapper.Messages.Add(Messages.EntityNotFound.ToDetailModel($"BankId: {bankId}"));
                    return wrapper;
                }
            }

            BankReadResponseModel response = mapper.Map<BankReadResponseModel>(bankEntity);
            wrapper.Response = response;

            return wrapper;
        }

        public async Task<IResponseWrapper<BankSearchResponseModel>> SearchBankAsync(BankSearchRequestModel requestModel, string? offset, string count)
        {
            var wrapper = new ResponseWrapper<BankSearchResponseModel>();

            BankSearchRequestEntity? request = mapper.Map<BankSearchRequestEntity>(requestModel);
            var rules = new BankSearchRules(request, offset, count);
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

            BankSearchResponseEntity entityResponse = await bankRepository.SearchBankAsync(request);

            BankSearchResponseModel bankReadResponse = mapper.Map<BankSearchResponseModel>(entityResponse);

            wrapper.Response = bankReadResponse;

            return wrapper;
        }

        public async Task<IResponseWrapper<BankReadResponseModel>> UpdateBankAsync(BankUpdateRequestModel requestModel, int bankId)
        {
            var wrapper = new ResponseWrapper<BankReadResponseModel>();
            BankEntity? bankEntity = await bankRepository.FindAsync(bankId);

            if (bankEntity == null)
            {
                wrapper.Messages.Add(Messages.EntityNotFound.ToDetailModel($"BankId: {bankId}"));
                return wrapper;
            }
            else
            {
                if (requestModel.Status == Status.Inactive.ToString() && bankEntity.Status != Status.Inactive.ToString())
                {
                    bankEntity.InactiveDate = DateTime.Now;
                }

                bankEntity.LastUpdatedBy = requestModel.ActionBy;
                bankEntity.BankContactNo = requestModel.BankContactNo;
                bankEntity.Status = requestModel.Status;



                var bankResponse = await bankRepository.UpdateAsync(bankEntity);

                BankReadResponseModel bankReadResponse = mapper.Map<BankReadResponseModel>(bankResponse);
                wrapper.Response = bankReadResponse;
            }

            return wrapper;
        }
    }
}

        


