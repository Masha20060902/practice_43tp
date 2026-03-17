using System.ComponentModel.Design;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите вещественное число от -5 включительно до 5 включительно: ");
            double a = Convert.ToDouble(Console.ReadLine());
            if (a >= -5 && a <= 5)
            {
                Console.Write("Введите целое число степени от 1 включительно до 10 включительно: ");
                int n = Convert.ToInt32(Console.ReadLine());
                if (n >= 1 && n <= 10)
                {
                    double p = 1;
                    for (int i = 0; i < n; i++)
                    {
                        p *= a;
                    }
                    Console.WriteLine($"Число в степени равняется: {p:F4}");
                }
                else
                {
                    Console.WriteLine("Нужно ввести целое число от 1 включительно до 10 включительно.");
                }
            }
            else
            {
                Console.WriteLine("Нужно ввести вещественное число от -5 включительно до 5 включительно.");
            }
        }
    }
}
