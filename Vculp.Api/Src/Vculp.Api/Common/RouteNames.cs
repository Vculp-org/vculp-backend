namespace Vculp.Api.Common
{
    public static class RouteNames
    {
       
        //User
        public const string UserCreateUser = "UserCreateUser";
        public const string UserGetAllUsers = "UserGetAllUsers";
        public const string UserGetUserById = "UserGetUserById";
        public const string UserUpdateUserById = "UserUpdateUserById";

        //Auth
        
        public const string AuthSignInInitiate= "AuthSignInInitiate";
        public const string AuthSignInComplete= "AuthSignInComplete";
        
        // Location
        
        public const string LocationPushLocation = "LocationPushLocation";
        public const string LocationGetNearestDrivers = "LocationGetNearestDrivers";

    }
}
