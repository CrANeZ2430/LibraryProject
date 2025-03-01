using Library.Core.Domain.Authors.Data;
using Library.Core.Domain.Books.Models;

namespace Library.Core.Domain.Authors.Models;

public class Author
{
    private readonly List<BookAuthor> _books = new();

    private Author() { }

    internal Author(Guid id, string firstName, string lastName, string email)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public IReadOnlyCollection<BookAuthor> Books => _books.AsReadOnly();

    public static Author Create(CreateAuthorData data)
    {
        return new Author(
            Guid.NewGuid(),
            data.FirstName,
            data.LastName,
            data.Email);
    }

    public void Update(UpdateAuthorData data)
    {
        FirstName = data.FirstName;
        LastName = data.LastName;
        Email = data.Email;
    }
}
