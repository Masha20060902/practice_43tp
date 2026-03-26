namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var reader = new OrderFileReader();
            List<Order> orders = reader.ReadOrders();
            var processor = new OrderProcessor(orders);
            Console.Write("Введите N для топа товаров: ");
            int topN = Convert.ToInt32(Console.ReadLine());
            processor.GetMostPopularProducts(topN);
        }
    }
}
