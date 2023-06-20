using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Vculp.Api.Common;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Notifications.Commands;

namespace Vculp.Api.Notifications.Controllers
{
    [Area("Notifications")]
    [Route("notifications-api/notifications")]
    [Authorize]

    public class NotificationsController : PagedCollectionController
    {
        private readonly IMediator _mediator;
        
        public NotificationsController
        (
          IMediator mediator
        )
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        }
        /// <summary>
        /// Creates new Notification
        /// </summary>
        // [SwaggerOperation(Tags = new[] { "Notification/Notifications" })]
        // [Consumes(MediaTypes.NotificationsModuleDistributeNotificationV1MediaType)]
        // [HttpPost(Name = RouteNames.AddNotifications)]
        // public async Task<IActionResult> AddNotificationAsync([FromBody] DistributeNotificationCommand command)
        // {
        //     if (command == null) { return BadRequest(); }
        //
        //     if (!ModelState.IsValid)
        //     {
        //         return UnprocessableEntity(ModelState);
        //     }
        //
        //     var commandResult = await _mediator.Send(command);
        //
        //     if (commandResult.ResultType == CommandResultType.UnprocessableEntity)
        //     {
        //         ModelState.AddModelErrors(commandResult.Errors);
        //         return UnprocessableEntity(ModelState);
        //     }
        //
        //     return Accepted();
        // }
        //
    }
}
