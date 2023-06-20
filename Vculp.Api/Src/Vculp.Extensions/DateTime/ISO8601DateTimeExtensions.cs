using System.Globalization;

namespace Vculp.Extensions;

public static class ISO8601DateTimeExtensions
{
    public static string ConvertToIso8601Date (this DateTime dateTime)
    {
        return dateTime.ToString ("yyyy-MM-dd", CultureInfo.InvariantCulture);
    }

    public static string ConvertToIso8601DateTimeUtc (this DateTime dateTime)
    {
        return dateTime.ToUniversalTime ().ToString ("s", CultureInfo.InvariantCulture) + "Z";
    }
}