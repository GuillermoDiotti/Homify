using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Homify.BusinessLogic.Utility;

[ExcludeFromCodeCoverage]
public class HomifyDateTime
{
    public static DateTimeOffset Parse(string date)
    {
        var isParsed = DateTimeOffset.TryParseExact(
            date,
            "yyyy-MM-dd",
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out DateTimeOffset dateParsed);

        if (!isParsed)
        {
            throw new ArgumentException("Invalid published on");
        }

        return dateParsed;
    }
}
