namespace Task2
{
    internal class ThreadWorker
    {
        private Thread thread;
        public void StartThread(Action action)
        {
            ThreadInterruptedException captured = null;
            thread = new Thread(() =>
            {
                try
                {
                    action();
                }
                catch (ThreadInterruptedException ex)
                {
                    captured = ex;
                    throw;
                }
            });
            thread.Start();

        }
        public void Abort()
        {
            try
            {
                thread.Interrupt();
            }
            catch
            {
            }
        }
    }
}
