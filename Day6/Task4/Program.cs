namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dp = new DataProcessor();
            var n = new Notifier("Уведомитель");
            var rg = new ReportGenerator("Генератор отчетов");
            var pm = new ProcessingMonitor(dp, rg, n);
            Console.WriteLine("Введите отчет: ");
            string str = Console.ReadLine();
            dp.CompletedProcessing(str);
        }
    }
}
