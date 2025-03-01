using MediatR;

namespace Library.Application.Domain.Books.Commands.RemoveAuthors;

public record RemoveAuthorsCommand(
    Guid BookId,
    Guid[] AuthorIds) : IRequest;
