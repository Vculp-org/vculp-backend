using System.Threading.Tasks;
using Vculp.Api.Domain.Interfaces.Common;

namespace Vculp.Api.Domain.Interfaces.Vehicle;

public interface IVehicleTypeRepository : IRepository<Core.Vehicle.VehicleType>
{
    Task<Core.Vehicle.FareDetails> GetVehicleFareDetails(string vehicleType, string vehicleBodyType, string city);
}