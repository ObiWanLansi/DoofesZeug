using System;



namespace DoofesZeug.Exceptions;

public sealed class ParseException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ParseException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public ParseException(string message)
        : base(message)
    {
    }
}
