namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите предложение: ");
            string text = Console.ReadLine()!;       
            string[] words = text.Split(' ');           
            for (int i = 0; i < words.Length; i++)
            {
                char[] ch = words[i].ToCharArray();  
                Array.Reverse(ch);                 
                words[i] = new string(ch);          
            }
            string result = string.Join(" ", words);
            Console.WriteLine($"Перевернутые слова: {result}");
        }
    }
}
