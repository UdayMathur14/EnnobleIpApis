﻿using Models.ResponseModels.BaseResponseSetup;

namespace DataAccess.Domain.Masters.LookUp
{
    public class LookUpSearchResponseEntity
    {
        public IEnumerable<LookUpEntity>? LookUps { get; set; } = new List<LookUpEntity>();
        public PagingModel Paging { get; set; } = new PagingModel();
        public Dictionary<string, List<string>> Filters { get; set; } = new Dictionary<string, List<string>>();
    }
}
