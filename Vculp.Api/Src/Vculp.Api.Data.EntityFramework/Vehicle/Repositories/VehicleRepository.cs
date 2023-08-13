using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vculp.Api.Data.EntityFramework.Common;
using Vculp.Api.Domain.Interfaces.Vehicle;

namespace Vculp.Api.Data.EntityFramework.Vehicle.Repositories;

public class VehicleRepository : Repository<Domain.Core.Vehicle.Vehicle>, IVehicleRepository
{
    public VehicleRepository(CoreContext context) : base(context)
    {
    }

    protected override IQueryable<Domain.Core.Vehicle.Vehicle> IncludeAll()
    {
        return DbSet;
    }

    public async Task<Domain.Core.Vehicle.FareDetails> GetVehicleFareDetails(string vehicleType, string vehicleBodyType,
        string city)
    {
        if (string.IsNullOrWhiteSpace(vehicleType))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(vehicleType));
        if (string.IsNullOrWhiteSpace(vehicleBodyType))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(vehicleBodyType));
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(city));

        var fareDetails = IncludeAll().Where(x =>
                x.VehicleType == vehicleType && x.VehicleBodyType == vehicleBodyType)
            .Select(x => x.FareDetails.FirstOrDefault(q => q.City.Contains(city))).FirstOrDefaultAsync();

        return await fareDetails;
    }
}