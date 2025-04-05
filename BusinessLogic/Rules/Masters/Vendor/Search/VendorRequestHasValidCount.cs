﻿using BusinessLogic.Rules.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Constants;

namespace BusinessLogic.Rules.Masters.Vendor.Search
{
    public partial class VendorSearchRules
    {
        public void RequestHasValidCount()
        {
            if (!int.TryParse(this.Count, out var intCount) || intCount < 0)
            {
                throw new RuleException(
                    Messages.InvalidCount.Description,
                    Messages.InvalidCount.Element,
                    this.Count,
                    Codes.InvalidCount,
                    Utilities.Category.Warning
                    );
            }

            this.VendorSearchRequestEntity.Count = intCount;
        }
    }
}
