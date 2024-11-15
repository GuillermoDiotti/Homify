using Homify.Exceptions;
using InvalidOperationException = Homify.Exceptions.InvalidOperationException;

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

    public static void ValidateNotFound(string? actor, Object? obj)
    {
        if (obj == null)
        {
            throw new NotFoundException($"{actor} not found");
        }
    }

    public static void ValidateInvalidOperation(bool obj)
    {
        if (obj == false)
        {
            throw new InvalidOperationException("Error: The data you provided is incorrect");
        }
    }

    public static void ValidateArgsNull(string? actor, Object? obj)
    {
        if (obj == null)
        {
            throw new ArgsNullException($"{actor} cannot be null");
        }
    }
}
