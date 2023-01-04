namespace CoTools.Common.Exceptions
{
    public class CoToolsException : Exception
    {
        public CoToolsException(string? message) : base(message)
        {
        }

        public CoToolsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
