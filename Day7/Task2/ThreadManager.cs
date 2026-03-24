
namespace Task2
{
    internal class ThreadManager
    {
        private ThreadWorker _worker = new ThreadWorker();
        public ThreadManager(ThreadWorker worker)
        {
            _worker = worker;
        }
        public void RunWithLogging(Action action)
        {
            try
            {
                _worker.StartThread(action);

            }
            catch (ThreadInterruptedException ex)
            {
                var wrapped = new ThreadOperationException("Поток был принудительно завершён.", ex);
                Console.WriteLine(wrapped.Message);
                Console.WriteLine("Inner: " + wrapped.InnerException);
                Console.WriteLine("StackTrace:");
                Console.WriteLine(wrapped.InnerException.StackTrace);
                throw wrapped;
            }
        }
    }
}
