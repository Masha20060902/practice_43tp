namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите трёхзначное число");
            int num = Convert.ToInt32(Console.ReadLine());
            int num1 = (num % 10);
            int num2 = (num % 100) / 10;
            int num3 = num / 100;
            int p = num1 * num2 * num3;
            Console.WriteLine($"Прозведение чисел: {p}");
        }
    }
}
