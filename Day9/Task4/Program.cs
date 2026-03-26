namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Папка для отслеживания: ");
            string path = Console.ReadLine();
            if (!Directory.Exists(path))
            {
                Console.WriteLine("Папка не найдена.");
                return;
            }
            var watcher = new FileWatcher(path);
            Console.WriteLine("Отслеживание запущено");
            Console.ReadLine();
        }
    }
}
