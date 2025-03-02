namespace Library.Core.Domain.Authors.Checkers;

public interface IPhoneMustBeUniqueChecker
{
    Task<bool> IsUnique(string phone, CancellationToken cancellationToken);
}
