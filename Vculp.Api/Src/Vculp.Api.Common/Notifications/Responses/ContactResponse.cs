using System;
using Vculp.Api.Common.Common.Dtos;

namespace Vculp.Api.Common.Notifications.Responses
{
    public class ContactResponse: LinkedResourceDto
    {
        public Guid ContactId { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
    }
}
    