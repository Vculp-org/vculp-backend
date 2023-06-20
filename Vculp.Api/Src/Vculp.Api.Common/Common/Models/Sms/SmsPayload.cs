using Newtonsoft.Json;

namespace Vculp.Api.Common.Common.Models.Sms
{
    public class SmsPayload
    {
        [JsonProperty("messagetext")] 
        public string MessageText { get; set; }
        [JsonProperty("recipients")] 
        public string[] Recipient { get; set; }
        [JsonProperty("senderid")] 
        public string SenderId { get; set; }
        [JsonProperty("scheduledate")]
        public string ScheduleDate { get; set; }
    }
}