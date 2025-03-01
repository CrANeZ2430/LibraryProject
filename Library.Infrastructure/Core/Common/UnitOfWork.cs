using Library.Core.Common.DbContext;
using Library.Persistence.LibraryDb;

namespace Library.Infrastructure.Core.Common;

internal class UnitOfWork(LibraryDbContext dbContext) : IUnitOfWork
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.SaveChangesAsync(cancellationToken);
    }
}
