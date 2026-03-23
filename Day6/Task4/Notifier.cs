namespace Task4
{
    internal class Notifier
    {
        private string name;
        public Notifier(string name)
        {
            this.name = name;
        }
        public void Notifiers(object sender, string news)
        {
            Console.WriteLine($"{name} оповестил пользователя об отчете: {news}");
        }
    }
}
