using BusinessLogic.Rules.Enums;
using BusinessLogic.Rules.Exceptions;

namespace BusinessLogic.Rules.Models
{
    public class RuleResult
    {
        public RuleResult()
        {
            this.ResultCode = RuleResultType.Pass;   
        }

        public string? Source { get; set; }
        public RuleResultType ResultCode { get; set; }
        public string Result => this.ResultCode.ToString();
        public RuleException? Exception { get; set; }
    }
}
