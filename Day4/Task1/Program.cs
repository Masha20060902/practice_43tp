namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите длину массива: ");
            int n = Convert.ToInt32(Console.ReadLine());
            var arr = ClassArray.GenerationArray(n);
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{arr[i]}, ");
            }
            Console.WriteLine();
            Console.Write("Введите элемент массива: ");
            int ind = Convert.ToInt32(Console.ReadLine());
            Console.Write("Индекс элемента: ");
            int search = ClassArray.SearchIndex(ind, arr);
            Console.WriteLine(search);
        }
    }
}