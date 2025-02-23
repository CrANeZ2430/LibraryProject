using Library.Core.Domain.Authors.Models;
using Library.Core.Domain.Books.Data;

namespace Library.Core.Domain.Books.Models;

public class Book
{
    private readonly List<BookAuthor> _authors = new();
    private Book() { }

    public Book(Guid id, string title, string description)
    {
        Id = id;
        Title = title;
        Description = description;
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public IReadOnlyCollection<BookAuthor> Authors => _authors.AsReadOnly();

    public static Book Create(CreateBookData data)
    {
        return new Book(
            Guid.NewGuid(), 
            data.Title, 
            data.Description);
    }

    public void AssignAuthor(Author author)
    {
        if (_authors.Any(x => x.AuthorId == author.Id))
        {
            return;
        }

        _authors.Add(BookAuthor.Create(Id, author.Id));
    }
}
