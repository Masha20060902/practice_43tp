namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество строк (1..10): ");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n < 10)
            {
                int[][] arr = new int[n][];
                var r = new Random();
                Console.WriteLine("Введите диапазон заполнения.");
                Console.Write("Начальное значение: ");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.Write("Конечное значение (не включительно): ");
                int b = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"Введите длину строки: ");
                    int m = Convert.ToInt32(Console.ReadLine());
                    arr[i] = new int[m];
                    for (int j = 0; j < m; j++)
                    {
                        arr[i][j] = r.Next(a, b);
                        Console.Write(arr[i][j] + " ");
                    }
                    Console.WriteLine();
                }
                for (int i = 0; i < arr.Length; i++)
                {
                    Array.Sort(arr[i]);         
                    Array.Reverse(arr[i]);       
                }
                Console.WriteLine();
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine(string.Join(" ", arr[i]));
                }
            }
            else
            {
                Console.WriteLine("Количество элементов строго до 10");
            }

        }
    }
}
