using System;
using FluentValidation;
using Microsoft.Extensions.Localization;
using Vculp.Api.Common.Notifications.Commands;
using Vculp.Api.Common.Validators;
using Vculp.Extensions.String;

namespace Vculp.Api.Notifications.Validators
{
    public class SendSmsMessageCommandValidator : CommandValidator<SendSmsMessageCommand>
    {
        public SendSmsMessageCommandValidator(IStringLocalizer<CommandValidatorMessages> stringLocalizer)
            : base(stringLocalizer)
        {
            RuleFor(c => c.Recipient).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.Recipient)]);


            RuleFor(c => c.MessageText).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.MessageText)]);

            When(c => !string.IsNullOrWhiteSpace(c.ScheduleDate), () =>
            {
                RuleFor(c => c.ScheduleDate).Cascade(CascadeMode.Stop)
                    .Must(BeAValidIso8601DateTime)
                        .WithMessage(c => Localizer["SendSmsMessageCommandValidator_InvalidScheduleDate", c.ScheduleDate]);
            });
        }

        private bool BeAValidIso8601DateTime(string timestring)
        {
            if (string.IsNullOrWhiteSpace(timestring))
            {
                return false;
            }

            return timestring.TryParseIso8601DateTimeToUtc(out DateTime _);
        }
    }
}