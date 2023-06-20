using System;
using System.Reflection;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.FileProviders;
using MimeKit;
using Vculp.Api.Common.Common.Models.Email;
using Vculp.Api.Common.Notifications.Configs;
using Vculp.Api.Domain.Interfaces.EmailSender;

namespace Vculp.Api.Domain.Common.EmailSender
{
    public class DevEmailSender : IEmailSender
    {
        private readonly EmailConfiguration _emailConfiguration;
        public DevEmailSender(EmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration ?? throw new ArgumentNullException(nameof(emailConfiguration));
        }

        public async Task SendMail(MailRequest mailRequest)
        {
            if (mailRequest == null)
                throw new ArgumentNullException(nameof(mailRequest));

            //this is development email handler, hence overriding the dev values for message object.
            //Prepare message object
            var message = new MimeMessage
            {
                Sender = MailboxAddress.Parse(_emailConfiguration.DevelopmentModeFromAddress)
            };
            //decorate from address
            message.From.Add(MailboxAddress.Parse(_emailConfiguration.DevelopmentModeFromAddress));

            //decorate to address      
            message.To.Add(MailboxAddress.Parse(_emailConfiguration.DevelopmentModeRecipientAddress));

            //set subject
            message.Subject = mailRequest.Subject;

            // prepare message body
            var bodyBuilder = new BodyBuilder();

            // In order to reference Embedded images from the html text, we'll need to add it
            // to builder.LinkedResources and then use its Content-Id value in the img src.
            var embeddedProvider = new EmbeddedFileProvider(Assembly.GetExecutingAssembly());

            if (mailRequest.EmbeddedResources != null && mailRequest.EmbeddedResources?.Count > 0)
            {
                foreach (var embeddedResource in mailRequest.EmbeddedResources)
                {
                    await using var stream = embeddedProvider.GetFileInfo(embeddedResource.Path).CreateReadStream();
                    {
                        // add image linked resource to the builder
                        var image = await bodyBuilder.LinkedResources.AddAsync(embeddedResource.Key, stream,
                            ContentType.Parse(embeddedResource.ContentType));

                        // set the contentId for the resource added to the builder to the contentId passed
                        image.ContentId = embeddedResource.Key;
                    }
                }
            }

            //Add Attachments to body, if available
            if (mailRequest.Attachment?.ContentStream != null)
            {
                await bodyBuilder.Attachments.AddAsync(mailRequest.Attachment.Name, mailRequest.Attachment.ContentStream);
            }

            // prepare message body
            bodyBuilder.HtmlBody = mailRequest.HtmlBody;
            bodyBuilder.TextBody = new TextPart("plain") { Text = mailRequest.HtmlBody }.Text;

            message.Body = bodyBuilder.ToMessageBody();

            //Prepare SMTP client 
            using var client = new SmtpClient();

            var secureSocketOptions = SecureSocketOptions.Auto;

            if (_emailConfiguration.SecureSocketOptions.HasValue &&
                Enum.IsDefined(typeof(SecureSocketOptions), _emailConfiguration.SecureSocketOptions.Value))
            {
                secureSocketOptions = (SecureSocketOptions)_emailConfiguration.SecureSocketOptions.Value;
            }

            await client.ConnectAsync(_emailConfiguration.Host, _emailConfiguration.Port, secureSocketOptions);
            await client.AuthenticateAsync(_emailConfiguration.UserName, _emailConfiguration.Password);

            // After configuring the SMTP server connection
            // we can now send a message and then disconnect from the server.
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
            client.Dispose();
        }
    }
}