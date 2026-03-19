namespace Task3
{
    sealed class Swimmer : Athlete
    {
        public Swimmer(string name, int age, int medals)
            : base(name, age, "Swimmer", medals)
        {
        }
    }
}
