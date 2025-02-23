using Library.Core.Domain.Books.Models;

namespace Library.Core.Domain.Books.Common;

public interface IBooksRepository
{
    void Add(Book book);
    void Delete(Book book);
    Task<Book> GetById(Guid id, CancellationToken cancellationToken);
}
