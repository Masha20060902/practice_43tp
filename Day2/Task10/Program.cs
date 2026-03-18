using System.Text;

namespace Task10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите строку: ");
            String a = Console.ReadLine();
            var sb = new StringBuilder();
            sb.Append(a);
            string text = sb.ToString();
            int i = 0;
            while (i < text.Length)
            {
                int start = text.IndexOf('<', i);   
                int end = text.IndexOf('>', start + 1);  
                string tag = text.Substring(start, end - start + 1);
                Console.WriteLine(tag);
                i = end + 1;
            }
        }
    }
}
