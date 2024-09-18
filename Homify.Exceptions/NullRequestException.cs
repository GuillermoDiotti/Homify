namespace Homify.Exceptions;

public class NullRequestException : Exception
{
    public NullRequestException()
        : base("Request cannot be null")
    {
    }

    public NullRequestException(string message)
        : base(message)
    {
    }
}

