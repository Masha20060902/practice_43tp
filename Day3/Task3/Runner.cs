namespace Task3
{
    public sealed class Runner : Athlete
    {
        public Runner(string name, int age, int medals)
            : base(name, age, "Running", medals)
        {
        }
    }
}
