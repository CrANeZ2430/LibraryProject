using Library.Core.Common.Validation;
using Library.Core.Domain.Authors.Models;
using Library.Core.Domain.Books.Data;
using Library.Core.Domain.Books.Validators;

namespace Library.Core.Domain.Books.Models;

public class Book : Entity
{
    private readonly List<BookAuthor> _authors = new();
    private Book() { }

    public Book(
        Guid id, 
        string title, 
        string description)
    {
        Id = id;
        Title = title;
        Description = description;
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public IReadOnlyCollection<BookAuthor> Authors => _authors.AsReadOnly();

    public static async Task<Book> Create(CreateBookData data)
    {
        await ValidateAsync(new CreateBookDataValidator(), data);

        return new Book(
            Guid.NewGuid(), 
            data.Title, 
            data.Description);
    }

    public void Update(UpdateBookData data)
    {
        Title = data.Title;
        Description = data.Description;
    }

    //public void AssignAuthor(Author author)
    //{
    //    if (_authors.Any(x => x.AuthorId == author.Id))
    //    {
    //        return;
    //    }

    //    _authors.Add(BookAuthor.Create(Id, author.Id));
    //}

    // Finish this method
    public void AssignAuthors(IList<Author> authors)
    {
        foreach (var author in authors)
            _authors.Add(BookAuthor.Create(Id, author.Id));
    }

    // Finish this method
    public void RemoveAuthors(IList<Author> authors)
    {
        foreach (var author in authors)
            _authors.Remove(_authors.First(x => x.AuthorId == author.Id));
    }
}
