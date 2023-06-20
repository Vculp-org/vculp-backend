using System;

namespace Vculp.Api.Domain.Core.Notifications
{
    public interface IContact
    {
        public Guid ContactId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string EmailAddress { get; }
        public string MobileNumber { get; }
    }
}
