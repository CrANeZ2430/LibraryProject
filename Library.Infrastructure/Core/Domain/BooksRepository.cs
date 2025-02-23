using Library.Core.Domain.Books.Common;
using Library.Core.Domain.Books.Models;
using Library.Persistence.LibraryDb;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Core.Domain;

internal class BooksRepository(LibraryDbContext dbContext) : IBooksRepository
{
    public void Add(Book book)
    {
        dbContext.Add(book);
    }

    public void Delete(Book book)
    {
        dbContext.Remove(book);
    }

    public async Task<Book> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.Books
            .Include(x => x.Authors)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken) ?? throw new InvalidOperationException($"{nameof(Book)} was not found");
    }
}
