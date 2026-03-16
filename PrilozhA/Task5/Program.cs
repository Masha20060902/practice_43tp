namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите четырехзначное число");
            int num = Convert.ToInt32(Console.ReadLine());
            int num1 = num % 10;
            int num2 = (num % 100) / 10;
            int num3 = (num % 1000) / 100;
            int num4 = (num % 10000) / 1000;
            Console.WriteLine($"Перевернутое число: {num1}{num2}{num3}{num4}");
        }
    }
}
