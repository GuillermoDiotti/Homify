namespace Homify.Exceptions;

public class DuplicatedDataException : Exception
{
    public DuplicatedDataException(string message)
        : base(message)
    {
    }
}
