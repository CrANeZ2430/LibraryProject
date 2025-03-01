using Library.Core.Domain.Authors.Checkers;
using Library.Persistence.LibraryDb;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Core.Domain.Authors.Checkers;

public class EmailMustBeUniqueChecker(
    LibraryDbContext dbContext) : IEmailMustBeUniqueChecker
{
    public async Task<bool> IsUnique(string email, CancellationToken cancellationToken = default)
    {
        return await dbContext.Authors.AllAsync(x => x.Email != email, cancellationToken);
    }
}
