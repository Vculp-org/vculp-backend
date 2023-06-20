using FluentValidation;
using Microsoft.Extensions.Localization;
using Vculp.Api.Common.Rbac.Commands;
using Vculp.Api.Common.Validators;

namespace Vculp.Api.Rbac.Validators
{
    public class CreateRoleCommandValidator : CommandValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator
        (          
            IStringLocalizer<CommandValidatorMessages> stringLocalizer
        )
            : base(stringLocalizer)
        {
            RuleFor(v => v.Name).Cascade(CascadeMode.Stop)
                 .NotEmpty()
                 .WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.Name)])
                 .MaximumLength(50)
                 .WithMessage(c => Localizer["FieldExceedsMaximumLengthError", nameof(c.Name), 50]);

            RuleFor(v => v.Description).Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.Description)])
                .MaximumLength(100)
                .WithMessage(c => Localizer["FieldExceedsMaximumLengthError", nameof(c.Description), 100]);


        }
    }
}
