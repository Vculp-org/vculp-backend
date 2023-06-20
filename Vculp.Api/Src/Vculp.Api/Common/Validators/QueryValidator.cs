using System;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Vculp.Api.Common.Validators
{
    public abstract class QueryValidator<T> : AbstractValidator<T>
    {
        public QueryValidator(IStringLocalizer<QueryValidatorMessages> stringLocalizer)
        {
            Localizer = stringLocalizer ?? throw new ArgumentNullException(nameof(stringLocalizer));
        }

        protected IStringLocalizer<QueryValidatorMessages> Localizer { get; }
    }
}
