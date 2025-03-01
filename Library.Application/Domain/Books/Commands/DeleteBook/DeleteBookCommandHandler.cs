using Library.Core.Common.DbContext;
using Library.Core.Domain.Books.Common;
using MediatR;

namespace Library.Application.Domain.Books.Commands.DeleteBook;

public class DeleteBookCommandHandler(
    IBooksRepository booksRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteBookCommand>
{
    public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await booksRepository.GetById(request.BookId, cancellationToken);
        booksRepository.Delete(book);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
