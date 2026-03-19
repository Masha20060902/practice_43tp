namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите кол-во блюд: ");
            int count = Convert.ToInt32(Console.ReadLine());
            Dish[] dish = Restaurant.Generation(count);
            foreach (var d in dish)
            {
                Console.WriteLine($"{d.Name}, категория: {d.Category}, стоимость: {d.Price} руб., масса {d.Weight} г.");
            }
            var rest = new Restaurant(dish);
            Dish dishexpen = rest.GetMostExpensiveDish();
            Console.WriteLine($"Самое дорогое блюдо: {dishexpen.Name}, категория: {dishexpen.Category}, стоимость: {dishexpen.Price} руб., масса {dishexpen.Weight} г.");
            Console.Write("Введите категорию блюда: ");
            string category = Console.ReadLine();
            Dish[] list = rest.GetDishesByCategory(category);
            foreach (var i in list)
            {
                Console.WriteLine($"{i.Name}, категория: {i.Category}, стоимость: {dishexpen.Price} руб., масса {dishexpen.Weight} г.");
            }
        }
    }
}
