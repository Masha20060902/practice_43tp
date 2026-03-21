namespace Task2
{
    internal class StoreService
    {
        private Random r = new Random();
        public Supplier[] CreateSuppliers(int countSupplier)
        {
            var suppliers = new Supplier[countSupplier];
            for (int i = 0; i < countSupplier; i++)
                suppliers[i] = new Supplier(i + 1);
            return suppliers;
        }
        public Store[] CreateStores(int countStore, int suppliersStore, Supplier[] suppliers)
        {
            var stores = new Store[countStore];
            int countSupplier = suppliers.Length;
            for (int i = 0; i < countStore; i++)
            {
                Supplier[] storeSuppliers = new Supplier[suppliersStore];
                for (int j = 0; j < suppliersStore; j++)
                {
                    int idx = (i * suppliersStore + j) % countSupplier;
                    storeSuppliers[j] = suppliers[idx];
                }
                stores[i] = new Store(i + 1, storeSuppliers);
            }
            return stores;
        }
        public void FillProducts(Store[] stores, int countProduct)
        {
            foreach (var store in stores)
            {
                for (int i = 0; i < countProduct; i++)
                {
                    int productName = r.Next(1, 200);
                    int countProd = r.Next(1, 20);
                    double price = r.Next(2, 100);

                    store.AddProduct(new Products(countProd, productName, price));
                }
            }
        }
        public Products[] GetAllProducts(Store[] stores)
        {
            List<Products> list = new List<Products>();
            foreach (var store in stores)
            {
                Products[] products = store.GetAllProducts();
                foreach (var p in products)
                    list.Add(p);
            }
            return list.ToArray();
        }
        public Products[] SortProductsByPrice(Store[] stores, bool ascending = true)
        {
            Products[] all = GetAllProducts(stores);
            Array.Sort(all, (a, b) =>
            {
                if (a.Price == b.Price)
                {
                    return 0;
                }
                if (ascending)
                {
                    if (a.Price < b.Price)
                    {
                        return -1;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    if (a.Price > b.Price)
                    {
                        return -1;
                    }
                    else
                    {
                        return 1;
                    }
                }
            });
            return all;
        }
        public int CountAllProducts(Store[] stores)
        {
            int total = 0;
            foreach (var store in stores)
            {
                Products[] products = store.GetAllProducts();
                for (int i = 0; i < products.Length; i++)
                {
                    total += products[i].CountProducts;
                }
            }
            return total;
        }
    }
}
