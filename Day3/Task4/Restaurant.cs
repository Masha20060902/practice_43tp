namespace Task4
{
    internal class Restaurant
    {
        private static string[] categoryDish = { "Десерты", "Горячие блюда", "Закуски" };
        public Dish[] Dishs { get; set; }

        public Restaurant(Dish[] dish)
        {
            Dishs = dish;
        }
        public static Dish[] Generation(int count)
        {
            var r = new Random();
            var d = new Dish[count];
            for (int i = 0; i < count; i++)
            {
                string name = $"Блюдо {i}";
                int index = r.Next(categoryDish.Length);
                string category = categoryDish[index];
                int price = r.Next(5, 50);
                int weight = r.Next(100, 501);

                d[i] = new Dish(name, category, price, weight);
            }
            return d;
        }
        public Dish GetMostExpensiveDish()
        {
            Dish mostExpensive = Dishs[0];
            foreach (var d in Dishs)
            {
                if (d.MoreExpensive(mostExpensive))
                    mostExpensive = d;
            }
            return mostExpensive;
        }
        public Dish[] GetDishesByCategory(string category)
        {
            var result = new List<Dish>();
            foreach (var d in Dishs)
            {
                if (d.Categor(category))
                    result.Add(d);
            }
            return result.ToArray();
        }
    }
}
