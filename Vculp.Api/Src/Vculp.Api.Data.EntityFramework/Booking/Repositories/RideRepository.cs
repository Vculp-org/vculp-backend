using System.Linq;
using Vculp.Api.Data.EntityFramework.Common;
using Vculp.Api.Domain.Core.Booking;
using Vculp.Api.Domain.Interfaces.Booking;

namespace Vculp.Api.Data.EntityFramework.Booking.Repositories;

public class RideRepository: Repository<Ride>, IRideRepository
{
    public RideRepository(CoreContext context) : base(context)
    {
    }

    protected override IQueryable<Ride> IncludeAll()
    {
        return DbSet;
    }
}