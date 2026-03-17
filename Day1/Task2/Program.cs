namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Проверка на разные цифры в трехзначном числе.");
            Console.Write("Введите трехзначное число: ");
            int num = Convert.ToInt32(Console.ReadLine());
            if ((num % 10) != (num % 100 / 10) && (num % 10) != (num % 1000 / 100) && (num % 100 / 10) != (num % 1000 / 100))
            {
                Console.WriteLine("Все цифры не равны");
            }
            else
            {
                Console.WriteLine("Есть равные цифры");
            }
        }
    }
}
