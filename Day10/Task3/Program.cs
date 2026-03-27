namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите кол-во заказчиков: ");
            int count = Convert.ToInt32(Console.ReadLine());
            var customers = new List<Customer>(count);
            var r = new Random();
            for (int i = 0; i < count; i++)
            {
                var customer = new Customer
                {
                    name = r.Next(1, 50),
                };
                customers.Add(customer);
            }
            Console.WriteLine("Список заказчиков");
            foreach (var c in customers)
            {
                Console.WriteLine(c);
            }
            var store = new OnlineStore();
            foreach (var customer in customers)
            {
                store.Subscribe(customer);
            }
            Console.WriteLine("Вы магазин. Напишите, какая у вас будет скидка: ");
            var dis = Console.ReadLine();
            store.AnnounceDiscount(dis);
            Console.WriteLine("Введите номер заказчика, которого хотите отписать: ");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Оставшиеся заказчики");
            var toRemove = new List<Customer>();
            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].name == num)
                {
                    toRemove.Add(customers[i]);
                }
            }
            foreach (var customer in toRemove)
            {
                store.Unsubscribe(customer);
                customers.Remove(customer);
            }
            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }
            Console.WriteLine("Напишите, какая еще у вас будет скидка: ");
            var dis2 = Console.ReadLine();
            store.AnnounceDiscount(dis2);
        }
    }
}
