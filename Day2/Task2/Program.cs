namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[n];
            var r = new Random();
            for (int i = 0; i < n; i++)
            {
                a[i] = r.Next(-70, 70);
                Console.Write($"{a[i]}  ");
            }
            bool queue = true;
            for (int i = 1; i < n; i++)
            {
                if (Math.Sign(a[i]) == Math.Sign(a[i - 1]))
                {
                    queue = false;
                    break;
                }
            }
            int[] result;
            if (queue)
            {
                result = a;
                Console.WriteLine("Знаки элементов чередуются");
            }
            else
            {
                Console.WriteLine("Знаки не чередуются.");
                int count = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] < 0)
                        count++;
                }
                result = new int[count];
                int idx = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] < 0)
                    {
                        result[idx] = a[i];
                        idx++;

                    }
                }
                Console.WriteLine("Отрицательные элементы:");
                for (int i = 0; i < result.Length; i++)
                {
                    Console.Write(result[i] + " ");
                }
            }
            Console.WriteLine();
            Array.Sort(result);
            Console.WriteLine("Отсортированный массив:");
            if (result.Length > 0)
            {
                Console.WriteLine(string.Join(" ", result));
            }
            else
            {
                Console.WriteLine("ничего");
            }
            Console.Write("Введите k для поиска: ");
            int k = Convert.ToInt32(Console.ReadLine());
            int index = Array.BinarySearch(result, k);
            if (index >= 0)
            {
                Console.WriteLine($"Элемент {k} найден, индекс = {index}");
            }
            else
            {
                Console.WriteLine($"Элемент {k} в массиве не найден.");
            }
        }
    }
}
