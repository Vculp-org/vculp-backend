using System;
using System.Collections.Generic;
using MediatR;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Notifications.Responses;
using Vculp.Api.Shared.Abstractions.Paging;

namespace Vculp.Api.Common.Notifications.Queries
{
    public class NotificationContactsQuery : PagedResourceParameters, IRequest<IPagedList<ContactResponse>>
    {
        public NotificationContactsQuery()
            : base(10, 20)
        {

        }
        public IEnumerable<string> ContactType { get; set; }

        public Guid? CustomerId { get; set; }
    }
}
