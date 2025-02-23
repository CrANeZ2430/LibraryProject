namespace Library.API.Domain.Authors.Records;

public record CreateAuthorRequest(
    string FirstName,
    string LastName,
    string Email);
