using Library.Core.Common.Validation;
using Library.Core.Domain.Authors.Checkers;

namespace Library.Core.Domain.Authors.Rules;

public class PhoneMustBeUniqueBusinessRule(
    string phoneNumber,
    IPhoneMustBeUniqueChecker phoneMustBeUniqueChecker) : IBusinessRuleAsync
{
    public Task<RuleResult> CheckAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    private void Check()
    {

    }
}
