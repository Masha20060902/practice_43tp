namespace Task3
{
    internal class Customer : ICustomer
    {
        public int name { get; set; }
        public void Update(string discountInfo)
        {
            Console.WriteLine($"ВНИМАНИЕ заказчик {name}!!! скидка на {discountInfo}");
        }
        public override string ToString()
        {
            return $"Заказчик {name}";
        }
    }
}