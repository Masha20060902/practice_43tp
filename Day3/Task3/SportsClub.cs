namespace Task3
{
    public class SportsClub
    {
        public Athlete[] Athletes { get; set; }
        public SportsClub(Athlete[] athletes)
        {
            Athletes = athletes;
        }
        public static Athlete[] Generation(int count)
        {
            var r = new Random();
            var a = new Athlete[count];
            for (int i = 0; i < count; i++)
            {
                string name = $"Спортсмен {i}";
                int age = r.Next(19, 50);
                int medals = r.Next(1, 20);
                int type = r.Next(1, 3);
                if (type == 1)
                {
                    a[i] = new Runner(name, age, medals);
                }
                else
                {
                    a[i] = new Swimmer(name, age, medals);
                }
            }
            return a;
        }
        public Athlete GetMostAwardedAthlete()
        {
            Athlete best = Athletes[0];
            foreach (var a in Athletes)
            {
                if (a.Medals > best.Medals)
                    best = a;
            }
            return best;
        }
        public Athlete[] GetAthletesBySport(string sport)
        {
            var matches = new List<Athlete>();
            foreach (var i in this.Athletes)
            {
                if (i.Sport.Equals(sport))
                {
                    matches.Add(i);
                }
            }
            return matches.ToArray();
        }
    }
}
