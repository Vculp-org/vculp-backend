using System.Linq;
using FluentValidation;
using Microsoft.Extensions.Localization;
using Vculp.Api.Common.Notifications.Commands;
using Vculp.Api.Common.Validators;

namespace Vculp.Api.Notifications.Validators
{
    public class DistributeBulkNotificationCommandValidator : CommandValidator<DistributeBulkNotificationCommand>
    {
        public DistributeBulkNotificationCommandValidator(IStringLocalizer<CommandValidatorMessages> stringLocalizer) : base(stringLocalizer)
        {
            RuleFor(c => c.Counties).Cascade(CascadeMode.Stop)
                .Must(c => c == null || c.Count() > 0)
                .WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.Counties)]);

            RuleFor(c => c.Categories).Cascade(CascadeMode.Stop)
                .Must(c => c == null || c.Count() > 0)
                .WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.Categories)]);

            RuleFor(c => c.Species).Cascade(CascadeMode.Stop)
                .Must(c => c == null || c.Count() > 0)
                .WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.Species)]);
        }
    }
}
