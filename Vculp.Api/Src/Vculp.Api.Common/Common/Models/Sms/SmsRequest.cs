using System;

namespace Vculp.Api.Common.Common.Models.Sms
{
    public class SmsRequest
    {
        public SmsRequest(string messageText, string recipient)
        {
            if (string.IsNullOrEmpty(messageText))
                throw new ArgumentException($"{nameof(messageText)} is null, empty or contains only whitespace",
                    nameof(messageText));
            if (string.IsNullOrEmpty(recipient))
                throw new ArgumentException($"{nameof(recipient)} is null, empty or contains only whitespace",
                    nameof(recipient));

            MessageText = messageText;
            Recipient = recipient;
        }

        public string MessageText { get; }
        public string Recipient { get; }
        public DateTime? ScheduleDate { get; private set; }

        public void SetScheduleDate(DateTime scheduleDate)
        {
            if (scheduleDate.ToUniversalTime() < DateTime.UtcNow)
            {
                throw new ArgumentException($"{scheduleDate} cannot be in the past.", nameof(scheduleDate));
            }

            ScheduleDate = scheduleDate;
        }
    }
}