using AutoMapper;
using BusinessLogic.Interfaces.Masters;
using DataAccess.Domain.Masters.Vendor;
using DataAccess.Interfaces.Masters;
using Models.RequestModels.Masters.Vendor;
using Models.ResponseModels.Masters.Vendor;
using Utilities;
using Utilities.Constants;
using Utilities.Extensions;
using Utilities.Implementation;

namespace BusinessLogic.Services.Masters
{
    internal class VendorService(IVendorRepository VendorRepository, IMapper mapper) : IVendorService
    {
        public async Task<IResponseWrapper<VendorReadResponseModel>> GetVendorAsync(int id)
        {
            var wrapper = new ResponseWrapper<VendorReadResponseModel>();
            VendorEntity? VendorEntity = await VendorRepository.FindAsync(id);

            if (VendorEntity == null)
            {
                wrapper.Messages.Add(Messages.EntityNotFound.ToDetailModel(id.ToString()));
            }

            VendorReadResponseModel response = mapper.Map<VendorReadResponseModel>(VendorEntity);
            wrapper.Response = response;

            return wrapper;
        }


        public async Task<IResponseWrapper<VendorSearchResponse>> SearchVendorAsync(VendorSearchRequestModel requestModel, string? offset, string count)
        {
            var wrapper = new ResponseWrapper<VendorSearchResponse>();

            VendorSearchRequestEntity? request = mapper.Map<VendorSearchRequestEntity>(requestModel);

            VendorSearchResponseEntity entityResponse = await VendorRepository.SearchLookUpAsync(request);
            VendorSearchResponse lookUpReadResponse = mapper.Map<VendorSearchResponse>(entityResponse);

            wrapper.Response = lookUpReadResponse;

            return wrapper;
        }


        public async Task<IResponseWrapper<VendorReadResponseModel>> UpdateVendorAsync(VendorUpdateRequestModel requestModel, int id)
        {
            var wrapper = new ResponseWrapper<VendorReadResponseModel>();

            VendorEntity? VendorEntity = await VendorRepository.FindAsync(id);

            if (VendorEntity == null)
            {
                wrapper.Messages.Add(Messages.EntityNotFound.ToDetailModel(id.ToString()));
            }
            else
            {
                mapper.Map(requestModel, VendorEntity);
                if (requestModel.Status == Status.Inactive.ToString() && VendorEntity.Status != Status.Active.ToString())
                {
                    VendorEntity.InactiveDate = DateTime.Now;
                }
                var VendorResponse = await VendorRepository.UpdateAsync(VendorEntity);

                VendorReadResponseModel VendorSearchResponse = mapper.Map<VendorReadResponseModel>(VendorResponse);
                wrapper.Response = VendorSearchResponse;
            }
            return wrapper;
        }


        public async Task<IResponseWrapper<VendorCreateResponseModel>> CreateVendorAsync(VendorRequestModel requestModel)
        {
            var wrapper = new ResponseWrapper<VendorCreateResponseModel>();

            VendorEntity? VendorEntity = await VendorRepository.IsExistsAsync(requestModel.Type);

            if (VendorEntity != null)
            {
                wrapper.Messages.Add(Messages.AlreadyExists.ToDetailModel(requestModel.Type.ToString()));
            }
            else
            {
                VendorEntity entity = mapper.Map<VendorEntity>(requestModel);

                
                entity.Status = Status.Active.ToString();

                int id = await VendorRepository.AddAsync(entity);

                wrapper.Response = new VendorCreateResponseModel()
                {
                    Id = id
                };
            }
            return wrapper;
        }

        
    }
}
