namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Нахождение порядкогого номера максимального элемента.");
            var r = new Random();
            double[] arr = new double[10];
            double max = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.NextDouble();
                Console.Write($"{arr[i]}  ");
                if(arr[i] > max)
                {
                    max = arr[i];
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Максимальный элемент {max} на позиции: {Array.IndexOf(arr,max)}");
        }
    }
}
