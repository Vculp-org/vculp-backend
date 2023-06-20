using FluentValidation;
using Microsoft.Extensions.Localization;
using Vculp.Api.Common.Notifications.Commands;
using Vculp.Api.Common.Validators;

namespace Vculp.Api.Notifications.Validators
{
    public class SendOrderCreatedEmailToCustomerCommandValidator : CommandValidator<SendOrderCreatedEmailToCustomerCommand>
    {
        public SendOrderCreatedEmailToCustomerCommandValidator(IStringLocalizer<CommandValidatorMessages> stringLocalizer) : base(stringLocalizer)
        {
            RuleFor(c => c.OrderNumber).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.OrderNumber)]);

            RuleFor(c => c.To).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.To)]);

            RuleFor(c => c.ToName).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.ToName)]);

        }
    }
}