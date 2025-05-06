using AutoMapper;
using DataAccess.Domain.Masters.Transaction;
using Models.RequestModels.Masters.Transaction;
using Models.ResponseModels.Masters.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Mappings.Transactions
{
    public class TransactionMappingProfile : Profile
    {
        public TransactionMappingProfile()
        {
            CreateMap<TransactionSearchRequestModel, TransactionSearchRequestEntity>();
            CreateMap<TransactionSearchResponseEntity, TransactionSearchResponse>();
            CreateMap<TransactionRequestModel, TransactionRequestEntity>();
            CreateMap<TransactionEntity, TransactionSearchResponse>();
            CreateMap<TransactionRequestModel, TransactionEntity>();
            CreateMap<TransactionEntity, TransactionRequestModel>();
            CreateMap<TransactionUpdateRequestModel, TransactionEntity>();

            CreateMap<TransactionEntity, TransactionReadResponseModel>();
        }
    }
}
