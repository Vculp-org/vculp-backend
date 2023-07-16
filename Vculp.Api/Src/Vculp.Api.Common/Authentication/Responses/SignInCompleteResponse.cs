using System;
using System.Text.Json.Serialization;
using Vculp.Api.Common.Common;

namespace Vculp.Api.Common.Authentication.Responses;

public class SignInCompleteResponse
{
    [JsonIgnore] public Guid UserId { get; set; }
    public string Token { get; set; }
    public bool IsNewUser { get; set; }
    public UserType UserType { get; set; }
    public RegistrationStatus RegistrationStatus { get; set; }
}