using Library.Core.Common.DbContext;
using Library.Core.Domain.Authors.Common;
using MediatR;

namespace Library.Application.Domain.Authors.Commands.DeleteAuthor;

class DeleteAuthorCommandHandler(
    IAuthorsRepository authorsRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteAuthorCommand>
{
    public async Task Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await authorsRepository.GetById(request.AuthorId, cancellationToken);
        authorsRepository.Delete(author);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
