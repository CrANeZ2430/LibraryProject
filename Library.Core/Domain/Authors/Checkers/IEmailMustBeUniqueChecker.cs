namespace Library.Core.Domain.Authors.Checkers;

public interface IEmailMustBeUniqueChecker
{
    Task<bool> IsUnique(string email, CancellationToken cancellationToken = default);
}