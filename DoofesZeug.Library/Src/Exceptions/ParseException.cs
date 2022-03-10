using System;



namespace DoofesZeug.Exceptions
{
    public sealed class ParseException : Exception
    {
        public ParseException( string message )
            : base(message)
        {
        }
    }
}
