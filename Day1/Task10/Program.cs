using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Runtime.InteropServices.JavaScript.JSType.String;

namespace Task10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите натуральное число: ");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num > 0)
            {
                int min = 10000000;
                int max = 1;
                while (num > 0)
                {
                    int n = Convert.ToInt32(num % 10);
                    if (n <= min)
                    {
                        min = n;
                    }
                    if (n >= max)
                    {
                        max = n;
                    }
                    num /= 10;
                }
                Console.WriteLine($"Минимальная цифра в числе = {min}");
                Console.WriteLine($"Максимальная цифра в числе = {max}");
            }
            else
            {
                Console.WriteLine("Натуральное число не может быть отрицательным и равнятся 0.");
            }
        }
    }
}