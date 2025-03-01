namespace Library.API.Domain.Books.Records;

public record AssignAuthorsRequest(
    Guid BookId,
    Guid[] AuthorIds);