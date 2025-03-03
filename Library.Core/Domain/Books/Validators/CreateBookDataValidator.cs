using FluentValidation;
using Library.Core.Domain.Books.Data;

namespace Library.Core.Domain.Books.Validators;

public class CreateBookDataValidator : AbstractValidator<CreateBookData>
{
    public CreateBookDataValidator()
    {
        RuleFor(data => data.Title)
            .NotEmpty().WithMessage($"{nameof(CreateBookData.Title)} is required.")
            .MaximumLength(50).WithMessage($"{nameof(CreateBookData.Title)} must be less than 50 characters.");

        RuleFor(data => data.Description)
            .NotEmpty().WithMessage($"{nameof(CreateBookData.Description)} is required.")
            .MaximumLength(2000).WithMessage($"{nameof(CreateBookData.Description)} must be less than 2000 characters.");
    }
}
