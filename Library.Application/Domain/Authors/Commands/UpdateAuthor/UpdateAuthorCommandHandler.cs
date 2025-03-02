using Library.Core.Common.DbContext;
using Library.Core.Domain.Authors.Checkers;
using Library.Core.Domain.Authors.Common;
using Library.Core.Domain.Authors.Data;
using MediatR;

namespace Library.Application.Domain.Authors.Commands.UpdateAuthor;

public class UpdateAuthorCommandHandler(
    IAuthorsRepository authorsRepository,
    IUnitOfWork unitOfWork,
    IEmailMustBeUniqueChecker emailMustBeUniqueChecker,
    IPhoneMustBeUniqueChecker phoneMustBeUniqueChecker) 
    : IRequestHandler<UpdateAuthorCommand>
{
    public async Task Handle(
        UpdateAuthorCommand command,
        CancellationToken cancellationToken)
    {
        var author = await authorsRepository.GetById(command.AuthorId, cancellationToken);
        var data = new UpdateAuthorData(
            command.FirstName, 
            command.LastName, 
            command.MiddleName!, 
            command.Email, 
            command.PhoneNumber);

        await author.Update(data, emailMustBeUniqueChecker, phoneMustBeUniqueChecker);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
