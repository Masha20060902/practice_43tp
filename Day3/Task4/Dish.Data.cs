namespace Task4
{
    partial class Dish
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public int Weight { get; set; }

        public Dish(string name, string category, int price, int weight)
        {
            Name = name;
            Category = category;
            Price = price;
            Weight = weight;
        }
    }
}
