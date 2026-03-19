namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите кол-во спортсменов: ");
            int count = Convert.ToInt32(Console.ReadLine());
            Athlete[] atletes = SportsClub.Generation(count);
            foreach (var a in atletes)
            {
                Console.WriteLine($"Имя: {a.Name}, возраст: {a.Age}, спорт: {a.Sport}, медалей: {a.Medals}");
            }
            var club = new SportsClub(atletes);
            Athlete athletbest = club.GetMostAwardedAthlete();
            Console.WriteLine($"Наибольшее количество медалий у: {athletbest.Name}");
            Console.Write("Введите название спорта: ");
            string sport = Console.ReadLine();
            Athlete[] list = club.GetAthletesBySport(sport);
            foreach (var i in list)
            {
                Console.WriteLine($"Имя: {i.Name}, возраст: {i.Age}, медалей: {i.Medals}");
            }
        }

    }
}
