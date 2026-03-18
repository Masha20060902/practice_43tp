namespace Task4
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
                int sum_row = 0;
                Console.Write("Введите номер строки: ");
                int k = Convert.ToInt32(Console.ReadLine());
                if (k < n)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        sum_row += arr[k, j];
                    }
                    Console.WriteLine($"Сумма заданной строки = {sum_row} ");
                }
                else
                {
                    Console.WriteLine("Такой строки нет.");
                }
                Console.Write("Введите номер столбца: ");
                int s = Convert.ToInt32(Console.ReadLine());
                int sum_coll = 0;
                if (s < n)
                {
                    for (int i = 0; i < arr.GetLength(0); i++)
                    {
                        sum_coll += arr[i, s];
                    }
                    Console.WriteLine($"Сумма заданного столбца = {sum_coll} ");
                }
                else
                {
                    Console.WriteLine("Такого столбца нет.");
                }
                if (sum_row> sum_coll)
                {
                    Console.WriteLine("Сумма элементов строки больше суммы элементов столбца");
                }
                else
                {
                    Console.WriteLine("Сумма элементов столбца больше суммы элементов строки");
                }
            }
            else
            {
                Console.WriteLine("Количество элементов строго до 10");
            }
        }
    }
}
