namespace Task2
{
    internal class Store
    {
        public Supplier[] Suppliers { get; }
        private Inventory invent = new Inventory();
        public int Name { get; set; }
        public Store(int name, Supplier[] suppliers)
        {
            Name = name;
            Suppliers = suppliers;
        }

        public void AddProduct(Products product)
        {
            invent.AddProduct(product);
        }
        public string SellProduct(int productName, int count, Customer customer)
        {
            var product = invent.FindProduct(productName);
            if (product == null)
            {
                return "Нет товара";
            }
            if (!product.Sale(count))
            {
                return "Не хватает товара";
            }
            return "Продажа прошла успешно";
        }
        public override string ToString()
        {
            return $"Магазин {Name}";
        }
        public Products[] GetAllProducts()
        {
            return invent.GetAllProducts();
        }
    }
}
