using System.Threading.Tasks;
using Refit;
using Vculp.Api.Common.GoogleMaps.Models;

namespace Vculp.Api.Domain.Interfaces.GoogleMaps;

public interface IDistanceMatrixApi
{
    [Get("destinations=<{destinations}>&origins<{origins}>")]
    Task<DistanceMatrixResponse> GetAsync(string destinations, string origins);
}