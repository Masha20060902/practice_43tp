namespace Task4
{
    internal class ProcessingMonitor
    {
        private DataProcessor dataprocessor;
        private ReportGenerator reportGeneratorcs;
        private Notifier notifier;
        public ProcessingMonitor(DataProcessor dataprocessor, ReportGenerator reportGeneratorcs, Notifier notifier)
        {
            dataprocessor.ProcessingCompleted += reportGeneratorcs.CreateReport;
            dataprocessor.ProcessingCompleted += notifier.Notifiers;
        }
    }
}
