namespace Task3
{
    public abstract class Athlete
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sport { get; set; }
        public int Medals { get; set; }
        public Athlete(string name, int age, string sport, int medals)
        {
            Name = name;
            Age = age;
            Sport = sport;
            Medals = medals;
        }
    }
}
