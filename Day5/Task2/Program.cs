namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Позравляю с повышением, вы самый главный управляющий сетью магазинов!");
            var manager = new StoreService();
            Console.Write("Введите кол-во поставщиков товаров: ");
            int countSupplier = Convert.ToInt32(Console.ReadLine());
            Supplier[] suppliers = manager.CreateSuppliers(countSupplier);
            Console.WriteLine("Ваши поставщики: ");
            foreach (var s in suppliers)
            {
                Console.WriteLine(s);
            }
            Console.Write("Введите кол-во ваших магазинов: ");
            int countStore = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите кол-во поставщиков у одного магазина: ");
            int suppliersStore = Convert.ToInt32(Console.ReadLine());
            Store[] stores = manager.CreateStores(countStore,suppliersStore, suppliers);
            Console.WriteLine("Вот список работы поставщиков в ваших магазинах: ");
            for (int i = 0; i < countStore; i++)
            {
                Console.Write($"{stores[i]}: ");
                foreach (var sup in stores[i].Suppliers)
                    Console.Write($"{sup}  ");
                Console.WriteLine();
            }

            Console.Write("Введите количество товаров: ");
            int countProduct = Convert.ToInt32(Console.ReadLine());
            manager.FillProducts(stores,countProduct);
            Console.WriteLine("Товары по магазинам: ");
            foreach (var store in stores)
            {
                Console.WriteLine($"\n{store}:");
                foreach (var p in store.GetAllProducts())
                {
                    Console.WriteLine(p);
                }
            }
            Console.Write("Ваш покупатель совершает покупку...");
            var customer = new Customer(1);
            Console.Write("Введите номер магазина, где покупатель покупает:", countStore);
            int storeIndex = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Write("Введите номер товара: ");
            int prodName = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите количество: ");
            int count = Convert.ToInt32(Console.ReadLine());
            string result = stores[storeIndex].SellProduct(prodName, count, customer);
            Console.WriteLine(result);
            Console.WriteLine();
            Console.WriteLine("Инвенторизация: ");
            var allProducts = manager.GetAllProducts(stores);
            foreach (var p in allProducts)
            {  
                Console.WriteLine(p); 
            }
            Products[] sortedAsc = manager.SortProductsByPrice(stores, true);
            Console.WriteLine("\nТовары, отсортированные по цене (по возрастанию):");
            for (int i = 0; i < sortedAsc.Length; i++)
            {
                Console.WriteLine(sortedAsc[i]);
            }
            Products[] sortedDesc = manager.SortProductsByPrice(stores, false);
            Console.WriteLine("\nТовары, отсортированные по цене (по убыванию):");
            for (int i = 0; i < sortedDesc.Length; i++)
            {
                Console.WriteLine(sortedDesc[i]);
            }
            int totalCount = manager.CountAllProducts(stores);
            Console.WriteLine($"Общее количество всех товаров во всех магазинах: {totalCount}");
        }
    }
}
