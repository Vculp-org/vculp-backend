using System;
using Microsoft.Extensions.Localization;

namespace Vculp.Api.Application.Services.Common
{
    public abstract class CommandHandler
    {
        public CommandHandler(IStringLocalizer<CommandHandlerErrors> stringLocalizer)
        {
            Localizer = stringLocalizer ?? throw new ArgumentNullException(nameof(stringLocalizer));
        }

        protected IStringLocalizer<CommandHandlerErrors> Localizer { get; }
    }
}
