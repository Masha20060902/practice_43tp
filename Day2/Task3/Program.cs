namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размерность квадратной матрицы от 1 до 10: ");
            var n = Convert.ToInt32(Console.ReadLine());
            if (n < 10)
            {
                int[,] arr = new int[n, n];
                var r = new Random();
                Console.WriteLine("Введите диапазон заполнения.");
                Console.Write("Начальное значение: ");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.Write("Конечное значение: ");
                int b = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        arr[i, j] = r.Next(a, b);
                        Console.Write($"{arr[i, j]}   ");
                    }
                    Console.WriteLine();
                }
                Console.Write("Введите число Н: ");
                int h = Convert.ToInt32(Console.ReadLine());
                int count = 0;
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        if (arr[i, j] < h)
                        {
                            count++;
                        }
                    }
                }
                Console.WriteLine($"Кол-во элементов меньше заданного = {count} ");
                Console.Write("Введите номер столбца: ");
                int k = Convert.ToInt32(Console.ReadLine());
                int count_num = 0;
                if (k < n)
                {
                    for (int i = 0; i < arr.GetLength(0); i++)
                    {
                        if (arr[i, k] % 2 != 0)
                        {
                            count_num++;
                        }
                    }
                    Console.WriteLine($"Кол-во нечетных элементов в заданном столбце = {count_num} ");
                }
                else
                {
                    Console.WriteLine("Такого столбца нет.");
                }
            }
            else
            {
                Console.WriteLine("Количество элементов строго до 10");
            }
        }
    }
}
