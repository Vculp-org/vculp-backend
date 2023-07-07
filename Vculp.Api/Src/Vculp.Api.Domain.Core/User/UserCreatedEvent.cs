using System;
using Vculp.DDD.Shared;

namespace Vculp.Api.Domain.Core.User
{
    public class UserCreatedEvent : DomainEvent
    {
        /// <summary>
        /// Used for deserialization
        /// </summary>
        private UserCreatedEvent()
        {
        }

        public UserCreatedEvent(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            UserId = user.Id;
           
        }

        public Guid UserId { get; private set; }
     
    }
}

