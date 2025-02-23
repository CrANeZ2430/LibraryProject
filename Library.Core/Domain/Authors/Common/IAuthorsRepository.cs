using Library.Core.Domain.Authors.Models;

namespace Library.Core.Domain.Authors.Common;

public interface IAuthorsRepository
{
    void Add(Author author);
    void Delete(Author author);
    Task<Author> GetById(Guid id, CancellationToken cancellationToken);
}
