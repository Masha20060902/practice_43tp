namespace Task8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите строку: ");
            string str = Console.ReadLine();
            ClassFormat.FormatText(in str, out string res);
            Console.WriteLine($"Результ: {res}");
            Console.WriteLine("Какой регистр хотите: ");
            Console.WriteLine("Вверхний(true), Нижний(false)");
            bool s = Convert.ToBoolean(Console.ReadLine());
            ClassFormat.FormatText(in str, s, out res);
            Console.WriteLine($"Результ: {res}");
        }
    }
}
