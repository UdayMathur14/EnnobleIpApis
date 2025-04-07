using Models.ResponseModels.BaseResponseSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ResponseModels.Masters.Customer
{
    public  class CustomerCreateResponseModel : ResponseMessage
    {
        public int Id { get; set; }

        public CustomerCreateResponseModel() { }

        public CustomerCreateResponseModel(int id)
        {
            Id = id;
        }
    }
}
