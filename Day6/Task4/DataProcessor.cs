namespace Task4
{
    internal class DataProcessor
    {
        public event EventHandler<string> ProcessingCompleted;
        public void CompletedProcessing(string news)
        {
            ProcessingCompleted?.Invoke(this, news);
        }
    }
}