using FluentValidation;
using Microsoft.Extensions.Localization;
using Vculp.Api.Common.Rbac.Commands;
using Vculp.Api.Common.Validators;

namespace Vculp.Api.Rbac.Validators
{
    public class UpdateRoleCommandValidator : CommandValidator<UpdateRoleCommand>
    {
        public UpdateRoleCommandValidator
        (
            IStringLocalizer<CommandValidatorMessages> stringLocalizer
        )
            : base(stringLocalizer)
        {
            RuleFor(v => v.Body.Name).Cascade(CascadeMode.Stop)
                 .NotEmpty()
                 .WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.Body.Name)])
                 .MaximumLength(50)
                 .WithMessage(c => Localizer["FieldExceedsMaximumLengthError", nameof(c.Body.Name), 50]);

            RuleFor(v => v.Body.Description).Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.Body.Description)])
                .MaximumLength(100)
                .WithMessage(c => Localizer["FieldExceedsMaximumLengthError", nameof(c.Body.Description), 100]);
        }
    }
}
