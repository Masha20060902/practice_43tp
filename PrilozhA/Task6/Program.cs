namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var x = 1;
            double y = Math.Pow(x, 2) - (Math.Sqrt(Math.Abs(1 - Math.Pow(Math.Sin(x), 2)))) / (Math.Cos(2 * Math.PI) / 3) * Math.Exp(4 * Math.Sqrt(x));
            Console.WriteLine($"Значение функции= {y}");
        }
    }
}
