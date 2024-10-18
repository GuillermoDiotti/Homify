using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Homify.BusinessLogic.Utility;

[ExcludeFromCodeCoverage]
public static class HomifyDateTime
{
    public static string Parse(string date)
    {
        try
        {
            var isParsed = DateTimeOffset.TryParseExact(
                date,
                "dd/MM/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTimeOffset dateParsed);

            if (!isParsed)
            {
                throw new ArgumentException("Invalid date format");
            }

            return dateParsed.ToString("dd/MM/yyyy");
        }
        catch (ArgumentException ex)
        {
            return ex.Message;
        }
    }

    public static string GetActualDate()
    {
        DateTimeOffset actual = DateTimeOffset.Now;
        var fecha = Parse(actual.ToString("dd/MM/yyyy"));
        return fecha;
    }
}
