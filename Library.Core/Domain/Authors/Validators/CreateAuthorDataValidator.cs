using FluentValidation;
using FluentValidation.Results;
using Library.Core.Domain.Authors.Checkers;
using Library.Core.Domain.Authors.Data;
using Library.Core.Domain.Authors.Rules;
using System.Text.RegularExpressions;

namespace Library.Core.Domain.Authors.Validators;

public class CreateAuthorDataValidator : AbstractValidator<CreateAuthorData>
{
    public CreateAuthorDataValidator(
        IEmailMustBeUniqueChecker emailMustBeUniqueChecker, 
        IPhoneMustBeUniqueChecker phoneMustBeUniqueChecker)
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage($"{nameof(CreateAuthorData.FirstName)} is required.")
            .MaximumLength(50).WithMessage($"{nameof(CreateAuthorData.FirstName)} must be less than 50 characters");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage($"{nameof(CreateAuthorData.LastName)} is required.")
            .MaximumLength(50).WithMessage($"{nameof(CreateAuthorData.LastName)} must be less than 50 characters.");

        RuleFor(x => x.MiddleName)
            .MaximumLength(50).WithMessage($"{nameof(CreateAuthorData.MiddleName)} must be less than 20 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage($"{nameof(CreateAuthorData.Email)} is required.")
            .MaximumLength(50).WithMessage($"{nameof(CreateAuthorData.Email)} must be less than 20 characters.")
            .EmailAddress().WithMessage($"{nameof(CreateAuthorData.Email)} is not valid.");
        RuleFor(x => x.Email)
            .CustomAsync(async (email, context, cancellationToken) =>
            {
                var checkResult = await new EmailMustBeUniqueBusinessRule(email, emailMustBeUniqueChecker).CheckAsync(cancellationToken);

                if (checkResult.IsSuccess) return;

                foreach (var error in checkResult.Errors)
                {
                    context.AddFailure(new ValidationFailure(nameof(CreateAuthorData.Email), error));
                }
            });

        RuleFor(p => p.PhoneNumber)
            .NotEmpty().WithMessage($"{nameof(CreateAuthorData.PhoneNumber)} is required.")
            .MaximumLength(20).WithMessage($"{nameof(CreateAuthorData.PhoneNumber)} must be less than 20 characters.")
            .Matches(new Regex(@"(\+\d{1,3} )?((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}")).WithMessage($"{nameof(CreateAuthorData.PhoneNumber)} is not valid");
        RuleFor(p => p.PhoneNumber)
            .CustomAsync(async (phoneNumber, context, cancellationToken) =>
            {
                var checkResult = await new PhoneMustBeUniqueBusinessRule(phoneNumber, phoneMustBeUniqueChecker).CheckAsync(cancellationToken);
            });
    }
}
