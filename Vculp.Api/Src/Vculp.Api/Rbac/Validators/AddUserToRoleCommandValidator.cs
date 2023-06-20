using FluentValidation;
using Microsoft.Extensions.Localization;
using Vculp.Api.Common.Rbac.Commands;
using Vculp.Api.Common.Validators;

namespace Vculp.Api.Rbac.Validators
{
    public class AddUserToRoleCommandValidator : CommandValidator<AddUserToRoleCommand>
    {
        public AddUserToRoleCommandValidator
        (
           IStringLocalizer<CommandValidatorMessages> stringLocalizer
        )
           : base(stringLocalizer)
        {
            RuleFor(v => v.Body.UserId).Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.Body.UserId)]);

            
        }
    }
}
