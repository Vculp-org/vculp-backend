using FluentValidation;
using Microsoft.Extensions.Localization;
using Vculp.Api.Common.Notifications.Commands;
using Vculp.Api.Common.Validators;

namespace Vculp.Api.Notifications.Validators
{
    public class SendVwdCancelledByVetNotificationCommandValidator : CommandValidator<SendVwdCancelledByVetNotificationCommand>
    {
        public SendVwdCancelledByVetNotificationCommandValidator(IStringLocalizer<CommandValidatorMessages> stringLocalizer)
            : base(stringLocalizer)
        {
          
            RuleFor(c => c.ScriptNumber).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.ScriptNumber)]);
            
        }
    }
}