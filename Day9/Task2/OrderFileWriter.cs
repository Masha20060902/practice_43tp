namespace Task2
{
    internal class OrderFileWriter
    {
        private string fileorders = "file.data";
        public void WriteOrders(List<Order> orders)
        {
            using (StreamWriter stream = new StreamWriter(fileorders))
            {
                foreach (var order in orders)
                {
                    stream.WriteLine(order);
                }
            }
        }
    }
}
