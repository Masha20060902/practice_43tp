namespace Task4
{
    partial class Dish
    {
        public bool MoreExpensive(Dish dish)
        {
            return Price > dish.Price;
        }
        public bool Categor(string category)
        {
            return Category.ToLower() == category.ToLower();
        }
    }
}
