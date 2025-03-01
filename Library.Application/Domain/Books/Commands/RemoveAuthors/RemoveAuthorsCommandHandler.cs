using Library.Core.Common.DbContext;
using Library.Core.Domain.Authors.Common;
using Library.Core.Domain.Books.Common;
using MediatR;

namespace Library.Application.Domain.Books.Commands.RemoveAuthors;

public class RemoveAuthorsCommandHandler(
    IAuthorsRepository authorsRepository,
    IBooksRepository booksRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<RemoveAuthorsCommand>
{
    public async Task Handle(
        RemoveAuthorsCommand request, 
        CancellationToken cancellationToken)
    {
        var book = await booksRepository.GetById(request.BookId, cancellationToken);
        var authors = await authorsRepository.GetByIds(request.AuthorIds, cancellationToken);
        book.RemoveAuthors(authors);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
