using Library.Core.Domain.Authors.Models;
using Library.Core.Domain.Books.Models;

namespace Library.Core.Domain.Authors.Common;

public interface IAuthorsRepository
{
    void Add(Author author);
    void Remove(Author author);
    Task<Author> GetById(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<Author>> GetByIds(Guid[] ids, CancellationToken cancellationToken);
}
