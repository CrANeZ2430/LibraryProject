using MediatR;

namespace Library.Application.Domain.Books.Commands.UpdateBook;

public record UpdateBookCommand(
    Guid BookId,
    string Title,
    string Description) : IRequest;
