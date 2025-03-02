using Library.Core.Common.DbContext;
using Library.Core.Domain.Authors.Checkers;
using Library.Core.Domain.Authors.Common;
using Library.Core.Domain.Authors.Data;
using Library.Core.Domain.Authors.Models;
using MediatR;

namespace Library.Application.Domain.Authors.Commands.CreateAuthor;

public class CreateAuthorCommandHandler(
    IUnitOfWork unitOfWork,
    IAuthorsRepository authorsRepository,
    IEmailMustBeUniqueChecker emailMustBeUniqueChecker,
    IPhoneMustBeUniqueChecker phoneMustBeUniqueChecker) 
    : IRequestHandler<CreateAuthorCommand, Guid>
{
    public async Task<Guid> Handle(
        CreateAuthorCommand command, 
        CancellationToken cancellationToken)
    {
        var data = new CreateAuthorData(
            command.FirstName,
            command.LastName,
            command.MiddleName!,
            command.Email,
            command.PhoneNumber);

        var author = await Author.Create(
            data, 
            emailMustBeUniqueChecker, 
            phoneMustBeUniqueChecker);

        authorsRepository.Add(author);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return author.Id;
    }
}
