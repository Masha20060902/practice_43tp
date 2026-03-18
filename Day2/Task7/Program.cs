using System.Text.RegularExpressions;

namespace Task7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку: ");
            String str = Console.ReadLine();
            var patern = @"\d";
            var r = new Regex(patern);
            String new_str = r.Replace(str, "");
            Console.WriteLine($"Строка без цифр{new_str}");

        }
    }
}
