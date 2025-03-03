using FluentValidation.Results;
using Library.Core.Domain.Authors.Common;
using Library.Core.Domain.Authors.Models;
using Library.Core.Domain.Books.Models;
using Library.Core.Exceptions;
using Library.Persistence.LibraryDb;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Core.Domain.Authors.Common;

internal class AuthorsRepository(LibraryDbContext dbContext) : IAuthorsRepository
{
    public void Add(Author author)
    {
        dbContext.Add(author);
    }

    public void Remove(Author author)
    {
        dbContext.Remove(author);
    }

    public async Task<Author> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.Authors
            .Include(x => x.Books)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken) ?? throw new NotFoundException($"{nameof(Author)} was not found.");
    }

    public async Task<IEnumerable<Author>> GetByIds(Guid[] ids, CancellationToken cancellationToken)
    {
        if (ids.Distinct().Count() != ids.Count())
            throw new BadRequestException($"Two identical {nameof(Author)}s cannot be added.");

       var authors = await dbContext.Authors
            .Include(x => x.Books)
            .Where(x => ids.Contains(x.Id))
            .ToArrayAsync(cancellationToken);

        if (authors.Length < ids.Length)
            throw new NotFoundException($"{nameof(Author)} or more was not found.");

            return authors;
    }
}
