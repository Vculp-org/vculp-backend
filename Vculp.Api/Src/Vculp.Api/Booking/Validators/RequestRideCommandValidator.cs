using FluentValidation;
using Microsoft.Extensions.Localization;
using Vculp.Api.Common.Booking.Commands;
using Vculp.Api.Common.Validators;

namespace Vculp.Api.Booking.Validators;

public class RequestRideCommandValidator: CommandValidator<RequestRideCommand>
{
    public RequestRideCommandValidator(IStringLocalizer<CommandValidatorMessages> stringLocalizer) : base(stringLocalizer)
    {
        RuleFor(x => x.Latitude).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("latitude should not be empty")
            .LessThan(90).WithMessage("Latitude should not be greater than 90")
            .GreaterThan(-90).WithMessage("latitude should not be less than -90");
        RuleFor(x => x.Longitude).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Longitude should not be empty")
            .LessThan(180).WithMessage("Longitude should not be greater than 180")
            .GreaterThan(-180).WithMessage("Longitude should not be less than -180");
    }
}
