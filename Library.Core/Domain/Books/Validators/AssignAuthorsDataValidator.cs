using FluentValidation;
using Library.Core.Domain.Authors.Models;
using Library.Core.Domain.Books.Data;

namespace Library.Core.Domain.Books.Validators;

public class AssignAuthorsDataValidator : AbstractValidator<AssignAuthorsData>
{
    public AssignAuthorsDataValidator()
    {
        RuleFor(x => x.AuthorsToAssign)
            .NotEmpty()
            .WithMessage($"{nameof(Author)}s' number cannot cannot be 0.");

        RuleFor(x => x)
            .Must(x => x.AuthorsToAssign.All(author =>
                !x.BookAuthors.Any(bookAuthor => bookAuthor.AuthorId == author.Id)))
            .WithMessage($"All {nameof(Author)}s to assign must not exist in the book's authors list.");
    }
}
