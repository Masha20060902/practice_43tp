namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вычисление объема цилиндра.");
            Console.WriteLine("Введите исходные данные: ");
            Console.Write("Радиус основания (см) -> ");
            double r = Convert.ToDouble(Console.ReadLine());
            Console.Write("Высота цилиндра (см) -> ");
            int h = Convert.ToInt32(Console.ReadLine());
            var V = Math.PI * Math.Pow(r, 2) * h;
            Console.Write($"Объем цилиндра: {V:F2} куб. см.");
        }
    }
}