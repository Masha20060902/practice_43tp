namespace Task3
{
    internal class Gearbox : CarPart, IMechanicalComponent
    {
        public int Weight { get; }
        public Gearbox(int name, int weight) : base(name)
        {
            Weight = weight;
        }
        public override string ToString()
        {
            return base.ToString() + $", механика, вес: {Weight} кг";
        }
    }
}
