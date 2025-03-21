using Library.Core.Domain.Authors.Models;

namespace Library.Core.Domain.Books.Models;

public class BookAuthor
{
    private BookAuthor() { }

    private BookAuthor(
        Guid bookId, 
        Guid userId)
    {
        BookId = bookId;
        AuthorId = userId;
    }

    public Guid BookId { get; private set; }
    public Book Book { get; private set; }

    public Guid AuthorId { get; private set; }
    public Author Author { get; private set; }

    public static BookAuthor Create(Guid animalId, Guid ownerId)
    {
        return new BookAuthor(animalId, ownerId);
    }
}
