namespace Task3
{
    internal class ShoppingCart //Получатель
    {
        private List<string> _items = new List<string>();
        public void AddItem(string item)
        {
            _items.Add(item);
            Console.WriteLine("Добавлено в корзину");
        }
        public void RemoveItem(int index)
        {
            Console.WriteLine("Товар удален из корзины");
            _items.RemoveAt(index);
        }
        public void PrintItems()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                Console.WriteLine($"{i}: {_items[i]}");
            }
        }
    }
}
