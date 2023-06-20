using FluentValidation;
using Microsoft.Extensions.Localization;
using Vculp.Api.Common.Rbac.Commands;
using Vculp.Api.Common.Validators;

namespace Vculp.Api.Rbac.Validators
{
    public class AddApplicationPermissionToRoleCommandValidator : CommandValidator<AddApplicationPermissionToRoleCommand>
    {
        public AddApplicationPermissionToRoleCommandValidator(IStringLocalizer<CommandValidatorMessages> stringLocalizer) 
            : base(stringLocalizer)
        {
            RuleFor(c => c.Body)
                .SetValidator(new AddApplicationPermissionToRoleCommandBodyValidator(stringLocalizer));
        }
    }

    public class AddApplicationPermissionToRoleCommandBodyValidator : CommandValidator<AddApplicationPermissionToRoleCommandBody>
    {
        public AddApplicationPermissionToRoleCommandBodyValidator(IStringLocalizer<CommandValidatorMessages> stringLocalizer)
            : base(stringLocalizer)
        {
            RuleFor(c => c.ApplicationPermissionId).Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.ApplicationPermissionId)]);
        }
    }
}
