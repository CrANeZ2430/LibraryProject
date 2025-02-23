using Library.Core.Domain.Authors.Common;
using Library.Core.Domain.Authors.Models;
using Library.Persistence.LibraryDb;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Core.Domain;

internal class AuthorsRepository(LibraryDbContext dbContext) : IAuthorsRepository
{
    public void Add(Author author)
    {
        dbContext.Add(author);
    }

    public void Delete(Author author)
    {
        dbContext.Remove(author);
    }

    public async Task<Author> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.Authors
            .Include(x => x.Books)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken) ?? throw new InvalidOperationException($"{nameof(Author)} was not found");
    }
}
