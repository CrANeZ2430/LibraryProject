namespace Library.Core.Domain.Authors.Data;

public record UpdateAuthorData(
    string FirstName,
    string LastName,
    string MiddleName,
    string Email,
    string PhoneNumber);
