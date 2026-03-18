using System.Text.RegularExpressions;

namespace Task8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите строку: ");
            string text = Console.ReadLine();
            string[] words = text.Split(' ');
            string result = words[0].ToLower();
            for (int i = 1; i < words.Length; i++)
            {
                string w = words[i].ToLower();
                result += char.ToUpper(w[0]) + w.Substring(1);
            }
            Console.WriteLine(result);
        }
    }
}
