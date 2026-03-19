
namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите первое значение: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите второе значение: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            var a = new A(num1, num2);
            var expression1 = a.Calculation();
            Console.WriteLine($"Результат вычисления выражения: {expression1}");
            var expression2 = a.Exponentiation();
            Console.WriteLine($"Результат возведения произведения: {expression2}");
        }
    }
}
