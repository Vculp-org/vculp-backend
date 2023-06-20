using FluentValidation;
using Microsoft.Extensions.Localization;
using Vculp.Api.Common.Notifications.Commands;
using Vculp.Api.Common.Validators;

namespace Vculp.Api.Notifications.Validators
{
    public class EmailBillingDocumentToCustomerCommandValidator : CommandValidator<EmailBillingDocumentToCustomerCommand>
    {
        public EmailBillingDocumentToCustomerCommandValidator(IStringLocalizer<CommandValidatorMessages> stringLocalizer) : base(stringLocalizer)
        {
            RuleFor(c => c.RecipientEmail).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.RecipientEmail)]);

            RuleFor(c => c.BillingDocumentFileId).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.BillingDocumentFileId)]);

            RuleFor(c => c.BillingDocumentNumber).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.BillingDocumentNumber)]);

            RuleFor(c => c.BillingDocumentType).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.BillingDocumentType)]);

        }
    }
}
