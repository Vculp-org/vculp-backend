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
        public DateTime DateOfBirth { get; set; }
        public string CreationTime { get; set; }
        public string LastUpdated { get; set; }
        public bool IsActive { get; set; }
        public string DisplayName { get; set; }
        public int? CreatedByUserId { get; set; }
        public string CreatedByUserName { get; set; }
        public int? LastUpdatedByUserId { get; set; }
        public string LastUpdatedByUserName { get; set; }
    }
}   