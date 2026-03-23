namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите длину массива строк: ");
            int n = Convert.ToInt32(Console.ReadLine());
            string[] str = new string[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите {i + 1} строку: ");
                str[i] = Console.ReadLine();
            }
            var classtext = new ClassText();
            TextFilter ft1 = classtext.ConteinsDigit;
            var filter = classtext.FilterText(str, ft1);
            Console.Write("Строки, где есть цифры: ");
            foreach (var f in filter)
            {
                Console.WriteLine($"{f}  ");
            }
            TextFilter ft2 = classtext.ContainsSpecialCharacters;
            var contains = classtext.FilterText(str, ft2);
            Console.Write("Строки, содержащие спец. символы: ");
            foreach (var c in contains)
            {
                Console.WriteLine($"{c}  ");
            }
        }
    }
}
