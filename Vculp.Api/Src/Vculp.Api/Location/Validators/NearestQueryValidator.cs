using FluentValidation;
using Microsoft.Extensions.Localization;
using Vculp.Api.Common.Validators;
using Vculp.Api.Common.Location.Queries;

namespace Vculp.Api.Location.Validators;

public class NearestQueryValidator:QueryValidator<NearestQuery>
{
    public NearestQueryValidator(IStringLocalizer<QueryValidatorMessages> stringLocalizer) : base(stringLocalizer)
    {
        RuleFor(x => x.Latitude).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("latitude should not be empty")
            .LessThan(90).WithMessage("Latitude should not be greater than 90")
            .GreaterThan(-90).WithMessage("latitude should not be less than -90");
        RuleFor(x => x.Longitude).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Longitude should not be empty")
            .LessThan(180).WithMessage("Longitude should not be greater than 180")
            .GreaterThan(-180).WithMessage("Longitude should not be less than -180");
        RuleFor(x => x.GeofencingRadiusInMt).Cascade(CascadeMode.Stop)
            .GreaterThanOrEqualTo(0).WithMessage("Fencing radius should be greater than 0")
            .LessThan(5000).WithMessage("Radius cannot be greater than 5 km");
    }
}