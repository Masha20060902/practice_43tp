namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вычисление функции y.");
            Console.Write("Введите х от 0,1 включительно до 1,5 вклюительно: ");
            double x = Convert.ToDouble(Console.ReadLine());
            if (x >= 0.1 && x <= 1.5)
            {
                double y = Math.Log(Math.Exp(x) + 4) - 2 * x;
                Console.Write($"Функция y равняется: {y}");
            }
            else if (x > 1.5)
            {
                double y = Math.Pow(x, 2) - 1;
                Console.Write($"Функция y равняется: {y}");
            }
            else
            {
                Console.WriteLine("Число х должно быть от 0,1 включительно до 1,5 вклюительно.");
            }
        }
    }
}
