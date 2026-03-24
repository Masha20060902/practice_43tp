namespace Task3
{
    internal class InvalidDateFormatException : Exception
    {
        public InvalidDateFormatException() { }
        public InvalidDateFormatException(string message) : base(message) { }
    }
}
