using System;
using FluentValidation;
using Microsoft.Extensions.Localization;
using Vculp.Api.Common.FavoriteRegion.Commands;
using Vculp.Api.Common.User.Commands;
using Vculp.Api.Common.Validators;
using Vculp.Extensions.String;

namespace Vculp.Api.User.Validators;

public class UpdateFavortieRegionCommandValidator : CommandValidator<UpdateFavoriteRegionCommand>
{
    public UpdateFavortieRegionCommandValidator(IStringLocalizer<CommandValidatorMessages> stringLocalizer) : base(stringLocalizer)
    {
        RuleFor(c => c.Body)
            .SetValidator(new UpdateFavortieRegionRequestBodyValidator(stringLocalizer));
    }
}

public class UpdateFavortieRegionRequestBodyValidator : CommandValidator<UpdateFavoriteRegionBody>
{
    public UpdateFavortieRegionRequestBodyValidator(IStringLocalizer<CommandValidatorMessages> stringLocalizer)
        : base(stringLocalizer)
    {
        RuleFor(c => c.Name).Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.Name)]);

        RuleFor(c => c.AreaName).Cascade(CascadeMode.Stop)
       .NotEmpty()
       .WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.AreaName)]);

        RuleFor(c => c.Latitude).Cascade(CascadeMode.Stop)
         .LessThanOrEqualTo(90).GreaterThanOrEqualTo(-90)
         .WithMessage(c => Localizer["InvalidRange", nameof(c.Latitude), -90, 90]);

        RuleFor(c => c.Longitude).Cascade(CascadeMode.Stop)
       .LessThanOrEqualTo(180).GreaterThanOrEqualTo(-180)
      .WithMessage(c => Localizer["InvalidRange", nameof(c.Longitude), -180, 180]);

    }
}
