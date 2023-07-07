using System;
using System.Text.Json.Serialization;
using Vculp.Api.Common.Common.Dtos;

namespace Vculp.Api.Common.User.Responses
{

    public class UserResponse : LinkedResourceDto
    {
        [JsonIgnore] public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Mobile { get; set; }
        public string CreationTime { get; set; }
    }
}