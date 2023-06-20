using FluentValidation;
using Microsoft.Extensions.Localization;
using Vculp.Api.Common.Notifications.Commands;
using Vculp.Api.Common.Validators;

namespace Vculp.Api.Notifications.Validators
{
    public class SendOrderUnblockedEmailNotificationCommandValidator : CommandValidator<SendOrderUnblockedEmailNotificationCommand>
    {
        public SendOrderUnblockedEmailNotificationCommandValidator(IStringLocalizer<CommandValidatorMessages> stringLocalizer) : base(stringLocalizer)
        {
            RuleFor(c => c.OrderNumber).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.OrderNumber)]);

        }
    }
}