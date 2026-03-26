namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var filewrite = new OrderFileWriter();
            Console.Write("Введите количество заказов: ");
            int n = Convert.ToInt32(Console.ReadLine());
            var orders = new List<Order>(n);
            var r = new Random();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите название продукта {i}: ");
                var order = new Order
                {
                    Id = r.Next(0, 100),
                    ProductName = Console.ReadLine(),
                    Quantity = r.Next(0, 100),
                };
                orders.Add(order);
            }
            filewrite.WriteOrders(orders);
            var filereader = new OrderFileReader("file.data", orders);
            Console.Write("Проверка соответствия данных файла и списка заказов: ");
            Console.WriteLine(filereader.VerifyFile());
        }
    }
}
