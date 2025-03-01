namespace Library.API.Domain.Books.Records;

public record RemoveAuthorsRequest(
    Guid BookId,
    Guid[] AuthorIds);