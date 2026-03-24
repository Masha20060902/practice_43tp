namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите дату: ");
            string level = Console.ReadLine();
            DateValidator bm = new DateValidator();
            try
            {
                bm.ValidateDate(level);
            }
            catch (InvalidDateFormatException lb)
            {
                Console.WriteLine(lb.Message);
            }
        }
    }
}
