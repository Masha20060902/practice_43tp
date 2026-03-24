namespace Task1
{
    internal class LowBatteryException : Exception
    {
        public LowBatteryException() { }
        public LowBatteryException(string message) : base(message) { }
        public LowBatteryException(string message, Exception innerException) : base(message, innerException) { }
    }
}
