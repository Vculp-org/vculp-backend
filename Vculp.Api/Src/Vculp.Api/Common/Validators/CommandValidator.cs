using System;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Vculp.Api.Common.Validators
{
    public abstract class CommandValidator<T> : AbstractValidator<T>
    {
        public CommandValidator(IStringLocalizer<CommandValidatorMessages> stringLocalizer)
        {
            Localizer = stringLocalizer ?? throw new ArgumentNullException(nameof(stringLocalizer));
        }

        protected IStringLocalizer<CommandValidatorMessages> Localizer { get; }
    }
}
