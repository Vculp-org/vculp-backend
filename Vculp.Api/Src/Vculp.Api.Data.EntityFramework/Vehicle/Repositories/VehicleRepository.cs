using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vculp.Api.Data.EntityFramework.Common;
using Vculp.Api.Domain.Interfaces.Vehicle;

namespace Vculp.Api.Data.EntityFramework.Vehicle.Repositories;

public class VehicleTypeRepository : Repository<Domain.Core.Vehicle.VehicleType>, IVehicleTypeRepository
{
    public VehicleTypeRepository(CoreContext context) : base(context)
    {
    }

    protected override IQueryable<Domain.Core.Vehicle.VehicleType> IncludeAll()
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
                x.Type == vehicleType && x.BodyType == vehicleBodyType)
            .Select(x => x.FareDetails.FirstOrDefault(q => q.City.Contains(city))).FirstOrDefaultAsync();

        return await fareDetails;
    }
}