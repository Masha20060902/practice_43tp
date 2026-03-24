namespace Task2
{
    internal class ThreadOperationException : Exception
    {
        public ThreadOperationException(string message, Exception innerException) : base(message, innerException) { }
    }
}
