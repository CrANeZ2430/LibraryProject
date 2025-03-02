namespace Library.Application.Domain.Authors.Queries.GetAuthors;

public record AuthorDto(
    Guid Id,
    string FirstName,
    string LastName,
    string? MiddleName,
    string Email,
    string PhoneNumber,
    BookDto[] Books);
