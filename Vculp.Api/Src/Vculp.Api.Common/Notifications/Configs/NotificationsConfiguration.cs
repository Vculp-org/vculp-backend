namespace Vculp.Api.Common.Notifications.Configs
{
    public class NotificationsConfiguration
    {
        public EmailConfiguration EmailConfiguration { get; set; }
        public SmsConfiguration SmsConfiguration { get; set; }
        public VwdCancelledByVetConfiguration VwdCancelledByVetConfiguration { get; set; }
        public VwdApprovedByVetConfiguration VwdApprovedByVetConfiguration { get; set; }
        public OrderUnblockedConfiguration OrderUnblockedConfiguration { get; set; }
        public ManualNotificationConfiguration ManualNotificationConfiguration { get; set; }
    }

    public class EmailConfiguration
    {
        public bool IsProductionModeEnabled { get; set; }
        public string DevelopmentModeFromAddress { get; set; }
        public string DevelopmentModeRecipientAddress { get; set; }
        public string FromAddress { get; set; }
        public string FromName { get; set; }
        public string Host { get; set; }
        public short Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool UseSSL { get; set; }
        public int? SecureSocketOptions { get; set; }
    }
    public class ManualNotificationConfiguration
    {
        public string FromName { get; set; }
        public string FromAddress { get; set; }
    }

    public class SmsConfiguration
    {
        public bool IsProductionModeEnabled { get; set; }
        public string DevelopmentModeSenderId { get; set; }
        public string DevelopmentModeRecipientMobile { get; set; }
        public string BaseUrl { get; set; }
        public string AccessKey { get; set; }
        public string SenderId { get; set; }
        public int TimeOutSeconds { get; set; }
    }

    public class VwdCancelledByVetConfiguration
    {
        public string NotificationRecipientAddress { get; set; }
        public string NotificationRecipientName { get; set; }
        public string FromAddress { get; set; }
        public string FromName { get; set; }
    }

    public class OrderUnblockedConfiguration
    {
        public string NotificationRecipientAddress { get; set; }
        public string NotificationRecipientName { get; set; }
        public string FromAddress { get; set; }
        public string FromName { get; set; }
    }

    public class VwdApprovedByVetConfiguration
    {
        public string FromAddress { get; set; }
        public string FromName { get; set; }
    }
}
