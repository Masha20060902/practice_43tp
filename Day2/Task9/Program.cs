using System.Text;

namespace Task9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите строку: ");
            string a = Console.ReadLine();
            var sb = new StringBuilder();
            sb.Append(a);
            Console.Write("Введите символ-разделитель: ");
            char ras = Convert.ToChar(Console.ReadLine());
            string text = sb.ToString();
            string[] lines = text.Split(ras);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}
