namespace Task7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите сумму: ");
            double sales = Convert.ToDouble(Console.ReadLine());
            Console.Write("Вы VIP-клиент (true, false): ");
            bool isVip = Convert.ToBoolean(Console.ReadLine());
            var c = CountingCommission.CalculateCommission(sales, isVip);
            Console.WriteLine($"Комиссионные: {c:F2}");
        }
    }
}
