using Library.Core.Common.Validation;
using Library.Core.Domain.Authors.Checkers;
using Library.Core.Domain.Authors.Data;
using Library.Core.Domain.Authors.Validators;
using Library.Core.Domain.Books.Models;

namespace Library.Core.Domain.Authors.Models;

public class Author : Entity
{
    private readonly List<BookAuthor> _books = new();

    private Author() { }

    internal Author(
        Guid id, 
        string firstName, 
        string lastName, 
        string middleName, 
        string email, 
        string phoneNumber)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string? MiddleName { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public IReadOnlyCollection<BookAuthor> Books => _books.AsReadOnly();

    public static async Task<Author> Create(CreateAuthorData data, IEmailMustBeUniqueChecker emailMustBeUniqueChecker)
    {
        await ValidateAsync(new CreateAuthorDataValidator(emailMustBeUniqueChecker), data);

        return new Author(
            Guid.NewGuid(),
            data.FirstName,
            data.LastName,
            data.MiddleName,
            data.Email,
            data.PhoneNumber);
    }

    public void Update(UpdateAuthorData data)
    {
        FirstName = data.FirstName;
        LastName = data.LastName;
        MiddleName = data.MiddleName;
        Email = data.Email;
        PhoneNumber = data.PhoneNumber;
    }
}
