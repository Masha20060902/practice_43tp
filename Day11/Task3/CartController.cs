namespace Task3
{
    internal class CartController
    {
        private ShoppingCart _cart;
        public CartController(ShoppingCart cart)
        {
            _cart = cart;
        }
        public void AddCart(string item)
        {
            ICommand cmd = new AddToCartCommand(_cart, item);
            cmd.Execute();
        }
        public void RemoveCart(int index)
        {
            ICommand cmd = new RemoveFromCartCommand(_cart, index);
            cmd.Execute();
        }
    }
}
