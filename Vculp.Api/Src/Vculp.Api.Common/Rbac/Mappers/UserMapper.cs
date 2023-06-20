using Vculp.Api.Common.Common;
using Vculp.Api.Common.Rbac.Responses;
using Vculp.Api.Domain.Core.Rbac;

namespace Vculp.Api.Common.Rbac.Mappers
{
    public class UserMapper : Mapper<User>
    {
        static UserMapper()
        {
            CreateMapTo<UserResponse>(MapToUserResponse);
           
        }

        new public static TDestination MapTo<TDestination>(User source)
           => Mapper<User>.MapTo<TDestination>(source);

        private static UserResponse MapToUserResponse(User user)
        {           
            return new UserResponse
            {
                UserId = user.Id,
                DisplayName = user.DisplayName,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }
    }
}
