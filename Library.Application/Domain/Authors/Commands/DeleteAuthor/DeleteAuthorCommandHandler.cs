using Library.Core.Common.DbContext;
using Library.Core.Domain.Authors.Common;
using MediatR;

namespace Library.Application.Domain.Authors.Commands.DeleteAuthor;

class DeleteAuthorCommandHandler(
    IAuthorsRepository authorsRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteAuthorCommand>
{
    public async Task Handle(
        DeleteAuthorCommand command, 
        CancellationToken cancellationToken)
    {
        var author = await authorsRepository.GetById(command.AuthorId, cancellationToken);
        authorsRepository.Remove(author);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
