namespace Task2
{
    internal class SimpleRating : IRatingStrategy
    {
        public void PrintRating()
        {
            Console.WriteLine("У вас простой рейтинг");
        }
    }
}
