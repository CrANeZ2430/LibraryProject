using Library.Core.Common.Validation;
using Library.Core.Domain.Authors.Models;
using Library.Core.Domain.Books.Data;
using Library.Core.Domain.Books.Validators;
using Library.Core.Exceptions;
using System.Threading.Tasks;

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

    public async Task Update(UpdateBookData data)
    {
        await ValidateAsync(new UpdateBookDataValidator(), data);

        Title = data.Title;
        Description = data.Description;
    }

    public async Task AssignAuthors(AssignAuthorsData data)
    {
        await ValidateAsync(new AssignAuthorsDataValidator(), data);

        foreach (var author in data.AuthorsToAssign)
            _authors.Add(BookAuthor.Create(Id, author.Id));
    }

    public async Task RemoveAuthors(RemoveAuthorsData data)
    {
        await ValidateAsync(new RemoveAuthorsDataValidator(), data);

        foreach (var author in data.AuthorsToRemove)
            _authors.Remove(_authors.First(x => x.AuthorId == author.Id));
    }
}
