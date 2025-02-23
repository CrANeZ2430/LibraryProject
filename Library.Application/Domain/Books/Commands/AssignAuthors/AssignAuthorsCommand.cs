using MediatR;

namespace Library.Application.Domain.Books.Commands.AssignAuthors;

public record AssignAuthorsCommand(
    Guid BookId,
    Guid AuthorId) : IRequest;
