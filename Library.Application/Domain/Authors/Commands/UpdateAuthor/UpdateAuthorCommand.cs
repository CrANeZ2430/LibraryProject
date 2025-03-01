using MediatR;

namespace Library.Application.Domain.Authors.Commands.UpdateAuthor;

public record UpdateAuthorCommand(
    Guid AuthorId,
    string FirstName,
    string MiddleName,
    string LastName,
    string Email,
    string Phone) : IRequest;
