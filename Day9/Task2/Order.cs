namespace Task2
{
    internal class Order
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"Заказ {Id}: {ProductName} покупает {Quantity} покупатель";
        }
    }
}
