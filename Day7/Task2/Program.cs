namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread curr = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(1000);
                }
            });
            ThreadWorker th = new ThreadWorker();
            var manager = new ThreadManager(th);
            Console.WriteLine("Поток запущен");
            try
            {
                manager.RunWithLogging(() =>
                {
                    try
                    {
                        while (true)
                        {
                            Thread.Sleep(1000);
                        }
                    }
                    catch (ThreadInterruptedException ex)
                    {
                        var wrapped = new ThreadOperationException("Поток был принудительно завершён.", ex);
                        Console.WriteLine(wrapped.Message);
                        Console.WriteLine("Inner: " + wrapped.InnerException);
                        //throw wrapped;
                    }
                });
            }
            catch (ThreadOperationException toe)
            {
                Console.WriteLine("В Main поймали ThreadOperationException:");
                Console.WriteLine(toe.Message);
            }
            th.Abort();
        }
    }
}
