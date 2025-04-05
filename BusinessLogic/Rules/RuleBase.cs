using BusinessLogic.Rules.Enums;
using BusinessLogic.Rules.Exceptions;
using BusinessLogic.Rules.Models;
using System.Reflection;
using Utilities;

namespace BusinessLogic.Rules
{
    public abstract class RuleBase<TRuleSet>
    {
        protected RuleBase() 
        {
            this.Result = RuleResultType.Pass;
            this.Results = new List<RuleResult>();
        }

        public RuleResultType Result { get; private set; }
        public List<RuleResult> Results { get; }

        public void RunRules()
        {
            var methods = typeof(TRuleSet)
                .GetMethods(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance)
                .Where(m => m.ReturnType == typeof(void));

            foreach(var method in methods)
            {
                try
                {
                    method.Invoke(this, null);
                    this.Results.Add(new RuleResult
                    {
                        Source = method.Name
                    });
                }
                catch(TargetInvocationException exception)
                {
                    var ruleException = exception.InnerException as RuleException;
                    this.Results.Add(new RuleResult
                    {
                        Source = method.Name,
                        ResultCode = RuleResultType.Fail,
                        Exception = ruleException
                    });

                    this.Result = ruleException?.Category == Category.Error ? RuleResultType.Fail : this.Result;
                }
            }
        }
    }
}
