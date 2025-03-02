using FluentValidation;
using Library.Core.Domain.Authors.Models;
using Library.Core.Domain.Books.Data;

namespace Library.Core.Domain.Books.Validators;

public class AssignAuthorsDataValidator : AbstractValidator<AssignAuthorsData>
{
    public AssignAuthorsDataValidator()
    {
        RuleFor(x => x.Authors)
            .NotEmpty()
            .WithMessage($"{nameof(Author)}s' number cannot cannot be 0.")
            .Must((data, authorsToRemove) => authorsToRemove.All(author =>
                !data.BookAuthors.Any(bookAuthor => bookAuthor.AuthorId == author.Id)))
            .WithMessage($"All {nameof(Author)}s to assign must not exist in the book's authors list.");
    }
}
