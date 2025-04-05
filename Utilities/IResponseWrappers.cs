using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public interface IResponseWrappers
    {
        bool HasMessages { get; }

        bool HasErrors { get; }

        List<MessageStatusDetailModel> Messages { get; }

        MessageStatusModel ToMessageStatus(string description, string responseCode);

        object? ToResponse(string description, string responseCode);
    }
}
