using System;
using Newtonsoft.Json;

namespace Vculp.Api.Common.Common.Models.Sms
{

    public class SendModeSuccessResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("statusCode")]
        public long StatusCode { get; set; }

        [JsonProperty("acceptedDateTime")]
        public DateTimeOffset AcceptedDateTime { get; set; }

        [JsonProperty("message")]
        public Message Message { get; set; }
    }

    public class Message
    {
        [JsonProperty("senderid")]
        public string SenderId { get; set; }

        [JsonProperty("messagetext")]
        public string MessageText { get; set; }

        [JsonProperty("customerid")]
        public object CustomerId { get; set; }

        [JsonProperty("scheduledate")]
        public object ScheduleDate { get; set; }

        [JsonProperty("recipients")]
        public string[] Recipients { get; set; }
    }

    public class SendModeErrorResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }

    }
}