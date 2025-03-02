using Library.Core.Domain.Authors.Checkers;
using Library.Persistence.LibraryDb;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Core.Domain.Authors.Checkers;

public class PhoneMustBeUniqueChecker(
    LibraryDbContext dbContext) : IPhoneMustBeUniqueChecker
{
    public async Task<bool> IsUnique(string phone, CancellationToken cancellationToken)
    {
        return await dbContext.Authors.AllAsync(x => x.PhoneNumber != phone, cancellationToken);
    }
}
