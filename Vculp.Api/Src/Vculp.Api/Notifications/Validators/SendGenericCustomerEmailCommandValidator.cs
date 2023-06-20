using FluentValidation;
using Microsoft.Extensions.Localization;
using Vculp.Api.Common.Notifications.Commands;
using Vculp.Api.Common.Validators;

namespace Vculp.Api.Notifications.Validators
{
    public class SendGenericCustomerEmailCommandValidator : CommandValidator<SendGenericCustomerEmailCommand>
    {
        public SendGenericCustomerEmailCommandValidator(IStringLocalizer<CommandValidatorMessages> stringLocalizer)
            : base(stringLocalizer)
        {
            RuleFor(c => c.FirstName).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.FirstName)]);

            RuleFor(c => c.Subject).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.Subject)]);

            RuleFor(c => c.RecipientEmail).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.RecipientEmail)]);
            
            RuleFor(c => c.Message).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.Message)]);
            
            RuleFor(c => c.FromName).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.FromName)]);

            RuleFor(c => c.FromEmail).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.FromEmail)]);

        }
    }
}