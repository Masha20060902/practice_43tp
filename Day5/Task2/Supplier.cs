namespace Task2
{
    internal class Supplier
    {
        public int Name { get; }
        public Supplier(int name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return $"Поставщик {Name}";
        }
    }
}
