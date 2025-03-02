using Library.Core.Common.Validation;
using Library.Core.Domain.Authors.Checkers;
using Library.Core.Domain.Authors.Models;

namespace Library.Core.Domain.Authors.Rules;

public class PhoneMustBeUniqueBusinessRule(
    string phoneNumber,
    IPhoneMustBeUniqueChecker checker) : IBusinessRuleAsync
{
    public async Task<RuleResult> CheckAsync(CancellationToken cancellationToken = default)
    {
        var isUnique = await checker.IsUnique(phoneNumber, cancellationToken);
        return Check(isUnique);
    }

    private RuleResult Check(bool isBelongs)
    {
        if (isBelongs) return RuleResult.Success();
        return RuleResult.Failed($"{nameof(Author)}'s {nameof(Author.Email)} must be unique.");
    }
}
