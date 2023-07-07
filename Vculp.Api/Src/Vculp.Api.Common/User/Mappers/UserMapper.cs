using Vculp.Api.Common.Common;
using Vculp.Api.Common.User.Responses;

namespace Vculp.Api.Common.User.Mappers;

public class UserMapper : Mapper<Domain.Core.User.User>
{
    static UserMapper()
    {
        CreateMapTo<UserResponse>(MapToUserResponse);

    }

    new public static TDestination MapTo<TDestination>(Domain.Core.User.User source)
        => Mapper<Domain.Core.User.User>.MapTo<TDestination>(source);

    public static UserResponse MapToUserResponse(Domain.Core.User.User user)
    {
        return new UserResponse()
        {
            Mobile = user.MobileNumber,
            EmailAddress = user.EmailAddress,
            FirstName = user.FirstName,
            LastName = user.LastName,
            UserId = user.Id
        };
    }
}