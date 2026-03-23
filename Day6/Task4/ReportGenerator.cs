namespace Task4
{
    internal class ReportGenerator
    {
        private string name;
        public ReportGenerator(string name)
        {
            this.name = name;
        }
        public void CreateReport(object sender, string news)
        {
            Console.WriteLine($"{name} создал отчет: {news}");
        }
    }
}
