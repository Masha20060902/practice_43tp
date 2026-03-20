namespace Task5
{
    abstract class Book
    {
        public abstract void Read();
        public virtual void DisplayInfo()
        {
            Console.WriteLine("Информация о книге");
        }
    }
}
