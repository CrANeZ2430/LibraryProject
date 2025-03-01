using Library.Core.Common.DbContext;
using Library.Core.Domain.Authors.Common;
using Library.Core.Domain.Authors.Data;
using MediatR;

namespace Library.Application.Domain.Authors.Commands.UpdateAuthor;

public class UpdateAuthorCommandHandler(
    IAuthorsRepository authorsRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateAuthorCommand>
{
    public async Task Handle(
        UpdateAuthorCommand request, 
        CancellationToken cancellationToken)
    {
        var author = await authorsRepository.GetById(request.AuthorId, cancellationToken);
        var data = new UpdateAuthorData(request.FirstName, request.LastName, request.Email);
        author.Update(data);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
