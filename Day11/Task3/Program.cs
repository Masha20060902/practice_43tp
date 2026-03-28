namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            CartController cart = new CartController(shoppingCart);
            Console.WriteLine("Вы в интернет магазине! Для выхода нажмите 0, для продолжения нажмите 1.");
            int t = Convert.ToInt32(Console.ReadLine());
            if (t != 0)
            {
                Console.WriteLine("Какой хотите добавить товар в корзину?");
                while (true)
                {
                    string str = Console.ReadLine();
                    if (str == "0")
                    {
                        break;
                    }
                    cart.AddCart(str);
                    Console.WriteLine("Какой еще (для выхода нажмите 0): ");

                }
                Console.WriteLine("Ваша корзина: ");
                shoppingCart.PrintItems();
                Console.WriteLine("Какой хотите товар удалить (по индексу)?");
                while (true)
                {
                    int el = Convert.ToInt32(Console.ReadLine());
                    cart.RemoveCart(el);
                    Console.WriteLine("Что-то еще(если нет, введите: нет): ");
                    string str = Console.ReadLine();
                    if (str == "нет")
                    {
                        break;
                    }
                }
                Console.WriteLine("Ваша корзина: ");
                shoppingCart.PrintItems();
            }
            else
            {
                Console.WriteLine("Вы вышли из программы");
            }
        }
    }
}
