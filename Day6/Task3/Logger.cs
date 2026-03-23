namespace Task3
{
    internal class Logger
    {
        public void OnFileChanged(string filename)
        {
            Console.WriteLine($"Файл изменен {filename}");
        }
    }
}
