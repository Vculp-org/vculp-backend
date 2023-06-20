namespace Vculp.Api.Application.Services.Notifications
{
    public class NotificationConstants
    {
        #region Content Types
        public const string ImagePng = "image/png";
        #endregion

        #region Email Templates
        public const string OrderCreatedTemplate = "Notifications.Email.Templates.order-created.cshtml";
        public const string OrderCreatedTemplateTextPlain = "Notifications.Email.Templates.order-created-plain.cshtml";
       
        #endregion Email Templates

        #region Footer Assets
        public const string AssetsFooterGpsPin = "Notifications.Email.Assets.GpsPin.png";
        public const string AssetsFooterLogo = "Notifications.Email.Assets.logo.png";
        public const string AssetsFooterPhone = "Notifications.Email.Assets.Phone.png";
        public const string AssetsFooterSeparator = "Notifications.Email.Assets.Separator.png";
        public const string AssetsFooterSlogan = "Notifications.Email.Assets.Slogan.png";
        public const string AssetsFooterWeb = "Notifications.Email.Assets.Web.png";
        #endregion Footer Assets
    }
}