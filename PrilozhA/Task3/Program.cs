namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число а: ");
            int a = Convert.ToInt32(Console.ReadLine());
            double z1 = Math.Pow((1 + a + Math.Pow(a, 2)) / (2 * a + a) + 2 - (1 - a + Math.Pow(a, 2)) / (2 * a - Math.Pow(a, 2)), -1) * (5 - 2 * Math.Pow(a, 2));
            double z2 = (4 - Math.Pow(a, 2)) / 2;
            Console.WriteLine($"Ответ на первое уравнение: {z1}");
            Console.WriteLine($"Ответ на второе уравнение: {z2}");
        }
    }
}
