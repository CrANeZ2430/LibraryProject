namespace Library.Application.Domain.Books.Queries.GetBooks;

public record BookDto(
    Guid Id,
    string Title,
    string Description,
    AuthorDto[] Authors);
