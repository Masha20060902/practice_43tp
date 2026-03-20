namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Нахождение максимального  и минимального значения");
            var s = new Search();
            Console.Write("Введите число а: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите число b: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите число c: ");
            double c = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите число d: ");
            double d = Convert.ToDouble(Console.ReadLine());
            s.Minmax(ref a, ref b);
            s.Minmax(ref c, ref d);
            s.Minmax(ref a, ref c);
            s.Minmax(ref b, ref d);
            Console.WriteLine($"Min: {a}, Max: {d}");
        }
    }
}
