namespace Library.Core.Common.Validation;

public interface IBusinessRuleAsync
{
    Task<RuleResult> CheckAsync(CancellationToken cancellationToken = default);
}
