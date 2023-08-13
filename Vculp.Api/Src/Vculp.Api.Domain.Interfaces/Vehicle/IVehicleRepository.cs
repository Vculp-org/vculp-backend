using System.Threading.Tasks;
using Vculp.Api.Domain.Interfaces.Common;

namespace Vculp.Api.Domain.Interfaces.Vehicle;

public interface IVehicleRepository : IRepository<Core.Vehicle.Vehicle>
{
    Task<Core.Vehicle.FareDetails> GetVehicleFareDetails(string vehicleType, string vehicleBodyType, string city);
}