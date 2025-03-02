using MediatR;

namespace Library.Application.Domain.Authors.Commands.UpdateAuthor;

public record UpdateAuthorCommand(
    Guid AuthorId,
    string FirstName,
    string LastName,
    string? MiddleName,
    string Email,
    string PhoneNumber) : IRequest;
