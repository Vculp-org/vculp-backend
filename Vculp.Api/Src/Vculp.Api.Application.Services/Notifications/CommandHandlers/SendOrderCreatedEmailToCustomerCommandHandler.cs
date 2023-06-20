using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using RazorLight;
using Vculp.Api.Application.Services.Common;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Common.Models.Email;
using Vculp.Api.Common.Notifications.Commands;
using Vculp.Api.Common.Notifications.Configs;
using Vculp.Api.Domain.Interfaces.EmailSender;

namespace Vculp.Api.Application.Services.Notifications.CommandHandlers
{
    public class SendOrderCreatedEmailToCustomerCommandHandler : CommandHandler, IRequestHandler<SendOrderCreatedEmailToCustomerCommand, ICommandResult>
    {
        private readonly IEmailSender _emailSender;
        private readonly IRazorLightEngine _razorLightEngine;
        private readonly EmailConfiguration _emailConfiguration;
       
        public SendOrderCreatedEmailToCustomerCommandHandler(IEmailSender emailSender, IRazorLightEngine razorLightEngine, 
            IOptions<NotificationsConfiguration> options,
            IStringLocalizer<CommandHandlerErrors> stringLocalizer) : base(stringLocalizer)
        {
            _emailSender = emailSender ?? throw new ArgumentNullException(nameof(emailSender));
            _razorLightEngine = razorLightEngine ?? throw new ArgumentNullException(nameof(razorLightEngine));
            _emailConfiguration = options?.Value?.EmailConfiguration ?? throw new ArgumentNullException(nameof(options));
        }

        public async Task<ICommandResult> Handle(SendOrderCreatedEmailToCustomerCommand request,
            CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            //create mail request from command
            var mailRequest = await GetMailRequest(request);

            // Send the message using ISmsSender
            await _emailSender.SendMail(mailRequest);

            return new SuccessCommandResult();
        }

        private async Task<MailRequest> GetMailRequest
            (SendOrderCreatedEmailToCustomerCommand sendOrderCreatedEmailToCustomerCommand)
        {

            //Prepare Assets Resources 
            var embeddedResource = NotificationExtensions.GetEmbeddedResources();

            // Compile and generate template
            var htmlTemplate = await _razorLightEngine.GetTemplate(NotificationConstants.OrderCreatedTemplate, sendOrderCreatedEmailToCustomerCommand);
            var plainTextTemplate =
                await _razorLightEngine.GetTemplate(NotificationConstants.OrderCreatedTemplateTextPlain, sendOrderCreatedEmailToCustomerCommand);

            //subject
            var subject = $"Your order, number {sendOrderCreatedEmailToCustomerCommand.OrderNumber}, has been queued for production.";

            //get the attachment from repo

            //Create Attachment object
            

            //decorate Mail request here!!
            var mailRequest = new MailRequest(_emailConfiguration.FromAddress, _emailConfiguration.FromName, sendOrderCreatedEmailToCustomerCommand.To, sendOrderCreatedEmailToCustomerCommand.ToName,
                plainTextTemplate, htmlTemplate, subject, embeddedResource, null);

            return mailRequest;
        }
    }
}