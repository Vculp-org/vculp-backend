namespace Vculp.Api.Common
{
    public static class MediaTypes
    {
        //User
        
        public const string UserModuleUserV1MediaType = "application/vnd.vculp.user.v1.hateoas+json";
        public const string UserModuleCreateUserV1MediaType = "application/vnd.vculp.user.create.v1+json";
        public const string UserModuleUpdateV1MediaType = "application/vnd.vculp.user.update.v1+json";
        
        //FareRecommendation
        public const string FareRecommenderModuleFareRecommendationV1MediaType = "application/vnd.vculp.farerecommendation.v1.hateoas+json";
        
        
        //Auth Module
        
        public const string AuthModuleSignInInitiateV1MediaType = "application/vnd.vculp.auth.signin.initiate.v1+json";
        public const string AuthModuleUserSignInInitiateV1MediaType = "application/vnd.vculp.auth.user.signin.initiate.v1+json";
        
        public const string AuthModuleSignInCompleteV1MediaType = "application/vnd.vculp.auth.signin.complete.v1+json";
        public const string AuthModuleUserSignInCompleteV1MediaType = "application/vnd.vculp.auth.user.signin.complete.v1+json";

        // Location Module
        public const string LocationModuleLocationV1MediaType = "application/vnd.vculp.lcation.v1.hateoas+json";
        public const string LocationModulePushLocationV1MediaType = "application/vnd.vculp.location.push.v1+json";
        public const string LocationModuleFavLocationV1MediaType = "application/vnd.vculp.fav.lcation.v1.hateoas+json";
        public const string LocationModuleAddFavLocationV1MediaType = "application/vnd.vculp.location.fav.v1+json";

        // Booking Module
        public const string BookingModuleBookingV1MediaType = "application/vnd.vculp.booking.v1.hateoas+json";
        public const string BookingModuleRequestRideV1MediaType = "application/vnd.vculp.booking.request.ride.v1+json";

        //Favorite Region
        public const string FavoriteRegionModuleMediaType = "application/vnd.vculp.favoriteregion.v1.hateoas+json";
        public const string FavoriteRegionModuleCreateMediaType = "application/vnd.vculp.favoriteregion.create.v1+json";
        public const string FavoriteRegionModuleUpdateMediaType = "application/vnd.vculp.favoriteregion.update.v1+json";
    }
}
