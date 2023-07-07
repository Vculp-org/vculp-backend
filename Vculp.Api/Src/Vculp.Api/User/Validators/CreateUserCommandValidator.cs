using FluentValidation;
using Microsoft.Extensions.Localization;
using Vculp.Api.Common.User;
using Vculp.Api.Common.Validators;

namespace Vculp.Api.User.Validators;

public class CreateUserCommandValidator: CommandValidator<CreateUserCommand>
{
    public CreateUserCommandValidator(IStringLocalizer<CommandValidatorMessages> stringLocalizer) : base(stringLocalizer)
    {
        RuleFor(c => c.FirstName).Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.FirstName)]);

        RuleFor(c => c.LastName).Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.LastName)]);

        RuleFor(c => c.EmailAddress).Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.EmailAddress)]);
        
        RuleFor(c => c.MobileNumber).Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.MobileNumber)]);

        RuleFor(c => c.ExternalUserId).Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.ExternalUserId)]);


    }
}