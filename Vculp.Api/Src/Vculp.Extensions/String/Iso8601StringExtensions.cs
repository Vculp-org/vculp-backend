using System.Globalization;

namespace Vculp.Extensions.String;

public static class Iso8601StringExtensions
{
    public static bool TryParseIso8601Date (this string iso8601Date, out DateTime result)
    {
        if (string.IsNullOrWhiteSpace (iso8601Date)) {
            result = default(DateTime);
            return false;
        }
        if (!DateTime.TryParseExact (iso8601Date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var result2)) {
            result = default(DateTime);
            return false;
        }
        result = result2;
        return true;
    }

    public static bool TryParseIso8601DateTimeToUtc (this string iso8601DateTime, out DateTime result)
    {
        if (string.IsNullOrWhiteSpace (iso8601DateTime)) {
            result = default(DateTime);
            return false;
        }
        if (!DateTime.TryParse (iso8601DateTime, null, DateTimeStyles.RoundtripKind, out var result2)) {
            result = default(DateTime);
            return false;
        }
        result = result2.ToUniversalTime ();
        return true;
    }
}