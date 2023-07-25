using System;
using System.Collections.Generic;
using MediatR;
using Vculp.Api.Common.Location.Responses;

namespace Vculp.Api.Common.Location.Queries;

public class NearestQuery: IRequest<IList<NearestDriverResponse>>
{
    public Guid UserId { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public int GeofencingRadiusInMt { get; set; }
}