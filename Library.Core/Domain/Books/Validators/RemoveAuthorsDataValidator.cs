using FluentValidation;
using Library.Core.Domain.Authors.Models;
using Library.Core.Domain.Books.Models;

namespace Library.Core.Domain.Books.Validators;

public class RemoveAuthorsDataValidator : AbstractValidator<(IEnumerable<Author> authorsToRemove, Book book)>
{
    public RemoveAuthorsDataValidator()
    {
        RuleFor(x => x)
            .Must(x => x.authorsToRemove.Count() < x.book.Authors.Count)
            .WithMessage("The number of authors to remove must be less than the number of the book's authors.");
    }
}
