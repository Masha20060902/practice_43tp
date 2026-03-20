namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите часы: ");
            int h = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите минуты: ");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите секунды: ");
            int s = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите секунды для вычетания: ");
            int t = Convert.ToInt32(Console.ReadLine());
            ClassTime.DecTime(ref h, ref m, ref s, t);
            Console.WriteLine($"Результат: {h:D2}:{m:D2}:{s:D2}");
        }
    }
}
