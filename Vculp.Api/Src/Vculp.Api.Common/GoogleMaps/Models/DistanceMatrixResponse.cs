using System.Text.Json.Serialization;

namespace Vculp.Api.Common.GoogleMaps.Models;

public class DistanceMatrixResponse
{
    [JsonPropertyName("destination_addresses")]
    public string[] DestinationAddresses { get; set; }

    [JsonPropertyName("origin_addresses")]
    public string[] OriginAddresses { get; set; }

    [JsonPropertyName("rows")]
    public Row[] Rows { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }
}

public class Row
{
    [JsonPropertyName("elements")]
    public Element[] Elements { get; set; }
}

public class Element
{
    [JsonPropertyName("distance")]
    public Distance Distance { get; set; }

    [JsonPropertyName("duration")]
    public Distance Duration { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }
}

public class Distance
{
    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("value")]
    public long Value { get; set; }
}