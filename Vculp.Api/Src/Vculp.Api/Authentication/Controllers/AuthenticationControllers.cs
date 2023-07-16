using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Swashbuckle.AspNetCore.Annotations;
using Vculp.Api.Common;
using Vculp.Api.Common.Authentication.Commands;
using Vculp.Api.Common.Authentication.Responses;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.User.Commands;
using Vculp.Api.Common.User.Queries;
using Vculp.Api.Common.User.Responses;

namespace Vculp.Api.Authentication.Controllers;

[Area("Authentication")]
[Route("auth-api/auth")]
[Microsoft.AspNetCore.Authorization.Authorize]
public class AuthenticationControllers : PagedCollectionController
{
    private readonly IMediator _mediator;
    //private readonly IHateoasLinkGenerator<UserResponse> _linkGenerator;

    public AuthenticationControllers(IMediator mediator) //, IHateoasLinkGenerator<UserResponse> linkGenerator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        //_linkGenerator = linkGenerator ?? throw new ArgumentNullException(nameof(linkGenerator));

    }


    /// <summary>
    /// User Sign in - Step 1
    /// </summary>
    /// <response code="200">Returns OTP</response>
    /// <response code="400">When a model with invalid structure is supplied</response>
    /// <response code="422">When the model structure is correct but validation fails</response>
    [SwaggerOperation(Tags = new[] { "Auth/Signin" })]
    [ProducesResponseType(typeof(SignInInitiateResponse), 200)]
    [Consumes(MediaTypes.AuthModuleSignInInitiateV1MediaType)]
    [Produces(MediaTypes.AuthModuleUserSignInInitiateV1MediaType)]
    [HttpPost(Name = RouteNames.AuthSignInInitiate)]
    //[ValidateAntiForgeryToken]
    [AllowAnonymous]
    [NonAction]
    public async Task<IActionResult> SignInInitiateAsync([FromBody] SignInInitiateCommand command)
    {
        if (command == null)
        {
            return BadRequest();
        }

        string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

        string randomOTP = GenerateRandomOtp(6, saAllowedCharacters);
        
        var response = new SignInInitiateResponse()
        {
            MobileNumber = command.MobileNumber,
            OneTimePassword = 111111
        };

        return Ok(response);
    }




    /// <summary>
    /// User Sign in - Step 2
    /// </summary>
    /// <response code="200">Sends auth token and signed in the user</response>
    /// <response code="400">When a model with invalid structure is supplied</response>
    /// <response code="422">When the model structure is correct but validation fails</response>
    [SwaggerOperation(Tags = new[] { "Auth/SigninComplete" })]
    [ProducesResponseType(typeof(SignInCompleteResponse), 200)]
    [Consumes(MediaTypes.AuthModuleSignInCompleteV1MediaType)]
    [Produces(MediaTypes.AuthModuleUserSignInCompleteV1MediaType)]
    [HttpPost(Name = RouteNames.AuthSignInComplete)]
    [AllowAnonymous]
    public async Task<IActionResult> SignInCompleteAsync([FromBody] SignInCompleteCommand command)
    {
        if (command == null)
        {
            return BadRequest();
        }

        //Validate OTP

        // Genrate Auth Token


        var response = new SignInCompleteResponse()
        {
            UserId = Guid.NewGuid(),
            RegistrationStatus = RegistrationStatus.OtpVerified,
            IsNewUser = true,
            Token = Request.Headers[HeaderNames.Authorization]
        };

        if (command.OneTimePassword == 111111)
        {
            response.UserType = UserType.Rider;
        }
        else if (command.OneTimePassword == 222222)
        {
            response.RegistrationStatus = RegistrationStatus.BasicComplete;
            response.IsNewUser = false;
        }
        else
        {
            response.UserType = UserType.Driver;
        }

        return Ok(response);
    }


    private string GenerateRandomOtp(int otpLength, IReadOnlyList<string> saAllowedCharacters)
    {

        string sOtp = string.Empty;

        string tempChars = string.Empty;

        Random rand = new Random();

        for (var i = 0; i < otpLength; i++)

        {

            int p = rand.Next(0, saAllowedCharacters.Count);

            tempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Count)];

            sOtp += tempChars;

        }

        return sOtp;

    }


}