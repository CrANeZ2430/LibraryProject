namespace Library.API.Domain.Books.Records;

public record UpdateBookRequest(
    Guid BookId,
    string Title,
    string Description);
