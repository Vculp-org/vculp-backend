using System;
using System.Threading.Tasks;
using Vculp.Api.Common.Common.Models.Sms;
using Vculp.Api.Common.Notifications.Configs;
using Vculp.Api.Domain.Interfaces.SMSSender;
using Vculp.Extensions;

namespace Vculp.Api.Domain.Common.SmsSenders
{
    public class SmsSender : ISmsSender
    {
        private readonly ISendModeService _sendModeService;
        private readonly SmsConfiguration _smsConfiguration;

        public SmsSender(ISendModeService sendModeService, SmsConfiguration smsConfiguration)
        {
            _sendModeService = sendModeService ?? throw new ArgumentNullException(nameof(sendModeService));
            _smsConfiguration = smsConfiguration ?? throw new ArgumentNullException(nameof(smsConfiguration));
        }

        public async Task SendSms(SmsRequest smsRequest)
        {
            if (smsRequest == null)
                throw new ArgumentNullException(nameof(smsRequest));

            //Create SMS api payload here
            var payload = new SmsPayload
            {
                SenderId = _smsConfiguration.SenderId,
                MessageText = smsRequest.MessageText,
                Recipient = new[] { smsRequest.Recipient }
            };

            if (smsRequest.ScheduleDate.HasValue)
            {
                payload.ScheduleDate = smsRequest.ScheduleDate.Value.ConvertToIso8601DateTimeUtc();
            }

            await _sendModeService.SendSms(payload);
        }
    }
}