using MediatR;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Location.Responses;
using Vculp.Api.Shared.Abstractions.Paging;

namespace Vculp.Api.Common.Location.Queries;

public class FavoriteLocationsQuery: PagedResourceParameters, IRequest<IPagedList<FavoriteLocationResponse>>
{
    public FavoriteLocationsQuery()
        : base(10, 20)
    {
    }


    
}