namespace Task3
{
    internal class OrderFileReader
    {
        private string _fileorder = "C:\\Users\\Маша\\Desktop\\Учеба\\Практика\\Day9\\Task2\\bin\\Debug\\net10.0\\file.data";
        public List<Order> ReadOrders()
        {
            var orders = new List<Order>();
            foreach (var line in File.ReadLines(_fileorder))
            {
                var el = line.Split(' ');
                var idStr = el[1].TrimEnd(':');
                var qtyStr = el[4];
                var order = new Order
                {
                    Id = Convert.ToInt32(idStr),
                    ProductName = el[2],
                    Quantity = Convert.ToInt32(qtyStr)
                };
                orders.Add(order);
            }
            return orders;
        }
    }
}