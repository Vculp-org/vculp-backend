using FluentValidation;
using Microsoft.Extensions.Localization;
using Vculp.Api.Common.FavoriteRegion.Commands;
using Vculp.Api.Common.User.Commands;
using Vculp.Api.Common.Validators;

namespace Vculp.Api.FavoriteRegion.Validators
{
    public class CreateFavortieRegionCommandValidator : CommandValidator<CreateFavoriteRegionCommand>
    {
        public CreateFavortieRegionCommandValidator(IStringLocalizer<CommandValidatorMessages> stringLocalizer) : base(stringLocalizer)
        {
            RuleFor(c => c.Name).Cascade(CascadeMode.Stop)
           .NotEmpty()
           .WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.Name)]);
           
           RuleFor(c => c.AreaName).Cascade(CascadeMode.Stop)
          .NotEmpty()
          .WithMessage(c => Localizer["FieldIsRequiredError", nameof(c.AreaName)]);

           RuleFor(c => c.Latitude).Cascade(CascadeMode.Stop)
          .NotEmpty().LessThanOrEqualTo(90).GreaterThanOrEqualTo(-90)
          .WithMessage(c => Localizer["InvalidRangeError", nameof(c.Latitude), -90, 90]);

            RuleFor(c => c.Longitude).Cascade(CascadeMode.Stop)
           .NotEmpty().LessThanOrEqualTo(180).GreaterThanOrEqualTo(-180)
          .WithMessage(c => Localizer["InvalidRangeError", nameof(c.Longitude), -180, 180]);
           
           
        }
    }
}
