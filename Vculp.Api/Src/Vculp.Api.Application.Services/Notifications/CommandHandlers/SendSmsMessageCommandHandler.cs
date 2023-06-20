using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Localization;
using Vculp.Api.Application.Services.Common;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Common.Models.Sms;
using Vculp.Api.Common.Notifications.Commands;
using Vculp.Api.Domain.Interfaces.SMSSender;
using Vculp.Extensions.String;

namespace Vculp.Api.Application.Services.Notifications.CommandHandlers
{
    public class SendSmsMessageCommandHandler : CommandHandler, IRequestHandler<SendSmsMessageCommand, ICommandResult>
    {
        private readonly ISmsSender _smsSender;

        public SendSmsMessageCommandHandler(ISmsSender smsSender, IStringLocalizer<CommandHandlerErrors> stringLocalizer)
            : base(stringLocalizer)
        {
            _smsSender = smsSender ?? throw new ArgumentNullException(nameof(smsSender));
        }
        public async Task<ICommandResult> Handle(SendSmsMessageCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            //create sms request from command
            var smsRequest = new SmsRequest(request.MessageText, request.Recipient);

            if (!string.IsNullOrWhiteSpace(request.ScheduleDate) &&
                request.ScheduleDate.TryParseIso8601DateTimeToUtc(out DateTime scheduleDate))
            {
                smsRequest.SetScheduleDate(scheduleDate);
            }

            // Send the message using ISmsSender
            await _smsSender.SendSms(smsRequest);

            return new SuccessCommandResult();
        }
    }
}