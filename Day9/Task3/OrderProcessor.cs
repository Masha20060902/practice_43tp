namespace Task3
{
    internal class OrderProcessor
    {
        private List<Order> _orders;
        public OrderProcessor(List<Order> orders)
        {
            _orders = orders;
        }
        private void CountProducts(out List<string> products, out List<int> counts)
        {
            products = new List<string>();
            counts = new List<int>();
            foreach (var order in _orders)
            {
                string name = order.ProductName;
                int index = products.IndexOf(name);
                if (index == -1)
                {
                    products.Add(name);
                    counts.Add(1);
                }
                else
                {
                    counts[index]++;
                }
            }
        }
        private void SortProductsByCount(List<string> products, List<int> counts)
        {
            for (int i = 0; i < counts.Count - 1; i++)
            {
                for (int j = i + 1; j < counts.Count; j++)
                {
                    if (counts[j] > counts[i])
                    {
                        int tmpCount = counts[i];
                        counts[i] = counts[j];
                        counts[j] = tmpCount;
                        string tmpProd = products[i];
                        products[i] = products[j];
                        products[j] = tmpProd;
                    }
                }
            }
        }
        public void GetMostPopularProducts(int topN)
        {
            CountProducts(out var products, out var counts);
            SortProductsByCount(products, counts);
            int limit = Math.Min(topN, products.Count);
            Console.WriteLine($"Топ {limit} товаров:");
            for (int i = 0; i < limit; i++)
            {
                Console.WriteLine($"{products[i]} — {counts[i]} заказ(ов)");
            }
        }
    }
}
