namespace Vculp.Api.Common.Authentication.Responses;

public class SignInInitiateResponse
{
    public string MobileNumber  { get; set; }
    public int OneTimePassword { get; set; }
    public int? RetryCount { get; set; }
}