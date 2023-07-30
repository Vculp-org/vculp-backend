using System;
using FluentValidation;
using Microsoft.Extensions.Localization;
using Vculp.Api.Common.User.Commands;
using Vculp.Api.Common.Validators;
using Vculp.Extensions.String;

namespace Vculp.Api.User.Validators;

public class UpdateUserCommandValidator: CommandValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator(IStringLocalizer<CommandValidatorMessages> stringLocalizer) : base(stringLocalizer)
    {
        RuleFor(c => c.Body)
            .SetValidator(new UpdateUserRequestBodyValidator(stringLocalizer));
    }
}

public class UpdateUserRequestBodyValidator : CommandValidator<UpdateUserRequestBody>
{
    public UpdateUserRequestBodyValidator(IStringLocalizer<CommandValidatorMessages> stringLocalizer)
        : base(stringLocalizer)
    {
        When(q => string.IsNullOrWhiteSpace(q.EmailAddress), () =>
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
                .WithMessage(c => Localizer["UpdateUserCommandValidator_DateCannotBeInTheFuture", nameof(c.DateOfBirth)]);
        });

    }
}