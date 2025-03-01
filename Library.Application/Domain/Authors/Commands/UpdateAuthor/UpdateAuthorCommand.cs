using MediatR;

namespace Library.Application.Domain.Authors.Commands.UpdateAuthor;

public record UpdateAuthorCommand(
    Guid AuthorId,
    string FirstName,
    string LastName,
    string Email) : IRequest;
