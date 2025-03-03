using FluentValidation;
using Library.Core.Domain.Authors.Models;
using Library.Core.Domain.Books.Data;

namespace Library.Core.Domain.Books.Validators;

public class RemoveAuthorsDataValidator : AbstractValidator<RemoveAuthorsData>
{
    public RemoveAuthorsDataValidator()
    {
        RuleFor(x => x.AuthorsToRemove)
            .NotEmpty()
            .WithMessage($"{nameof(Author)}s' number cannot cannot be 0.");

        RuleFor(x => x)
            .Must(x => x.AuthorsToRemove.Count() < x.Quantity)
            .WithMessage($"{nameof(Author)}s' number must be less than the number of the book's authors.")
            .Must(x => x.AuthorsToRemove.All(author => x.BookAuthors.Any(bookAuthor => bookAuthor.AuthorId == author.Id)))
            .WithMessage($"All {nameof(Author)}s to remove must exist in the book's authors list.");
    }
}
