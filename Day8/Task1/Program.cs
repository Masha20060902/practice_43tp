namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество заказов: ");
            int n = Convert.ToInt32(Console.ReadLine());
            var processor = new OrderProcessor();
            Console.WriteLine("Все заказы: ");
            var orders = processor.Addition(n);
            processor.Print(orders);
            Console.WriteLine("Введите Id заказа который хотите удалить: ");
            int orderid = Convert.ToInt32(Console.ReadLine());
            var del = processor.DeliteQueue(orders, orderid);
            Console.WriteLine("После удаления заказа: ");
            processor.Print(del);
            Console.WriteLine("Какой по счету заказ вывести?");
            int id = Convert.ToInt32(Console.ReadLine());
            var billnum = processor.SearchElement(del, id);
            Console.WriteLine(billnum);
            Console.WriteLine("Как отсортировать заказы: по возрастанию(1), по убыванию(2)");
            int sort = Convert.ToInt32(Console.ReadLine());
            del = processor.SortQueue(del, sort);
            processor.Print(del);
        }
    }
}
