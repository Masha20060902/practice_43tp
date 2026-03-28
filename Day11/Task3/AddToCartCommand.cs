namespace Task3
{
    internal class AddToCartCommand : ICommand
    {
        ShoppingCart shoppingCart;
        private string _item;
        public AddToCartCommand(ShoppingCart s, string item)
        {
            shoppingCart = s;
            _item = item;
        }
        public void Execute()
        {
            shoppingCart.AddItem(_item);
        }
    }
}
