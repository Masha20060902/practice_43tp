namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите длину массива: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[n];
            var r = new Random();
            for (int i = 0; i < n; i++)
            {
                a[i] = r.Next(1, 10);
                Console.WriteLine(a[i]);
            }
            int sum = ClassArr.ArraySum(a);
            Console.WriteLine("Сумма: " + sum);
        }
    }
}
