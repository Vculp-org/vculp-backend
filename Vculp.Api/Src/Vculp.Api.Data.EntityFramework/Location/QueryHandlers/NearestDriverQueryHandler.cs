using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Location.Queries;
using Vculp.Api.Common.Location.Responses;
using Vculp.Api.Data.EntityFramework.Common;
using Vculp.Api.Domain.Core.SharedKernel;

namespace Vculp.Api.Data.EntityFramework.Location.QueryHandlers;

public class NearestDriverQueryHandler: QueryHandler, IRequestHandler<NearestQuery, IList<NearestDriverResponse>>
{
    public NearestDriverQueryHandler(
        CoreContext context) : base(context)
    {
    }

    public async Task<IList<NearestDriverResponse>> Handle(NearestQuery request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        //Check user already exist
        var user = await Context.Users.FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);
        if (user != null)
        {

            /// TODO: Logic has to be implemented here, as of now creating dummy list

            // 28.591378050041225, 77.31897799677277
            // 28.58509909389177, 77.31158582884416
            Random rnd = new Random();
            var list = new List<NearestDriverResponse>
            {
                new NearestDriverResponse
                {
                    Latitude = request.Latitude + (rnd.Next(-1000, 1000) / 10000M),
                    Longitude = request.Longitude + (rnd.Next(-1000, 1000) / 10000M),
                    VehicleNumber = "BOND 007",
                    Model = "Aston Martin",
                    Type = SharedEnums.VehicleType.Car
                },
                new NearestDriverResponse
                {
                    Latitude = request.Latitude + (rnd.Next(-1000, 1000) / 10000M),
                    Longitude = request.Longitude + (rnd.Next(-1000, 1000) / 10000M),
                    VehicleNumber = "JAR 1111",
                    Model = "Bugatti",
                    Type = SharedEnums.VehicleType.Car
                },
                new NearestDriverResponse
                {
                    Latitude = request.Latitude + (rnd.Next(-1000, 1000) / 10000M),
                    Longitude = request.Longitude + (rnd.Next(-1000, 1000) / 10000M),
                    VehicleNumber = "STAT 404",
                    Model = "Royal Enfield",
                    Type = SharedEnums.VehicleType.Bike
                },
                new NearestDriverResponse
                {
                    Latitude = request.Latitude + (rnd.Next(-1000, 1000) / 10000M),
                    Longitude = request.Longitude + (rnd.Next(-1000, 1000) / 10000M),
                    VehicleNumber = "TOM 3435",
                    Model = "Kawasaki Ninja",
                    Type = SharedEnums.VehicleType.Bike
                },
            };

            return list;
        }
        else
            return null;
    }
}