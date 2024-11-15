using Homify.Exceptions;

namespace Homify.Utility;

public static class Helpers
{
    public static string GetUserFullName(string name, string lastName)
    {
        return $"{name} {lastName}";
    }

    public static void ValidateRequest(Object? obj)
    {
        if (obj == null)
        {
            throw new NullRequestException("Request cannot be null");
        }
    }
}
