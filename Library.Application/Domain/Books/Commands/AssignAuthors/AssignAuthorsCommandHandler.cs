using Library.Core.Common;
using Library.Core.Domain.Authors.Common;
using Library.Core.Domain.Books.Common;
using MediatR;

namespace Library.Application.Domain.Books.Commands.AssignAuthors;

public class AssignAuthorsCommandHandler(
    IUnitOfWork unitOfWork,
    IBooksRepository booksRepository,
    IAuthorsRepository authorsRepository) : IRequestHandler<AssignAuthorsCommand>
{
    public async Task Handle(AssignAuthorsCommand request, CancellationToken cancellationToken)
    {
        var book = await booksRepository.GetById(request.BookId, cancellationToken);
        var author = await authorsRepository.GetById(request.AuthorId, cancellationToken);
        book.AssignAuthor(author);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
