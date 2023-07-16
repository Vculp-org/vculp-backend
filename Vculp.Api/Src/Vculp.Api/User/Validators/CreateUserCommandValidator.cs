using System;
using FluentValidation;
using Microsoft.Extensions.Localization;
using Vculp.Api.Common.User.Commands;
using Vculp.Api.Common.Validators;
using Vculp.Extensions.String;

namespace Vculp.Api.User.Validators;

public class CreateUserCommandValidator: CommandValidator<CreateUserCommand>
{
    public CreateUserCommandValidator(IStringLocalizer<CommandValidatorMessages> stringLocalizer) : base(stringLocalizer)
    {
        RuleFor(c => c.FirstName).Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.FirstName)]);

        RuleFor(c => c.LastName).Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.LastName)]);

        When(q => !string.IsNullOrWhiteSpace(q.EmailAddress), () =>
        {
            RuleFor(c => c.EmailAddress).Cascade(CascadeMode.Stop)
                .EmailAddress()
                .WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.EmailAddress)]);
        });
        
        When(q => !string.IsNullOrWhiteSpace(q.DateOfBirth), () =>
        {
            RuleFor(c => c.DateOfBirth).Cascade(CascadeMode.Stop)
                .Must((time) => time.TryParseIso8601DateTimeToUtc(out var date))
                .WithMessage(c => Localizer["FieldIsNotValidISO8601Date", nameof(c.DateOfBirth)])
                .Must(s => s.TryParseIso8601DateTimeToUtc(out var date) && date <= DateTime.UtcNow)
                .WithMessage(c => Localizer["CreateUserCommandValidator_DateCannotBeInTheFuture", nameof(c.DateOfBirth)]);
        });
        
        RuleFor(c => c.MobileNumber).Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.MobileNumber)]);

        RuleFor(c => c.ExternalUserId).Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.ExternalUserId)]);
    }
}