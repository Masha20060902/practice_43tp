namespace Task2
{
    internal class Customer
    {
        public int Name { get; }
        public Customer(int name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return $"Покупатель {Name}";
        }
    }
}
