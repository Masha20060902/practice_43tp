namespace Task1
{
    internal class Order
    {
        public int OrderID { get; set; }
        public int Customer { get; set; }
        public int Items { get; set; }
        public override string ToString()
        {
            return $"Заказ {OrderID} от клиента {Customer}: Кол-во предметов {Items}";
        }
    }
}
