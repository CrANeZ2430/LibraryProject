using FluentValidation;
using Library.Core.Domain.Books.Data;

namespace Library.Core.Domain.Books.Validators;

public class CreateBookDataValidator : AbstractValidator<CreateBookData>
{
    public CreateBookDataValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(2000);
    }
}
