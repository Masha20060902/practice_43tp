namespace Task2
{
    internal class Products
    {
        public int CountProducts {  get; set; }
        public int Name { get; }
        public double Price { get; set; }
        public Products(int countProducts, int name, double price)
        {
            CountProducts = countProducts;
            Name = name;
            Price = price;
        }
        public bool Sale(int count)
        {
            if (CountProducts < count)
                return false;

            CountProducts -= count;
            return true;
        }
        public override string ToString()
        {
            return $"Товар {Name}, кол-во: {CountProducts}, цена за штуку: {Price}";
        }
    }
}
