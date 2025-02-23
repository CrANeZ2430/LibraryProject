namespace Library.API.Domain.Books.Records;

public record CreateBookRequest(
    string Title,
    string Description);
