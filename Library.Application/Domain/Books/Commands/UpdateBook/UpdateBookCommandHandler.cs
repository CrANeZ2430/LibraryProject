using Library.Core.Common.DbContext;
using Library.Core.Domain.Books.Common;
using Library.Core.Domain.Books.Data;
using MediatR;

namespace Library.Application.Domain.Books.Commands.UpdateBook;

public class UpdateBookCommandHandler(
    IBooksRepository booksRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateBookCommand>
{
    public async Task Handle(
        UpdateBookCommand request, 
        CancellationToken cancellationToken)
    {
        var book = await booksRepository.GetById(request.BookId, cancellationToken);
        var data = new UpdateBookData(request.Title, request.Description);
        book.Update(data);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
