using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vculp.Api.Common;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.User.Responses;

namespace Vculp.Api.FareRecommendation.Controllers;

[Area("FareRecommendation")]
[Route("fareRecommender-api/fareRecommendation")]
[Microsoft.AspNetCore.Authorization.Authorize]
public class FareRecommendationController: PagedCollectionController
{
    private readonly IMediator _mediator;
    private readonly IHateoasLinkGenerator<UserResponse> _linkGenerator;

    public FareRecommendationController(IMediator mediator, IHateoasLinkGenerator<UserResponse> linkGenerator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _linkGenerator = linkGenerator ?? throw new ArgumentNullException(nameof(linkGenerator));

    }
    
    
}