namespace Task2
{
    internal class Inventory
    {
        private List<Products> products = new List<Products>();
        public void AddProduct(Products p)
        {
            products.Add(p);
        }
        public Products FindProduct(int name)
        {
            return products.FirstOrDefault(p => p.Name == name);
        }
        public Products[] GetAllProducts()
        {
            return products.ToArray();
        }
    }
}
