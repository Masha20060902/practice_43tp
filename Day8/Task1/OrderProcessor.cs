namespace Task1
{
    internal class OrderProcessor
    {
        public Queue<Order> Addition(int n)
        {
            var orders = new Queue<Order>(n);
            var order = new List<Order>(n);
            var r = new Random();
            for (int i = 0; i < n; i++)
            {
                var OrderID = r.Next(1, 1000);
                var Customer = r.Next(1, 1000);
                var Items = r.Next(1, 2000);
                order.Add(new Order { OrderID = OrderID, Customer = Customer, Items = Items });
            }
            foreach (var item in order)
            {
                orders.Enqueue(item);
            }
            return orders;
        }
        public Queue<Order> DeliteQueue(Queue<Order> orders, int element)
        {
            var newqueue = new Queue<Order>();
            foreach (var t in orders)
            {
                if (t.OrderID != element)
                {
                    newqueue.Enqueue(t);
                }
            }
            return newqueue;
        }
        public string SearchElement(Queue<Order> orders, int element)
        {
            int i = 1;
            foreach (var item in orders)
            {
                if (i == element)
                {
                    return $"Заказ {item.OrderID} от клиента {item.Customer}: Кол-во предметов {item.Items}";
                }
                i++;
            }
            return "Такого заказа нет";
        }
        public Queue<Order> SortQueue(Queue<Order> orders, int sort)
        {
            Order[] arr = new Order[orders.Count];
            orders.CopyTo(arr, 0);
            Array.Sort(arr, CompareOrdersById);
            if (sort == 2)
            {
                Array.Reverse(arr);
            }
            return new Queue<Order>(arr);
        }
        private static int CompareOrdersById(Order a, Order b)
        {
            return a.OrderID.CompareTo(b.OrderID);
        }
        public void Print(Queue<Order> orders)
        {
            foreach (var o in orders)
            {
                Console.WriteLine(o);
            }
        }
    }
}
