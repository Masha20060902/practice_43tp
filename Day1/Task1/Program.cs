namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Нахождение периметра прямоугольного треугольника.");
            Console.Write("Введите первый катет: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите второй катет: ");
            double b = Convert.ToDouble(Console.ReadLine());
            double p = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2)) + a + b;
            Console.WriteLine($"Периметр прямоугольного треугольника = {p}");
        }
    }
}

