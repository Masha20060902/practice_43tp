namespace Task3
{
    internal class CarPart
    {
        public int Name { get; }

        public CarPart(int name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return $"Деталь {Name}";
        }
    }
}
