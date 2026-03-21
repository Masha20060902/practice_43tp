namespace Task3
{
    internal class Battery : CarPart, IElectricalComponent
    {
        public int Voltage { get; }
        public Battery(int name, int voltage) : base(name)
        {
            Voltage = voltage;
        }
        public override string ToString()
        {
            return base.ToString() + $", электроника, напряжение: {Voltage} В";
        }
    }
}
