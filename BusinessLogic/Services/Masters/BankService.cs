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
        public async Task<IResponseWrapper<BankCreateResponseModel>> CreateBankAsync(BankRequestModel requestModel)
        {
            var wrapper = new ResponseWrapper<BankCreateResponseModel>();

            BankEntity? BankEntity = await bankRepository.IsExistsAsync(requestModel.AccountNumber, requestModel.AccountType);

            if (BankEntity != null)
            {
                wrapper.Messages.Add(Messages.AlreadyExists.ToDetailModel(requestModel.AccountNumber.ToString()));
            }
            else
            {
                BankEntity entity = mapper.Map<BankEntity>(requestModel);


                entity.Status = Status.Active.ToString();

                int id = await bankRepository.AddAsync(entity);

                wrapper.Response = new BankCreateResponseModel()
                {
                    Id = id
                };
            }
            return wrapper;
        }

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

                bankEntity.BankCode = requestModel.BankCode;
                bankEntity.BankName = requestModel.BankName;
                bankEntity.BankAddress1 = requestModel.BankAddress1;
                bankEntity.BankAddress2 = requestModel.BankAddress2;
                bankEntity.City = requestModel.City;
                bankEntity.State = requestModel.State;
                bankEntity.Country = requestModel.Country;
                bankEntity.BankContactNo = requestModel.BankContactNo;
                bankEntity.BankEmailId = requestModel.BankEmailId;
                bankEntity.BankBranch = requestModel.BankBranch;
                bankEntity.IFSCCode = requestModel.IfscCode;
                bankEntity.AccountNumber = requestModel.AccountNumber;
                bankEntity.AccountHolderName = requestModel.AccountHolderName;
                bankEntity.AccountType = requestModel.AccountType;
                bankEntity.Status = requestModel.Status;



                var bankResponse = await bankRepository.UpdateAsync(bankEntity);

                BankReadResponseModel bankReadResponse = mapper.Map<BankReadResponseModel>(bankResponse);
                wrapper.Response = bankReadResponse;
            }

            return wrapper;
        }
    }
}

        


