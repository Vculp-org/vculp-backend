using System.Threading.Tasks;
using Refit;
using Vculp.Api.Common.GoogleMaps.Models;

namespace Vculp.Api.Domain.Interfaces.GoogleMaps;

public interface IDistanceMatrixApi
{
    [Get($"/api/distancematrix/json")]
    Task<DistanceMatrixResponse> GetAsync([Query] DistanceMatrixQueryParams @params);
}



public class DistanceMatrixQueryParams
{
    [AliasAs("key")]
    public string Key { get; set; }
    [AliasAs("destinations")]
    public string Destinations { get; set; }
    [AliasAs("origins")]
    public string Origins { get; set; }
}