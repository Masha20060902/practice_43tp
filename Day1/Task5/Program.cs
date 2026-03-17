namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите стороны.");
            Console.Write("a= ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("b= ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.Write("c= ");
            double c = Convert.ToDouble(Console.ReadLine());
            if (Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2))
            {
                Console.WriteLine("Треугольник прямоугольный.");
            }
            else
            {
                Console.WriteLine("Треугольник не является прямоугольным.");
            }
        }
    }
}
