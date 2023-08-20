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

    public async Task<Domain.Core.Vehicle.VehicleType> GetVehicleType(string vehicleType, string vehicleBodyType,
        string city, int? noOfSeater)
    {
        if (string.IsNullOrWhiteSpace(vehicleType))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(vehicleType));
        if (string.IsNullOrWhiteSpace(vehicleBodyType))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(vehicleBodyType));
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(city));

        var fareDetails = IncludeAll().FirstOrDefaultAsync(x =>
            x.Type.Contains(vehicleType) && x.BodyType.Contains(vehicleBodyType) && x.NoOfSeaters >= noOfSeater);
        return await fareDetails;
    }
}