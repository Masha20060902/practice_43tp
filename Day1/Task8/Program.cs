namespace Task8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите цену 1 кг конфет: ");
            double a = Convert.ToDouble(Console.ReadLine());
            if (a >= 1 && a <= 100)
            {
                for (double i = 0.0; i <= 1.0; i += 0.1)
                {
                    double cell = i * a;
                    Console.WriteLine($"За {i:F3} кг. - {cell:F4} руб.");
                }
            }
            else
            {
                Console.WriteLine("Цена должна быть от 1 до 100 рублей");
            }
        }
    }
}
