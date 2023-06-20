using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Vculp.Api.Common.Common.Exceptions;
using Vculp.Api.Common.Common.Models.Sms;
using Vculp.Api.Domain.Interfaces.SMSSender;

namespace Vculp.Api.Domain.Common.SmsSenders
{
    public class SendModeService : ISendModeService
    {
        private const string _irishMobileNumberPrefix = "00353";
        private readonly ILogger<SendModeService> _logger;
        private readonly HttpClient _httpClient;

        public SendModeService(ILogger<SendModeService> logger, HttpClient httpClient)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); ;
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient)); ;
        }
        public async Task SendSms(SmsPayload smsPayload)
        {
            if (smsPayload == null)
                throw new ArgumentNullException(nameof(smsPayload));

            // handle the sms number replacement if needed

            for (int i = 0; i < smsPayload.Recipient.Count(); i++)
            {
                var recipientNumber = smsPayload.Recipient[i];

                if (recipientNumber.StartsWith("08"))
                {
                    recipientNumber = $"{_irishMobileNumberPrefix}{recipientNumber.Substring(1)}";
                }
                else if (recipientNumber.StartsWith('8'))
                {
                    recipientNumber = $"{_irishMobileNumberPrefix}{recipientNumber}";
                }
                else if (recipientNumber.StartsWith('+'))
                {
                    recipientNumber = $"00{recipientNumber.Substring(1)}";
                }

                smsPayload.Recipient[i] = recipientNumber;
            }

            //create http request for sms api
            var request = new HttpRequestMessage(HttpMethod.Post, "send");
            var values = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>
                    ("message", JsonConvert.SerializeObject(smsPayload))
            };
            request.Content = new FormUrlEncodedContent(values);

            using var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseStream = await response.Content.ReadAsStreamAsync();
                    using var streamReader = new StreamReader(responseStream);
                    using var jsonReader = new JsonTextReader(streamReader);
                    var serializer = new JsonSerializer();
                    var responseModel = serializer.Deserialize<SendModeSuccessResponse>(jsonReader);
                    _logger.LogInformation("Sms sent successfully with response - {0}",
                        JsonConvert.SerializeObject(responseModel));
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new ApiException(response.StatusCode, content);
                }
            }
        }
    }
}