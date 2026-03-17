namespace Task9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вычисление функции.");
            int m = 10;
            double a = 0;
            double b = 3 * Math.PI;
            double h = (b - a) / m;
            Console.Write("Введите х: ");
            double x = Convert.ToDouble(Console.ReadLine());
            for (double i = 0.0; i <= m; i += h)
            {
                double xi = x + i;
                double f = xi * Math.Sin(xi);
                Console.WriteLine($"{xi} ; {f}");
            }
        }
    }
}
