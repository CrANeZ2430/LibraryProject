namespace Library.Core.Domain.Authors.Data;

public record CreateAuthorData(
    string FirstName,
    string LastName,
    string MiddleName,
    string Email,
    string Phone);
