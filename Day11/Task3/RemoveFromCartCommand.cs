namespace Task3
{
    internal class RemoveFromCartCommand : ICommand
    {
        ShoppingCart shoppingCart;
        private int _index;
        public RemoveFromCartCommand(ShoppingCart s, int index)
        {
            shoppingCart = s;
            _index = index;
        }
        public void Execute()
        {
            shoppingCart.RemoveItem(_index);
        }
    }
}
