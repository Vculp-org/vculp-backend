using FluentValidation;
using Microsoft.Extensions.Localization;
using Vculp.Api.Common.Notifications.Commands;
using Vculp.Api.Common.Validators;

namespace Vculp.Api.Notifications.Validators
{
    public class SendVwdApprovedByVetNotificationCommandValidator : CommandValidator<SendVwdApprovedByVetNotificationCommand>
    {
        public SendVwdApprovedByVetNotificationCommandValidator(IStringLocalizer<CommandValidatorMessages> stringLocalizer)
            : base(stringLocalizer)
        {

            RuleFor(c => c.ScriptNumber).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.ScriptNumber)]);

            RuleFor(c => c.VwdId).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.VwdId)]);

            RuleFor(c => c.VwdEmailAddress).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.VwdEmailAddress)]);

        }
    }
}