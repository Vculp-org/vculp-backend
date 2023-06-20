using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace Vculp.Api.Common.Common.Models.Email
{
    public class MailRequest
    {
        public MailRequest(string from, string fromName, string to, string toName, string plainTextBody,
            string htmlBody, string subject, IList<EmbeddedResource> embeddedResources = null,
            Attachment attachment = null)
        {
            if (string.IsNullOrEmpty(from)) throw new ArgumentException($"{nameof(from)} is null, empty or contains only whitespace", nameof(from));
            if (string.IsNullOrEmpty(fromName)) throw new ArgumentException($"{nameof(from)} is null, empty or contains only whitespace", nameof(fromName));
            if (string.IsNullOrEmpty(to)) throw new ArgumentException($"{nameof(to)} is null, empty or contains only whitespace", nameof(to));
            if (string.IsNullOrEmpty(toName)) throw new ArgumentException($"{nameof(toName)} is null, empty or contains only whitespace", nameof(toName));
            if (string.IsNullOrEmpty(plainTextBody)) throw new ArgumentException($"{nameof(plainTextBody)} is null, empty or contains only whitespace", nameof(plainTextBody));
            if (string.IsNullOrEmpty(htmlBody)) throw new ArgumentException($"{nameof(htmlBody)} is null, empty or contains only whitespace", nameof(htmlBody));
            if (string.IsNullOrEmpty(subject)) throw new ArgumentException($"{nameof(subject)} is null, empty or contains only whitespace", nameof(subject));

            From = from;
            FromName = fromName;
            To = to;
            ToName = toName;
            PlainTextBody = plainTextBody;
            HtmlBody = htmlBody;
            Subject = subject;
            EmbeddedResources = embeddedResources ?? new List<EmbeddedResource>();
            Attachment = attachment;
        }

        public string From { get; }
        public string FromName { get; }
        public string To { get; }
        public string ToName { get; }
        public string PlainTextBody { get; }
        public string HtmlBody { get; }
        public string Subject { get; }
        public IList<EmbeddedResource> EmbeddedResources { get; }
        public Attachment? Attachment { get; }
    }

    public class EmbeddedResource
    {
        public string Key { get; set; }
        public string Path { get; set; }
        public string ContentType { get; set; }
    }

}