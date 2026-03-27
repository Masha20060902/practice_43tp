namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EventDispatcher.Dispatcher.Subscribe("User1", Handler);
            EventDispatcher.Dispatcher.Dispatch("User1");
            EventDispatcher.Dispatcher.Unsubscribe("User1", Handler);
        }
        static void Handler()
        {
            Console.WriteLine("Пользователь вошел в систему");
        }
    }
}
