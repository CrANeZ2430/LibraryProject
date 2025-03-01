using FluentValidation;
using FluentValidation.Results;
using Library.Core.Domain.Authors.Checkers;
using Library.Core.Domain.Authors.Data;
using Library.Core.Domain.Authors.Rules;

namespace Library.Core.Domain.Authors.Validators;

public class CreateAuthorDataValidator : AbstractValidator<CreateAuthorData>
{
    public CreateAuthorDataValidator(IEmailMustBeUniqueChecker emailMustBeUniqueChecker)
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(x => x.Email)
            .NotEmpty()
            .MaximumLength(50)
            .EmailAddress();
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
    }
}
